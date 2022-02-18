namespace Saraha.Controllers;
public class MessagesController : Controller
{
    private readonly SarahaContext _context;

    public MessagesController(SarahaContext context) => _context = context;

    public IActionResult Index() => View(_context.Messages.ToList());

    //Get the view
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Message message)
    {
        if (ModelState.IsValid)
        {
            message.Created = DateTime.Now;
            _context.Messages.Add(message);
            _context.SaveChanges();
            TempData["success"] = "Message Sent Successfully";
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    public IActionResult Delete(int? id)
        => View(_context.Messages.Find(id));

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