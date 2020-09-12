using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceManager.Testing.API.Mocks.DevicesController
{
    public class DevicesControllerHttpContextMock : HttpContext
    {
        public override ConnectionInfo Connection { get; }
        public override IFeatureCollection Features { get; }
        public override IDictionary<object, object> Items { get; set; }
        public override HttpRequest Request => requestMock;
        public override CancellationToken RequestAborted { get; set; }
        public override IServiceProvider RequestServices { get; set; }
        public override HttpResponse Response { get; }
        public override ISession Session { get; set; }
        public override string TraceIdentifier { get; set; }
        public override ClaimsPrincipal User { get; set; }
        public override WebSocketManager WebSockets { get; }

        private HttpRequest requestMock;

        public DevicesControllerHttpContextMock(IFormCollection collection)
        {
            requestMock = new DevicesControllerHttpRequestMock();
            requestMock.Form = collection;
        }

        public override void Abort()
        {
            throw new NotImplementedException();
        }
    }

    public class DevicesControllerHttpRequestMock : HttpRequest
    {
        public override Stream Body { get; set; }
        public override long? ContentLength { get; set; }
        public override string ContentType { get; set; }
        public override IRequestCookieCollection Cookies { get; set; }
        public override IFormCollection Form { get; set; }
        public override bool HasFormContentType { get; }
        public override IHeaderDictionary Headers { get; }
        public override HostString Host { get; set; }
        public override HttpContext HttpContext { get; }
        public override bool IsHttps { get; set; }
        public override string Method { get; set; }
        public override PathString Path { get; set; }
        public override PathString PathBase { get; set; }
        public override string Protocol { get; set; }
        public override IQueryCollection Query { get; set; }
        public override QueryString QueryString { get; set; }
        public override string Scheme { get; set; }

        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default)
        {
            return null;
        }
    }

}
