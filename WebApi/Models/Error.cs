using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Error
    {
        public static string sms_error(int error)
        {
            string sms = "";
            switch (error)
            {
                case 401:
                    sms = "Error de Autenticacion.";
                    break;
                case 402:
                    sms = "Error al editar o guardar municipio";
                    break;
                case 403:
                    sms = "Error al editar o guardar region";
                    break;
                default:
                    break;
            }

            return sms;
        }

    }
}