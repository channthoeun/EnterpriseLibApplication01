using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnterpriseLibApplication01
{
    public partial class EmployeeByDepartment : System.Web.UI.Page
    {
        private const string connectionStringName = "WUSales";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDepartments();
            }
        }

        private void LoadEmployeeByDepartment(string department)
        {
            //This code is used to call stored procedure without parameter and bind gridview
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(connectionStringName);
            DataSet ds = new DataSet();

            try
            {
                ds = db.ExecuteDataSet("getEmployeeByDepartment", department);
                
                //DbCommand cm = db.GetStoredProcCommand("getEmployeeByDepartment");
                //                                     // getEmployeeByDepartment
                //db.AddInParameter(cm, "DepartmentName", DbType.String, department);
                //ds = db.ExecuteDataSet(cm);
                grvEmployee.DataSource = ds;
                grvEmployee.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void LoadDepartments()
        {
            //This code is used to call stored procedure without parameter and bind gridview
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db;
            // Database db = factory.Create("SalesMySql");
            db = factory.Create(connectionStringName);
            DataSet ds = new DataSet();

            try
            {
                ds = db.ExecuteDataSet("getDepartments");                
                ddlDepartment.DataSource = ds;
                ddlDepartment.DataValueField = "Department";
                ddlDepartment.DataTextField = "Department";

                ddlDepartment.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        protected void btnListEmployee_Click(object sender, EventArgs e)
        {
            //Response.Write("Department: " + ddlDepartment.Text);
            LoadEmployeeByDepartment(ddlDepartment.Text);
        }
    }
}