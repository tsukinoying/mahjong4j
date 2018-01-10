using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public interface YakumanResolver
    {
        Yakuman getYakuman();

        bool isMatch();
    }
}
