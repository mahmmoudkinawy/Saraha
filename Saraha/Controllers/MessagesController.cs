namespace Saraha.Controllers;
public class MessagesController : Controller
{
    private readonly SarahaContext _context;

    public MessagesController(SarahaContext context) => _context = context;

    [Authorize]
    public IActionResult Index()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return View(_context.Messages.Where(m => m.AppUserId == claim).ToList());
    }

    public IActionResult Create(string userPublicId)
        => View(new Message
        {
            AppUserId = userPublicId
        });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(string userPublicId, Message message)
    {
        if (ModelState.IsValid)
        {
            message.AppUserId = userPublicId;
            message.Created = DateTime.Now;

            _context.Messages.Add(message);
            _context.SaveChanges();
            TempData["success"] = "Message Sent Successfully";
            return RedirectToAction(nameof(Create));
        }
        return View();
    }

    public IActionResult Delete(int? id)
        => View(_context.Messages.Find(id));

    [Authorize]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        if (id == null || id == 0) return NotFound();

        var message = _context.Messages.FirstOrDefault(m => m.Id == id);

        if (message == null) return NotFound();

        _context.Messages.Remove(message);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

}