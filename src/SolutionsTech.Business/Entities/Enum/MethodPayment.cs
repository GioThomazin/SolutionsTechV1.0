using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsTech.Business.Entities.Enum
{
    public enum MethodPaymentEnum
    {
			[Description("Débito")]
			Debito = 1,

			[Description("Crédito")]
			Credito = 2,

			[Description("PIX")]
			Pix = 3,

			[Description("Dinheiro")]
			Dinheiro = 4
	}
}
