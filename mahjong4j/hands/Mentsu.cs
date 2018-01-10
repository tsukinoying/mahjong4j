using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 面子に関するインターフェイスです
 * 順子・刻子・槓子・対子を扱います
 *
 * @author tsukinoying
 */
namespace mahjong4j.hands
{
    public abstract class Mentsu
    {
        protected Tile identifierTile;

        /**
         * 面子として成立している場合true
         * 面子として成立していない場合false
         */
        protected bool isMentsu_b;

        /**
         * 明X子の場合はtrue
         * 暗X子の場合はfalse
         */
        protected bool isOpen_b;

        /**
         * 順子の場合は2番目の牌です
         *
         * @return どの牌で面子となっているか
         */
        public Tile getTile()
        {
            return identifierTile;
        }

        /**
         * 面子として成立している場合true
         * 面子として成立していない場合false
         *
         * @return 面子として成立しているか
         */
        public bool isMentsu()
        {
            return isMentsu_b;
        }

        /**
         * 食い下がり判定用です
         * 鳴いている場合はtrueですが、
         * 暗槓の場合はfalseです。
         *
         * @return 鳴いているか
         */
        public bool isOpen()
        {
            return isOpen_b;
        }

        /**
         * 符計算用
         *
         * @return 各面子での加算符
         */
        public abstract int getFu();
    }
}
