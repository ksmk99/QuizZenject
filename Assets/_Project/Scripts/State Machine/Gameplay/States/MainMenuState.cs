using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace GameplayState
{
    public class MainMenuState : GameState
    {
        public override void Enter()
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }

        public override void Exit()
        {

        }
    }
}
