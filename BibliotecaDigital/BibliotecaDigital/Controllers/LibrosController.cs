using Microsoft.AspNetCore.Mvc;
using BibliotecaDigital.Data;
using BibliotecaDigital.Models;
using System.Linq;

namespace BibliotecaDigital.Controllers
{
    public class LibrosController : Controller
    {
        private readonly BibliotecaContext _context;

        public LibrosController(BibliotecaContext context)
        {
            _context = context;
        }

        // Acción para explorar libros con filtros y paginación
        public IActionResult Index(string filtroTitulo, string filtroGenero, int pagina = 1)
        {
            int tamanoPagina = 6; //Cantidad de libros a mostrar en la página
            var libros = _context.Libros.AsQueryable();

            // 🔍 Obtener lista de géneros únicos
            var generosDisponibles = _context.Libros
                .Select(l => l.Genero)
                .Distinct()
                .OrderBy(g => g)
                .ToList();

            ViewBag.Generos = generosDisponibles;

            // Aplicar filtros
            if (!string.IsNullOrEmpty(filtroTitulo))
                libros = libros.Where(l => l.Titulo.Contains(filtroTitulo));

            if (!string.IsNullOrEmpty(filtroGenero))
                libros = libros.Where(l => l.Genero == filtroGenero);

            // 📌 Paginación
            int totalLibros = libros.Count();
            int totalPaginas = (int)Math.Ceiling((double)totalLibros / tamanoPagina);
            var listaLibros = libros.Skip((pagina - 1) * tamanoPagina).Take(tamanoPagina).ToList();

            // Pasar datos a la vista
            ViewBag.Pagina = pagina;
            ViewBag.TotalPaginas = totalPaginas;

            return View(listaLibros);
        }

        // Acción para calificar un libro (sin necesidad de autenticación)
        [HttpPost]
        public IActionResult Calificar(int idLibro, int puntuacion)
        {
            if (puntuacion < 1 || puntuacion > 5)
                return BadRequest("La calificación debe estar entre 1 y 5.");

            var calificacion = new Calificacion
            {
                IdLibro = idLibro,
                Puntuacion = puntuacion
            };

            _context.Calificaciones.Add(calificacion);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Acción para mostrar los 5 libros mejor calificados
        public IActionResult TopLecturas()
        {
            var mejoresLibros = _context.Libros
                .ToList()
                .Select(libro => new
                {
                    libro,
                    Promedio = _context.Calificaciones
                                .Where(c => c.IdLibro == libro.IdLibro)
                                .Select(c => c.Puntuacion)
                                .ToList() 
                                .DefaultIfEmpty(0)
                                .Average()
                })
                .OrderByDescending(x => x.Promedio)
                .Take(5)
                .ToList()
                .Select(x => new Libro
                {
                    IdLibro = x.libro.IdLibro,
                    Titulo = x.libro.Titulo,
                    Autor = x.libro.Autor,
                    Genero = x.libro.Genero,
                    Sinopsis = x.libro.Sinopsis,
                    Portada_URL = x.libro.Portada_URL,
                    Calificaciones = x.libro.Calificaciones,
                    PromedioCalificacion = Math.Round(x.Promedio, 1)
                })
                .ToList();

            return View(mejoresLibros);
        }

        // SECCION DE FORMULARIO PARA LIBROS
        // Mostrar el formulario para crear un libro
        public IActionResult Create()
        {
            return View();
        }

        // Procesar el formulario y guardar el libro en la BD
        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libros.Add(libro);
                _context.SaveChanges();
                return RedirectToAction("Index"); //Redirige a la lista de libros
            }

            return View(libro);
        }

        // Mostrar el formulario para editar un libro
        public IActionResult Edit(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null) return NotFound();
            return View(libro);
        }

        // Procesar la edición y guardar cambios
        [HttpPost]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libros.Update(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libro);
        }

        // Mostrar el formulario de confirmación para eliminar
        public IActionResult Delete(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null) return NotFound();
            return View(libro);
        }

        // Procesar la eliminación
        [HttpPost]
        public IActionResult DeleteConfirmed([FromForm] int id) //Forzar que el parámetro venga del formulario
        {
            if (id <= 0) return BadRequest("ID no válido."); //Validación para evitar errores

            var libro = _context.Libros.FirstOrDefault(l => l.IdLibro == id);
            if (libro == null) return NotFound();

            _context.Libros.Remove(libro);
            _context.SaveChanges();

            return RedirectToAction("Admin");
        }

        public IActionResult Admin()
        {
            _context.ChangeTracker.Clear(); // Limpia el caché de entidades
            var listaLibros = _context.Libros.ToList(); // Obtiene la lista real desde la BD
            return View(listaLibros);
        }
    }
}