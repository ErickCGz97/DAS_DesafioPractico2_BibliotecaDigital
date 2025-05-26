using Microsoft.AspNetCore.Mvc;
using BibliotecaDigital.Data;

public class PruebaConexionController : Controller
{
    private readonly BibliotecaContext _context;

    public PruebaConexionController(BibliotecaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var libros = _context.Libros.ToList();
        return Ok(libros);
    }
}