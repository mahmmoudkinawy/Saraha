namespace Saraha.Data;
public class SarahaContext : IdentityDbContext
{
    public SarahaContext(DbContextOptions<SarahaContext> options) : base(options)
    { }

    public DbSet<Message> Messages { get; set; }

    //Seeding data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        //modelBuilder.Entity<Message>().HasData(new Message
        //{
        //    Id = 1,
        //    Content = "Hello I Love you",
        //    Created = new DateTime(2022, 01, 15)
        //});

        //modelBuilder.Entity<Message>().HasData(new Message
        //{
        //    Id = 2,
        //    Content = "Play tinnes",
        //    Created = DateTime.Today
        //});
    }
}