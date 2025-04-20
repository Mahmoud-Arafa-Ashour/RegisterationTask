namespace RegisterationTask;

public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :
    IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Contact> Contacts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
