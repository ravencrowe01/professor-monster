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
using System.Collections.Generic;

namespace ProfMon.Player {
    public class PlayerMonster : NamedProfObj {
        public readonly ID OwnerID;

        public readonly ID SpeciesID;

        public bool Nicknamed { get; private set; }

        public float Happiness { get; private set; }

        public ID StatusID { get; private set; }

        public Stats StatTraining { get; private set; }
        public readonly ReadonlyStats UniqueStats;

        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }

        public readonly ID NatureID;
        public readonly ID TraitID;

        private MoveMetadata [] _moves;
        public IReadOnlyList<MoveMetadata> Moves => _moves;

        public PlayerMonster () : base (null, null) { }

        public PlayerMonster (ID iD,
                              string name,
                              ID ownerID,
                              ID speciesID,
                              bool nicknamed,
                              float happiness,
                              ID statusID,
                              Stats statTraining,
                              ReadonlyStats uniqueStats,
                              float currentHealth,
                              float maxHealth,
                              ID natureID,
                              ID traitID,
                              MoveMetadata [] moves) : base (iD, name) {
            OwnerID = ownerID;
            SpeciesID = speciesID;
            Nicknamed = nicknamed;
            Happiness = happiness;
            StatusID = statusID;
            StatTraining = statTraining;
            UniqueStats = uniqueStats;
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
            NatureID = natureID;
            TraitID = traitID;
            _moves = moves;
        }

        public void Heal (float amount) {
            ModifyHealth (amount);
        }

        public void Damage (float amount) {
            ModifyHealth (-amount);
        }

        private void ModifyHealth (float delta) {
            if (CurrentHealth + delta < 0) {
                CurrentHealth = 0;
            }
            else if (CurrentHealth + delta > MaxHealth) {
                CurrentHealth = MaxHealth;
            }
            else {
                CurrentHealth += delta;
            }
        }

        public void Rename (string name) {
            Name = name;
        }

        public bool CanRemoveMove () {
            foreach (var move in _moves) {
                if (move != null) {
                    return true;
                }
            }

            return false;
        }

        public void RemoveMove (int index) {
            _moves [index] = null;

            ShiftNullElements ();

            void ShiftNullElements () {
                for (int x = 0; x < _moves.Length; x++) {
                    if (_moves [x] == null) {
                        for (int y = x + 1; y < _moves.Length; y++) {
                            if (_moves [y] != null) {
                                _moves [x] = _moves [y];
                                _moves [y] = null;
                            }
                        }
                    }
                }
            }
        }

        public bool CanAddMove () {
            foreach (var move in _moves) {
                if (move == null) {
                    return true;
                }
            }

            return false;
        }

        public void AddMove (MoveMetadata newMove) {
            for (int i = 0; i < _moves.Length; i++) {
                if (_moves [i] == null) {
                    _moves [i] = newMove;
                }
            }
        }

        public void ReplaceMove (int index, MoveMetadata move) {
            RemoveMove (index);
            AddMove (move);
        }

        public void SwitchMoves (int from, int to) {
            var temp = _moves [from];
            _moves [from] = _moves [to];
            _moves [to] = temp;
        }

        public void UpdateMoveUses (int index, int delta) {
            _moves [index].UpdateUses (delta);
        }

        public void UpdateMoveBoosted (int index, int delta) {
            _moves [index].UpdateTimesBoosted (delta);
        }
    }
}