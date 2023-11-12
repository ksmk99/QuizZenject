using GameplayState;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplayStateMachineInstaller : MonoInstaller
    {
        [SerializeField] private BackMusicView backMusicView;
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
        }

        private void BindMusic()
        {
            Container.BindInstance(backMusicView);
            Container.Bind<BackMusicModel>()
                .AsSingle()
                .WithArguments(normalVolume, mutedVolume);
            Container.BindInterfacesAndSelfTo<BackMusicPresenter>()
                .AsSingle();

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
