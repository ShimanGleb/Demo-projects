using System.Collections.Generic;
using System.Linq;

using MonoTouch.Dialog;
using Newtonsoft.Json.Linq;

namespace ApiTree
{
	public class JsonViewController : DialogViewController
	{
		public JsonViewController(JToken structure) : base(new RootElement("Observing object"), true)
		{
			Style = UIKit.UITableViewStyle.Plain;

			var section = new Section();

			var iterator = 0;

			if (structure.Type.ToString() == "Array")
			{
				structure = structure as JArray;

				foreach (JToken child in structure.Children())
				{
					StringElement childElement = new StringElement((iterator++).ToString());

					childElement.Tapped += () =>
					{
						NavigationController.PushViewController(new JsonViewController(structure.ElementAt(iterator - 1)), true);
					};

					section.Add(childElement);
				}
			}
			else
				foreach (JToken child in structure.Children())
				{
					StringElement childElement = null;
					List<string> keys = null;
					List<JToken> values = null;

				if (structure.Type.ToString()=="Object")
					{
						keys = (structure as JObject).Properties().Select(p => p.Name).ToList<string>();
						values = (structure as JObject).Properties().Select(p => p.Value).ToList<JToken>();
						if (child.ElementAt(0).Type.ToString() != "Object")
						{
							try
							{
								childElement = new StringElement(keys[iterator] + " : \"" + child.ElementAt(0).Value<string>() + "\"");
							}
							catch
							{
								childElement = new StringElement(keys[iterator]);
								JToken newSection = values[iterator];
								childElement.Tapped += () =>
								{
									NavigationController.PushViewController(new JsonViewController(newSection), true);
								};
							}
						}
						else
						{
							childElement = new StringElement(keys[iterator]);
							JToken newSection = values[iterator];

							childElement.Tapped += () =>
							{
								NavigationController.PushViewController(new JsonViewController(newSection), true);
							};
						}
					}

					section.Add(childElement);

					iterator++;
				}

			Root.Add(section);
		}
	}
}

