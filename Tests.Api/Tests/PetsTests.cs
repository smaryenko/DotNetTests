namespace Tests.Api.Tests
{
    [TestFixture]
    public class PetsTests : ApiBase
    {
        public override Url RelativeUri => Constants.PetsRelativeUrl;

        [TestCase("blah")]
        [TestCase("!@#$%^&*():<>?")]
        [TestCase("")]
        [TestCase("10; DROP TABLE pets")]
        [TestCase("javascript:alert(‘Executed!’);")]
        public void CreatePet_WithName_Success(string name)
        {
            //Arrange
            var pet = new PetBuilder()
                .WithName(name)
                .Build();

            //Act
            var result = restClient.CreateObject(RelativeUri, pet);

            var resultObject = result.TryDeserializeJson<Pet>();

            //Assert
            Assert.Multiple(
                () =>
                {
                    Assert.That(resultObject.Name, Is.EqualTo(name));
                    Assert.NotNull(resultObject.Id);
                    Assert.That(resultObject.Id, Is.Not.EqualTo(0));
                });
        }

        [Test]
        public void DeletePet_Success()
        {
            //Arrange
            var pet = new PetBuilder()
                .WithName("to_delete")
                .Build();

            var result = restClient.CreateObject(RelativeUri, pet);
            var resultObject = result.TryDeserializeJson<Pet>();

            //Act
            restClient.DeleteObject(RelativeUri.AppendPathSegment(resultObject.Id));

            //Assert
            restClient.GetObject(RelativeUri.AppendPathSegment(resultObject.Id), HttpStatusCode.NotFound);
        }

        [Test]
        public void GetPet_NonExisting_NotFound()
        {
            //Arrange

            //Act
            //Assert
            restClient.GetObject(RelativeUri.AppendPathSegment(Guid.NewGuid()), HttpStatusCode.NotFound);
        }

        [Test]
        public void DeletePet_NonExisting_NotFound()
        {
            //Arrange

            //Act
            //Assert
            restClient.DeleteObject(RelativeUri.AppendPathSegment(Guid.NewGuid()), HttpStatusCode.NotFound);
        }
    }
}
