using GameplayState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Quiz
{
    public class LORPresenter
    {
        private readonly LORView view;
        private readonly LORModel model;

        public LORPresenter(LORView view, LORModel model)
        {
            this.view = view;
            this.model = model;
        }

        public void Show()
        {
            SetQuest();
            RunQuest();
        }

        private void SetQuest()
        {
            LOR data = (LOR)model.PLayerData.GetQuestionData();
            model.Data = data;
        }

        private async void RunQuest()
        {
            view.gameObject.SetActive(true);
            for (int i = 0; i < model.Data.Parts.Length; i++)
            {
                var part = model.Data.Parts[i];
                var t = 0f;
                var duration = part.AudioClip == null ? part.Duration : part.AudioClip.length + part.ClipDelay;
                view.SetMessage(part.Text, part.AudioClip);

                while (t <= duration)
                {
                    view.UpdateTimer(t, duration);
                    t += Time.deltaTime;

                    await Task.Yield();
                }
            }

            await Task.Delay((int)(model.Data.ExitDelay * 1000));

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                await Task.Yield();
            }

            var reloadState = new ReloadState();
            reloadState.SetStateMachine(model.StateMachine);
            model.StateMachine.TransitionTo(reloadState);
        }
    }
}
