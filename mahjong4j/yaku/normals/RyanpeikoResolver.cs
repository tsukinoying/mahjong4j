using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 二盃口判定クラス
 * 一盃口が２つ含まれる場合に成立
 * 一盃口とは複合しない
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class RyanpeikoResolver:PeikoResolver,NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.RYANPEIKO;

        private List<Shuntsu> shuntsuList;

        public RyanpeikoResolver(MentsuComp comp)
        {
            shuntsuList = comp.getShuntsuList();
        }

        public override NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public override bool isMatch()
        {
            return peiko(shuntsuList) == 2;
        }
    }
}
