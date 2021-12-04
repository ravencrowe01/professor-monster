using System.Collections.Generic;

namespace ProfMon.Base {
    public interface ITaggable<T> {
        IEnumerable<T> Tags { get; }
    }
}
