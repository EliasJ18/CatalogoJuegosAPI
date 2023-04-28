using CatalogoJuegos.Contexts;
using CatalogoJuegos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace CatalogoJuegos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JuegosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JuegosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Juego>> Get()
        {
            return _context.Juegos.Include(x => x.Empresa).ToList();
        }

        [HttpGet ("{id}", Name = "ObtenerJuego")]
        public ActionResult<Juego> Get(int id)
        {
            var juego = _context.Juegos.Include(x => x.Empresa).FirstOrDefault(x => x.Id == id);

            if (juego == null)
            {
                return NotFound();
            }

            return juego;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Juego juego)
        {
            _context.Add(juego);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerJuego", new { id = juego.Id }, juego);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] Juego juego)
        {
            if (juego == null)
            {
                return BadRequest();
            }

            _context.Entry(juego).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult<Juego> Delete(int id)
        {
            var juego = _context.Juegos.FirstOrDefault(x => x.Id == id);

            if (juego == null)
            {
                return NotFound();
            }

            _context.Juegos.Remove(juego);
            _context.SaveChanges();
            return juego;
        }

    }
}
