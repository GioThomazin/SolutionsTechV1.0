using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface IFormPaymentService
    {
        Task CreateFormPayment(FormPayment formPayment);
        Task UpdateFormPayment(FormPayment formPayment);
        Task DeleteFormPayment(long id);
        Task<FormPayment> GetById(long id);
        Task<List<FormPayment>> GetListIndex();
        Task<bool> ExistsByNameAsync(string name);
    }
}
