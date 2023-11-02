using GameplayState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Quiz
{
    public class LORModel
    {
        public float ActionTimer { get; set; }

        public LOR Data { get; set; }
        public IPLayerData PLayerData { get; }
        public GameplayStateMachine StateMachine { get; }
        public SignalBus SignalBus { get; }


        public LORModel(IPLayerData pLayerData, GameplayStateMachine stateMachine, SignalBus signalBus)
        {
            PLayerData = pLayerData;
            StateMachine = stateMachine;
            SignalBus = signalBus;
        }
    }
}
