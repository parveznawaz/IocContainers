namespace AutofacImpl
{
	public class NotificationSender: INotificationSender
	{
		private IMobileService mobileService = null;
		private IMailService mailService = null;
		public NotificationSender(IMobileService _mobileService, IMailService _mailService)
		{
			mobileService = _mobileService;
			mailService = _mailService;
		}

		public void SendMail()
		{
			mailService.Execute();
		}
		
		public void SendSms()
		{
			mobileService.Execute();
		}
	}
}
