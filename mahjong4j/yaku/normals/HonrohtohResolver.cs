﻿using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 混老頭判定クラス
 * 么九牌のみで構成される場合成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class HonrohtohResolver:NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.HONROHTOH;

        private List<Shuntsu> shuntsuList;
        private List<Toitsu> toitsuList;
        private List<Kotsu> kotsuList;

        public HonrohtohResolver(MentsuComp comp)
        {
            shuntsuList = comp.getShuntsuList();
            toitsuList = comp.getToitsuList();
            kotsuList = comp.getKotsuKantsu();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        /**
         * 么九牌以外を見つけたらfalseを返す
         *
         * @return 混老頭かどうか
         */
        public bool isMatch()
        {
            if (shuntsuList.Count() > 0)
            {
                return false;
            }
            foreach (Toitsu toitsu in toitsuList)
            {
                int num = toitsu.getTile().getNumber();
                if (1 < num && num < 9)
                {
                    return false;
                }
            }

            foreach (Kotsu kotsu in kotsuList)
            {
                int num = kotsu.getTile().getNumber();
                if (1 < num && num < 9)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
