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
		public async Task<List<FormPayment>> GetListIndex() =>
			await _formPaymentRepository.GetListRepository("");
	}
}
