namespace Saraha.Data;
public class SarahaContext : IdentityDbContext
{
    public SarahaContext(DbContextOptions<SarahaContext> options) : base(options)
    { }

    public DbSet<Message> Messages { get; set; }

}