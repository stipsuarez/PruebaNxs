using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaNxs.Appliation;
using PruebaNxs.DataAccess;
using PruebaNxs.Webapi.Dtos;
using PruebaNxs.Models;

namespace PruebaNxs.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IApplication <Autor>_app;

        public AutoresController( ApiDbContext context, IApplication<Autor> app)
        {
            _context = context;
            _app = app;
        }

        // GET: api/Autor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutors()
        {
            List<Autor> autores = _app.GetAll().ToList<Autor>();
            //System.Console.WriteLine(autores);
           return autores;
           // return await _context.Autors.ToListAsync();
        }

        // GET: api/Autor/5
        [HttpGet("{id}")]
        public  async Task<ActionResult<Autor>> GetAutor(int id)
        {
            //var autor = await _context.Autors.FindAsync(id);
            var autor = _app.GetById(id);
            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // PUT: api/Autor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, AutorDto dto)
        {
            if (id != dto.id)
            {
                return BadRequest();
            }

            Autor autor = new Autor
            {
                id = dto.id,
                Nombre = dto.Nombre,
                Fechanacimiento = dto.Fechanacimiento,
                Ciudad = dto.Ciudad,
                Email = dto.Email
            };

            _context.Entry(autor).State = EntityState.Modified;
            

   
            try
            {
               // _app.Save(autor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Autor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(AutorDto dto)
        {
            Autor autor = new Autor
            {
                id = dto.id,
                Nombre = dto.Nombre,
                Fechanacimiento = dto.Fechanacimiento,
                Ciudad = dto.Ciudad,
                Email = dto.Email
            };
            _app.Save(autor);
           // _context.Autors.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.id }, autor);
        }

        // DELETE: api/Autor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            //var autor = await _context.Autors.FindAsync(id);
            var autor = _app.GetById(id);
            if (autor == null)
            {
                return NotFound();
            }
            _app.Delete(id);
            //_context.Autors.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutorExists(int id)
        {
            return _context.Autors.Any(e => e.id == id);
        }
    }
}
