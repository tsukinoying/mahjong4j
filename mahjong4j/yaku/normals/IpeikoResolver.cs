using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 一盃口判定クラス
 * 223344など、同種同数の順子が2組ある場合に成立
 * 二盃口の場合は二盃口のみとなる
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class IpeikoResolver:PeikoResolver,NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.IPEIKO;
        private List<Shuntsu> shuntsuList;

        public IpeikoResolver(MentsuComp comp)
        {
            shuntsuList = comp.getShuntsuList();
        }

        public override NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public override bool isMatch()
        {
            //二盃口とは複合しない
            return peiko(shuntsuList) == 1;
        }


    }
}
