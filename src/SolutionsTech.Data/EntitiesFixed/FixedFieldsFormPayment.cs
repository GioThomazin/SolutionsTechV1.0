using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.EntitiesFixed
{
   public class FixedFieldsFormPayment
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new ApplicationDbContext(
				serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
			{
				if (context.FormPayment.Any())
				{
					return; // Já existem dados, não faz nada
				}

				context.FormPayment.AddRange(
					new FormPayment { Name = "Débito", DtCreate = DateTime.Now, Active = true },
					new FormPayment { Name = "Crédito", DtCreate = DateTime.Now, Active = true },
					new FormPayment { Name = "PIX", DtCreate = DateTime.Now, Active = true },
					new FormPayment { Name = "Dinheiro", DtCreate = DateTime.Now, Active = true },
					new FormPayment { Name = "Pendente", DtCreate = DateTime.Now, Active = true }
				);
				context.SaveChanges();
			}
		}
	}
}
