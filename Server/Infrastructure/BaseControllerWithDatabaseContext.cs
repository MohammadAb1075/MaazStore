using Data.Common;

namespace Infrastructure;

public abstract class BaseControllerWithDatabaseContext : BaseController
{
    public BaseControllerWithDatabaseContext
        (DatabaseContext databaseContext) : base()
    {
        DatabaseContext = databaseContext;
    }

    protected DatabaseContext DatabaseContext { get; }

    protected async
        System.Threading.Tasks.Task DisposeDatabaseContextAsync()
    {
        if (DatabaseContext != null)
        {
            await DatabaseContext.DisposeAsync();

        }
    }
}
