using Tests.Api.Helpers.Models;

namespace Tests.Api.Helpers.Builders
{
    public class PetBuilder
    {
        private readonly Pet _instance;

    public PetBuilder()
    {
        _instance = new Pet();
    }

    public PetBuilder WithName(string name)
    {
        _instance.Name = name;
        return this;
    }

    public Pet Build()
    {
        return _instance;
    }
}
}
