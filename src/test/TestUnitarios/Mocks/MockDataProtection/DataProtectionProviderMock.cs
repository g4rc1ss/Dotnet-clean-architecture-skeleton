using Moq;

namespace TestUnitarios.Mocks.MockDataProtection
{
    internal class DataProtectionProviderMock
    {
        public Mock<IDataProtectionProvider> MockingDataProtectionProvider { get; set; }

        public DataProtectionProviderMock()
        {
            MockingDataProtectionProvider = new();
            Initialize();
        }

        private void Initialize()
        {
            MockingDataProtectionProvider.Setup(x => x.CreateProtector(It.IsAny<string>())).Returns(new DataProtectionMock().MockingDataProtector.Object);
        }
    }
}
