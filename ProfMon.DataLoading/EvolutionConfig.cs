using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfMon.Monster;

namespace ProfMon.DataLoading {
    public class EvolutionConfig : EntityConfig<Evolution> {
        public override void Configure (EntityTypeBuilder<Evolution> builder) {
            base.Configure (builder);

            builder.HasOne (evolution => evolution.ItemRequired).WithMany ();
            builder.HasOne (evolution => evolution.WeatherRequired).WithMany ();
            builder.HasOne (evolution => evolution.TerrainRequired).WithMany ();
        }
    }
}
