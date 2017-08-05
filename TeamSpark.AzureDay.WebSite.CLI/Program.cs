using System;
using System.Collections.Generic;
using System.IO;
using TeamSpark.AzureDay.WebSite.CLI.Data;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			//DataFactory.InitializeAsync().Wait();

			//Speaker.Add();
			//Timetable.Move();
			//SpeakerTopic.Add();
			//Partner.Add();
			//Timetable.Switch();
			//Coupon.Add();

			var emails = new List<string>();
			using (var file = new FileStream("C:\\Users\\aboyko\\Downloads\\azureday2016-registered.txt", FileMode.Open))
			{
				using (var reader = new StreamReader(file))
				{
					while (!reader.EndOfStream)
					{
						emails.Add(reader.ReadLine());
					}
				}
			}

			Coupon.Add(emails, DiscountType.Percentage, 10);


			//KaznacheyTest.Pay();

				Console.WriteLine("Press 'enter' to close.");
			Console.ReadLine();
		}
	}
}
