using GameplayState;
using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private LogoView view;

        public override void InstallBindings()
        {
            Container.BindInstance(view);
            Container.Bind<LogoModel>()
                .AsSingle()
                .WithArguments(new PlayingState());
            Container.BindInterfacesAndSelfTo<LogoPresenter>()
                .AsSingle();
        }
    }
}