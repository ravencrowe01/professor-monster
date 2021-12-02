using ProfMon.Base;
using ProfMon.Monster.MonsterSpecies;

namespace ProfMon.Monster.Storage {
    public class Folder : StorageUnit {
        public int Background { get; private set; }

        public Folder (ID id, string name, int size, int background = 0) : base (id, name, size) {
            Background = background;
        }

        public Folder(ID id, string name, ISpeciesInstance [] monsters, int background) : base(id, name, monsters) {
            Background = background;
        }

        public void ChangeBackground (int background) {
            Background = background;
        }
    }
}
