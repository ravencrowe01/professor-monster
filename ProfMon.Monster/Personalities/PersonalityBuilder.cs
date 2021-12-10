using ProfMon.Base;

namespace ProfMon.Monster.Personalities {
    public class PersonalityBuilder : Builder<PersonalityBuilder, Personality> {
        public override Personality Build () {
            return new Personality (new Config () {
                ID = _id,
                Name = _name,
                Description = _description
            });
        }
    }
}
