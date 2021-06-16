using System;
using System.ComponentModel.DataAnnotations;

namespace DecimalChecker.Models
{
	public class DecimalNumber
	{
		private string input;
		[RegularExpression(@"^(-)?\d*([\.\,]\d+)?$")]
		public string Input 
		{ 
			get => input;
			set
			{
				input = value;

				if (input != null && Decimal.TryParse(input, out decimal dec))
				{
					ErrorMessage = string.Empty;
					Number = dec;
				}
				else
				{
					ErrorMessage = "Invalid number format";
					Number = default;
				}
			}
		}
		public decimal Number { get; set; }
		public string ErrorMessage { get; private set; }
	}
}
