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

namespace ProfMon.Objects.Combat {
    public class MoveHPModifier {
        public Move Move { get; set; }

        public CombatMonster Actor { get; set; }
        public CombatMonster Target { get; set; }

        public bool IsCrit { get; set; }
        public float CritModifier { get; set; } = 1f;

        public bool IsStrongAttack { get; set; }
        public float StrongAttackModifier { get; set; } = 1f;

        public bool IsWeakAttack { get; set; }
        public float WeakAttackModifier { get; set; } = 1f;

        public bool IsProficientAttack { get; set; }
        public float ProficiencyModifier { get; set; } = 1f;

        public float AbilityModifier { get; set; } = 1f;

        public float StatusModifier { get; set; } = 1f;

        public float TeamStatusModifier { get; set; } = 1f;

        public float FieldModifier { get; set; } = 1f;
        public float WeatherModifier { get; set; } = 1f;

        public float ItemModifier { get; set; } = 1f;

        public float CalculcateHPModifier (ICombatCalculator calculator) {
            float damage = calculator.CalculateBaseHPModifier (Move, Actor, Target);

            return damage
                * CritModifier
                * (IsStrongAttack ? StrongAttackModifier : 1f)
                * (IsWeakAttack ? WeakAttackModifier : 1f)
                * (IsProficientAttack ? ProficiencyModifier : 1f)
                * AbilityModifier
                * StatusModifier
                * TeamStatusModifier
                * FieldModifier
                * WeatherModifier
                * ItemModifier;
        }
    }
}
