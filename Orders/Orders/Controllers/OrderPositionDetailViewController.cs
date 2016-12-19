using System;
using UIKit;

using MonoTouch.Dialog;
using SQLite.Net;

namespace Orders
{
	public class OrderPositionDetailViewController: DialogViewController
	{
		public OrderPositionDetailViewController(OrderPosition position, SQLiteConnection database) : base(new RootElement("Details"),true)
		{
			Section section = new Section();

			EntryElement name = new EntryElement("Name: ","", position.Name);

			EntryElement price = new EntryElement("Price: ", "", position.Price.ToString());

			EntryElement amount = new EntryElement("Amount: ", "", position.Amount.ToString());

			StringElement deleteElement = new StringElement("Delete");

			deleteElement.Tapped += () =>
			{
				database.Delete(position);

				NavigationController.PopViewController(true);
			};

			section.Add(name);

			section.Add(price);

			section.Add(amount);

			section.Add(deleteElement);

			Root.Add(section);

			NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Save, (sender, args) =>
				{
					position.Name = name.Value;
					position.Price = Convert.ToInt32(price.Value);
					position.Amount = Convert.ToInt32(amount.Value);
					database.Update(position);
				}), true);

		}
	}
}

