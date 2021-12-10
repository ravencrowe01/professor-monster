using ProfMon.Base;

namespace ProfMon.Environment.Locations {
    public class LocationBuilder : Builder<LocationBuilder, Location> {
        public override Location Build () {
            return new Location (new Config () {
                ID = _id,
                Name = _name
            });
        }
    }
}
