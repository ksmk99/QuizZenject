using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class InputModel
    {
        public IPLayerData PLayerData { get; }
        public LORPresenter LOR { get; }

        public InputModel(IPLayerData pLayerData, LORPresenter lor)
        {
            PLayerData = pLayerData;
            LOR = lor;
        }
    }
}
