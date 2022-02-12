﻿using System;

namespace ProfMon.Monster.Moves {
    public class Attack {
        public float MovePower { get; set; }

        public float StatModifierBase { get; set; }

        public float AttackStat { get; set; }
        public float AttackStatModifier { get; set; }
        public float AttackLevel { get; set; }

        public float DefenseStat { get; set; }
        public float DefenseStatModifier { get; set; }
        public float DefenseLevel { get; set; }

        public float CritModifier { get; set; } = 1f;

        public float WeakAttackModifier { get; set; } = 1f;
        public float StrongAttackModifier { get; set; } = 1f;

        public float ProficiencyModifier { get; set; } = 1f;

        public float AbilityModifier { get; set; } = 1f;

        public float StatusModifier { get; set; } = 1f;

        public float TeamStatusModifier { get; set; } = 1f;

        public float FieldModifier { get; set; } = 1f;
        public float WeatherModifier { get; set; } = 1f;

        public float ItemModifier { get; set; } = 1f;

        public bool IsCrit { get; set; }

        public bool IsStrong { get; set; }
        public bool IsWeak { get; set; }

        public bool IsProficient { get; set; }

        public float CalculcateDamage () {
            float atk = AttackStat * (1 + CalculateStatModifier (AttackStatModifier));
            float def = DefenseStat * (1 + CalculateStatModifier (DefenseStatModifier));
            float statModifier = atk / def;
            float damage = MovePower * statModifier;

            return damage
                * CritModifier
                * StrongAttackModifier
                * WeakAttackModifier
                * ProficiencyModifier
                * AbilityModifier
                * StatusModifier
                * TeamStatusModifier
                * FieldModifier
                * WeatherModifier
                * ItemModifier;
        }

        private float CalculateStatModifier (float modifier) {
            if (modifier < 0) {
                return StatModifierBase / (StatModifierBase - modifier);
            }
            else {
                return StatModifierBase + modifier / StatModifierBase;
            }
        }
    }
}
