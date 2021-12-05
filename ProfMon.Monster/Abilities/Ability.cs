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
using ProfMon.Base.ProfObj;
using ProfMon.Monster.MonsterSpecies;
using System;
using System.Collections.Generic;

namespace ProfMon.Monster.Abilities {
    public class Ability : DescribedProfObj, ITaggable<Tag> {
        public readonly AbilityTrigger AbilityTrigger;

        public readonly Func<ISpeciesInstance, IOutcome> TriggerProcesser;

        private readonly List<Tag> _tags;

        public IEnumerable<Tag> Tags => _tags;

        protected internal Ability (AbilityConfig config) : base (config.ID, config.Name, config.Description) {
            AbilityTrigger = config.Trigger;

            TriggerProcesser = config.TriggerProcessor;

            _tags = (List<Tag>) config.Tags;
        }
    }
}