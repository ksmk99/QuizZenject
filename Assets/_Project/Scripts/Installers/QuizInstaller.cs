using Quiz;
using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class QuestShowSignal { }    
    public class QuestEndSignal { }


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

            Container.BindSignal<QuestShowSignal>()
                .ToMethod<LORPresenter>(x => x.Show)
                .FromResolve();
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
