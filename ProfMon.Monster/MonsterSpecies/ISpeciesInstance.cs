#region copyright
/** Raven Bot, a light-weight Discord bot using DSharp+ for gateway and command handling.
 *  Copyright (C) 2021 Raven Crowe
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Affero General Public License as published
 *  by the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Affero General Public License for more details.
 *  
 *  You should have received a copy of the GNU Affero General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
#endregion

using ProfMon.Base;
using ProfMon.Monster.Abilities;
using ProfMon.Monster.Medals;
using ProfMon.Monster.Moves;
using ProfMon.Monster.Natures;
using ProfMon.Monster.Statuses;
using System;
using System.Collections.Generic;

namespace ProfMon.Monster.MonsterSpecies {
    public interface ISpeciesInstance {
        Species Species { get; }

        ID ID { get; }

        ID OriginalTrainerID { get; }
        string OriginalTrainerName { get; }

        ID OwnerID { get; }
        string OwnerName { get; }

        bool Nicknamed { get; }
        string Name { get; }

        int Gender { get; }

        float Happiness { get; }

        int Level { get; }
        int Experience { get; }

        DateTime MetTime { get; }
        ID MetLocation { get; }

        bool ReceivedAsEgg { get; }
        DateTime EggReceivedDate { get; }
        ID EggReceivedLocation { get; }

        bool FatefulEncounter { get; }

        ID Personality { get; }

        ID CaptureDevice { get; }

        bool IsAlternateForm { get; }

        IEnumerable<Medal> Medals { get; }

        Ability Ability { get; }
        Nature Nature { get; }

        ReadonlyStats StatTotals { get; }
        ReadonlyStats GeneticStats { get; }
        ReadonlyStats StatTraining { get; }

        float CurrentHealth { get; }

        IEnumerable<IStatusInstance> CurrentStatuses { get; }

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

        void UpdateStats (Stats stats);

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
