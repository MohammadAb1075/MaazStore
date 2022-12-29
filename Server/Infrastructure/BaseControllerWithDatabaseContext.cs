namespace Infrastructure;

public abstract class BaseControllerWithDatabaseContext : BaseController
{
    public BaseControllerWithDatabaseContext
        (Data.DatabaseContext databaseContext) : base()
    {
        DatabaseContext = databaseContext;
    }

    protected Data.DatabaseContext DatabaseContext { get; }

    protected async
        System.Threading.Tasks.Task DisposeDatabaseContextAsync()
    {
        if (DatabaseContext != null)
        {
            await DatabaseContext.DisposeAsync();

        }
    }
}
