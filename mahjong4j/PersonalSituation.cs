using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahjong4j
{
    public class PersonalSituation
    {
        private bool isParent_b;
        private bool isTsumo_b;
        private bool isIppatsu_b;
        private bool isReach_b;
        private bool isDoubleReach_b;
        private bool isChankan_b;
        private bool isRinshankaihoh_b;
        private Tile jikaze;

        public PersonalSituation()
        {
        }

        public PersonalSituation(bool isTsumo, bool isIppatsu, bool isReach, bool isDoubleReach, bool isChankan, bool isRinshankaihoh, Tile jikaze)
        {
            this.isTsumo_b = isTsumo;
            this.isIppatsu_b = isIppatsu;
            this.isReach_b = isReach;
            this.isDoubleReach_b = isDoubleReach;
            this.isChankan_b = isChankan;
            this.isRinshankaihoh_b = isRinshankaihoh;
            this.jikaze = jikaze;
            isParent_b = (jikaze == Tile.TON);
        }

        public bool isParent()
        {
            return isParent_b;
        }

        public bool isTsumo()
        {
            return isTsumo_b;
        }

        public void setTsumo(bool tsumo)
        {
            isTsumo_b = tsumo;
        }

        public bool isIppatsu()
        {
            return isIppatsu_b;
        }

        public void setIppatsu(bool ippatsu)
        {
            isIppatsu_b = ippatsu;
        }

        public bool isReach()
        {
            return isReach_b;
        }

        public void setReach(bool reach)
        {
            this.isReach_b = reach;
        }

        public bool isDoubleReach()
        {
            return isDoubleReach_b;
        }

        public void setDoubleReach(bool doubleReach)
        {
            isDoubleReach_b = doubleReach;
        }

        public bool isChankan()
        {
            return isChankan_b;
        }

        public void setChankan(bool chankan)
        {
            isChankan_b = chankan;
        }

        public bool isRinshankaihoh()
        {
            return isRinshankaihoh_b;
        }

        public void setRinshankaihoh(bool rinshankaihoh)
        {
            isRinshankaihoh_b = rinshankaihoh;
        }

        public Tile getJikaze()
        {
            return jikaze;
        }

        public void setJikaze(Tile jikaze)
        {
            this.jikaze = jikaze;
            isParent_b = (jikaze == Tile.TON);
        }
    }
}
