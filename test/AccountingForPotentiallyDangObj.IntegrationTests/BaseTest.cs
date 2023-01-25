using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class BaseTest
    {
        public AfPdoDbContext _tmContext;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
                

        public async Task DeleteEntitiesAfterTests<T>(T entity) where T : BaseModel
        {
            var repository = new AfPdoRepository<T>(_tmContext);
            await repository.DeleteAsync(entity);
        }
    }
}
