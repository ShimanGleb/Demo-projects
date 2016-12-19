using System;
using System.Collections.Generic;

using SQLite.Net.Attributes;

namespace Orders
{
	[Table("Order")]
	public class Order
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[Ignore]
		public List<OrderPosition> Positions { get; set; }

		public int TotalSum { get; set; }

		public DateTime Date { get; set; }

		public Order()
		{
			Date = new DateTime();

			Positions = new List<OrderPosition>();

			TotalSum = GetTotalSum();
		}

		public Order(List<OrderPosition> positions, DateTime date)
		{
			Date = date;
			TotalSum = GetTotalSum();
		}

		public void AddPostion(OrderPosition position)
		{
			Positions.Add(position);
			TotalSum += position.Price * position.Amount;
		}

		public int GetTotalSum()
		{
			int totalSum = 0;

			foreach (var position in Positions)
			{
				totalSum += position.Price * position.Amount;
			}

			return totalSum;
		}

	}
}

