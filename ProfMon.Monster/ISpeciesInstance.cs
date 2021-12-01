using ProfMon.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfMon.Monster {
    public interface ISpeciesInstance {
        Species Species { get; }

        ID ID { get; }

        ID OriginalTrainerID { get; }
        string OriginalTrainerName { get; }

        ID OwnerID { get; }

        bool Nicknamed { get; }
        string Name { get; }

        // Should be readonly
        int Gender { get; }

        float Happiness { get; }

        int Level { get; }
        int Experience { get; }

        // Should be readonly
        DateTime EggReceivedDate { get; }
        // Should be readonly
        ID EggReceivedLocation { get; }

        // Should be readonly
        DateTime MetTime { get; }
        // Should be readonly
        ID MetLocation { get; }

        // Should be readonly
        bool FatefulEncounter { get; }

        // Should be readonly
        ID Personality { get; }

        // Should be readonly
        ID CaptureDevice { get; }

        // Should be readonly
        bool IsAlternateForm { get; }

        IEnumerable<Medal> Medals { get; }

        // Should be readonly
        Ability Ability { get; }
        // Should be readonly
        Nature Nature { get; }

        ReadonlyStats StatTotals { get; }
        ReadonlyStats StateModifiers { get; }

        float CurrentHealth { get; }

        IEnumerable<Status> CurrentStatus { get; }

        IReadOnlyList<IMoveInstance> Moves { get; }

        void AddID (ID id);

        void AddOriginalTrainer (ID id, string name);

        void Rename (string name);

        void UpdateHappiness (float amount);

        void AddExperice (int amount);
        bool CanLevelUp ();
        void LevelUp ();

        bool CanEvolve ();
        ISpeciesInstance Evolve ();

        void AddMedal (Medal medal);

        void Damage (float amount);
        void Heal (float amount);

        void UpdateStats(Stats stats);

        bool CanAddMove ();
        bool CanRemoveMove ();
        void AddMove (IMoveInstance newMove);
        void RemoveMove (int index);
        void SwitchMoves (int from, int to);
        void ReplaceMove (int index, IMoveInstance move);

        void UpdateMoveBoosted (int index, int delta);
        void UpdateMoveUses (int index, int delta);

        bool HasMajorStatus ();
        void AddStatus (Status status);
        void RemoveStatus (Status status);
    }
}
