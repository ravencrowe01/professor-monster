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

using Microsoft.EntityFrameworkCore;
using ProfMon.Base;
using ProfMon.Base.ProfObj;
using ProfMon.Registry;

namespace ProfMon.DataLoading.Registry {
    public class WriteableRegistry<T> : ReadOnlyRegistry<T>, IWriteableRegistry<T> where T : BaseProfObj {
        public WriteableRegistry (DbContext dbContext, DbSet<T> dbSet) : base (dbContext, dbSet) {
        }

        public void Add (T obj) {
            _dbSet.Add (obj);
            _dbContext.SaveChanges ();
        }

        public void AddAll (IEnumerable<T> objs) {
            _dbSet.AddRange (objs);
            _dbContext.SaveChanges ();
        }

        public void Remove (ID id) {
            var entity = GetByID(id);

            if (entity != null) {
                _dbSet.Remove (entity);
                _dbContext.SaveChanges ();
            }
        }

        public void Update (T obj) {
            _dbSet.Update (obj);
            _dbContext.SaveChanges ();
        }

        public void UpdateAll (IEnumerable<T> objs) {
            _dbSet.UpdateRange (objs);
            _dbContext.SaveChanges ();
        }
    }
}
