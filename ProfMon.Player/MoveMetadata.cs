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

namespace ProfMon.Player {
    public class MoveMetadata : BaseProfObj {
        public readonly ID Move;

        public readonly ID OwnerID;

        public int CurrentUses { get; protected set; }
        public int MaxUses { get; private set; }

        public int TimesBoosted { get; protected set; }
        public int MaxBoosts { get; private set; }

        public MoveMetadata () : base (null) { }

        public MoveMetadata (ID iD,
                             ID move,
                             ID ownerID,
                             int currentUses,
                             int maxUses,
                             int timesBoosted,
                             int maxBoosts) : base (iD) {
            Move = move;
            OwnerID = ownerID;
            CurrentUses = currentUses;
            MaxUses = maxUses;
            TimesBoosted = timesBoosted;
            MaxBoosts = maxBoosts;
        }

        public void UpdateUses (int delta) {
            if (CurrentUses + delta < 0) {
                CurrentUses = 0;
            }
            else if (CurrentUses + delta > MaxUses) {
                CurrentUses = MaxUses;
            }
            else {
                CurrentUses += delta;
            }
        }

        public void UpdateTimesBoosted (int delta) {
            if (TimesBoosted + delta > MaxBoosts) {
                TimesBoosted = MaxBoosts;
            }
            else {
                TimesBoosted += delta;
            }
        }
    }
}