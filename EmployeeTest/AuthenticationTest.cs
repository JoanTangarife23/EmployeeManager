using EmployeeManager.Data;
using System;
using Xunit;

namespace Test
{
    public class AuthenticationTest
    {
        private string connectionString = "Data Source=(localdb)\\Servidor_Joan;Initial Catalog=AdminEmployees;Integrated Security=False;Persist Security Info=False;User ID=joan_tan;Password=joan@123";

        public AuthenticationTest()
        {
            Environment.SetEnvironmentVariable("ConnectionString", connectionString);
        }

        [Fact]
        public void TheIdExists()
        {
            //Inicializar datos
            int id = 1;
            //Ejecutar método
            var idExists = ConnectionBD.GetAuthenticationData(id);
            //Comprobar resultado
            Assert.Equal("joantan", idExists.UserName);
            Assert.Equal("12345", idExists.Password);
        }

        [Fact]
        public void TheIdDoesNotExist()
        {
            //Inicializar datos
            int id = 999;
            //Ejecutar método
            var idExists = ConnectionBD.GetAuthenticationData(id);
            //Comprobar resultado
            Assert.Equal(0, idExists.EmployeeId);
        }
    }
}
