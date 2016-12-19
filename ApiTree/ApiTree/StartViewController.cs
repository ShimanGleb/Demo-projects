using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;

using MonoTouch.Dialog;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTree
{
	public class StartViewController : DialogViewController
	{
		public List<Uri> urls;

		private bool _loading;

		public StartViewController() : base(new RootElement("Available URLs"), true)
		{
			_loading = false;

			Style = UIKit.UITableViewStyle.Plain;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			PopulateUrlList();

			var section = new Section();

			foreach (Uri url in urls)
			{
				var element = new StringElement(url.ToString());

				element.Tapped += () =>
				{
					if (!_loading)
					{
						GetData(url);
					}
				};

				section.Add(element);
			}

			Root.Add(section);
		}

		public async void GetData(Uri source)
		{
			_loading = true;

			var loadingSection = new Section();
			var element = new StringElement("Now loading...");
			loadingSection.Add(element);
			Root.Insert(0,loadingSection);

			var client = new HttpClient();

			byte[] response = await client.GetByteArrayAsync(source);

			string data = Encoding.Default.GetString(response);
			JToken structure = null;

			try
			{
				structure = JToken.Parse(data);
			}
			catch
			{
				var doc = XDocument.Parse(data);

				data = JsonConvert.SerializeXNode(doc);

				structure = JToken.Parse(data);
			}
			NavigationController.PushViewController(new JsonViewController(structure), true);

			Root.RemoveAt(0);

			_loading = false;
		}

		public void PopulateUrlList()
		{
			urls = new List<Uri>();
			urls.Add(new Uri("http://api.geonames.org/postalCodeLookupJSON?postalcode=6600&country=AT&username=demo"));
			urls.Add(new Uri("http://apiv3.iucnredlist.org/api/v3/country/list?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee"));
			urls.Add(new Uri("http://apilayer.net/api/live?access_key=88ac736de70eaf00263ab52afe0de9b0&currencies=TWD&source=USD&format=1"));
			urls.Add(new Uri("http://jsonplaceholder.typicode.com/posts"));
			urls.Add(new Uri("https://freemusicarchive.org/api/get/curators.xml?api_key=60BLHNQCAOUFPIBZ"));
		}
	}
}

