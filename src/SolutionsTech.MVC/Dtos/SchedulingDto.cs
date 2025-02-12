﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class SchedulingDto
	{
		public long IdScheduling { get; set; }
		public string Name { get; set; }
		public DateTime DtCreate { get; set; } = DateTime.Now;
		public decimal TotalValue { get; set; }
		public string Observation { get; set; }
		public long IdUser { get; set; }
		public long IdFormPayment { get; set; }
	}
}
