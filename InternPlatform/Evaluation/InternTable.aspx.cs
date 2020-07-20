using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace InternPlatform.Evaluation
{
    public partial class InternTable : System.Web.UI.Page
    {
        private CRUD myCrud = new CRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            string mySql = "SELECT Intern.InternID, Intern.Fname, Intern.Lname, InternContact.Email FROM Intern INNER JOIN InternContact ON InternContact.InternID=Intern.InternID;";
            var sda = myCrud.dataAdapt(mySql);

            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                GV.DataSource = dt;
                GV.DataBind();

                if (dt.Rows.Count > 0)
                {
                    GV.DataSource = dt;
                    GV.DataBind();
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GV.DataSource = dt;
                    GV.DataBind();
                    GV.Rows[0].Cells.Clear();
                    GV.Rows[0].Cells.Add(new TableCell());
                    GV.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                    GV.Rows[0].Cells[0].Text = "No Data Found ..!";
                    GV.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GV.PageIndex = e.NewPageIndex;
        }

        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string query = "BEGIN TRANSACTION DECLARE @DataID int;" +
                    "INSERT INTO Intern(Fname, Lname) VALUES(@FirstName, @LastName);" +
                    "SELECT @DataID = scope_identity();" +
                    "INSERT INTO InternContact(InternID, Email) VALUES(@DataID, @Email);" +
                    "COMMIT;";

                    Dictionary<string, object> myPara = new Dictionary<string, object>();

                    myPara.Add("@FirstName", (GV.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                    myPara.Add("@LastName", (GV.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                    myPara.Add("@Email", (GV.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());

                    myCrud.InsertUpdateDelete(query, myPara);

                    BindGrid();

                    lblSuccessMessage.Text = "New Record Added";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void GV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GV.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GV.EditIndex = -1;
            BindGrid();
        }

        protected void GV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string query = "BEGIN TRANSACTION " +
                               "DECLARE @DataID int;" +
                               "UPDATE Intern" +
                               "SET Intern.Fname = @FirstName" +
                               "SET Intern.Lname = @LastName" +
                               "OUTPUT INSERTED.id INTO @DataID;" +
                               "UPDATE InternContact" +
                               "SET InternContact.Email = @Email" +
                               "Where InternContact.InternID = @DataID;" +
                                               " COMMIT; ";
                Dictionary<string, object> myPara = new Dictionary<string, object>();

                myPara.Add("@FirstName", (GV.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                myPara.Add("@LastName", (GV.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                myPara.Add("@Email", (GV.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                myPara.Add("@id", Convert.ToInt32(GV.DataKeys[e.RowIndex].Value.ToString()));
                myCrud.InsertUpdateDelete(query, myPara);

                GV.EditIndex = -1;
                BindGrid();
                lblSuccessMessage.Text = "Selected Record Updated";
                lblErrorMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e) //fk dependency
        {
            try
            {
                string query = "DELETE FROM Intern WHERE InternID = @id";
                Dictionary<string, object> myPara = new Dictionary<string, object>();

                myPara.Add("@id", Convert.ToInt32(GV.DataKeys[e.RowIndex].Value.ToString()));
                myCrud.InsertUpdateDelete(query, myPara);

                BindGrid();
                lblSuccessMessage.Text = "Selected Record Deleted";
                lblErrorMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}