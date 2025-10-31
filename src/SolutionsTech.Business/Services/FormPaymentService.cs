using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
    public class FormPaymentService : IFormPaymentService
    {
        private readonly IFormPaymentRepository _formPaymentRepository;
        public FormPaymentService(IFormPaymentRepository formPaymentRepository) => _formPaymentRepository = formPaymentRepository;
        public async Task CreateFormPayment(FormPayment formPayment)
        {
            formPayment.CreateFormPayment(formPayment);
            await _formPaymentRepository.AddAsync(formPayment);
        }

        public async Task UpdateFormPayment(FormPayment formPayment)
        {
            var formPaymentConsulting = await GetById(formPayment.IdFormPayment);
            await _formPaymentRepository.UpdateAsync(formPaymentConsulting);
        }

        public async Task DeleteFormPayment(long id)
        {
            await _formPaymentRepository.DeleteAsync(id);
        }
        public async Task<FormPayment> GetById(long id) =>
            await _formPaymentRepository.GetById(id);

        public async Task<List<FormPayment>> GetListIndex() =>
            await _formPaymentRepository.GetListRepository("");

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _formPaymentRepository.ExistsByNameAsync(name);
        }
    }
}
