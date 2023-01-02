using Common.Paginations;

namespace Server.Models;

public class ListViewModel<T> where T : class
{
    public PagedData<T>? Data { get; set; }
}
