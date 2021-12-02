using ProfMon.Base;
using ProfMon.Base.ProfObj;

namespace ProfMon.Inventory.Catagories {
    public class ItemCatagory : DescribedProfObj {
        internal ItemCatagory (BaseConfig config) : base (config.ID, config.Name, config.Description) { }
    }
}
