﻿using Soukoku.Owin.Webdav.Handlers;
using Soukoku.Owin.Webdav.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soukoku.Owin.Webdav
{
    using Soukoku.Owin.Webdav.Responses;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    /// <summary>
    /// Owin middle ware for webdav function.
    /// </summary>
    public class WebdavMiddleware
    {
        readonly WebdavConfig _options;
        readonly AppFunc _next;
        readonly Dictionary<string, IMethodHandler> _handlers;

        /// <summary>
        /// Instantiates the middleware with a pointer to the next component.
        /// </summary>
        /// <param name="next">The next component.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="System.ArgumentNullException">
        /// next
        /// or
        /// options
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is how Owin works.")]
        public WebdavMiddleware(AppFunc next, WebdavConfig options)
        {
            if (next == null) { throw new ArgumentNullException("next"); }
            if (options == null) { throw new ArgumentNullException("options"); }

            _next = next;
            _options = options;
            _handlers = new Dictionary<string, IMethodHandler>(StringComparer.OrdinalIgnoreCase);

            var getHandler = new GetHandler();
            _handlers.Add(DavConsts.Methods.Get, getHandler);
            _handlers.Add(DavConsts.Methods.Head, getHandler);
            _handlers.Add(DavConsts.Methods.Options, new OptionsHandler());
            _handlers.Add(DavConsts.Methods.PropFind, new PropFindHandler());
            _handlers.Add(DavConsts.Methods.MkCol, new MkColHandler());
        }


        /// <summary>
        /// Process the owin request.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <returns></returns>
        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new DavContext(_options, environment);

            try
            {
                _options.Log.LogDebug("{0} for {1}{2}", context.Request.Method, context.Request.PathBase, context.Request.Path);

                ResourceResponse resource = _options.DataStore.GetResource(context, context.Request.Path);

                // TODO: handle query string part?
                //var fullUrl = context.Request.Uri.ToString();
                //if (resource.Resource != null && resource.Resource.ResourceType == ResourceType.Collection && !fullUrl.EndsWith("/", StringComparison.Ordinal))
                //{
                //    context.Response.Headers.Replace("Content-Location", fullUrl + "/");
                //}

                var code = StatusCode.NotHandled;
                IMethodHandler handler;
                if (_handlers.TryGetValue(context.Request.Method, out handler))
                {
                    code = await handler.HandleAsync(context, resource);
                }

                if (code == StatusCode.NotHandled)
                {
                    await _next.Invoke(environment);
                }
                else
                {
                    context.Response.StatusCode = (int)code;
                }
            }
            catch (Exception ex)
            {
                _options.Log.LogError(ex.ToString());
                //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //return context.Response.WriteAsync(ex.Message);
                throw;
            }
        }
    }
}
