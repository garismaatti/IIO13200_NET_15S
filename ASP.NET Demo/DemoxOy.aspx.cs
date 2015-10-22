using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DemoxOy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ladataan asiaakkaan siedot
        //täytetään gridview 
        //GetDemoData();
        GetRealData();
    }

    protected void GetDemoData()
    {
        DataTable dt = JAMK.IT.DBDemoxOy.GetDataSimple();
        gvCustomers.DataSource = dt;
        gvCustomers.DataBind();
    }

    protected void GetRealData()
    {
        try {
            DataTable dt = JAMK.IT.DBDemoxOy.GetDataReal( System.Configuration.ConfigurationManager.ConnectionStrings["Ilmot"].ConnectionString );
            gvCustomers.DataSource = dt;
            gvCustomers.DataBind();
        }
        catch (Exception ex)
        {
            //Error
            //throw;
            lblNotes.Text = ex.Message;
        }
    }
}