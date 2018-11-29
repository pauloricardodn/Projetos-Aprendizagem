using Administracao.Web.AutoMapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administracao.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configurar()
        {
            Mapper.AddProfile<DominioParaViewModeProfile>();
            Mapper.AddProfile<ViewModelParaDominioProfile>();
        }
    }
}