using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnterpriseLibApplication01
{
    public partial class UsingSqlStatement : System.Web.UI.Page
    {
        String[] headers = { "ID", "FirstName", "LastName", "Gender", "DateOfBirth", "Department" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadEmployee();
            }
        }

        private void LoadEmployee()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db;
            // db = factory.CreateDefault();
            // db = factory.Create("SalesMsAccess");  
            db = factory.Create("SalesMsAccess");  
            
            DataSet ds = new DataSet();
            String sql = "SELECT * From Employees";
            try
            {
                IDataReader dr = db.ExecuteReader(CommandType.Text, sql);
                ShowEmployeeTable(tblSale, dr);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void ShowEmployeeTable(Table sale, IDataReader dr)
        {            
            AddTableHeader(sale, headers);
            DisplayRowValues(sale, dr);
        }

        private void AddTableHeader(Table tbl, String [] headers)
        {            
            TableHeaderRow r = new TableHeaderRow();;
            TableHeaderCell c;
            for (int i = 0; i < headers.Length; i++)
            {                
                c = new TableHeaderCell();
                c.Text = headers[i];
                r.Cells.Add(c);
            }
            tbl.Rows.Add(r);
        }

        void DisplayRowValues(Table t, IDataReader reader)
        {
            TableRow r;
            TableCell c;
            while (reader.Read())
            {
                r = new TableRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    c = new TableCell();
                    c.Text = reader[i].ToString();
                    r.Cells.Add(c);
                }
                t.Rows.Add(r);
            }
        }
    }
}