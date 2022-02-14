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
using ProfMon.Objects.Inventory;
using System;
using System.Collections.Generic;

namespace ProfMon.Objects.Instances {
    public interface ISpeciesInstance : IReadOnlySpeciesInstance {
        void Rename (string name);

        void UpdateHappiness (float amount);

        void AddExperice (int amount);
        bool CanLevelUp ();
        void LevelUp ();

        void AddMedal (Medal medal);

        void Damage (float amount);
        void Heal (float amount);

        void UpdateStatTraining (Stats stats);

        bool CanAddMove ();
        bool CanRemoveMove ();
        void AddMove (IMoveInstance newMove);
        void RemoveMove (int index);
        void SwitchMoves (int from, int to);
        void ReplaceMove (int index, IMoveInstance move);

        void UpdateMoveBoosted (int index, int delta);
        void UpdateMoveUses (int index, int delta);

        bool HasMajorStatus ();
        void AddStatus (StatusInstance status);
        void RemoveStatus (Status status);
    }
}
