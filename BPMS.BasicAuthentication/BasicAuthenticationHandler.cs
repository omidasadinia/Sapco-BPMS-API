using BPMS.Domain.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BPMS.BasicAuthentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly BPMS_Context _context;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock , BPMS_Context context) : base(options, logger, encoder, clock)
        {
            _context = context;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missng Authorization Key"));

            }

            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                if (!Request.Headers.ContainsKey("Authorization"))
                {
                    return Task.FromResult(AuthenticateResult.Fail("Authorization Header does not start whit 'Basic '"));

                }

            }
            var authBase64Decoded = Encoding.UTF8.GetString(
                Convert.FromBase64String(
                    authorizationHeader.Replace("Basic ", "",
                    StringComparison.OrdinalIgnoreCase
                ))
               );

            var authSplit = authBase64Decoded.Split(new[] { ':' }, 2);

            if (authSplit.Length != 2)
            {
                return Task.FromResult(AuthenticateResult.Fail("invalid Authorization header format"));
            }


            var clientId = authSplit[0];
            var clientSecret = authSplit[1];

            // validating username & password with the help of ADMIN.DBA_AUTHENTICATION_F function in sapdb database
            OracleParameter p1 = new("p_username", clientId);
            OracleParameter p2 = new("p_password", clientSecret);
            OracleParameter p3 = new("result", OracleDbType.Byte, DBNull.Value, ParameterDirection.Output);
            string sql = "Begin :result:= ADMIN.DBA_AUTHENTICATION_F(:p_username, :p_password);END;";
            _context.Database.ExecuteSqlRaw(sql, p1, p2, p3);
            var result = Convert.ToByte(p3.Value.ToString());


            if (!(result==1)) //&& responseStatusCode == 200
            {

                return Task.FromResult(AuthenticateResult.Fail("UserName Or Password is incorrect"));

            }


            var client = new BasicAuthenticationClient
            {
                AuthenticationType = BasicAuthenticationDefaults.AuthenticationScheme,
                IsAuthenticated = true,
                Name = clientId
            };


            var ClaimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
            {
                new Claim(ClaimTypes.Name, clientId)
            }));


            return Task.FromResult(
                AuthenticateResult.Success(
                    new AuthenticationTicket(ClaimsPrincipal, Scheme.Name
                    )));


        }
    }
}
