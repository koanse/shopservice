using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShopClient.Properties;
using ShopClient.Service;
using ShopClient.ShopServiceReference;

namespace ShopClient
{
	public partial class MainForm : Form
	{
		private readonly ShopServiceClient serviceClient;
		private Dictionary<string, Item> dicItems;

		public MainForm()
		{
			InitializeComponent();

			serviceClient = new ShopServiceClient();
			dicItems = new Dictionary<string, Item>();

			wb.DocumentText = Resources.BasketIsEmpty;
			wb.IsWebBrowserContextMenuEnabled = false;
			lblTotalAmount.Text = 0.ToString(".00");
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				var itemCode = tbItemCode.Text;
				Item item;
				if (dicItems.TryGetValue(itemCode, out item))
				{
					MessageBox.Show($"The item '{itemCode}' has already been added to basket!", Resources.IncorrectItemCode);
					return;
				}

				item = serviceClient.GetItemData(itemCode);

				if (item == null)
				{
					MessageBox.Show($"The item '{itemCode}' does not exist!", Resources.IncorrectItemCode);
					return;
				}

				dicItems.Add(itemCode, item);

				var listItems = dicItems.Select(p => p.Value).ToList();

				var total = listItems.Sum(i => i.Price);
				lblTotalAmount.Text = total.ToString(".00");

				wb.Document.Body.InnerHtml = listItems.ToHtml();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error occured: {ex.Message}.", Resources.Error);
			}
		}

		private void btnBuy_Click(object sender, EventArgs e)
		{
			try
			{
				if (!dicItems.Any())
				{
					MessageBox.Show(Resources.BasketIsEmpty, Resources.Basket);
					return;
				}

				var listItems = dicItems.Select(p => p.Value).ToList();

				var content = listItems.SerializeToXml();

				serviceClient.SaveBasket(DateTime.Now, content);

				var totalAmountText = lblTotalAmount.Text;

				MessageBox.Show($"Done! Total amount was {totalAmountText}!", Resources.Basket);

				lblTotalAmount.Text = 0.ToString(".00");
				dicItems = new Dictionary<string, Item>();
				wb.Document.Body.InnerText = Resources.BasketIsEmpty;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error occured: {ex.Message}.", Resources.Error);
			}
		}
	}
}
