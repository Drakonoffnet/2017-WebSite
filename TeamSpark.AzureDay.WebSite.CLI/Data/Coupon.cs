using System;
using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class Coupon
	{
		internal static void Add()
		{
			Console.WriteLine("Add coupon");
			var coupon = new WebSite.Data.Entity.Table.Coupon
			{
				IsEnabled = true
			};

			Console.Write("Code: ");
			coupon.Code = Console.ReadLine().ToLowerInvariant();

			Console.WriteLine("Discount type:");
			foreach (DiscountType discountType in Enum.GetValues(typeof(DiscountType)))
			{
				Console.WriteLine("{0} {1}", (int)discountType, discountType);
			}
			coupon.DiscountTypeId = int.Parse(Console.ReadLine());

			Console.Write("Discount amount: ");
			coupon.DiscountAmountValue = float.Parse(Console.ReadLine());

			Console.Write("Is infinite: ");
			coupon.IsInfinite = bool.Parse(Console.ReadLine());

			if (!coupon.IsInfinite)
			{
				Console.Write("Count: ");
				coupon.CouponsCount = int.Parse(Console.ReadLine());
			}

			Console.WriteLine("Working...");
			DataFactory.CouponService.Value.InsertAsync(coupon).Wait();
			Console.WriteLine("Done.");
		}

		internal static void Add(List<string> emails, DiscountType discountType, decimal discountAmount)
		{
			foreach (var email in emails)
			{
				var couponTask = DataFactory.CouponService.Value.GetByKeysAsync(Configuration.Year, email);
				couponTask.Wait();
				var couponOld = couponTask.Result;

				var coupon = new WebSite.Data.Entity.Table.Coupon
				{
					IsEnabled = true,
					DiscountType = discountType,
					DiscountAmount = discountAmount,
					Code = email.ToLowerInvariant(),
					IsInfinite = false,
					CouponsCount = 2
				};

				if (couponOld == null)
				{
					DataFactory.CouponService.Value.InsertAsync(coupon).Wait();
				}
				else
				{
					if (coupon.DiscountType == couponOld.DiscountType)
					{
						if (coupon.DiscountAmount > couponOld.DiscountAmount)
						{
							DataFactory.CouponService.Value.ReplaceAsync(coupon).Wait();
						}
					}
				}
			}
		}
	}
}
