using System;

namespace AutofacImpl
{
	public class EmailSevice : IMailService
	{
		public void Execute()
		{
			Console.WriteLine("Executing Email Service");
		}
	}
}
