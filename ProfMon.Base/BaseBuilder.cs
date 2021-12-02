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

namespace ProfMon.Base {
    public abstract class BaseBuilder<TBuilder, TOutput> where TBuilder : BaseBuilder<TBuilder, TOutput> where TOutput : class {
        protected ID _id;
        protected string _name;
        protected string _description;

        public TBuilder WithID (ID id) {
            _id = id;
            return (TBuilder) this;
        }

        public TBuilder WithName (string name) {
            _name = name;
            return (TBuilder) this;
        }

        public TBuilder WithDescription (string description) {
            _description = description;
            return (TBuilder) this;
        }

        public abstract TOutput Build ();
    }
}
