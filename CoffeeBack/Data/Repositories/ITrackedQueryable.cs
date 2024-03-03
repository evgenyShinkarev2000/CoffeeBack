using System.Linq;

namespace CoffeeBack.Data.Repositories
{
    public interface ITrackedQueryable<T>
    {
        IQueryable<T> Tracked { get; }
    }
}
