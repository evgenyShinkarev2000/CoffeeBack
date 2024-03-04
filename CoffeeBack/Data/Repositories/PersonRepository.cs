using CoffeeBack.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBack.Data.Repositories
{
    public interface IPersonRepository: IUntrackedQueryable<Person>, ITrackedQueryable<Person>, ISave
    {
        Person Add(Person person);
        Person Remove(Person person);
        Person Update(Person person);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext appDbContext;
        public IQueryable<Person> Untracked => appDbContext.People.AsNoTracking();

        public IQueryable<Person> Tracked => appDbContext.People;

        public PersonRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Person Add(Person person)
        {
            return appDbContext.Add(person).Entity;
        }

        public Person Update(Person person)
        {
            return appDbContext.Update(person).Entity;
        }

        public Person Remove(Person person)
        {
            return appDbContext.Remove(person).Entity;
        }

        public async Task Save()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
