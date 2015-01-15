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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadEmployee();
            }
        }

        private void LoadEmployee()
        {
            //This code is used to call stored procedure without parameter and bind gridview
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database objDataBase = factory.CreateDefault();
            DataSet ds = new DataSet();

            try
            {
                ds = objDataBase.ExecuteDataSet("uspGetEmployees");

                grvEmployee.DataSource = ds;
                grvEmployee.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}