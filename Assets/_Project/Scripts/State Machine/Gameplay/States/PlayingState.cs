using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameplayState
{
    public class PlayingState : GameState
    {
        public override void Enter()
        {
            SceneManager.LoadSceneAsync("Quiz");
        }

        public override void Exit()
        {

        }
    }
}