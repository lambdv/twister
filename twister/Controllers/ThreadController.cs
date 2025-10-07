using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using twister.Models;

namespace twister.Controllers;

[Route("api/threads")]
[ApiController]
public class ThreadController : ControllerBase
{
    private readonly ILogger<ThreadController> _logger;
    private readonly ApplicationDbContext _context;
    public ThreadController(ILogger<ThreadController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

}
