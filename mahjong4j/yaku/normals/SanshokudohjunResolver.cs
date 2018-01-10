using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 三色同順判定クラス
 * 萬子・索子・筒子それぞれの色で同じ並びの順子を作ったときに成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class SanshokudohjunResolver: SanshokuResolver,NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.SANSHOKUDOHJUN;
        private int shuntsuCount;
        private List<Shuntsu> shuntsuList;

        public SanshokudohjunResolver(MentsuComp comp)
        {
            shuntsuCount = comp.getShuntsuCount();
            shuntsuList = comp.getShuntsuList();
        }

        public override NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public override bool isMatch()
        {
            if (shuntsuCount < 3)
            {
                return false;
            }

            Shuntsu candidate = null;

            foreach (Shuntsu shuntsu in shuntsuList)
            {
                TileType shuntsuType = shuntsu.getTile().getType();
                int shuntsuNum = shuntsu.getTile().getNumber();

                if (candidate == null)
                {
                    candidate = shuntsu;
                    continue;
                }

                if (candidate.getTile().getNumber() == shuntsuNum)
                {
                    detectType(shuntsuType);
                    detectType(candidate.getTile().getType());
                }
                else
                {
                    candidate = shuntsu;
                }
            }
            return manzu && pinzu && sohzu;
        }
    }
}
