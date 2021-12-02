using ProfMon.Base;
using ProfMon.Base.ProfObj;
using ProfMon.Monster.MonsterSpecies;
using System.Collections.Generic;

namespace ProfMon.Monster.Storage {
    public class StorageUnit : NamedProfObj {
        private ISpeciesInstance [] _monsters;
        public IReadOnlyList<ISpeciesInstance> Monsters => _monsters;

        public int Size => _monsters.Length;

        public StorageUnit (ID id, string name, int size) : this (id, name) {
            _monsters = new ISpeciesInstance [size];
        }

        public StorageUnit (ID id, string name, ISpeciesInstance [] monsters) : this (id, name) {
            _monsters = monsters;
        }

        private StorageUnit (ID id, string name) : base (id, name) { }

        public ISpeciesInstance RemoveMonster (int slot) {
            var temp = _monsters [slot];
            _monsters [slot] = null;
            return temp;
        }

        public bool CanAddMonster () {
            for (int i = 0; i < Size; i++) {
                if (_monsters [i] == null) {
                    return true;
                }
            }

            return false;
        }

        public void AddMonster (ISpeciesInstance monster) {
            var slot = 0;

            while (slot < Size && _monsters [slot] != null) {
                slot++;
            }

            if (slot < Size) {
                AddMonster (monster, slot);
            }
        }

        public void AddMonster (ISpeciesInstance monster, int slot) {
            _monsters [slot] = monster;
        }

        public void SwitchMonsters (int from, int to) {
            var temp = _monsters [from];
            _monsters [from] = _monsters [to];
            _monsters [to] = temp;
        }
    }
}
