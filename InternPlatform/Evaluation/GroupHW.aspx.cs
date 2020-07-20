using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternPlatform.Evaluation
{
    public partial class GroupHW : System.Web.UI.Page
    {
        string hobbies;
        protected void Page_Load(object sender, EventArgs e)
        {
            populateNationaltiyDdl();
        }

        protected void populateNationaltiyDdl()
        {
            //     here I create the code to access the database
            CRUD myCrud = new CRUD();
            string mySql = (@" select country_code, country_enName from Countries");
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlCountry.DataTextField = "country_enName";
            ddlCountry.DataValueField = "country_code";
            ddlCountry.DataSource = dr;
            ddlCountry.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string mySql = "insert into Intern (Fname,FnameA,country,Salary,Gender,Hobbies) " +
            "values (@fNameEn,@fNameAr,@country,@Salary,@Gender,@Hobbies)";   //
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@fNameEn", txtFnameEn.Text);
            myPara.Add("@fNameAr", txtFnameAr.Text);
            myPara.Add("@country", ddlCountry.SelectedValue);
            myPara.Add("@Salary", textSalary.Text);
            myPara.Add("@Gender", RadioButtonList1.SelectedValue);
            if (CheckBox1.Checked)
                hobbies = CheckBox1.Text;
            if (CheckBox2.Checked)
                hobbies += ", " + CheckBox2.Text;
            if (CheckBox1.Checked)
                hobbies += ", " + CheckBox1.Text;

            myPara.Add("@Hobbies", hobbies);

            CRUD myCrud = new CRUD();
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Success !"; }
            else
            { lblOutput.Text = "Failed !"; }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtInternId.Text = ""; txtFnameAr.Text = ""; txtFnameEn.Text = ""; textSalary.Text = "";
            RadioButtonList1.ClearSelection();
            if (CheckBox1.Checked)
            {
                CheckBox1.Checked = false;
            }
            else if (CheckBox2.Checked) { CheckBox2.Checked = false; } else if (CheckBox3.Checked) { CheckBox3.Checked = false; }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string mySql = @"update Intern set fname = @fNameEn, fnameA = @fNameAr,country=@country,Salary=@Salary,Gender=@Active,Hobbies=@Hobbies
                                    where internid = @internId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", int.Parse(txtInternId.Text));  // demo for conversion 
            myPara.Add("@fNameEn", txtFnameEn.Text);  // demo for conversion 
            myPara.Add("@fNameAr", txtFnameAr.Text);  // demo for conversion 
            myPara.Add("@country", ddlCountry.SelectedValue);
            myPara.Add("@Salary", textSalary.Text);
            myPara.Add("@Active", RadioButtonList1.SelectedValue);

            if (CheckBox1.Checked)
            hobbies = CheckBox1.Text;
            if (CheckBox2.Checked)
                hobbies += ", "+CheckBox2.Text;
            if (CheckBox1.Checked)
                hobbies += ", " + CheckBox1.Text;

            myPara.Add("@Hobbies", hobbies);


            CRUD myCrud = new CRUD();
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Success !"; }
            else
            { lblOutput.Text = "Failed !"; }

            showAllInterns();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // I need to insert a new data to the database
            string mySql = "delete Intern where InternID = @internId ";   //
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", int.Parse(txtInternId.Text));  // demo for conversion 

            CRUD myCrud = new CRUD();
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Success !"; }
            else
            { lblOutput.Text = "Failed !"; }
            showAllInterns();
        }

        protected void btnShowData_Click(object sender, EventArgs e)
        {
            showAllInterns();
        }
        protected void showAllInterns()
        {
            string mySql = @" SELECT * FROM Intern; ";
            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(mySql);

            gvIntern.DataSource = dr;
            gvIntern.DataBind();

        }

        protected void showInterPerId(int myInternId)
        {
            string mySql = @" select InternID,	fname,fnameA,country_code ,Salary,Gender,Hobbies from Intern
                               where InternID = @internId";   //
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", myInternId);  // demo for conversion 

            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);

            gvIntern.DataSource = dr;
            gvIntern.DataBind();

        }

        protected void btnShowIntern_Click(object sender, EventArgs e)
        {
            if (txtInternId.Text == "")
            {
                lblOutput.Text = " Please enter intern Id !";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                return;
            }
            int myInternId = int.Parse(txtInternId.Text);
            showInterPerId(myInternId);
        }
   
    }
}
