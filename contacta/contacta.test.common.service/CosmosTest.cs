using System;
using contacta.data.common.Models.Cosmos;
using contacta.services.cosmos.common.Delegate;
using Xunit;

namespace contacta.test.common.service
{
    public class CosmosTest
    {
        [Fact]
        public async void AddContacto()
        {
            Random random = new Random();
            int correlative = random.Next(1000, 1000000);
            Contacto contacto = new Contacto()
            {
                nombre = "Test_" + correlative,
                apellido = "ApellidoTest_" + correlative,
                email = "test@test.cl",
                telefono = "5555 5555",
                empresa = "TestFactory_" + correlative,
                cargo = "TestCargo_" + correlative,
                fecha = DateTime.Now.ToString()
            };

            CosmosDelegate instanceCosmos = CosmosDelegate.Instance;
            var addContanctAsync = await instanceCosmos.AddContact(contacto);

            if (addContanctAsync.Success) { }

        }
    }
}
