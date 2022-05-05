using TestIntegracion.Initializers;
using Xunit;

namespace TestIntegracion
{
    [CollectionDefinition(TestCollections.WebApiTests)]
    public class TestApiConnectionFixture : ICollectionFixture<TestApiConnectionInitializer>
    {
    }


}
