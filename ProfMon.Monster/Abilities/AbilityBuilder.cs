﻿#region copyright
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
using ProfMon.Monster.MonsterSpecies;
using System;

namespace ProfMon.Monster.Abilities {
    public class AbilityBuilder : BaseBuilder<AbilityBuilder, Ability> {
        private AbilityTrigger _trigger;
        private Func<ISpeciesInstance, ISpeciesInstance> _processor;

        public AbilityBuilder WithTrigger (AbilityTrigger trigger) {
            _trigger = trigger;
            return this;
        }

        public AbilityBuilder WithProcessor (Func<ISpeciesInstance, ISpeciesInstance> processor) {
            _processor = processor;
            return this;
        }

        public override Ability Build () {
            return new Ability (new AbilityConfig () {
                ID = _id,
                Name = _name,
                Description = _description,
                Trigger = _trigger,
                TriggerProcessor = _processor
            });
        }
    }
}