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
using ProfMon.Monster.Elements;
using ProfMon.Monster.MonsterSpecies;
using ProfMon.Monster.Statuses;
using System.Collections.Generic;

namespace ProfMon.Monster {
	public interface IOutcome {
        ISpeciesInstance Target { get; }

        bool TargetHit { get; }

        bool TargetImmune { get; }

        bool TargetDodged { get; }

        bool CriticalHit { get; }

        bool SuperEffective { get; }

        bool RecoilDamage { get; }

        float HealthModifier { get; }

        List<Status> StatusesAdded { get; }

        Stats StatChanges { get; }

        Element ElementChangedTo { get; }

        Ability AbilityChangedTo { get; }
    } 
}
