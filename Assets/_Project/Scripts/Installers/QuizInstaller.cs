using Quiz;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class QuizInstaller : MonoInstaller
    {
        [SerializeField] private QuizData quizData;
        [Space]
        [SerializeField] private InputView inputView;
        [SerializeField] private LORView lorView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PLayerData>()
                .AsSingle()
                .WithArguments(quizData);
            BindLOR();
            BindInput();
        }

        private void BindLOR()
        {
            Container.BindInstance(lorView);
            Container.Bind<LORModel>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<LORPresenter>()
                .AsSingle();
        }

        private void BindInput()
        {
            Container.BindInstance(inputView);
            Container.Bind<InputModel>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<InputPresenter>()
                .AsSingle();
        }
    }
}
