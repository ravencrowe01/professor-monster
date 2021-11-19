using ProfMon.Base.ProfObj;
using ProfMon.Registry.Filter;
using System.Collections.Generic;

namespace ProfMon.Registry {
    public interface IFilterableRegistry<T> : IReadOnlyRegistry<T> where T : BaseProfObj {
        IEnumerable<T> Filter (IBaseFilter registryFilter);
    }
}
