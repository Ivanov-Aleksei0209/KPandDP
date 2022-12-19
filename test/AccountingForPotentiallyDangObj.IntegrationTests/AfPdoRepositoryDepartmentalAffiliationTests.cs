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

        [Test]
        public void DepartmentalAffiliationTest()
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

            List<DepartmentalAffiliation> expected = new List<DepartmentalAffiliation>()
            {
                expectedObj1,
                expectedObj2,
                expectedObj3,
                expectedObj4,
                expectedObj5,
                expectedObj6,
                expectedObj7,
                expectedObj8
            };

            // Act
            var entitiesDepartmentalAffiliation = _departmentalAffiliationRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesDepartmentalAffiliation);

        }

    }
}