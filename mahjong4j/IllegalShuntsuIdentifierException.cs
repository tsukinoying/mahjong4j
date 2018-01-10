using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahjong4j
{
    class IllegalShuntsuIdentifierException : Mahjong4jException
    {
        private Tile tile;

        public IllegalShuntsuIdentifierException(Tile tile) : base("順子識別牌としてありえない牌を検出しました")
        {
            
            this.tile = tile;
        }

        public String getAdvice()
        {
            String entry = tile.ToString() + "を識別牌として保存しようとしました\n";
            
            if (tile.getNumber() == 0)
            {
                return entry + "字牌は順子になりえません";
            }
            return entry + "2番目の牌を順子識別牌とするため、1・9牌は識別牌になりえません";
        }
    }
}
