using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 役満の列挙
 * 役一覧と別にすることで
 * 四暗刻ドラ13などでダブル役満にならないようにします
 * @author tsukinoying
 * TODO:English
 */
namespace mahjong4j.yaku.yakuman
{
    public class Yakuman
    {
        public static Yakuman KOKUSHIMUSO = new Yakuman("国士無双");
        public static Yakuman SUANKO = new Yakuman("四暗刻");
        public static Yakuman CHURENPOHTO = new Yakuman("九蓮宝燈");
        public static Yakuman DAISANGEN = new Yakuman("大三元");
        public static Yakuman TSUISO = new Yakuman("字一色");
        public static Yakuman SHOSUSHI = new Yakuman("小四喜");
        public static Yakuman DAISUSHI = new Yakuman("大四喜");
        public static Yakuman RYUISO = new Yakuman("緑一色");
        public static Yakuman CHINROTO = new Yakuman("清老頭");
        public static Yakuman SUKANTSU = new Yakuman("四槓子");
        public static Yakuman RENHO = new Yakuman("人和");
        public static Yakuman CHIHO = new Yakuman("地和");
        public static Yakuman TENHO = new Yakuman("天和");

        private String japanese;
        
        Yakuman(String japanese)
        {
            
            this.japanese = japanese;
        }

        public String getJapanese()
        {
            return japanese;
        }
    }
}
