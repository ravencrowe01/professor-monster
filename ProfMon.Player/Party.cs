using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfMon.Player {
    public class Party : IReadOnlyList<PlayerMonster> {
        private PlayerMonster[] _monsters;

        public int Count => throw new NotImplementedException();

        public PlayerMonster this[int index] => _monsters[index];

        private Party () { }

        public Party(List<PlayerMonster> monsters) {
            _monsters = monsters.ToArray();
        }

        public Party(int partySize) {
            _monsters = new PlayerMonster[partySize];
        }

        public IEnumerator<PlayerMonster> GetEnumerator () {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator () {
            throw new NotImplementedException();
        }
    }
}
