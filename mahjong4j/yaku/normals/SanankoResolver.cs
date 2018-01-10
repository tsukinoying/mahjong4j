using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 三暗刻判定クラス
 * 暗刻が３つ存在する場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class SanankoResolver:NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.SANANKO;
        private List<Kotsu> kotsuList;
        private int kotsuCount;

        public SanankoResolver(MentsuComp comp)
        {
            kotsuList = comp.getKotsuKantsu();
            kotsuCount = comp.getKotsuCount() + comp.getKantsuCount();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            if (kotsuCount < 3)
            {
                return false;
            }

            int ankoCount = 0;
            foreach (Kotsu kotsu in kotsuList)
            {
                if (!kotsu.isOpen())
                {
                    ankoCount++;
                }
            }
            return ankoCount == 3;
        }
    }
}
