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
using System.Linq;

namespace ProfMon.Monster.Storage {
    public class MonsterStorage : BaseProfObj {
        private List<StorageUnit> _units;

        public StorageUnit Party => _units [0];

        public StorageUnit [] Folders => _units.Skip (1).ToArray ();

        public MonsterStorage (ID id, StorageUnit party, List<StorageUnit> folders) : base (id) {
            _units = new List<StorageUnit> { party };
            _units.AddRange (folders);
        }

        public MonsterStorage (ID id, int partySize, int folderCounter, int folderSize) : base (id) {
            _units = new List<StorageUnit> ();

            var partyID = new ID (id.Identifier, 1);
            var party = new StorageUnit (partyID, "Party", partySize);

            _units.Add (party);

            for (int i = 0; i < folderCounter; i++) {
                var folderID = new ID (id.Identifier, (uint) (1 + i));

                _units.Add (new Folder (folderID, $"Folder {i + 1}", folderSize, 1));
            }
        }

        public void AddMonster (int unit, ISpeciesInstance monster) {
            if (_units [unit].CanAddMonster ()) {
                _units [unit].AddMonster (monster);
            }
        }

        public ISpeciesInstance RemoveMonster (int unit, int slot) {
            if (unit == 0) {
                throw new Exception ("Party member removal must be handle by RemovePartyMonster.");
            }

            return _units [unit].RemoveMonster (slot);
        }

        public void SwitchMonster (int unit, int from, int to) {
            _units [unit].SwitchMonsters (from, to);
        }

        public ISpeciesInstance RemovePartyMonster (int slot) {
            var temp = Party.RemoveMonster (slot);

            if (temp == null) {
                throw new Exception ("Tried to remove a party member from an empty slot");
            }

            for (int i = 0; i < _units [0].Size - 1; i++) {
                Party.SwitchMonsters (i, i + 1);
            }

            return temp;
        }
    }
}
