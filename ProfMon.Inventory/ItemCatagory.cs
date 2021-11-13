using ProfMon.Base;
using ProfMon.Base.ProfObj;

namespace ProfMon.Inventory {
    public class ItemCatagory : DescribedProfObj {
        public ItemCatagory () : base (null, null, null) { }

        public ItemCatagory (ID iD, string name, string description) : base (iD, name, description) { }
    }
}
