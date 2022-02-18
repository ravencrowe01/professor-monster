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
        public CombatEventTypes EventType { get; }

        public CombatEvent Parent { get; }

        public List<CombatEvent> Children { get; }

        public bool ModifiesParent { get; set; }

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

        public ActionHPDelta Damage { get; private set; } = new ActionHPDelta ();

        public ActionHPDelta Healing { get; private set; } = new ActionHPDelta ();

        public ISpeciesInstance FormApplied { get; set; }

        public Stats StatChanges { get; set; }

        public List<Status> StatusesApplied { get; set; }
        public List<Status> StatusesRemoved { get; set; }

        public bool ForcedSwitch { get; set; }
        public int SwitchTarget { get; set; } = -1;

        public Item NewItem { get; set; }

        public Ability NewAbility { get; set; }

        public Element NewElement { get; set; }

        public List<Status> TeamStatusesApplied { get; set; }
        public List<Status> TeamStatusesRemoved { get; set; }

        public Weather WeatherApplied { get; set; }

        public Terrain TerrainApplied { get; set; }

        public CombatEvent (CombatEventTypes eventType, CombatEvent parent) {
            EventType = eventType;
            Parent = parent;
        }

        public CombatEvent (CombatEvent @event) {
            EventType = @event.EventType;
            Parent = @event.Parent;
            Children = @event.Children;
            ModifiesParent = @event.ModifiesParent;
            _actor = @event.Actor;
            ActorTeam = @event.ActorTeam;
            _target = @event.Target;
            TargetTeam = @event.TargetTeam;
            Priority = @event.Priority;
            _move = @event.Move;
            Damage = @event.Damage;
            Healing = @event.Healing;
            FormApplied = @event.FormApplied;
            StatChanges = @event.StatChanges;
            StatusesApplied = @event.StatusesApplied;
            StatusesRemoved = @event.StatusesRemoved;
            ForcedSwitch = @event.ForcedSwitch;
            SwitchTarget = @event.SwitchTarget;
            NewItem = @event.NewItem;
            NewAbility = @event.NewAbility;
            NewElement = @event.NewElement;
            TeamStatusesApplied = @event.TeamStatusesApplied;
            TeamStatusesRemoved = @event.TeamStatusesRemoved;
            WeatherApplied = @event.WeatherApplied;
            TerrainApplied = @event.TerrainApplied;
        }

        public void OverwriteWithChildren () {
            var children = new List<CombatEvent> (Children);
            children.Reverse ();

            foreach (var child in children) {
                if(child.ModifiesParent) {
                    Overwrite (child);
                }
            }
        }

        private void Overwrite (CombatEvent by) {
            Damage = by.Damage;
            Healing = by.Healing;

            if (by.FormApplied != null) {
                FormApplied = by.FormApplied;
            }

            if(by.StatChanges != null) {
                StatChanges = by.StatChanges;
            }

            if(by.StatusesApplied != null && by.StatusesApplied.Count > 0) {
                StatusesApplied = by.StatusesApplied;
            }

            if(by.StatusesRemoved != null && by.StatusesRemoved.Count > 0) {
                StatusesRemoved = by.StatusesRemoved;
            }

            ForcedSwitch = by.ForcedSwitch;

            SwitchTarget = by.SwitchTarget;

            if(by.NewItem != null) {
                NewItem = by.NewItem;
            }

            if(by.NewAbility != null) {
                NewAbility = by.NewAbility;
            }

            if (by.NewElement != null) {
                NewElement = by.NewElement;
            }

            if(by.TeamStatusesApplied != null && by.TeamStatusesApplied.Count > 0) { 
                TeamStatusesApplied = by.TeamStatusesApplied;
            }

            if(by.TeamStatusesRemoved != null & by.TeamStatusesRemoved.Count > 0) {
                TeamStatusesRemoved = by.TeamStatusesRemoved;
            }

            if(by.WeatherApplied != null) {
                WeatherApplied = by.WeatherApplied;
            }

            if(by.TerrainApplied != null) {
                TerrainApplied = by.TerrainApplied;
            }
        }

        public CombatEvent Copy () {
            return new (this);
        }
    }
}
