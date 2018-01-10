using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 清老頭判定クラス
 * 手牌全体が老頭牌（一九牌）だけの場合成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public class ChinrohtohResolver:YakumanResolver
    {
        private  Yakuman yakuman = Yakuman.CHINROTO;
        private  int totalKotsuKantsu;
        private  List<Kotsu> kotsuList;
        private  Toitsu janto;

        public ChinrohtohResolver(MentsuComp comp)
        {
            totalKotsuKantsu = comp.getKotsuCount() + comp.getKantsuCount();
            kotsuList = comp.getKotsuKantsu();
            janto = comp.getJanto();
        }

        public Yakuman getYakuman()
        {
            return yakuman;
        }

        /**
         * 違うものが見つかったらfalseを返す方針です
         *
         * @return 清老頭かどうか
         */
        public bool isMatch()
        {
            if (totalKotsuKantsu != 4)
            {
                return false;
            }

            int tileNum = janto.getTile().getNumber();
            if (tileNum != 1 && tileNum != 9)
            {
                return false;
            }

            //刻子が全て一九牌か
            foreach (Kotsu kotsu in kotsuList)
            {
                tileNum = kotsu.getTile().getNumber();
                if (tileNum != 1 && tileNum != 9)
                {
                    return false;
                }
            }

            //ここまできたら見つかっている
            return true;
        }
    }
}
