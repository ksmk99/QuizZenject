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

                view.SetMessage(part.Text);
                while (t <= part.Duration)
                {
                    view.UpdateTimer(t, part.Duration);
                    t += Time.deltaTime;

                    await Task.Yield();
                }
            }

            await Task.Delay((int)(model.Data.ExitDelay * 1000));

            var reloadState = new ReloadState();
            reloadState.SetStateMachine(model.StateMachine);
            model.StateMachine.TransitionTo(reloadState); 
        }
    }
}
