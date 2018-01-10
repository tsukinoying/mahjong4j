using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 役判定のためのインターフェイスです。
 * 役を判定するクラスを実装します
 * 和了判定は別です。
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public interface NormalYakuResolver
    {
        /**
         * このメソッドは役判定を行わないので
         * 先にisMatchを実行して判定して利用します
         *
         * @return それぞれの役のEnum
         */
        NormalYaku getNormalYaku();

        /**
         * 実際に役判定をおこないます
         *
         * @return その役がつくかどうか
         */
        bool isMatch();
    }
}
