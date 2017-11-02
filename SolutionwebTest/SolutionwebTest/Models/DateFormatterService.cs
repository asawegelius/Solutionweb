using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionwebTest.Models
{
    public class DateFormatterService
    {
		public string DateString(DateTime date)
		{
			return date.ToString("d");
		}
    }
}
