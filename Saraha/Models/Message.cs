namespace Saraha.Models;
public class Message
{
    public int Id { get; set; }

    [Required]
    public string Content { get; set; }
    public DateTime Created { get; set; }
}
