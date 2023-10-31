using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{

    [Serializable]
    public struct AnswerData
    {
        public string Text;
        public bool IsCorrect;
    }
}