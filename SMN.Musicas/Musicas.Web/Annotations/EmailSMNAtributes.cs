using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicas.Web.Annotations
{
    public class EmailSMNAtributes:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value.ToString().EndsWith("@smn.com.br");
        }
    }
}