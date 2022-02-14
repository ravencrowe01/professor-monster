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
using ProfMon.Objects.Inventory;
using System;
using System.Collections.Generic;

namespace ProfMon.Objects.Instances {
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

        IReadOnlyList<StatusInstance> CurrentStatuses { get; }

        IReadOnlyList<IMoveInstance> Moves { get; }
    }
}
