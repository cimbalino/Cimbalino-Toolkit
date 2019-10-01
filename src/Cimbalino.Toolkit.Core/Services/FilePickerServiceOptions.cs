// ****************************************************************************
// <copyright file="FilePickerServiceOptions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Core</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Collections.Generic;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// The options for a <see cref="IFilePickerService"/> operation.
    /// </summary>
    public class FilePickerServiceOptions
    {
        /// <summary>
        /// Gets or sets the file picker view mode.
        /// </summary>
        /// <value>The file picker view mode.</value>
        public FilePickerServiceViewMode ViewMode { get; set; }

        /// <summary>
        /// Gets or sets the file picker suggested start location.
        /// </summary>
        /// <value>The file picker suggested start location.</value>
        public FilePickerServiceLocationId SuggestedStartLocation { get; set; }

        /// <summary>
        /// Gets or sets the file picker file type filters.
        /// </summary>
        /// <value>The file picker file type filters.</value>
        public IEnumerable<string> FileTypeFilters { get; set; }
    }
}