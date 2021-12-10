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
using System.Collections.Generic;

namespace ProfMon.Monster.Statuses {
    public class StatusBuilder : Builder<StatusBuilder, Status> {
        private int _turnsActive;

        private bool _hidden;

        private bool _isMajor;
        private bool _overwritesMajor;

        private bool _stacks;
        private int _maxStacks;

        private IEnumerable<Tag> _tags;

        public StatusBuilder WithTurnsActive (int turnsActive) {
            _turnsActive = turnsActive;
            return this;
        }

        public StatusBuilder WithHidden (bool hidden) {
            _hidden = hidden;
            return this;
        }

        public StatusBuilder IsMajor(bool major) {
            _isMajor = major;
            return this;
        }

        public StatusBuilder OverwritesMajor (bool overwritesMajor) {
            _overwritesMajor = overwritesMajor;
            return this;
        }

        public StatusBuilder Stacks (bool stacks) {
            _stacks = stacks;
            return this;
        }

        public StatusBuilder WithMaxStacks (int maxStacks) {
            _maxStacks = maxStacks;
            return this;
        }

        public StatusBuilder WithTags (params Tag [] tags) {
            _tags = tags;
            return this;
        }

        public override Status Build () {
            return new Status (new StatusConfig () {
                ID = _id,
                Name = _name,
                Description = _description,
                TurnsActive = _turnsActive,
                Hidden = _hidden,
                IsMajor = _isMajor,
                OverwritesMajor = _overwritesMajor,
                Stacks = _stacks,
                MaxStacks = _maxStacks,
                Tags = _tags
            });
        }
    }
}