using EmployeeManager.Data;
using System;
using Xunit;

namespace Test
{
    public class EmployeeTest
    {
        private string connectionString = "Data Source=(localdb)\\Servidor_Joan;Initial Catalog=AdminEmployees;Integrated Security=False;Persist Security Info=False;User ID=joan_tan;Password=joan@123";

        public EmployeeTest()
        {
            Environment.SetEnvironmentVariable("ConnectionString", connectionString);
        }

        [Fact]
        public void TheEmployeeExists()
        {
            //Inicializar datos
            string documentType = "CC";
            string documentNumber = "98000000";
            //Ejecutar método
            var data = ConnectionBD.GetEmployee(documentType, documentNumber);
            //Comprobar resultado
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public void TheEmployeeDoesNotExist()
        {
            //Inicializar datos
            string documentType = "CX";
            string documentNumber = "87457212";
            //Ejecutar método
            var data = ConnectionBD.GetEmployee(documentType, documentNumber);

            //Comprobar resultado
            Assert.Equal(0, data.Id);
        }
    }
}
