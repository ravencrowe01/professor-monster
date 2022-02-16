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
    public enum CombatEventFlag {
        StartOfRound = 1,
        EndOfRound = 1 << 1,
        StartOfTurn = 1 << 2,
        EndOfTurn = 1 << 3,
        SwitchIn = 1 << 4,
        SwitchOut = 1 << 5,
        Attack = 1 << 6,
        PhysicalAttack = 1 << 7,
        WeatherChanged = 1 << 8,
        TerrainChanged = 1 << 9,
        KnockedOut = 1 << 10,
        Item = 1 << 11
    }
}