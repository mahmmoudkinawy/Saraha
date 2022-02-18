using System.ComponentModel.DataAnnotations.Schema;

namespace Saraha.Models;
public class Message
{
    public int Id { get; set; }

    [Required]
    [MaxLength(3000)]
    public string Content { get; set; }
    public DateTime Created { get; set; }


    public string AppUserId { get; set; }
    
    [ForeignKey("AppUserId")]
    public AppUser AppUser { get; set; }
}
