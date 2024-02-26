using System.Linq;

namespace CoffeeBack.Data.Repositories
{
    public interface IRawQueryable<T>
    {
        /// <summary>
        /// NoTracking
        /// </summary>
        public IQueryable<T> Raw { get; }
    }
}
