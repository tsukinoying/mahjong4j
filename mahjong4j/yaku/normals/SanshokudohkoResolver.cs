using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 三色同刻判定クラス
 * 萬子・索子・筒子それぞれの色で同じ数字の刻子（槓子も含む）を作ったときに成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class SanshokudohkoResolver: SanshokuResolver,NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.SANSHOKUDOHKO;
        private int kotsuCount;
        private List<Kotsu> kotsuList;

        public SanshokudohkoResolver(MentsuComp comp)
        {
            kotsuCount = comp.getKotsuCount() + comp.getKantsuCount();
            kotsuList = comp.getKotsuKantsu();
        }

        public override NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public override bool isMatch()
        {
            if (kotsuCount < 3)
            {
                return false;
            }

            Kotsu candidate = null;
            foreach (Kotsu kotsu in kotsuList)
            {
                TileType shuntsuType = kotsu.getTile().getType();
                int shuntsuNum = kotsu.getTile().getNumber();

                if (candidate == null)
                {
                    candidate = kotsu;
                    continue;
                }

                if (candidate.getTile().getNumber() == shuntsuNum)
                {
                    detectType(shuntsuType);
                    detectType(candidate.getTile().getType());
                }
                else
                {
                    candidate = kotsu;
                }
            }
            return manzu && pinzu && sohzu;
        }
    }
}
