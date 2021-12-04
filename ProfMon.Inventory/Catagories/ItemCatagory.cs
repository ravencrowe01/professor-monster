using ProfMon.Base;
using ProfMon.Base.ProfObj;

namespace ProfMon.Inventory.Catagories {
    public class ItemCatagory : DescribedProfObj {
        protected internal ItemCatagory (Config config) : base (config.ID, config.Name, config.Description) { }
    }
}
