using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameplayState
{
    public class ReloadState : GameState
    {
        public override void Enter()
        {
            stateMachine.TransitionTo(new PlayingState());
        }

        public override void Exit()
        {

        }
    }
}