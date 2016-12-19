using System;
using System.Collections.Generic;
using UIKit;

using MonoTouch.Dialog;
using SQLite.Net;

namespace Orders
{
	public class OrderPositionListViewController : DialogViewController
	{
		public List<OrderPosition> Positions;

		public SQLiteConnection Database;

		public int OrderId;

		public OrderPositionListViewController(int orderId, SQLiteConnection database) : base(new RootElement("Ordered stuff"), true)
		{
			NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, args) =>
				{
					CreateAddPositionScreen();
				}), true);

			OrderId = orderId;

			Database = database;
		}

		public void RefreshPositions()
		{
			Positions = new List<OrderPosition>();

			var positions = Database.Table<OrderPosition>().Where(p => p.OrderId == OrderId);

			foreach (var position in positions)
			{
				Positions.Add(position);
			}
		}

		public void ShowPositions()
		{
			Root.Clear();

			Section section = new Section();

			RefreshPositions();

			foreach (var position in Positions)
			{
				StringElement nameElement = new StringElement(position.Name);

				nameElement.Tapped += () =>
				{
					NavigationController.PushViewController(new OrderPositionDetailViewController(position, Database), true);
				};

				section.Add(nameElement);
			}

			Root.Add(section);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			ShowPositions();
		}

		public void CreateAddPositionScreen()
		{
			Section section = new Section();

			EntryElement nameEntry = new EntryElement("Name", "", "");
			EntryElement priceEntry = new EntryElement("Price", "price per unit", "");
			EntryElement amountEntry = new EntryElement("Amount", "", "");

			StringElement doneButton = new StringElement("DONE");
			doneButton.Tapped += () =>
			{
				var newPosition = new OrderPosition(0, nameEntry.Value,
												  Convert.ToInt32(priceEntry.Value),
													Convert.ToInt32(amountEntry.Value));

				newPosition.OrderId = OrderId;

				Database.Insert(newPosition);

				Positions.Add(newPosition);

				ShowPositions();
			};

			section.Add(nameEntry);
			section.Add(priceEntry);
			section.Add(amountEntry);
			section.Add(doneButton);

			Root.Add(section);
		}
	}
}

