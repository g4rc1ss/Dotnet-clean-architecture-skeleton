using Application.Interfaces.Data;
using Microsoft.AspNetCore.DataProtection;
using Moq;
using TestUnitarios.Mocks.MockRepositoryDatabase.Fake;

namespace TestUnitarios.Mocks.MockDataProtection
{
    internal class DataProtectionMock
    {
        public Mock<IDataProtector> MockingDataProtector { get; set; }

        public DataProtectionMock()
        {
            MockingDataProtector = new();
            Initialize();
        }

        private void Initialize()
        {
            MockingDataProtector.Setup(x => x.Protect(It.IsAny<byte[]>())).Returns((byte[] value) => value);
            MockingDataProtector.Setup(x => x.Unprotect(It.IsAny<byte[]>())).Returns((byte[] value) => value);
        }
    }
}
