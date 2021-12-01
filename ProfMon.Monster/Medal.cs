using ProfMon.Base;
using ProfMon.Base.ProfObj;

namespace ProfMon.Monster {
    public class Medal : DescribedProfObj {
        internal Medal (BaseConfig config) : base (config.ID, config.Name, config.Description) {
        }
    }
}
