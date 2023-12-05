using Microsoft.AspNetCore.Authentication.JwtBearer;
using KimdanishopeApp1.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KimdanishopeApp1.Server.Data;
using KimdanishopeApp1.Shared.Models;

namespace KimdanishopeApp1.Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext context;

        public CatalogoController(ApplicationDbContext context)
        {
            this.context = context();
        }

        [HttpGet]
        public async Task<List<Accesorio>> accesorios()
        {
            List<Accesorio> accesorios = new List<Accesorio>();
            accesorios = await context.Accesorios.ToListAsync();

            return accesorios;
        }

        [HttpGet ("Inspiracion")]
        public async Task<List<Inspiracion>> inspiracion()
        {
            List<Inspiracion> inspiracion = new List<Inspiracion>();
            inspiracion = await context.Inspiracion.ToListAsync();

            return inspiracion;
        }

        [HttpGet ("Adicional")]
        public async Task<List<Adicional>> adicional()
        {
            List<Adicional> adicional = new List<Adicional>();
            adicional = await context.Adicional.ToListAsync();

            return adicional;
        }

        [HttpPost ("nvoadicional")]
        public async Task<int> NuevoAdicional(Adicional nvoAdicional)
        {
            context.Add(nvoAdicional);
            await context.SaveChangesAsync();
            return nvoAdicional.Id;
        }
    }
}
