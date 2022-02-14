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

namespace ProfMon.Base {
    public class ID {
        public readonly uint Identifier = 0;
        public readonly uint Descriminator = 0;

        public ID (uint identifier, uint descriminator = 0) {
            Identifier = identifier;
            Descriminator = descriminator;
        }

        public ID (ulong id) {
            Identifier = (uint) id >> 32;
            Descriminator = (uint) id;
        }

        public ID () { }

        public ulong ToLong () {
            var major = (ulong) Identifier << 32;
            return major + Descriminator;
        }

        public override bool Equals (object obj) {
            var other = obj as ID;

            if (Identifier == other?.Identifier && Descriminator == other?.Descriminator) {
                return true;
            }

            return false;
        }

        public override int GetHashCode () {
            return (int) (Identifier ^ Descriminator);
        }

        public override string ToString () {
            return Identifier + GetDescriminatorString ();

            string GetDescriminatorString () {
                if (Descriminator > 0) {
                    return $":{Descriminator}";
                }

                return "";
            }
        }
    }
}