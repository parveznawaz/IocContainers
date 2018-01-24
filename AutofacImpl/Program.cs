using Autofac;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Ninject;
using System;
using Unity;

namespace AutofacImpl
{
	class Program
	{
		static void Main(string[] args)
		{
			//Autofac container
			var autofacBuilder = new ContainerBuilder();
			autofacBuilder.RegisterType<SmsService>().As<IMobileService>();
			autofacBuilder.RegisterType<EmailSevice>().As<IMailService>();
			autofacBuilder.RegisterType<NotificationSender>().As<INotificationSender>();
			var autofacContainer = autofacBuilder.Build();
			var autofactNotificationSender = autofacContainer.Resolve<INotificationSender>();
			autofactNotificationSender.SendMail();
			autofactNotificationSender.SendSms();

			//Unity container
			var unitycontainer = new UnityContainer();
			unitycontainer.RegisterType<IMobileService, SmsService>();
			unitycontainer.RegisterType<IMailService, EmailSevice>();
			unitycontainer.RegisterType<INotificationSender, NotificationSender>();
			var unityNotificationSender = unitycontainer.Resolve<INotificationSender>();
			unityNotificationSender.SendMail();
			unityNotificationSender.SendSms();


			//Ninject container
			var kernel = new StandardKernel();
			kernel.Bind<IMobileService>().To<SmsService>();
			kernel.Bind<IMailService>().To<EmailSevice>();
			kernel.Bind<INotificationSender>().To<NotificationSender>();
			var ninjectNotificationSender=kernel.Get<INotificationSender>();
			ninjectNotificationSender.SendMail();
			ninjectNotificationSender.SendSms();
			
			//windsor container
			var windsorContainer = new WindsorContainer();
			windsorContainer.Register(new IRegistration[] {
				Component.For<INotificationSender>().ImplementedBy<NotificationSender>(),
				Component.For<IMailService>().ImplementedBy<EmailSevice>(),
				Component.For<IMobileService>().ImplementedBy<SmsService>()
			});
			var windsorNotificationSender = windsorContainer.Resolve<INotificationSender>();
			windsorNotificationSender.SendMail();
			windsorNotificationSender.SendSms();
			Console.ReadKey();
		}
	}
}
