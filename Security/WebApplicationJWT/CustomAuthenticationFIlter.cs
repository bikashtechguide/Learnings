using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace WebApplicationJWT
{
    public class CustomAuthenticationFIlter : AuthorizationFilterAttribute, IAuthenticationFilter
    {
        public override bool AllowMultiple => base.AllowMultiple;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            string authParamter = string.Empty;
            HttpRequestMessage httpRequestMessage = context.Request;
            AuthenticationHeaderValue authenticationHeaderValue = httpRequestMessage.Headers.Authorization;
            if (authenticationHeaderValue == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Authorization Header", httpRequestMessage);
                return;
            }
            if (authenticationHeaderValue != null)
            {
                if (authenticationHeaderValue.Scheme != "Bearer")
                {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid Authorization Schema", context.Request);
                    return;
                }
                if (!string.IsNullOrEmpty(authenticationHeaderValue.Parameter))
                {
                    context.ErrorResult = new AuthenticationFailureResult("Missing Token", context.Request);
                    return;
                }
            }
            context.Principal = TokenManager.GetPrincipal(authenticationHeaderValue.Parameter);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", "realm=localhost"));
            }
            context.Result = new ResponseMessageResult(result);
        }
    }

    public class AuthenticationFailureResult : IHttpActionResult
    {
        string reasonPhrase;
        HttpRequestMessage requestMessage;
        public AuthenticationFailureResult(string reasonPhase, HttpRequestMessage httpRequest)
        {
            reasonPhase = reasonPhase;
            requestMessage = httpRequest;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            httpResponseMessage.ReasonPhrase = reasonPhrase;
            httpResponseMessage.RequestMessage = requestMessage;
            return Task.FromResult(httpResponseMessage);
        }
    }

}