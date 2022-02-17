namespace Saraha.Controllers;
public class MessagesController : Controller
{
    private readonly SarahaContext _context;

    public MessagesController(SarahaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Messages.ToList());
    }
}
