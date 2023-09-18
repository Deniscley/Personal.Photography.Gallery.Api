using Bogus;
using Bogus.Extensions.Brazil;
using Personal.Photography.Gallery.Domain.Entities;

namespace Personal.Photography.Gallery.FakeData.Entities
{
    public class ClientFaker : Faker<Client>
    {
        public ClientFaker()
        {
            var id = new Faker().Random.Guid();
            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Nome, f => f.Person.FullName);
            RuleFor(p => p.DataNascimento, f => f.Date.Past());
            RuleFor(p => p.Cpf, f => f.Person.Cpf());
            //RuleFor(p => p.Cpf.ToString(), f => f.Person.Cpf());
        }
    }
}
