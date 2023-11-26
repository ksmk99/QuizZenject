using GameplayState;
using Installers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Quiz
{
    public class InputPresenter : IInitializable
    {
        private readonly InputModel model;
        private readonly InputView view;

        public InputPresenter(InputModel model, InputView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Initialize()
        {
            view.OnTextSubmit += Submit;
            view.OnStart += StartTimer;
            view.OnTextValueChange += () => model.Time = 0;

            model.SignalBus.Fire(new QuizMusicSignal());
        }

        private async void StartTimer()
        {
            model.Time = 0f;
            while (model.Time < model.ExitDelay)
            {
                model.Time += 0.1f;
                await Task.Delay(100);
            }

            if (model.CanExit)
            {
                var state = new MainMenuState();
                SetState(state);
            }
        }

        private async void Submit(string key)
        {
            if(!model.CanExit)
            {
                return;
            }

            model.CanExit = false;
            var isSuccess = model.PLayerData.TrySetKey(key);
            var soundData = model.PLayerData.GetAnswerSound(isSuccess ? AnswerSoundType.Correct : AnswerSoundType.Incorrect);

            model.SignalBus.Fire(new AnswerStartSignal());

            view.SetMessageValue(soundData.Text, soundData.AudioClip);
            var duration = soundData.AudioClip.length + 1f;

            await Task.Delay((int)(duration * 1000));

            if (isSuccess)
            {
                view.gameObject.SetActive(false);
                model.SignalBus.Fire(new QuestShowSignal());
            }
            else
            {
                model.SignalBus.Fire(new AnswerEndSignal());

                var reloadState = new ReloadState();
                SetState(reloadState);
            }
        }

        private void SetState(GameState state)
        {
            state.SetStateMachine(model.StateMachine);
            model.StateMachine.TransitionTo(state);
        }
    }
}
