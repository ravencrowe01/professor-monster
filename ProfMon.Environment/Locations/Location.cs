using ProfMon.Base;
using ProfMon.Base.ProfObj;

namespace ProfMon.Environment.Locations {
    public class Location : NamedProfObj {
        public Location (Config config) : base (config.ID, config.Name) { }
    }
}
