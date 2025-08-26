using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface IFormPaymentService
    {
		Task CreateFormPayment(Entity.FormPayment formPayment);
		Task<List<FormPayment>> GetListIndex();
	}
}
