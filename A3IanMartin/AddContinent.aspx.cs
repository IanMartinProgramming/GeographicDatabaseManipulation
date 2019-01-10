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
	public partial class AddContinent : System.Web.UI.Page
	{
		string cs = Data.GetConnectionString("csAssignment3");
		string query = "SELECT * FROM Continents";

		SqlConnection conn;
		SqlDataAdapter dataAdapter;
		DataSet ds;
		SqlCommandBuilder cmdBuilder;
		DataTable tblContinents;

		public AddContinent()
		{
			conn = new SqlConnection(cs);
			dataAdapter = new SqlDataAdapter(query, conn);
			ds = new DataSet();
			cmdBuilder = new SqlCommandBuilder(dataAdapter);
		}

		private void CacheTable()
		{
			dataAdapter.Fill(ds, "Continents");
			tblContinents = ds.Tables["Continents"];

			// Assign primary key before caching
			DataColumn[] pk = new DataColumn[1];
			pk[0] = tblContinents.Columns["ContinentID"];
			tblContinents.PrimaryKey = pk;

			Cache["tblContinents"] = tblContinents;
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			if (Cache["tblContinents"] == null)
			{
				CacheTable();
			}

			tblContinents = (DataTable)Cache["tblContinents"];

			DataRow newRow = tblContinents.NewRow();

			newRow["ContinentID"] = 0;
			newRow["ContinentName"] = txtContinent.Text;

			tblContinents.Rows.Add(newRow);

			dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
			int rowsAffected = dataAdapter.Update(tblContinents);

			if (rowsAffected == 1)
				lblMessage.Text = "Data added to Continent Table";
			else
				lblMessage.Text = "Entry Failed";

		}
	}
}