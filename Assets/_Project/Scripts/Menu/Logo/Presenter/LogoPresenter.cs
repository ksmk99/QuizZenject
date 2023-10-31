using Zenject;

namespace Menu
{
    public class LogoPresenter : IInitializable
    {
        private readonly LogoModel model;
        private readonly LogoView view; 

        public LogoPresenter(LogoModel model, LogoView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Initialize()
        {
            view.OnClick += ChangeState;
        }

        private void ChangeState()
        {
            model.StateMachine.TransitionTo(model.State);
        }
    }
}
