﻿using System;
using Soukoku.Owin.Webdav.Models;
using System.IO;
using Microsoft.Owin;

namespace Owin.Webdav
{
    class FolderResource : Resource
    {
        private DirectoryInfo _info;

        public FolderResource(IOwinContext context, string logicalPath, string physicalPath) : base(context, logicalPath)
        {
            _info = new DirectoryInfo(physicalPath);
        }

        //string PhysicalPath { get { return _info.FullName; } }
        public override ResourceType Type { get { return ResourceType.Collection; } }
        public override DateTime CreationDateUtc { get { return _info.CreationTimeUtc; } }
        public override DateTime ModifiedDateUtc { get { return _info.LastWriteTimeUtc; } }

    }
}