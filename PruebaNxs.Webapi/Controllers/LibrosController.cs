using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaNxs.Appliation;
using PruebaNxs.DataAccess;
using PruebaNxs.Models;
using PruebaNxs.Webapi.Exeptions;


namespace PruebaNxs.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IApplication<Libro> _app;
        private int total;
        private int limitLibros=5;

        public LibrosController(ApiDbContext context, IApplication<Libro> app)
        {
            _context = context;
            _app = app;
            total = _app.GetAll().Count;

        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            List<Libro> libros = _app.GetAll().ToList<Libro>();
            //System.Console.WriteLine(libros);
            return libros;
          //  return await _context.Libros.ToListAsync();
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            //var libro = await _context.Libros.FindAsync(id);
            var libro = _app.GetById(id);
            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, LibroDto dto)
        {
            //implementamos método para restringir numero de Libros
            if (id != dto.id)
            {
                return BadRequest();
            }
          
            Libro libro= new Libro();
            libro.id = dto.id;
            libro.Titulo = dto.Titulo;
            libro.Ano = dto.Ano;
            libro.Genero = dto.Genero;
            libro.Nopaginas = dto.Nopaginas;
            libro.Idautor = dto.Idautor;

            var existing = _app.GetById(libro.id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(libro);
            }

            //_context.Entry(libro).State = EntityState.Modified;
            // _context.Update(libro);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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


        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(LibroDto dto)
        {
           
            if (total >= limitLibros)
            {
                Exception e = new ToMuchLibrosException();
                throw e;
                return BadRequest(e.Message.ToString());
            }
            bool ext = AutorExists(dto.Idautor);
            if (!AutorExists(dto.Idautor))
            {
                Exception e = new NoExistAutorException();
                throw e;
                return BadRequest(e.ToString());
            }

            Libro libro = new Libro
            {
                id = dto.id,
                Titulo = dto.Titulo,
                Ano = dto.Ano,
                Genero = dto.Genero,
                Nopaginas = dto.Nopaginas,
                Idautor = dto.Idautor,
                IdautorNavigation=null

            };
            _app.Save(libro);
            //_context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.id }, libro);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            //var libro = await _context.Libros.FindAsync(id);
            var libro = _app.GetById(id);
            if (libro == null)
            {
                return NotFound();
            }
            _app.Delete(id);
            //_context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.id == id);
        }
        private bool AutorExists(int id)
        {
            //return _app.GetAll().Any(a => a.id == id);
            return _context.Autors.Any(e => e.id == id);
        }
    }
}
