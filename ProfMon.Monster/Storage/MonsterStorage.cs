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
