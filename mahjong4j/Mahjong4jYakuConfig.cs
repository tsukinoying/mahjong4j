using mahjong4j.hands;
using mahjong4j.yaku.normals;
using mahjong4j.yaku.yakuman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * TODO: to be able to customize Yaku for use
 *
 * @author tsukinoying
 */
namespace mahjong4j
{
    public class Mahjong4jYakuConfig
    {
        public static HashSet<YakumanResolver> getYakumanResolverSet(MentsuComp comp, GeneralSituation generalSituation, PersonalSituation personalSituation)
        {
            HashSet<YakumanResolver> yakumanResolverSet = new HashSet<YakumanResolver>();
            yakumanResolverSet.Add(new ChinrohtohResolver(comp));
            yakumanResolverSet.Add(new ChurenpohtohResolver(comp));
            yakumanResolverSet.Add(new DaisangenResolver(comp));
            yakumanResolverSet.Add(new DaisushiResolver(comp));
            yakumanResolverSet.Add(new RyuisoResolver(comp));
            yakumanResolverSet.Add(new ShosushiResolver(comp));
            yakumanResolverSet.Add(new SuankoResolver(comp));
            yakumanResolverSet.Add(new SukantsuResolver(comp));
            yakumanResolverSet.Add(new TsuisoResolver(comp));

            yakumanResolverSet.Add(new RenhoResolver(generalSituation, personalSituation));
            yakumanResolverSet.Add(new ChihoResolver(generalSituation, personalSituation));
            yakumanResolverSet.Add(new TenhoResolver(generalSituation, personalSituation));

            return yakumanResolverSet;
        }

        public static HashSet<NormalYakuResolver> getNormalYakuResolverSet(MentsuComp comp, GeneralSituation generalSituation, PersonalSituation personalSituation)
        {
            HashSet<NormalYakuResolver> normalYakuResolverSet = new HashSet<NormalYakuResolver>();
            normalYakuResolverSet.Add(new ChantaResolver(comp));
            normalYakuResolverSet.Add(new ChunResolver(comp));
            normalYakuResolverSet.Add(new ChinitsuResolver(comp));
            normalYakuResolverSet.Add(new ChitoitsuResolver(comp));
            normalYakuResolverSet.Add(new HakuResolver(comp));
            normalYakuResolverSet.Add(new HatsuResolver(comp));
            normalYakuResolverSet.Add(new HonitsuResolver(comp));
            normalYakuResolverSet.Add(new HonrohtohResolver(comp));
            normalYakuResolverSet.Add(new IkkitsukanResolver(comp));
            normalYakuResolverSet.Add(new IpeikoResolver(comp));
            normalYakuResolverSet.Add(new JunchanResolver(comp));
            normalYakuResolverSet.Add(new RyanpeikoResolver(comp));
            normalYakuResolverSet.Add(new SanankoResolver(comp));
            normalYakuResolverSet.Add(new SankantsuResolver(comp));
            normalYakuResolverSet.Add(new SanshokudohjunResolver(comp));
            normalYakuResolverSet.Add(new SanshokudohkoResolver(comp));
            normalYakuResolverSet.Add(new ShosangenResolver(comp));
            normalYakuResolverSet.Add(new TanyaoResolver(comp));
            normalYakuResolverSet.Add(new ToitoihoResolver(comp));

            normalYakuResolverSet.Add(new PinfuResolver(comp, generalSituation, personalSituation));
            normalYakuResolverSet.Add(new TsumoResolver(comp, generalSituation, personalSituation));
            normalYakuResolverSet.Add(new JikazeResolver(comp, generalSituation, personalSituation));
            normalYakuResolverSet.Add(new BakazeResolver(comp, generalSituation, personalSituation));
            normalYakuResolverSet.Add(new IppatsuResolver(generalSituation, personalSituation));
            normalYakuResolverSet.Add(new HouteiResolver(generalSituation, personalSituation));
            normalYakuResolverSet.Add(new HaiteiResolver(generalSituation, personalSituation));
            normalYakuResolverSet.Add(new ReachResolver(generalSituation, personalSituation));
            normalYakuResolverSet.Add(new RinshankaihohResolver(comp, personalSituation));
            normalYakuResolverSet.Add(new ChankanResolver(generalSituation, personalSituation));
            normalYakuResolverSet.Add(new DoubleReachResolver(generalSituation, personalSituation));

            return normalYakuResolverSet;
        }
    }
}
