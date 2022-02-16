#region copyright
/** Professor Monster, a library for creating monster collection style games.
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
using ProfMon.Objects.Instances;
using ProfMon.Objects.Inventory;
using System.Collections.Generic;

namespace ProfMon.Objects.Combat {
    public class CombatEvent {
        public CombatEventFlag EventType { get; }

        private CombatMonster _actor;
        public CombatMonster Actor {
            get => _actor;
            private set {
                _actor = value;
                Damage.Actor = _actor;
                Healing.Actor = _actor;
            }
        }

        public CombatTeam ActorTeam { get; set; }

        private CombatMonster _target;
        public CombatMonster Target {
            get => _target;
            private set {
                _target = value;
                Damage.Target = _target;
                Healing.Target = _target;
            }
        }

        public CombatTeam TargetTeam { get; set; }

        public int Priority { get; set; }

        public Move _move;
        public Move Move {
            get => _move;
            set {
                _move = value;
                Damage.Move = _move;
                Healing.Move = _move;
            }
        }

        public ActionHPModifier Damage { get; } = new ActionHPModifier ();

        public ActionHPModifier Healing { get; } = new ActionHPModifier ();

        public ISpeciesInstance FormApplied { get; set; }

        public Stats StatChanges { get; set; }

        public List<Status> StatusesApplied { get; set; }
        public List<Status> StatusesRemoved { get; set; }

        public bool ForcedSwitch { get; set; }
        public int SwitchTarget { get; set; } = -1;

        public bool RemovedItem { get; set; }
        public bool RemovedConsumableItem { get; set; }
        public Item NewItem { get; set; }

        public Ability NewAbility { get; set; }

        public Element NewElement { get; set; }

        public Status TeamStatusApplied { get; set; }

        public Weather WeatherApplied { get; set; }

        public Terrain TerrainApplied { get; set; }

        public CombatEvent (CombatEventFlag eventType) {
            EventType = eventType;
        }
    }
}
