using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/municipio")]
    public class MunicipioController : ApiController
    {
        Answer result = new Answer();

        [HttpGet]
        [Route("list")]
        public IHttpActionResult getData()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            con.Open();
            try
            {
                string sql = String.Format("Select id, idregion, codigo, name, status From municipio where status = 1");
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    var tb = new DataTable();
                    tb.Load(dr);
                    result.data = tb;
                    result.status = true;
                    result.message = HttpStatusCode.OK.ToString();
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                result.data = ex.Message;
                result.status = false;
                result.message = Error.sms_error(403);
                return Ok(result);
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }

        [HttpPost]
        [Route("insert")]
        public IHttpActionResult SaveData(MunicipioRequest mun)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            con.Open();
            try
            {
                if (mun == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                if (mun.id == 0)
                {
                    string sql2 = String.Format("Select codigo From region Where id = '" + mun.idregion + "' and status = 1;");
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    Int32 count1 = Convert.ToInt32(cmd2.ExecuteScalar());
                    if(count1 == 0)
                    {
                        result.data = "Region no encontrada";
                        result.status = true;
                        result.message = HttpStatusCode.NotFound.ToString();
                        return Ok(result);
                    }
                    string sql1 = String.Format("Select codigo From municipio Where idregion = '" + mun.idregion + "' and codigo = '"+ mun.codigo +"' and status = 1;");
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    Int32 count = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (count > 1)
                    {
                        result.data = "Este Municipio ya esta asociado a la region indicada";
                        result.status = true;
                        result.message = HttpStatusCode.OK.ToString();
                        return Ok(result);
                    }
                    string sql = String.Format("insert into municipio(IDREGION, CODIGO, NAME, STATUS) values('" + mun.idregion + "', '" + mun.codigo + "','" + mun.name + "','" + mun.status + "')");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    result.data = "Exitoso";
                    result.status = true;
                    result.message = HttpStatusCode.OK.ToString();
                    return Ok(result);
                }
                else
                {
                    string sql = String.Format("update municipio set codigo = '" + mun.codigo + "', name = '" + mun.name + "', status = '" + mun.status + "' where id = '" + mun.codigo + "' and idregion = '"+ mun.idregion +"' and status = 1;");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    result.data = "Actualizado";
                    result.status = true;
                    result.message = HttpStatusCode.OK.ToString();
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                result.data = ex.Message;
                result.status = false;
                result.message = Error.sms_error(402);
                return Ok(result);
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult deleteData(int id, int idRegion)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            con.Open();
            try
            {
                if (id == 0 || idRegion == 0)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                string sql1 = String.Format("Delete From municipio Where id = '" + id + "' and idregion = '" + idRegion + "' and status = 1;");
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                cmd1.ExecuteNonQuery();
                result.data = "Eliminado";
                result.status = true;
                result.message = HttpStatusCode.OK.ToString();
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.data = ex.Message;
                result.status = false;
                result.message = Error.sms_error(403);
                return Ok(result);
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }
    }
}
