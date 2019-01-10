using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace A3IanMartin
{
	public partial class Home : System.Web.UI.Page
	{
		A3DataSetTableAdapters.ContinentsTableAdapter adpContinents = new A3DataSetTableAdapters.ContinentsTableAdapter();
		A3DataSet.ContinentsDataTable tblContinents = new A3DataSet.ContinentsDataTable();

		A3DataSetTableAdapters.CountriesTableAdapter adpCountries = new A3DataSetTableAdapters.CountriesTableAdapter();
		A3DataSet.CountriesDataTable tblCountries = new A3DataSet.CountriesDataTable();

		A3DataSetTableAdapters.TownsTableAdapter adpTowns = new A3DataSetTableAdapters.TownsTableAdapter();
		A3DataSet.TownsDataTable tblTowns = new A3DataSet.TownsDataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				tblContinents = adpContinents.GetContinents();

				lstContinents.DataSource = tblContinents;
				lstContinents.DataTextField = tblContinents.ContinentNameColumn.ToString();
				lstContinents.DataValueField = tblContinents.ContinentIDColumn.ToString();
				lstContinents.DataBind();

				ddlCountries.Items.Add("Select a Country");
				ddlCountries.Enabled = false;
			}
		}

		protected void lstContinents_SelectedIndexChanged(object sender, EventArgs e)
		{
			int continentID = int.Parse(lstContinents.SelectedValue);

			tblCountries = adpCountries.GetCountriesByContinentID(continentID);

			ddlCountries.DataSource = tblCountries;
			ddlCountries.DataTextField = tblCountries.CountryNameColumn.ToString();
			ddlCountries.DataValueField = tblCountries.CountryIDColumn.ToString();
			ddlCountries.DataBind();

			ddlCountries.Items.Insert(0, "Select a Country");
			ddlCountries.Enabled = true;

			imgFlag.ImageUrl = "";
			lblLanguage.Text = "";
			grdTowns.DataSource = null;
			grdTowns.DataBind();
		}

		protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlCountries.SelectedIndex == 0)
			{
				imgFlag.ImageUrl = "";
				lblLanguage.Text = "";
				grdTowns.DataSource = null;
				grdTowns.DataBind();
			} else { 
				int countryID = int.Parse(ddlCountries.SelectedValue);

				lblLanguage.Text = adpCountries.GetLanguage(countryID).ToString();
				imgFlag.ImageUrl = "images/" + adpCountries.GetFlag(countryID).ToString().Trim();

				tblTowns = adpTowns.GetTownsByCountryID(countryID);
				grdTowns.DataSource = tblTowns;
				grdTowns.DataBind();
			}
		}
	}
}