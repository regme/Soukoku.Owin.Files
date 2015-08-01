﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Soukoku.Owin.Files.Services
{
    /// <summary>
    /// Something that can generate the directory listing html.
    /// </summary>
    public interface IDirectoryListingGenerator
    {
        /// <summary>
        /// Generates the directory listing html string.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="parentResource">The parent resource.</param>
        /// <param name="childResources">The child resources.</param>
        /// <returns></returns>
        Task<string> GenerateAsync(Context context, IResource parentResource, IEnumerable<IResource> childResources);
    }
}
