﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Soukoku.Owin.Files
{
    /// <summary>
    /// Contains constant values used by webdav.
    /// </summary>
    public static class DavConsts
    {
        /// <summary>
        /// The namespace for all built-in webdav xml names.
        /// </summary>
        public const string XmlNamespace = "DAV:";
        

        /// <summary>
        /// Contains the http header names used by webdav.
        /// </summary>
        internal static class Headers
        {
            // spec section 10

            public const string Dav = "DAV";
            public const string Depth = "Depth";
            public const string Destination = "Destination";
            public const string If = "If";
            public const string LockToken = "Lock-Token";
            public const string Overwrite = "Overwrite";
            public const string Timeout = "Timeout";
        }

        /// <summary>
        /// Contains the xml element names used by webdav
        /// </summary>
        /// public class
        internal static class ElementNames
        {
            // spec section 14

            public const string ActiveLock = "activelock";
            public const string AllProp = "allprop";
            public const string Collection = "collection";
            public const string Depth = "depth";
            public const string Error = "error";
            public const string Exclusive = "exclusive";
            public const string Href = "href";
            public const string Include = "include";
            public const string Location = "location";
            public const string LockEntry = "lockentry";
            public const string LockInfo = "lockinfo";
            public const string LockRoot = "lockroot";
            public const string LockScope = "lockscope";
            public const string LockToken = "locktoken";
            public const string LockType = "locktype";
            public const string MultiStatus = "multistatus";
            public const string Owner = "owner";
            public const string Prop = "prop";
            public const string PropertyUpdate = "propertyupdate";
            public const string PropFind = "propfind";
            public const string PropName = "propname";
            public const string PropStat = "propstat";
            public const string Remove = "remove";
            public const string Response = "response";
            public const string ResponseDescription = "responsedescription";
            public const string Set = "set";
            public const string Shared = "shared";
            public const string Status = "status";
            public const string Timeout = "timeout";
            public const string Write = "write";

        }

        /// <summary>
        /// Contains property names defined by webdav.
        /// </summary>
        public static class PropertyNames
        {
            // spec section 15

            public const string CreationDate = "creationdate";
            public const string DisplayName = "displayname";
            public const string GetContentLanguage = "getcontentlanguage";
            public const string GetContentLength = "getcontentlength";
            public const string GetContentType = "getcontenttype";
            public const string GetETag = "getetag";
            public const string GetLastModified = "getlastmodified";
            public const string LockDiscovery = "lockdiscovery";
            public const string ResourceType = "resourcetype";
            public const string SupportedLock = "supportedlock";
        }

        /// <summary>
        /// Http status codes used by webdav.
        /// </summary>
        public enum StatusCode
        {
            /// <summary>
            /// Special indicator (not a real http code) for request not handled by webdav.
            /// </summary>
            NotHandled = 0,

            // spec section 11

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi", Justification = "Useless word block from ancient times.")]
            MultiStatus = 207,
            UnprocessableEntity = 422,
            Locked = 423,
            FailedDependency = 424,
            InsufficientStorage = 507,

            // standard codes
            OK = HttpStatusCode.OK,
            Created = HttpStatusCode.Created,
            NoContent = HttpStatusCode.NoContent,
            BadRequest = HttpStatusCode.BadRequest,
            NotFound = HttpStatusCode.NotFound,
            PreconditionFailed = HttpStatusCode.PreconditionFailed,
            Conflict = HttpStatusCode.Conflict,
            UnsupportedMediaType = HttpStatusCode.UnsupportedMediaType,
            Forbidden = HttpStatusCode.Forbidden,
            MethodNotAllowed = HttpStatusCode.MethodNotAllowed
        }
    }
}
