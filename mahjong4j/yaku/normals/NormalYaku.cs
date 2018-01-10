using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 役一覧列挙
 * 翻数,食い下がり翻数,日本語
 * 役満は別です
 * TODO:Add English
 *
 * @author tsukinoying
 * @see Yakuman
 */
namespace mahjong4j.yaku.normals
{
    public class NormalYaku
    {
        public static NormalYaku TANYAO = new NormalYaku(1, 1, "タンヤオ");
        public static NormalYaku TSUMO = new NormalYaku(1, 0, "ツモ");
        public static NormalYaku PINFU = new NormalYaku(1, 0, "平和");
        public static NormalYaku IPEIKO = new NormalYaku(1, 0, "一盃口");
        public static NormalYaku HAKU = new NormalYaku(1, 1, "白");
        public static NormalYaku HATSU = new NormalYaku(1, 1, "發");
        public static NormalYaku CHUN = new NormalYaku(1, 1, "中");
        public static NormalYaku JIKAZE = new NormalYaku(1, 1, "自風牌");
        public static NormalYaku BAKAZE = new NormalYaku(1, 1, "場風牌");
        public static NormalYaku IPPATSU = new NormalYaku(1, 0, "一発");
        public static NormalYaku HOUTEI = new NormalYaku(1, 1, "河底撈魚");
        public static NormalYaku HAITEI = new NormalYaku(1, 1, "海底摸月");
        public static NormalYaku REACH = new NormalYaku(1, 0, "リーチ");
        public static NormalYaku DORA = new NormalYaku(1, 1, "ドラ");
        public static NormalYaku URADORA = new NormalYaku(1, 1, "裏ドラ");
        public static NormalYaku RINSHANKAIHOH = new NormalYaku(1, 1, "嶺上開花");
        public static NormalYaku CHANKAN = new NormalYaku(1, 1, "槍槓");
        public static NormalYaku DOUBLE_REACH = new NormalYaku(1, 0, "ダブルリーチ");
        public static NormalYaku CHANTA = new NormalYaku(2, 1, "チャンタ");
        public static NormalYaku HONROHTOH = new NormalYaku(2, 2, "混老頭");
        public static NormalYaku SANSHOKUDOHJUN = new NormalYaku(2, 1, "三色同順");
        public static NormalYaku IKKITSUKAN = new NormalYaku(2, 1, "一気通貫");
        public static NormalYaku TOITOIHO = new NormalYaku(2, 2, "対々和");
        public static NormalYaku SANSHOKUDOHKO = new NormalYaku(2, 2, "三色同刻");
        public static NormalYaku SANANKO = new NormalYaku(2, 2, "三暗刻");
        public static NormalYaku SANKANTSU = new NormalYaku(2, 2, "三槓子");
        public static NormalYaku SHOSANGEN = new NormalYaku(2, 2, "小三元");
        public static NormalYaku CHITOITSU = new NormalYaku(2, 0, "七対子");
        public static NormalYaku RYANPEIKO = new NormalYaku(3, 0, "二盃口");
        public static NormalYaku JUNCHAN = new NormalYaku(3, 2, "純チャン");
        public static NormalYaku HONITSU = new NormalYaku(3, 2, "混一色");
        public static NormalYaku CHINITSU = new NormalYaku(6, 5, "清一色");

        private int han;
        private int kuisagari;
        private String japanese;

        NormalYaku(int han, int kuisagari, String japanese)
        {
            this.han = han;
            this.kuisagari = kuisagari;
            this.japanese = japanese;
        }

        public int getHan()
        {
            return han;
        }

        public int getKuisagari()
        {
            return kuisagari;
        }

        public String getJapanese()
        {
            return japanese;
        }
    }
}
