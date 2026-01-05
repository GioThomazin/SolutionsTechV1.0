using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Business.Validations;

namespace SolutionsTech.Business.Services
{
    public class FormPaymentService : BaseService, IFormPaymentService
    {
        private readonly IFormPaymentRepository _formPaymentRepository;
        public FormPaymentService(IFormPaymentRepository formPaymentRepository, INotificador notificador) : base(notificador) => _formPaymentRepository = formPaymentRepository;
       
        public async Task CreateFormPayment(FormPayment formPayment)
        {
            if(!ExecutarValidacao(new FormPaymentValidation(), formPayment))
                return;

            var existsFormPayment = await _formPaymentRepository.GetByName(formPayment.Name);
            
            if (existsFormPayment is not null)
            {
                Notificar($"Já existe uma forma de pagamento com este nome '{formPayment.Name}'");
                return;
			}
            await _formPaymentRepository.AddAsync(formPayment);
            return;
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
    }
}
