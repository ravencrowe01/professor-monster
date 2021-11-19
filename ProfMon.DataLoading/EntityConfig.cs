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
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfMon.Base;
using ProfMon.Base.ProfObj;

namespace ProfMon.DataLoading {
    public class EntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseProfObj {
        public virtual void Configure (EntityTypeBuilder<T> builder) {
            builder.HasKey (entity => entity.ID);

            builder.Property (entity => entity.ID).HasConversion (id => id.ToLong (), id => new ID (id));
        }
    }
}
