using System.Linq;

namespace CoffeeBack.Data.Repositories
{
    public interface IUntrackedQueryable<T>
    {
        /// <summary>
        /// NoTracking
        /// </summary>
        IQueryable<T> Untracked { get; }
    }
}
