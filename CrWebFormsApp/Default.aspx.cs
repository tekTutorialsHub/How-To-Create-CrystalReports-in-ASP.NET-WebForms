using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CrWebFormsApp
{
    public partial class Default : System.Web.UI.Page
    {

        rptCustomerList rpt;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["report"] != null)
            {
                CrystalReportViewer.ReportSource = (rptCustomerList)Session["report"];

            }
        }

        protected void Show_Click(object sender, EventArgs e)
        {
            if (Session["report"] == null)
            {
                CustomerTableAdapters.CustomersTableAdapter da = new CustomerTableAdapters.CustomersTableAdapter();
                
                Customer ds = new Customer();
                Customer.CustomersDataTable dt=(Customer.CustomersDataTable) ds.Tables["Customers"];
                da.Fill(dt);
                
                rpt = new rptCustomerList();
                rpt.SetDataSource(ds);
                CrystalReportViewer.ReportSource = rpt;


                Session.Add("report", rpt);
            }


        }

    }
}