using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace A3IanMartin
{
	public partial class AddCountry : System.Web.UI.Page
	{
		A3DataSetTableAdapters.ContinentsTableAdapter adpContinents = new A3DataSetTableAdapters.ContinentsTableAdapter();
		A3DataSet.ContinentsDataTable tblContinents = new A3DataSet.ContinentsDataTable();

		string cs = Data.GetConnectionString("csAssignment3");
		string query = "SELECT * FROM Countries";

		SqlConnection conn;
		SqlDataAdapter dataAdapter;
		DataSet ds;
		SqlCommandBuilder cmdBuilder;
		DataTable tblCountries;

		public AddCountry()
		{
			conn = new SqlConnection(cs);
			dataAdapter = new SqlDataAdapter(query, conn);
			ds = new DataSet();
			cmdBuilder = new SqlCommandBuilder(dataAdapter);
		}

		private void CacheTable()
		{
			dataAdapter.Fill(ds, "Countries");
			tblCountries = ds.Tables["Countries"];

			// Assign primary key before caching
			DataColumn[] pk = new DataColumn[1];
			pk[0] = tblCountries.Columns["CountryID"];
			tblCountries.PrimaryKey = pk;

			Cache["tblCountries"] = tblCountries;
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
			}
		}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			string fileName;
			fileName = uploadFlag.FileName;

			if (Path.GetExtension(fileName).ToLower() == ".jpg" || 
				Path.GetExtension(fileName).ToLower() == ".png")
			{
				uploadFlag.SaveAs(Server.MapPath("~/images/") + fileName);
			}	

			if (Cache["tblCountries"] == null)
			{
				CacheTable();
			}

			tblCountries = (DataTable)Cache["tblCountries"];

			DataRow newRow = tblCountries.NewRow();

			newRow["CountryID"] = 0;
			newRow["ContinentID"] = ddlContinents.SelectedValue;
			newRow["CountryName"] = txtCountry.Text;
			newRow["CountryFlag"] = fileName;
			newRow["CountryLanguage"] = txtLanguage.Text;

			tblCountries.Rows.Add(newRow);

			dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
			int rowsAffected = dataAdapter.Update(tblCountries);

			if(rowsAffected == 1)
				lblMessage.Text = "Data added to Country Table";
			else
				lblMessage.Text = "Entry Failed";
		}
	}
}