using Installers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void Submit(string key)
        {
            var isSuccess = model.PLayerData.TrySetKey(key);
            if(isSuccess)
            {
                view.SetMessageValue("Success!");
                model.SignalBus.Fire(new QuestShowSignal());
                view.gameObject.SetActive(false);
                return;
            }

            view.SetMessageValue("ERROR");
        }
    }
}
