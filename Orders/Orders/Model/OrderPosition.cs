using SQLite.Net.Attributes;

namespace Orders
{
	[Table("OrderPosition")]
	public class OrderPosition
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public int OrderId { get; set; }

		public string Name { get; set; }

		public int Amount { get; set; }

		public int Price { get; set; }

		public OrderPosition()
		{
			
		}

		public OrderPosition(int id, string name, int price, int amount)
		{
			Id = id;
			Name = name;
			Price = price;
			Amount = amount;
		}
	}
}

