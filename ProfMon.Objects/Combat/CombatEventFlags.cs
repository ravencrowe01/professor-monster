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

using System;

namespace ProfMon.Objects.Combat {
    [Flags]
    public enum CombatEventFlags {
        StartOfTurn = 1,
        EndOfTurn = 1 << 1,
        StartOfRound = 1 << 2,
        EndOfRound = 1 << 3,
        SwitchIn = 1 << 4,
        SwitchOut = 1 << 5,
        OpponentSwitchIn = 1 << 6,
        OpponentSwitchOut = 1 << 7,
        AllySwitchIn = 1 << 8,
        AllySwitchOut = 1 << 9,
        Attack = 1 << 10,
        OpponentAttack = 1 << 11,
        AllyAttack = 1 << 12,
        PhysicalAttack = 1 << 13,
        OpponentPhysicalAttack = 1 << 14,
        AllyPhysicalAttack = 1 << 15,
        NonpyhsicalAttack = 1 << 16,
        OpponentNonphysicalAttack = 1 << 17,
        AllyNonphysicalAttack = 1 << 18,
        Attacked = 1 << 19,
        OpponentAttacked = 1 << 20,
        AllyAttacked = 1 << 21,
        WeatherChanged = 1 << 22,
        TerrainChanged = 1 << 23,
        KnockedOut = 1 << 24,
        OpponentKnockedOut = 1 << 25,
        AllyKnockedOut = 1 << 26
    }
}