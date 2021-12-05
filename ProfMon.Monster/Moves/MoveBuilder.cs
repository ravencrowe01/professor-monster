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
using ProfMon.Monster.Elements;
using ProfMon.Monster.MonsterSpecies;
using System;
using System.Collections.Generic;

namespace ProfMon.Monster.Moves {
    public class MoveBuilder : Builder<MoveBuilder, Move> {
        private Element _element;

        private int _priority;

        private float _power;
        private float _accurecy;

        private IEnumerable<Tag> _tags;

        private Func<ISpeciesInstance, IOutcome> _onUse;

        public MoveBuilder WithElement (Element element) {
            _element = element;
            return this;
        }

        public MoveBuilder WithPriority (int priority) {
            _priority = priority;
            return this;
        }

        public MoveBuilder WithPower (float power) {
            _power = power;
            return this;
        }

        public MoveBuilder WithAccurecy (float accurecy) {
            _accurecy = accurecy;
            return this;
        }

        public MoveBuilder WithOnUse (Func<ISpeciesInstance, IOutcome> onUse) {
            _onUse = onUse;
            return this;
        }

        public MoveBuilder WitTags (params Tag [] tags) { 
            _tags = tags;
            return this;
        }

        public override Move Build () {
            return new Move (new MoveConfig () {
                ID = _id,
                Name = _name,
                Description = _description,
                Element = _element,
                Priority = _priority,
                Power = _power,
                Accurecy = _accurecy,
                OnUse = _onUse,
                Tags = _tags
            });
        }
    }
}
