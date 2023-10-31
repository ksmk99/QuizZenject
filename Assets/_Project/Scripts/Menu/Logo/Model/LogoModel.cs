using GameplayState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class LogoModel
    {
        public GameplayStateMachine StateMachine { get; }
        public GameState State { get; }

        public LogoModel(GameplayStateMachine stateMachine, GameState state)
        {
            StateMachine = stateMachine;
            State = state;
        }
    }
}
