using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * チャンタ判定クラス
 * 123の順子と789の順子、および一九字牌の対子と刻子
 * のみで構成された場合成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class ChantaResolver : NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.CHANTA;

        private MentsuComp comp;

        public ChantaResolver(MentsuComp comp)
        {
            this.comp = comp;
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            //雀頭がnullなら七対子なのでfalse
            if (comp.getJanto() == null)
            {
                return false;
            }
            //雀頭が一九字牌以外ならfalse
            int jantoNum = comp.getJanto().getTile().getNumber();
            if (jantoNum != 1 && jantoNum != 9 && jantoNum != 0)
            {
                return false;
            }

            //順子が無ければfalse
            if (comp.getShuntsuCount() == 0)
            {
                return false;
            }

            //順子が123の順子と789の順子でなければfalse
            foreach (Shuntsu shuntsu in comp.getShuntsuList())
            {
                int shuntsuNum = shuntsu.getTile().getNumber();
                if (shuntsuNum != 2 && shuntsuNum != 8)
                {
                    return false;
                }
            }

            //刻子・槓子が一九字牌以外ならfalse
            foreach (Kotsu kotsu in comp.getKotsuKantsu())
            {
                int kotsuNum = kotsu.getTile().getNumber();
                if (kotsuNum != 1 && kotsuNum != 9 && kotsuNum != 0)
                {
                    return false;
                }
            }

            //ここまでくればtrue
            return true;
        }
    }
}
