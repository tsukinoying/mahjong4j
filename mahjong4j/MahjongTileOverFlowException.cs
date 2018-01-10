using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * @author tsukinoying
 */
namespace mahjong4j
{
    class MahjongTileOverFlowException : Mahjong4jException
    {
        //Tile.code
        private int code;
        //何枚見つかり不正なのか
        private int num;

        public MahjongTileOverFlowException(int code, int num):base("麻雀の牌は4枚までしかありません")
        {

            this.code = code;
            this.num = num;
        }

        public String getAdvice()
        {
            return Tile.valueOf(code).ToString() + "(code = " + code + ")が" + num + "枚見つかりました";
        }

    }
}
