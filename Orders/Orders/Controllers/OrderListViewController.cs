using System;
using System.Collections.Generic;
using System.IO;
using UIKit;

using MonoTouch.Dialog;
using SQLite.Net;

namespace Orders
{
	public class OrderListViewController : DialogViewController
	{
		public List<Order> orders;

		public SQLiteConnection database;

		public OrderListViewController() : base(new RootElement("Order list"), true)
		{
			orders = new List<Order>();

			Style = UITableViewStyle.Plain;

			NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, args) =>
				{
					NavigationController.PushViewController(new AddOrderViewController(database), true);
				}), true);

			string dbPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
					"orders.db3");

			var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			database = new SQLiteConnection(platform, dbPath);

			database.CreateTable<Order>();

			database.CreateTable<OrderPosition>();

			UpdateList();
		}

		public override void ViewWillAppear(bool animated)
		{
			UpdateList();
		}

		public void UpdateList()
		{
			Root.Clear();

			orders.Clear();

			if (database.Table<Order>().Count() > 0)
			{
				var table = database.Table<Order>();

				foreach (var order in table)
				{
					orders.Add(order);

					var mapTable = database.Table<OrderPosition>();

					var positionIds = mapTable.Where(p => p.OrderId == order.Id);

					foreach (var position in positionIds)
					{
						orders[orders.Count-1].Positions.Add(position);
					}
				}
			}

			foreach (var order in orders)
			{
				Section section = new Section();

				StringElement idElement = new StringElement("Order ID: " + order.Id);

				idElement.Tapped += () =>
				{
					NavigationController.PushViewController(new OrderDetailViewController(order, database), true);
				};

				section.Add(idElement);

				Root.Add(section);
			}
		}
	}
}

