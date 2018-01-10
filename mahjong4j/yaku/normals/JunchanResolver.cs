using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 純チャン判定クラス
 * 123の順子と789の順子、および111、999といった老頭牌の刻子もしくは槓子
 * のみの場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class JunchanResolver : NormalYakuResolver
    {
        private Toitsu janto;
        private List<Shuntsu> shuntsuList;
        private List<Kotsu> kotsuList;
        private NormalYaku yakuEnum = NormalYaku.JUNCHAN;

        public JunchanResolver(MentsuComp comp)
        {
            janto = comp.getJanto();
            shuntsuList = comp.getShuntsuList();
            kotsuList = comp.getKotsuKantsu();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            if (janto == null)
            {
                return false;
            }
            foreach (Shuntsu shuntsu in shuntsuList)
            {
                int num = shuntsu.getTile().getNumber();
                if (num != 2 && num != 8)
                {
                    return false;
                }
            }

            foreach (Kotsu kotsu in kotsuList)
            {
                int num = kotsu.getTile().getNumber();
                if (num != 1 && num != 9)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
