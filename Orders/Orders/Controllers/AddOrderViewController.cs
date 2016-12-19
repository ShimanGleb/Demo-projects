using System;

using MonoTouch.Dialog;
using SQLite.Net;

namespace Orders
{
	public class AddOrderViewController : DialogViewController
	{
		public Order CurrentOrder;

		public SQLiteConnection Database;

		public AddOrderViewController(SQLiteConnection databse) : base(new RootElement("Add order"), true)
		{
			Database = databse;

			Root.UnevenRows = true;

			Section section = new Section();

			CurrentOrder = new Order();

			CreateAddOrderScreen(section);

			Root.Add(section);
		}

		public void CreateAddOrderScreen(Section section)
		{
			section.Clear();

			foreach (var position in CurrentOrder.Positions)
			{
				StringElement positionName = new StringElement(position.Name);

				section.Add(positionName);
			}

			StringElement addPositionElement = new StringElement("+Positions");

			addPositionElement.Tapped += () =>
			{
				CreateAddPositionScreen(section);
			};

			section.Add(addPositionElement);

			StringElement doneElement = new StringElement("Done");

			doneElement.Tapped += () =>
			{
				if (CurrentOrder.Positions.Count > 0)
				{
					CurrentOrder.Date = DateTime.Now;

					Database.Insert(CurrentOrder);

					int lastId = Database.ExecuteScalar<int>(@"select last_insert_rowid()");

					foreach (var position in CurrentOrder.Positions)
					{
						position.OrderId = lastId;
						Database.Insert(position);
					}

					NavigationController.PopViewController(true);
				}
			};

			section.Add(doneElement);
		}

		public void CreateAddPositionScreen(Section section)
		{
			section.Clear();

			EntryElement nameEntry = new EntryElement("Name", "", "");
			EntryElement priceEntry = new EntryElement("Price", "price per unit", "");
			EntryElement amountEntry = new EntryElement("Amount", "", "");

			StringElement doneButton = new StringElement("DONE");
			doneButton.Tapped += () =>
			{
				CurrentOrder.AddPostion(new OrderPosition(0, nameEntry.Value,
												  Convert.ToInt32(priceEntry.Value),
												  Convert.ToInt32(amountEntry.Value)));

				CreateAddOrderScreen(section);
			};

			section.Add(nameEntry);
			section.Add(priceEntry);
			section.Add(amountEntry);
			section.Add(doneButton);
		}
	}
}

