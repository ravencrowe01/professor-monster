using Microsoft.EntityFrameworkCore;
using ProfMon.Base.ProfObj;
using ProfMon.Environment;
using ProfMon.Inventory;
using ProfMon.Monster;

namespace ProfMon.DataLoading {
    public class ProfMonContext : DbContext {
        public DbSet<ItemCatagory> ItemCatagories { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<BreedingGroup> BreedingGroups { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<ElementModifier> ElementModifiers { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<LeveledMove> LeveledMoves { get; set; }
        public DbSet<Nature> Natures { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<StatChange> StatChanges { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Trait> Traits { get; set; }

        public DbSet<Terrain> Terrains { get; set; }
        public DbSet<Weather> Weathers { get; set; }

        public DbSet<Evolution> Evolutions { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite ($@"Data Source={Directory.GetCurrentDirectory ()}\data.db");

        protected override void OnModelCreating (ModelBuilder builder) {
            ConfigEntity<ItemCatagory> (builder);
            ConfigEntity<Item> (builder);

            ConfigEntity<BreedingGroup> (builder);
            ConfigEntity<Element> (builder);
            ConfigEntity<ElementModifier> (builder);
            ConfigEntity<Move> (builder);
            ConfigEntity<LeveledMove>(builder);
            ConfigEntity<Nature> (builder);
            ConfigEntity <Species> (builder);
            ConfigEntity<StatChange> (builder);
            ConfigEntity<Status> (builder);
            ConfigEntity<Trait> (builder);

            ConfigEntity<Terrain>(builder);
            ConfigEntity<Weather> (builder);

            new EvolutionConfig().Configure(builder.Entity<Evolution>());
        }

        private void ConfigEntity<T> (ModelBuilder builder) where T : BaseProfObj => new EntityConfig<T> ().Configure (builder.Entity<T> ());
    }
}