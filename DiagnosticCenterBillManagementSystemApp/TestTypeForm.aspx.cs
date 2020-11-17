using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystemApp.Getways;
using DiagnosticCenterBillManagementSystemApp.Managers;
using DiagnosticCenterBillManagementSystemApp.Models;

namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class testTypeForm : System.Web.UI.Page
    {
        private TestTypeManager _testTypeManager = new TestTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        public void LoadGridView()
        {
            tetTypeGridView.DataSource = _testTypeManager.GetAll();
            tetTypeGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (typeNameTextBox.Text != "")
            {
                var testType = new TestType();
                testType.Name = typeNameTextBox.Text;

                var isTypeNameExist = _testTypeManager.IsTypeNameExist(testType.Name);
                if (isTypeNameExist)
                {
                    massageLabel.Text = "This Test Type Name Already in Database";
                }
                else
                {
                    massageLabel.Text = _testTypeManager.Save(testType);
                    LoadGridView();
                }

            }

            else
            {
                massageLabel.Text = "Please insert text name";
                massageLabel.CssClass = "alert alert-warning";
            }
        }

        public void RefressForm()
        {
            typeNameTextBox.Text = "";
            LoadGridView();
        }

        protected void tetTypeGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void findButton_Click(object sender, EventArgs e)
        {
            if (typeNameTextBox.Text != "")
            {
                var testType = _testTypeManager.GetBytypeName(typeNameTextBox.Text);
                if (testType != null)
                {
                    massageLabel.Text = "Successfuly Find Test Type";
                    idHiddenField1.Value = testType.Id.ToString();
                    typeNameTextBox.Text = testType.Name;

                    var testTypeList = new List<TestType>();
                    testTypeList.Add(testType);

                    tetTypeGridView.DataSource = testTypeList;
                    tetTypeGridView.DataBind();
                }
                else
                {
                    massageLabel.Text = "This Test Type Not Find in Database";
                }
            }
            else
            {
                massageLabel.Text = "Please insert Test Type Name then Find";
                typeNameTextBox.Focus();
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (idHiddenField1.Value == "")
            {
                 massageLabel.Text = "First Find a Test Value Then Update it";
                massageLabel.CssClass = "alert alert-warning";
            }
            if (typeNameTextBox.Text != "")
            {
                int id = Convert.ToInt32(idHiddenField1.Value);

                var testType = new TestType();
                testType.Name = typeNameTextBox.Text;

                var isTypeNameExist = _testTypeManager.IsTypeNameExist(testType.Name);
                if (isTypeNameExist)
                {
                    massageLabel.Text = "This Test Type Name Already in Database";
                }
                else
                {
                    massageLabel.Text = _testTypeManager.Update(testType,id);
                    RefressForm();
                }

            }
            else
            {
                massageLabel.Text = "Please insert text name";
                massageLabel.CssClass = "alert alert-warning";
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            if (idHiddenField1.Value == "")
            {
                massageLabel.Text = "First Find a Test Value Then Update it";
                massageLabel.CssClass = "alert alert-warning";
            }
            else
            {
                int id = Convert.ToInt32(idHiddenField1.Value);
                massageLabel.Text = _testTypeManager.Delete(id);
                RefressForm();
            }
        }
    }
}  