namespace Persistence.Repository;

public class Repo
{
    private AppDbContext DbContext { get; set; }

    public Repo(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }
}