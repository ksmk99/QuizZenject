using GameplayState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Quiz
{
    public class InputModel
    {
        public IPLayerData PLayerData { get; }
        public GameplayStateMachine StateMachine { get; }
        public SignalBus SignalBus { get; }
        public float ExitDelay { get; }
        public bool CanExit;

        public InputModel(IPLayerData pLayerData, GameplayStateMachine stateMachine, SignalBus signalBus, float exitDelay)
        {
            PLayerData = pLayerData;
            StateMachine = stateMachine;
            SignalBus = signalBus;
            ExitDelay = exitDelay;

            CanExit = true;
        }
    }
}
