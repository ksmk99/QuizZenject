using GameplayState;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplayStateMachineInstaller : MonoInstaller
    {
        [SerializeField] private BackMusicView backMusicView;
        [Space]
        [SerializeField] private AudioClip menuMusicClip;
        [SerializeField] private AudioClip quizMusicClip;
        [SerializeField] private float normalVolume = 0.75f;
        [SerializeField] private float mutedVolume = 0.2f;

        public override void InstallBindings()
        {
            BindSignals();
            BindMusic();
            Container
                .Bind<GameplayStateMachine>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<Bootstrap>()
                .AsSingle();
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<QuestShowSignal>();
            Container.DeclareSignal<QuestEndSignal>();

            Container.DeclareSignal<AnswerStartSignal>();
            Container.DeclareSignal<AnswerEndSignal>();

            Container.DeclareSignal<MenuMusicSignal>();
            Container.DeclareSignal<QuizMusicSignal>();
        }

        private void BindMusic()
        {
            Container.BindInstance(backMusicView);
            Container.Bind<BackMusicModel>()
                .AsSingle()
                .WithArguments(menuMusicClip, quizMusicClip, normalVolume, mutedVolume);
            Container.BindInterfacesAndSelfTo<BackMusicPresenter>()
                .AsSingle();

            Container.BindSignal<MenuMusicSignal>()
                .ToMethod<BackMusicPresenter>(x => x.SetMenuAudio)
                .FromResolve();
            Container.BindSignal<QuizMusicSignal>()
                .ToMethod<BackMusicPresenter>(x => x.SetQuizAudio)
                .FromResolve();         
            
            Container.BindSignal<QuestShowSignal>()
                .ToMethod<BackMusicPresenter>(x => x.MuteVolume)
                .FromResolve();
            Container.BindSignal<QuestEndSignal>()
                .ToMethod<BackMusicPresenter>(x => x.SetNormalVolume)
                .FromResolve();

            Container.BindSignal<AnswerStartSignal>()
                .ToMethod<BackMusicPresenter>(x => x.MuteVolume)
                .FromResolve();
            Container.BindSignal<AnswerEndSignal>()
                .ToMethod<BackMusicPresenter>(x => x.SetNormalVolume)
                .FromResolve();
        }
    }
}
