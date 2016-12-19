using UIKit;

using MonoTouch.Dialog;
using SQLite.Net;

namespace Orders
{
	public class OrderDetailViewController : DialogViewController
	{
		public Order Order;

		public SQLiteConnection Database;

		public bool confirming = false;

		public OrderDetailViewController(Order order, SQLiteConnection database) : base(new RootElement("Order details"),true)
		{
			Order = order;
			Database = database;

			NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Save, (sender, args) =>
				{
					Database.Update(Order);
				}), true);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			Root.Clear();

			Section section = new Section();

			StringElement idElement = new StringElement("Id: " + Order.Id);

			var mapTable = Database.Table<OrderPosition>();

			var positionIds = mapTable.Where(p => p.OrderId == Order.Id);

			Order.Positions.Clear();

			foreach (var position in positionIds)
			{
				Order.Positions.Add(position);
			}

			StringElement totalSumElement = new StringElement("Total sum: " + Order.GetTotalSum());

			DateTimeElement dateElement = new DateTimeElement("Date: ", Order.Date);

			dateElement.DateSelected += (obj) =>
			{
				Order.Date = dateElement.DateValue;
			};

			StringElement positionsElement = new StringElement("See positions");

			positionsElement.Tapped += () =>
			{
				NavigationController.PushViewController(new OrderPositionListViewController(Order.Id, Database), true);
			};

			StringElement deleteElement = new StringElement("Delete");

			deleteElement.Tapped += () =>
			{
				if (!confirming)
				{
					confirming = true;

					Section confirmSection = new Section();

					StringElement confirmElement = new StringElement("Are you sure?");

					confirmElement.Alignment = UIKit.UITextAlignment.Center;

					confirmSection.Add(confirmElement);

					StringElement yesButton = new StringElement("Yes");

					yesButton.Alignment = UIKit.UITextAlignment.Center;

					yesButton.Tapped += () =>
					{
						Database.Execute(@"delete from OrderPosition where OrderId==" + Order.Id);

						Database.Delete(Order);

						NavigationController.PopViewController(true);
					};

					confirmSection.Add(yesButton);

					StringElement noButton = new StringElement("No");

					noButton.Alignment = UIKit.UITextAlignment.Center;

					noButton.Tapped += () =>
					{
						confirming = false;

						Root.Remove(confirmSection);
					};

					confirmSection.Add(noButton);

					Root.Add(confirmSection);
				}
			};

			section.Add(idElement);

			section.Add(totalSumElement);

			section.Add(dateElement);

			section.Add(positionsElement);

			section.Add(deleteElement);

			Root.Add(section);
		}
	}
}

