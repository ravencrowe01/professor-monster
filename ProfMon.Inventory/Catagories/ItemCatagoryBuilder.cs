using ProfMon.Base;

namespace ProfMon.Inventory.Catagories {
    public class ItemCatagoryBuilder : BaseBuilder<ItemCatagoryBuilder, ItemCatagory> {
        public override ItemCatagory Build () {
            return new ItemCatagory (new BaseConfig () {
                ID = _id,
                Name = _name,
                Description = _description
            });
        }
    }
}
