using ProfMon.Environment.Terrains;
using ProfMon.Environment.Weathers;
using ProfMon.Inventory.Items;
using ProfMon.Monster.MonsterSpecies;
using System.Collections.Generic;

namespace ProfMon.Monster.Evolutions {
    public interface IEvolutionManager {
        bool CanEvolve (ISpeciesInstance instance);

        ISpeciesInstance Evolve (ISpeciesInstance instance);

        void AddEvolveItem (Item item);

        void AddTerrain (Terrain terrain);

        void AddWeather (Weather weather);

        void AddPartyMembers (List<ISpeciesInstance> party);
    }
}
