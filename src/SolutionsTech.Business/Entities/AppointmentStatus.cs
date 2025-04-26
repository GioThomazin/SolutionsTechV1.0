using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsTech.Business.Entities
{
   public class AppointmentStatus
	{
		[Key]
		public long IdAppointmentStatus { get; set; }
		public string Name { get; set; }
		public DateTime DtCreate { get; set; } = DateTime.Now;
		public DateTime? DtDesativation { get; set; }
		public bool Active { get; set; } = true;
	}
}
