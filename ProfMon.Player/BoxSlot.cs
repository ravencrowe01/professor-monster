using ProfMon.Base;
using ProfMon.Base.ProfObj;
using System;

namespace ProfMon.Player {
    public class BoxSlot : BaseProfObj {
        public readonly Box Parent;
        public PlayerMonster Monster { get; private set; }

        public BoxSlot (ID iD, Box parent, PlayerMonster monster) : this (iD, parent) {
            Monster = monster;
        }

        public BoxSlot (ID iD, Box parent) : base (iD) {
            Parent = parent;
        }

        public void Add (PlayerMonster monster) {
            if (Monster == null) {
                Monster = monster;
            }
            else {
                throw new Exception ("Tried to add a monster to a filled box slot");
            }
        }

        public void Remove () {
            Monster = null;
        }
    }
}
