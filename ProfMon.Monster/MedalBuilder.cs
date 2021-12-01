using ProfMon.Base;

namespace ProfMon.Monster {
    public class MedalBuilder : BaseBuilder<MedalBuilder, Medal> {
        public override Medal Build () {
            return new Medal (new BaseConfig () {
                ID = _id,
                Name = _name,
                Description = _description
            });
        }
    }
}
