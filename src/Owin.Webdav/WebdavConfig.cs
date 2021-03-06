﻿using Soukoku.Owin.Webdav.DefaultImp;
using Soukoku.Owin.Webdav.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soukoku.Owin.Webdav
{
    /// <summary>
    /// Class for specifying the webdav configuration.
    /// </summary>
    public class WebdavConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebdavConfig"/> class.
        /// </summary>
        /// <param name="dataStore">The data store.</param>
        /// <exception cref="System.ArgumentNullException">dataStore</exception>
        public WebdavConfig(IDataStore dataStore)
        {
            if (dataStore == null) { throw new ArgumentNullException("dataStore"); }

            DataStore = dataStore;
            _defaultLog = new NullLog();
            _defaultDirGen = new BootstrapDirGenerator();
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow directory browsing.
        /// </summary>
        /// <value>
        /// <c>true</c> to allow directory browsing; otherwise, <c>false</c>.
        /// </value>
        public bool AllowDirectoryBrowsing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow infinite depth.
        /// </summary>
        /// <value>
        ///   <c>true</c> to allow infinite depth; otherwise, <c>false</c>.
        /// </value>
        public bool AllowInfiniteDepth { get; set; }

        /// <summary>
        /// Gets the data store.
        /// </summary>
        /// <value>
        /// The data store.
        /// </value>
        public IDataStore DataStore { get; private set; }

        NullLog _defaultLog;
        private ILog _log;
        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        public ILog Log
        {
            get { return _log ?? _defaultLog; }
            set { _log = value; }
        }

        BootstrapDirGenerator _defaultDirGen;
        private IDirectoryListingGenerator _dirGen;
        /// <summary>
        /// Gets or sets the directory listing generator.
        /// </summary>
        /// <value>
        /// The directory listing generator.
        /// </value>
        public IDirectoryListingGenerator DirectoryGenerator
        {
            get { return _dirGen ?? _defaultDirGen; }
            set { _dirGen = value; }
        }

    }

}
