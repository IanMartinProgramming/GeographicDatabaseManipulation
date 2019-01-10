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
	public partial class AddTown : System.Web.UI.Page
	{

		A3DataSetTableAdapters.ContinentsTableAdapter adpContinents = new A3DataSetTableAdapters.ContinentsTableAdapter();
		A3DataSet.ContinentsDataTable tblContinents = new A3DataSet.ContinentsDataTable();

		A3DataSetTableAdapters.CountriesTableAdapter adpCountries = new A3DataSetTableAdapters.CountriesTableAdapter();
		A3DataSet.CountriesDataTable tblCountries = new A3DataSet.CountriesDataTable();

		string cs = Data.GetConnectionString("csAssignment3");
		string query = "SELECT * FROM Towns";

		SqlConnection conn;
		SqlDataAdapter dataAdapter;
		DataSet ds;
		SqlCommandBuilder cmdBuilder;
		DataTable tblTowns;

		public AddTown()
		{
			conn = new SqlConnection(cs);
			dataAdapter = new SqlDataAdapter(query, conn);
			ds = new DataSet();
			cmdBuilder = new SqlCommandBuilder(dataAdapter);
		}

		private void CacheTable()
		{
			dataAdapter.Fill(ds, "Towns");
			tblTowns = ds.Tables["Towns"];

			// Assign primary key before caching
			DataColumn[] pk = new DataColumn[1];
			pk[0] = tblTowns.Columns["TownID"];
			tblTowns.PrimaryKey = pk;

			Cache["tblTowns"] = tblTowns;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				tblContinents = adpContinents.GetContinents();

				ddlContinents.DataSource = tblContinents;
				ddlContinents.DataTextField = tblContinents.ContinentNameColumn.ToString();
				ddlContinents.DataValueField = tblContinents.ContinentIDColumn.ToString();
				ddlContinents.DataBind();

				ddlContinents.Items.Insert(0, "Select a Continent");
				ddlCountries.Items.Insert(0, "Select a Country");
				ddlCountries.Enabled = false;
			}
		}

		protected void ddlContinents_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlContinents.SelectedIndex > 0)
			{
				int continentID = int.Parse(ddlContinents.SelectedValue);

				tblCountries = adpCountries.GetCountriesByContinentID(continentID);

				ddlCountries.DataSource = tblCountries;
				ddlCountries.DataTextField = tblCountries.CountryNameColumn.ToString();
				ddlCountries.DataValueField = tblCountries.CountryIDColumn.ToString();
				ddlCountries.DataBind();

				ddlCountries.Items.Insert(0, "Select a Country");
				ddlCountries.Enabled = true;
			} else
			{
				ddlCountries.SelectedIndex = 0;
				ddlCountries.Enabled = false;
			}
		}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			if (Cache["tblTowns"] == null)
			{
				CacheTable();
			}

			tblTowns = (DataTable)Cache["tblTowns"];

			DataRow newRow = tblTowns.NewRow();

			newRow["TownID"] = 0;
			newRow["CountryID"] = ddlCountries.SelectedValue;
			newRow["TownName"] = txtTownName.Text;
			newRow["TownPopulation"] = int.Parse(txtPopulation.Text);

			tblTowns.Rows.Add(newRow);

			dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
			int rowsAffected = dataAdapter.Update(tblTowns);

			if(rowsAffected == 1)
				lblMessage.Text = "Data added to Towns Table";
			else
				lblMessage.Text = "Entry Failed";
		}
	}
}