﻿using System.Web;
using System.Web.Mvc;

namespace Analisis_Proyecto_Facturacion
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}