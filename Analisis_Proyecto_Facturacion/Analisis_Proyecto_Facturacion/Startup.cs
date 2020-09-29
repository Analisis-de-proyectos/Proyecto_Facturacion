using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Analisis_Proyecto_Facturacion.Startup))]
namespace Analisis_Proyecto_Facturacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
