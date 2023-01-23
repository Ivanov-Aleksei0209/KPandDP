using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryDepartmentalAffiliationTests
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<DepartmentalAffiliation> _departmentalAffiliationRepository;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _departmentalAffiliationRepository = new AfPdoRepository<DepartmentalAffiliation>(_tmContext);
        }

        [Test, Order(1)]
        public void GetAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutListEntitiesFromDB()
        {
            // Arrange
            DepartmentalAffiliation expectedObj1 = new DepartmentalAffiliation();
            expectedObj1.Id = 1;
            expectedObj1.Name = "GomelRegionalExecutiveCommittee";

            DepartmentalAffiliation expectedObj2 = new DepartmentalAffiliation();
            expectedObj2.Id = 2;
            expectedObj2.Name = "MinistryOfIndustry";

            DepartmentalAffiliation expectedObj3 = new DepartmentalAffiliation();
            expectedObj3.Id = 3;
            expectedObj3.Name = "MinistryOfEnergy";

            DepartmentalAffiliation expectedObj4 = new DepartmentalAffiliation();
            expectedObj4.Id = 4;
            expectedObj4.Name = "MinistryOfHealth";

            DepartmentalAffiliation expectedObj5 = new DepartmentalAffiliation();
            expectedObj5.Id = 5;
            expectedObj5.Name = "MinistryOfEducation";

            DepartmentalAffiliation expectedObj6 = new DepartmentalAffiliation();
            expectedObj6.Id = 6;
            expectedObj6.Name = "Belneftekhim";

            DepartmentalAffiliation expectedObj7 = new DepartmentalAffiliation();
            expectedObj7.Id = 7;
            expectedObj7.Name = "Bellesbumprom";

            DepartmentalAffiliation expectedObj8 = new DepartmentalAffiliation();
            expectedObj8.Id = 8;
            expectedObj8.Name = "withoutDepartmentalSubordination";

            //DepartmentalAffiliation expectedObj9 = new DepartmentalAffiliation();
            //expectedObj9.Id = 9;
            //expectedObj9.Name = "MinistryOfJKH";

            List<DepartmentalAffiliation> expected = new List<DepartmentalAffiliation>()
            {
                expectedObj1,
                expectedObj2,
                expectedObj3,
                expectedObj4,
                expectedObj5,
                expectedObj6,
                expectedObj7,
                expectedObj8//,
                //expectedObj9

            };

            // Act
            var entitiesDepartmentalAffiliation = _departmentalAffiliationRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesDepartmentalAffiliation);

        }

        [Test, Order(2)]
        public void AddAsyncObject_WhenPropertiesIsNotNull_ThenOutIsListEntitiesFromDB()
        {
            // Arrange
            var addingDepartmentalAffiliation = new DepartmentalAffiliation();
            addingDepartmentalAffiliation.Name = "MinJKH";

            DepartmentalAffiliation expectedObj1 = new DepartmentalAffiliation();
            expectedObj1.Id = 1;
            expectedObj1.Name = "GomelRegionalExecutiveCommittee";

            DepartmentalAffiliation expectedObj2 = new DepartmentalAffiliation();
            expectedObj2.Id = 2;
            expectedObj2.Name = "MinistryOfIndustry";

            DepartmentalAffiliation expectedObj3 = new DepartmentalAffiliation();
            expectedObj3.Id = 3;
            expectedObj3.Name = "MinistryOfEnergy";

            DepartmentalAffiliation expectedObj4 = new DepartmentalAffiliation();
            expectedObj4.Id = 4;
            expectedObj4.Name = "MinistryOfHealth";

            DepartmentalAffiliation expectedObj5 = new DepartmentalAffiliation();
            expectedObj5.Id = 5;
            expectedObj5.Name = "MinistryOfEducation";

            DepartmentalAffiliation expectedObj6 = new DepartmentalAffiliation();
            expectedObj6.Id = 6;
            expectedObj6.Name = "Belneftekhim";

            DepartmentalAffiliation expectedObj7 = new DepartmentalAffiliation();
            expectedObj7.Id = 7;
            expectedObj7.Name = "Bellesbumprom";

            DepartmentalAffiliation expectedObj8 = new DepartmentalAffiliation();
            expectedObj8.Id = 8;
            expectedObj8.Name = "withoutDepartmentalSubordination";

            DepartmentalAffiliation expectedObj9 = new DepartmentalAffiliation();
            expectedObj9.Id = 9;
            expectedObj9.Name = "MinJKH";

            List<DepartmentalAffiliation> expected = new List<DepartmentalAffiliation>()
            {
                expectedObj1,
                expectedObj2,
                expectedObj3,
                expectedObj4,
                expectedObj5,
                expectedObj6,
                expectedObj7,
                expectedObj8,
                expectedObj9
            };
            // Act
            var entitiesDepartmentalAffilationId = _departmentalAffiliationRepository.AddAsync(addingDepartmentalAffiliation).Result;
            var entitiesDepartmentalAffilation = _departmentalAffiliationRepository.GetAllAsync().Result;
            // Assert
            Assert.AreEqual(expected, entitiesDepartmentalAffilation);
        }

        [Test, Order(3)]
        public void UpdateAsyncObject_WhenPropertiesIsNotNull_ThenOpdateIsListEntitiesFromDB()
        {
            // Arrange
            var updateDepartmentalAffiliation = new DepartmentalAffiliation();
            updateDepartmentalAffiliation.Id = 9;
            updateDepartmentalAffiliation.Name = "MinistryOfJKH";

            DepartmentalAffiliation expectedObj9 = new DepartmentalAffiliation();
            expectedObj9.Id = 9;
            expectedObj9.Name = "MinistryOfJKH";

            List<DepartmentalAffiliation> expected = new List<DepartmentalAffiliation>()
            {
                expectedObj9
            };

            // Act
            var DepartmentalAffiliationUpdate = _departmentalAffiliationRepository.UpdateAsync(updateDepartmentalAffiliation).Result;
            var entitiesDepartmentalAffiliation = _departmentalAffiliationRepository.GetByIdAsync(9).Result;

            //Assert
            Assert.AreEqual(expected, entitiesDepartmentalAffiliation);
        }

        [Test, Order(4)]
        public void GetByIdAsyncObject_WhenPropertiesIsNotNull_ThenDeleteIsListEntitiesFromDB()
        {
            //Arrange
            var getByIdDepartmentalAffiliation = new DepartmentalAffiliation();
            getByIdDepartmentalAffiliation.Id = 9;
            getByIdDepartmentalAffiliation.Name = "MinistryOfJKH";

            DepartmentalAffiliation expectedObj1 = new DepartmentalAffiliation();
            expectedObj1.Id = 9;
            expectedObj1.Name = "MinistryOfJKH";

            List<DepartmentalAffiliation> expected = new List<DepartmentalAffiliation>()
            { expectedObj1 };

            //Act
            var departmentalAffiliationGetById = _departmentalAffiliationRepository.GetByIdAsync(getByIdDepartmentalAffiliation.Id).Result;
            var entitiesDepartmentalAffiliation = _departmentalAffiliationRepository.GetByIdAsync(9).Result;

            //Assert
            Assert.AreEqual(expected, entitiesDepartmentalAffiliation);
        }

    }
}