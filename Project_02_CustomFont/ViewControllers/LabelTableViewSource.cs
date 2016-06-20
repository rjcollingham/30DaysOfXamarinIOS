using System;
using Foundation;
using UIKit;

namespace Project_02_CustomFont
{
	public class LabelTableViewSource : UITableViewSource
	{
		string[] Items;
		string[] Fonts;
		int FontIndex = 0;
		string CellIdentifier = "LabelTable";

		public LabelTableViewSource(string[] items, string[] fonts)
		{
			Items = items;
			Fonts = fonts;
		}

		public int ChangeFont()
		{
			FontIndex = (FontIndex + 1) % Fonts.Length;
			return FontIndex;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
			}

			string item = Items[indexPath.Row];

			cell.TextLabel.Text = item;
			cell.TextLabel.TextColor = UIColor.White;
			cell.BackgroundColor = UIColor.Black;
			cell.TextLabel.Font = UIFont.FromName(Fonts[FontIndex], 16);

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return Items.Length;
		}
	}
}

