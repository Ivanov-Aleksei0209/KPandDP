using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IPdoHelper
    {
        List<Pdo> GetNotWithdrawalFromRegistration(List<Pdo> models, int journalPdoId);

        List<Pdo> GetOldPdoModel(List<Pdo> models, int journalPdoId);

        double GetPercentOld(int notWithdrawalFromRegistration, int oldPdo);

        Task<PdoDto> GetPdoDtoForAddAsync(PdoViewModel model);

        Task<PdoDto> GetPdoDtoByIdAsync(int id);

        Task<PdoDto> GetPdoDtoForUpdateAsync(PdoViewModel model);


    }
}
