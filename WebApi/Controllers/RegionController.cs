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

    [RoutePrefix("api/region")]
    public class RegionController : ApiController
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
                string sql = String.Format("Select id, codigo, name, status From region where status = 1");
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


        [HttpGet]
        [Route("byId")]
        public IHttpActionResult getDatabyId(int id)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            con.Open();
            try
            {
                string sql = String.Format("Select id, codigo, name, status From region where id = '"+ id +"' and status = 1;");
                SqlCommand cmd = new SqlCommand(sql, con);
                Int32 com = Convert.ToInt32(cmd.ExecuteScalar());
                if(com == 0)
                {
                    result.data = "Region no encontrada";
                    result.status = true;
                    result.message = HttpStatusCode.NotFound.ToString();
                    return Ok(result);
                }
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
        public IHttpActionResult SaveData(RegionRequest region)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            con.Open();
            try
            {
                if (region == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                if (region.id == 0)
                {
                    string sql1 = String.Format("Select codigo From region Where codigo = '" + region.codigo + "' and status = 1;");
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    Int32 count = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (count > 1)
                    {
                        result.data = "Ya existe esa region";
                        result.status = true;
                        result.message = HttpStatusCode.OK.ToString();
                        return Ok(result);
                    }
                    string sql = String.Format("insert into region(CODIGO, NAME, STATUS) values('" + region.codigo + "','" + region.name + "','" + region.status + "')");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    result.data = "Exitoso";
                    result.status = true;
                    result.message = HttpStatusCode.OK.ToString();
                    return Ok(result);
                }
                else
                {
                    string sql = String.Format("update region set codigo = '"+region.codigo+"', name = '" + region.name + "', status = '" + region.status + "' where id = '" + region.codigo + "';");
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
                result.message = Error.sms_error(403);
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
        public IHttpActionResult deleteData(int region)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            con.Open();
            try
            {
                if (region == 0)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                string sql1 = String.Format("Delete From region Where id = '" + region + "' and status = 1;");
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
