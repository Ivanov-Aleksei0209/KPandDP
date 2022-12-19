using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryTypeOfPdoTests
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<TypeOfPdo> _typeOfPdoRepository;
        

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _typeOfPdoRepository = new AfPdoRepository<TypeOfPdo>(_tmContext);           
        }

        [Test]
        public void TypeOfPdoTest()
        {
            // Arrange
            TypeOfPdo expectedObj1 = new TypeOfPdo();
            expectedObj1.Id = 1;
            expectedObj1.Name = "automotive";
            expectedObj1.Abb = "CA";

            TypeOfPdo expectedObj2 = new TypeOfPdo();
            expectedObj2.Id = 2;
            expectedObj2.Name = "bridge";
            expectedObj2.Abb = "CB";
            
            TypeOfPdo expectedObj3 = new TypeOfPdo();
            expectedObj3.Id = 3;
            expectedObj3.Name = "gantry";
            expectedObj3.Abb = "CG";
            
            TypeOfPdo expectedObj4 = new TypeOfPdo();
            expectedObj4.Id = 4;
            expectedObj4.Name = "tower";
            expectedObj4.Abb = "CT";
            
            TypeOfPdo expectedObj5 = new TypeOfPdo();
            expectedObj5.Id = 5;
            expectedObj5.Name = "portal";
            expectedObj5.Abb = "CP";

            TypeOfPdo expectedObj6 = new TypeOfPdo();
            expectedObj6.Id = 6;
            expectedObj6.Name = "railway";
            expectedObj6.Abb = "CR"; 
            
            TypeOfPdo expectedObj7 = new TypeOfPdo();
            expectedObj7.Id = 7;
            expectedObj7.Name = "specialClass";
            expectedObj7.Abb = "CSc";
          
            TypeOfPdo expectedObj8 = new TypeOfPdo();
            expectedObj8.Id = 8;
            expectedObj8.Name = "pneumowheel";
            expectedObj8.Abb = "CPw";

            TypeOfPdo expectedObj9 = new TypeOfPdo();
            expectedObj9.Id = 9;
            expectedObj9.Name = "crawler";
            expectedObj9.Abb = "CC";

            TypeOfPdo expectedObj10 = new TypeOfPdo();
            expectedObj10.Id = 10;
            expectedObj10.Name = "passengerElectric";
            expectedObj10.Abb = "LPe";

            TypeOfPdo expectedObj11 = new TypeOfPdo();
            expectedObj11.Id = 11;
            expectedObj11.Name = "cargoElectric";
            expectedObj11.Abb = "LCe";

            TypeOfPdo expectedObj12 = new TypeOfPdo();
            expectedObj12.Id = 12;
            expectedObj12.Name = "hospitalElectric";
            expectedObj12.Abb = "LHe";

            List<TypeOfPdo> expected = new List<TypeOfPdo>()
            {
                expectedObj1,
                expectedObj2,
                expectedObj3,
                expectedObj4,
                expectedObj5,
                expectedObj6,
                expectedObj7,
                expectedObj8,
                expectedObj9,
                expectedObj10,
                expectedObj11,
                expectedObj12
            };

            // Act
            var entitiesTypeOfPdo = _typeOfPdoRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesTypeOfPdo);
        }

    }
}