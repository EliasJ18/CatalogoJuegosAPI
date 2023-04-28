using CatalogoJuegos.Contexts;
using CatalogoJuegos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoJuegos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Empresa>> Get()
        {
            return _context.Empresas.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerEmpresa")]
        public ActionResult<Empresa> Get(int id)
        {
            var empresa = _context.Empresas.FirstOrDefault(x => x.Id == id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Empresa empresa)
        {
            _context.Add(empresa);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerEmpresa", new { id = empresa.Id }, empresa);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] Empresa empresa)
        {
            if (empresa == null)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult<Empresa> Delete(int id)
        {
            var empresa = _context.Empresas.FirstOrDefault(x => x.Id == id);

            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            _context.SaveChanges();
            return empresa;
        }
    }
}
