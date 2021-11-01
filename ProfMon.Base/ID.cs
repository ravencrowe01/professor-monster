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

namespace ProfMon.Base {
    public class ID {
        public readonly uint Major;
        public readonly uint Minor;

        public ID (uint major, uint minor = 0) {
            Major = major;
            Minor = minor;
        }

        public ulong ToLong () { 
            var major = (ulong) Major << 32;
            return major + Minor;
        }

        public override bool Equals (object obj) {
            var other = obj as ID;

            if (Major == other?.Major && Minor == other?.Minor) {
                return true;
            }

            return false;
        }

        public override int GetHashCode () {
            return (int) (Major ^ Minor);
        }

        public override string ToString () {
            return Major + GetMinorString();

            string GetMinorString () {
                if (Minor > 0) {
                    return $":{Minor}";
                }

                return "";
            }
        }
    }
}