using SolutionsTech.Business.Entities;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;
using System;

namespace SolutionsTech.Data.EntitiesFixed
{
	public static class FixedFieldsSchedulingStatus
	{
		public static void Initialize(ApplicationDbContext context)
		{
			// Inserir apenas se não houver dados ainda
			if (!context.AppointmentStatus.Any())
			{
				context.Scheduling.AddRange(
					new AppointmentStatus { Name = Pending, DtCreate = DateTime.Now, Active = true },
					new AppointmentStatus { Name = Confirmed, DtCreate = DateTime.Now, Active = true },
					new AppointmentStatus { Name = InProgress, DtCreate = DateTime.Now, Active = true },
					new AppointmentStatus { Name = Completed, DtCreate = DateTime.Now, Active = true },
					new AppointmentStatus { Name = CanceledClient, DtCreate = DateTime.Now, Active = true },
					new AppointmentStatus { Name = CanceledStudio, DtCreate = DateTime.Now, Active = true },
					new AppointmentStatus { Name = NotAttended, DtCreate = DateTime.Now, Active = true },
					new AppointmentStatus { Name = Rescheduled, DtCreate = DateTime.Now, Active = true },
					new AppointmentStatus { Name = WaitingForPayment, DtCreate = DateTime.Now, Active = true },
					new AppointmentStatus { Name = Paid, DtCreate = DateTime.Now, Active = true }
				);

				context.SaveChanges();
			}
		}

		public static string Pending => "Pendente";
		public static string Confirmed => "Confirmado";
		public static string InProgress => "Em andamento";
		public static string Completed => "Concluído";
		public static string CanceledClient => "Cancelado pelo cliente";
		public static string CanceledStudio => "Cancelado pelo estúdio";
		public static string NotAttended => "Não compareceu";
		public static string Rescheduled => "Reagendado";
		public static string WaitingForPayment => "Aguardando pagamento";
		public static string Paid => "Pago";
	}
}
