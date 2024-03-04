using CoffeeBack.Data.Repositories;
using CoffeeBack.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CoffeeBack.Services
{
    public interface IProgressService
    {
        Task<IEnumerable<PersonProgress>> GetAllowedPeopleProgress();
    }

    public class ProgressService : IProgressService
    {
        private readonly IPersonRepository personRepository;
        private readonly IUserService userService;
        private readonly ICurrentUserService currentUserService;

        public ProgressService(
            IPersonRepository personRepository,
            IUserService userService,
            ICurrentUserService currentUserService)
        {
            this.personRepository = personRepository;
            this.userService = userService;
            this.currentUserService = currentUserService;
        }

        public async Task<IEnumerable<PersonProgress>> GetAllowedPeopleProgress()
        {
            var currentPersonAccessLevel = await userService.RoleToAccessLevel(currentUserService.Role);
            if (currentPersonAccessLevel == 0)
            {
                return Enumerable.Empty<PersonProgress>();
            }
            if (currentPersonAccessLevel == 100)
            {
                var person = await personRepository.Untracked
                .Include(p => p.CompleatedTextLectures)
                .Include(p => p.CompleatedVideoLectures)
                .FirstOrDefaultAsync(p => p.Id == currentUserService.Id);

                if (person == null)
                {
                    return Enumerable.Empty<PersonProgress>();
                }

                return Enumerable.Repeat(new PersonProgress(
                person,
                person.CompleatedVideoLectures.Select(vl => vl.Id),
                person.CompleatedTextLectures.Select(tl => tl.Id)
                ), 1);
            }

            var evryIElement = 6 - currentPersonAccessLevel / 100;

            var allPersons = await personRepository.Untracked
                .Include(p => p.CompleatedTextLectures)
                .Include(p => p.CompleatedVideoLectures)
                .ToArrayAsync();

            var allowedPersons = allPersons.Where((p, i) => p.Id == currentUserService.Id || i % evryIElement == 0);

            return allowedPersons.Select(p => new PersonProgress(
                p,
                p.CompleatedVideoLectures.Select(vl => vl.Id),
                p.CompleatedTextLectures.Select(tl => tl.Id)
                ));
        }
    }
}
