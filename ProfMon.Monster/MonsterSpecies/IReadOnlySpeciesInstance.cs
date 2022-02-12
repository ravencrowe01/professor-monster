using ProfMon.Base;
using ProfMon.Environment.Locations;
using ProfMon.Inventory.Items;
using ProfMon.Monster.Abilities;
using ProfMon.Monster.Medals;
using ProfMon.Monster.Moves;
using ProfMon.Monster.Natures;
using ProfMon.Monster.Personalities;
using ProfMon.Monster.Statuses;
using System;
using System.Collections.Generic;

namespace ProfMon.Monster.MonsterSpecies {
    public interface IReadOnlySpeciesInstance {
        Species Species { get; }

        ID ID { get; }

        ID OriginalTrainerID { get; }
        string OriginalTrainerName { get; }

        ID OwnerID { get; }
        string OwnerName { get; }

        bool Nicknamed { get; }
        string Name { get; }

        Item HeldItem { get; }

        int Gender { get; }

        float Happiness { get; }

        int Level { get; }
        int Experience { get; }

        DateTime MetTime { get; }
        Location MetLocation { get; }

        bool ReceivedAsEgg { get; }
        DateTime EggReceivedDate { get; }
        Location EggReceivedLocation { get; }

        bool FatefulEncounter { get; }

        Personality Personality { get; }

        Item CaptureDevice { get; }

        bool IsAlternateForm { get; }

        IReadOnlyList<Medal> Medals { get; }

        Ability Ability { get; }
        Nature Nature { get; }

        ReadonlyStats StatTotals { get; }
        ReadonlyStats GeneticStats { get; }
        ReadonlyStats StatTraining { get; }

        float CurrentHealth { get; }

        IReadOnlyList<IStatusInstance> CurrentStatuses { get; }

        IReadOnlyList<IMoveInstance> Moves { get; }


    }
}
