using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using WebApi.Models;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace WebApi.Controllers
{

    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpGet]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            //con.Open();
            
            Answer result = new Answer();
            result.status = false;
            bool isCredentialValid = true;
            try
            {
                //if (login == null)
                //    throw new HttpResponseException(HttpStatusCode.BadRequest);

                //TODO: Validate credentials Correctly, this code is only for demo !!
                //bool isCredentialValid = (login.Password == "123456");
                if (isCredentialValid)
                {
                    var token = TokenGenerator.GenerateTokenJwt("anthony");
                    result.data = token;
                    result.status = true;
                    result.message = HttpStatusCode.OK.ToString();
                    return Ok(result);
                }
                else
                {
                    result.status = false;
                    result.message = Error.sms_error(401);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                result.status = false;
                result.message = Error.sms_error(401);
                return Ok(result);
            }
            //con.Dispose();
            //con.Close();

        }
    }
}
