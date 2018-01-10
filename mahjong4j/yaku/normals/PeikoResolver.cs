using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public abstract class PeikoResolver: NormalYakuResolver
    {
        public abstract NormalYaku getNormalYaku();
        public abstract bool isMatch();

        protected int peiko(List<Shuntsu> shuntsuList)
        {
            if (shuntsuList.Count() < 2)
            {
                return 0;
            }

            Shuntsu stockOne = null;
            Shuntsu stockTwo = null;

            int peiko = 0;
            foreach (Shuntsu shuntsu in shuntsuList)
            {
                //鳴いている場合はfalse
                if (shuntsu.isOpen())
                {
                    return 0;
                }

                if (stockOne == null)
                {
                    stockOne = shuntsu;
                    continue;
                }

                //１つ目の盃口が見つかった
                if (stockOne.equals(shuntsu) && peiko == 0)
                {
                    peiko = 1;
                    continue;
                }

                if (stockTwo == null)
                {
                    stockTwo = shuntsu;
                    continue;
                }

                if (stockTwo.equals(shuntsu))
                {
                    return 2;
                }
            }
            return peiko;
        }
    }
}
