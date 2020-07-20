using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InternPlatform.Evaluation
{
    public partial class EvaluationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateNationaltiyDdl();
        }

        protected void ToTrainInfo_Click(object sender, EventArgs e)
        {
            string mySql = "BEGIN TRANSACTION " +
                           "DECLARE @DataID int;" +
                           "INSERT INTO Intern(Fname,FathName,GFName,Lname,DoB,Gender) VALUES(@first,@father,@grand,@last,@DoB,@Gender);" +
                           "SELECT @DataID = scope_identity();" +
                           "INSERT INTO ID_Doc(InternID,ID,Type,country_code,issueDate) VALUES(@DataID,@ID,@Type,@country_code,@issueDate);" +
                           "COMMIT";

          
            Dictionary<string, object> myPara = new Dictionary<string, object>();

            myPara.Add("@first", Name.Text);
            myPara.Add("@father", Father.Text);
            myPara.Add("@grand", Grand.Text);
            myPara.Add("@last", Last.Text);
            myPara.Add("@DoB", Dob.Text);
            myPara.Add("@Gender", Gender.SelectedValue);
            myPara.Add("@ID",IDNo.Text);
            myPara.Add("@Type",Type.Text);
            myPara.Add("@country_code", DdlNation.SelectedValue);
            myPara.Add("@issueDate",IssueDate.Text);

            CRUD myCrud = new CRUD();
            try {
                myCrud.InsertUpdateDelete(mySql, myPara);
            }catch(Exception ex)
            {
                Literal1.Text = ("Error: " + ex);
            }

            Response.Redirect("/Evaluation/Training_info");
        }

        protected void populateNationaltiyDdl()
        {
            //     here I create the code to access the database
            CRUD myCrud = new CRUD();
            string mySql = (@" select country_code, country_enNationality from Countries");
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            DdlNation.DataTextField = "country_enNationality";
            DdlNation.DataValueField = "country_code";
            DdlNation.DataSource = dr;
            DdlNation.DataBind();
        }
    }
}