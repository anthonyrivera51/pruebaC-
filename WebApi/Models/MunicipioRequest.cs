using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MunicipioRequest
    {
        public int id { get; set; }
        public int idregion { get; set; }
        public int codigo { get; set; }
        public string name { get; set; }
        public int status { get; set; }
    }
}