#region copyright
/** Professors Monster, a library for creating monster collection style games.
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

using ProfMon.Base;
using ProfMon.Objects.Inventory;
using System;

namespace ProfMon.Objects.Instances {
    public interface ISpeciesInstanceBuilder {
        ISpeciesInstanceBuilder WithOriginalTrainer (ID id, string name);

        ISpeciesInstanceBuilder WithAbility (Ability ability);

        ISpeciesInstanceBuilder WithNature (Nature nature);

        ISpeciesInstanceBuilder WithGeneticStats (Stats genes);

        ISpeciesInstanceBuilder WithMoves (params Move [] moves);

        ISpeciesInstanceBuilder WithTimeMet (DateTime dateTime);

        ISpeciesInstanceBuilder WithMetID (Location location);

        ISpeciesInstanceBuilder WithEggReceivedTime (DateTime dateTime);

        ISpeciesInstanceBuilder WithEggReceivedLocationID (ID id);

        ISpeciesInstanceBuilder WithPersonality (Personality personality);

        ISpeciesInstanceBuilder WithCaptureDeviceID (Item device);

        ISpeciesInstanceBuilder WithMedals (params Medal [] medals);

        ISpeciesInstanceBuilder WithStartingLevel (float level);

        ISpeciesInstanceBuilder WithStartingHappiness (float happiness);

        ISpeciesInstance Build ();
    }
}
