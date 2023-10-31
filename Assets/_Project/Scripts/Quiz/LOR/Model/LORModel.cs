using GameplayState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class LORModel
    {
        public float ActionTimer { get; set; }

        public LOR Data { get; set; }
        public IPLayerData PLayerData { get; }
        public GameplayStateMachine StateMachine { get; }

        public LORModel(IPLayerData pLayerData, GameplayStateMachine stateMachine)
        {
            PLayerData = pLayerData;
            StateMachine = stateMachine;
        }
    }
}
