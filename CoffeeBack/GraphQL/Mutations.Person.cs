using CoffeeBack.Data.Models;
using CoffeeBack.Data.Repositories;
using CoffeeBack.GraphQL.Schema;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate;
using System.Threading.Tasks;
using CoffeeBack.Authorization;
using HotChocolate.Authorization;
using CoffeeBack.GraphQL.Mapper;

namespace CoffeeBack.GraphQL
{
    public partial class Mutations
    {
        [UseServiceScope]
        [UseProjection]
        [Authorize(Policy = KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.Manager)]
        public async Task<Person> AddPerson(
            [Service(ServiceKind.Resolver)] IPersonRepository personRepository,
            [Service] IAddPersonInputToData addPersonInputToData,
            AddPersonInput addPersonInput)
        {
            var person = addPersonInputToData.Map(addPersonInput);
            personRepository.Add(person);
            await personRepository.Save();

            return person;
        }

        [UseServiceScope]
        [UseProjection]
        [Authorize(Policy = KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.Manager)]
        public async Task<Person> UpdatePerson(
            [Service(ServiceKind.Resolver)] IPersonRepository personRepository,
            [Service] IUpdatePersonInputToData updatePersonInputToData,
            UpdatePersonInput updatePersonInput)
        {
            var person = updatePersonInputToData.Map(updatePersonInput);
            personRepository.Update(person);
            await personRepository.Save();

            return person;
        }

        [UseServiceScope]
        [UseProjection]
        [Authorize(Policy = KnownAuthorizePolicy.RoleAtLeast + KnownRoleName.Manager)]
        public async Task<Person> RemovePerson(
            [Service(ServiceKind.Resolver)] IPersonRepository personRepository,
            [Service] IRemovePersonInputToData removePersonInputToData,
            RemovePersonInput removePersonInput)
        {
            var person = removePersonInputToData.Map(removePersonInput);
            personRepository.Remove(person);
            await personRepository.Save();

            return person;
        }
    }
}
