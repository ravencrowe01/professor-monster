using ProfMon.Base;
using ProfMon.Base.ProfObj;

namespace ProfMon.Monster.Personalities {
    public class Personality : DescribedProfObj {
        public Personality (Config config) : base (config.ID, config.Name, config.Description) { }
    }
}
