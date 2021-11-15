using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfMon.Base;
using ProfMon.Base.ProfObj;

namespace ProfMon.DataLoading {
    public class EntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseProfObj {
        public virtual void Configure (EntityTypeBuilder<T> builder) {
            builder.HasKey (entity => entity.ID);

            builder.Property (entity => entity.ID).HasConversion (id => id.ToLong (), id => new ID (id));
        }
    }
}
