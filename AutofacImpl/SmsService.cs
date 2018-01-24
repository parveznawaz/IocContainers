using System;

namespace AutofacImpl
{
	public class SmsService : IMobileService
	{
		public void Execute()
		{
			Console.WriteLine("Executing Sms Service");
		}
	}
}
