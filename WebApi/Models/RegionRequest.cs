using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class RegionRequest
    {
        public int id { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public int codigo { get; set; }

        [RegularExpression("^^[A-Za-z]+$", ErrorMessage = "** Solo se permiten Letras.")]
        public string name { get; set; }
        public int status { get; set; }
    }
}