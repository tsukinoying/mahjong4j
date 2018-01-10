using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahjong4j
{
    class HandsOverFlowException : Mahjong4jException
    {
        public HandsOverFlowException():base("多牌です")
        {

        }
    }
}
