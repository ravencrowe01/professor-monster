using ProfMon.Base;
using ProfMon.Objects.Instances;
using ProfMon.Objects.Inventory;

namespace ProfMon.Objects.Combat {
    public class CombatMonster {
        private readonly ISpeciesInstance _monster;
        public IReadOnlySpeciesInstance Monster => _monster;

        private ISpeciesInstance _form;
        public IReadOnlySpeciesInstance CurrentForm => _form;

        private Stats _stats;
        public ReadonlyStats Stats => _stats;

        private Item _item;
        public Item Item => _item ?? _monster.HeldItem;

        private Ability _ability;
        public Ability Ability => _ability ?? _monster.Ability;

        private Element _element;
        public Element PrimaryElement => _element ?? _monster.Species.PrimaryElement;
        public Element SecondaryElement => _element == null ? _monster.Species.SecondaryElement : null;

        public CombatMonster (ISpeciesInstance monster) {
            _monster = monster;
            _stats = new Stats ();
        }

        public void ApplyAction (ICombatCalculator calculator, Action action) {
            var dmg = action.Damage.CalculcateHPModifier (calculator);

            if (dmg > 0) {
                _monster.Damage (dmg);
            }

            _stats += action.StatChanges;

            action.StatusesApplied.ForEach (status => _monster.AddStatus (new StatusInstance (status)));
            action.StatusesRemoved.ForEach (status => _monster.RemoveStatus (status));

            if (action.RemovedItem) {
                _item = null;
            }

            if (action.NewItem != null) {
                _item = action.NewItem;
            }

            if (action.NewAbility != null) {
                _ability = action.NewAbility;
            }

            if (action.NewElement != null) {
                _element = action.NewElement;
            }

            if (action.FormApplied != null) {
                _form = action.FormApplied;
            }
        }
    }
}
