using ProfMon.Base;

namespace ProfMon.Inventory.Catagories {
    public class ItemCatagoryBuilder : Builder<ItemCatagoryBuilder, ItemCatagory> {
        public override ItemCatagory Build () {
            return new ItemCatagory (new Config () {
                ID = _id,
                Name = _name,
                Description = _description
            });
        }
    }
}
