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
        public SignalBus SignalBus { get; }

        public InputModel(IPLayerData pLayerData, SignalBus signalBus)
        {
            PLayerData = pLayerData;
            SignalBus = signalBus;
        }
    }
}
