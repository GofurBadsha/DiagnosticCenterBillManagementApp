using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemApp.Managers;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class TestForm : System.Web.UI.Page
    {
        private TestTypeManager _testTypeManager=new TestTypeManager();
        private TestManager _testManager=new TestManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllDropDown();
                LoadAllGridView();
            }
            
        }

        public void LoadAllGridView()
        {
            testGridView.DataSource = _testManager.GeAll();
            testGridView.DataBind();
        }


        public void LoadAllDropDown()
        {
            testTypeDropDownList.DataSource = _testTypeManager.GetAll();
            testTypeDropDownList.DataTextField = "Name";
            testTypeDropDownList.DataValueField = "Id";
            testTypeDropDownList.DataBind();

            testTypeDropDownList.Items.Insert(0, "");
            testTypeDropDownList.SelectedIndex = -1;
        }

        public void RefressForm()
        {
            idHiddenField.Value = "";
            testNameTextBox.Text = "";
            feeTextBox.Text = "";
            testTypeDropDownList.SelectedIndex = -1;

            LoadAllGridView();
        }

        public Test SetFormValueInMOdel()
        {
            var atest = new Test();
            atest.Name = testNameTextBox.Text;
            atest.Fee = Convert.ToDecimal(feeTextBox.Text);
            atest.TestTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);

            return atest;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (testNameTextBox.Text == "")
            {
                massageLabel.CssClass = "alert alert-warning";
                massageLabel.Text = "Please Insert Test Name";
                testNameTextBox.Focus();
            }
            else if (feeTextBox.Text == "")
            {
                massageLabel.CssClass = "alert alert-warning";
                massageLabel.Text = "Please Insert Test Fee";
                testNameTextBox.Focus();
            }
            else if (testTypeDropDownList.SelectedValue == "")
            {
                massageLabel.CssClass = "alert alert-warning";
                massageLabel.Text = "Please Insert Test Type";
                testNameTextBox.Focus();
            }
            else
            {
                var test = SetFormValueInMOdel();
                var isNameExit = _testManager.IsNameExitst(test.Name, test.TestTypeId);
                if (isNameExit)
                {
                    massageLabel.CssClass = "alert alert-warning";
                    massageLabel.Text = "This Test Type Already In Database";
                }
                else
                {
                    var success = _testManager.Save(test);
                    if (success > 0)
                    {
                        massageLabel.CssClass = "alert alert-success";
                        massageLabel.Text = "Save Success";

                        RefressForm();
                    }
                    else
                    {
                        massageLabel.CssClass = "alert alert-danger";
                        massageLabel.Text = "Save Fail";

                        
                    }
                }
            }
        }

        //protected void findButton_Click(object sender, EventArgs e)
        //{
        //    massageLabel.Text = "";
        //    massageLabel.CssClass = "alert alert-default";

        //    if (testNameTextBox.Text == "")
        //    {
        //        massageLabel.CssClass = "alert alert-warning";
        //        massageLabel.Text = "Please Insert Test Type";
        //        testNameTextBox.Focus();
        //    }
        //    else
        //    {
        //        var testName = testNameTextBox.Text;
        //        var aTest = _testManager.GeTestByNameAndType(testName);
        //        if (aTest != null)
        //        {
        //            idHiddenField.Value = aTest.Id.ToString();
        //            testNameTextBox.Text = aTest.Name;
        //            feeTextBox.Text = aTest.Fee.ToString("N2");
        //            testTypeDropDownList.SelectedValue = aTest.TestTypeId.ToString();
        //        }
        //        else
        //        {
        //            massageLabel.CssClass = "alert alert-info";
        //            massageLabel.Text = "There is no Test in This Name";
        //        }
        //    }

        //}

        protected void updatButton_Click(object sender, EventArgs e)
        {
            massageLabel.Text = "";
            massageLabel.CssClass = "alert alert-default";

            if (idHiddenField.Value == "")
            {
                massageLabel.CssClass = "alert alert-warning";
                massageLabel.Text = "First Find a Test Then Update";
            }
            else
            {
                var test = SetFormValueInMOdel();
                var isNameExit = _testManager.IsNameExitst(test.Name, test.TestTypeId);
                if (isNameExit)
                {
                    massageLabel.CssClass = "alert alert-warning";
                    massageLabel.Text = "This Test Type Already In Database";
                }
                else
                {
                    var id = Convert.ToInt32(idHiddenField.Value);
                    var success = _testManager.Update(id,test);
                    if (success > 0)
                    {
                        massageLabel.CssClass = "alert alert-success";
                        massageLabel.Text = "Update Success";

                        RefressForm();
                    }
                    else
                    {
                        massageLabel.CssClass = "alert alert-danger";
                        massageLabel.Text = "Update Fail";
                    }
                }
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            massageLabel.Text = "";
            massageLabel.CssClass = "alert alert-default";

            if (idHiddenField.Value == "")
            {
                massageLabel.CssClass = "alert alert-warning";
                massageLabel.Text = "First Find a Test Then Update";
            }
            else
            {
                var id = Convert.ToInt32(idHiddenField.Value);
                var success = _testManager.Delete(id);
                if (success > 0)
                {
                    massageLabel.CssClass = "alert alert-success";
                    massageLabel.Text = "Delete Success";

                    RefressForm();
                }
                else
                {
                    massageLabel.CssClass = "alert alert-danger";
                    massageLabel.Text = "Delete Fail";
                }
            }
        }

    }
}