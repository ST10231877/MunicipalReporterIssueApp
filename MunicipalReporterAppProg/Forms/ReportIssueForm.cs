using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// we use the Issue model and the in-memory AppState list
using MunicipalReporterAppProg.Models;
using MunicipalReporterAppProg.Services;

namespace MunicipalReporterAppProg.Forms
{
    // this class IS a Windows Form
    public partial class ReportIssueForm : Form
    {
        // we keep a reference to the main menu so we can go back to it
        private readonly Form _mainMenu;

        public ReportIssueForm(Form mainMenu)
        {
            _mainMenu = mainMenu;

            // builds all the controls created in the Designer file
            InitializeComponent();

            // fill the category dropdown with the enum names
            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(Enum.GetNames(typeof(IssueCategory)));
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;

            // show any issues already captured in this session
            RefreshList();
        }

        // back button: close this form and show the main menu
        private void BtnBack_Click(object sender, EventArgs e)
        {
            _mainMenu.Show();
            this.Close();
        }

        // browse button: let the user pick a file to attach
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an image or document";
                ofd.Filter = "Images or docs|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.pdf;*.doc;*.docx;*.xls;*.xlsx;*.txt|All files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Put the chosen path into the read-only textbox
                    txtAttachment.Text = ofd.FileName;
                }
            }
        }

        // check that the user filled in the important fields
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // keep description at least 10 characters so we get some detail
            if (rtbDescription.Text.Trim().Length < 10)
            {
                MessageBox.Show("Add a few more details (min 10 characters).", "Too short", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            // if the attachment textbox is not empty, the file must exist
            if (!string.IsNullOrWhiteSpace(txtAttachment.Text) && !File.Exists(txtAttachment.Text))
            {
                MessageBox.Show("Attachment path not found.", "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true; // all checks passed
        }

        // submit button: build an Issue, add it to the list, and show feedback
        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return; // stop if anything is missing

            // create a new Issue from the inputs
            var issue = new Issue
            {
                Title = txtTitle.Text.Trim(),
                Location = txtLocation.Text.Trim(),
                // convert the selected string back into the enum value
                Category = (IssueCategory)Enum.Parse(typeof(IssueCategory), cboCategory.SelectedItem.ToString()),
                Description = rtbDescription.Text.Trim(),
                // only save the path if the box is not empty
                AttachmentPath = string.IsNullOrWhiteSpace(txtAttachment.Text) ? null : txtAttachment.Text.Trim()
            };

            // show progress while we "submit"
            progress.Visible = true;
            lblEngage.Text = "Submitting your report… thanks for helping your community!";
            ToggleInputs(false); // Disable controls so user can't click twice

            // fake a small delay to feel like a network call
            await System.Threading.Tasks.Task.Delay(1200);

            // store the issue in memory for this assignment (simple List)
            AppState.Issues.Add(issue);

            // turn off progress and re-enable controls
            progress.Visible = false;
            ToggleInputs(true);

            // give the user a short reference (first 8 chars of the Guid)
            lblEngage.Text = "Submitted successfully. Reference: " + issue.Id.ToString().Substring(0, 8).ToUpper();
            MessageBox.Show("Your issue has been submitted. Thank you!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // clear the form for the next entry and update the list on the right
            ClearForm();
            RefreshList();
        }

        // enable/disable the main input controls together
        private void ToggleInputs(bool enabled)
        {
            txtTitle.Enabled = enabled;
            txtLocation.Enabled = enabled;
            cboCategory.Enabled = enabled;
            rtbDescription.Enabled = enabled;
            txtAttachment.Enabled = enabled;
            btnBrowse.Enabled = enabled;
            btnSubmit.Enabled = enabled;
            btnBack.Enabled = enabled;
        }

        // reset all fields to empty/default
        private void ClearForm()
        {
            txtTitle.Clear();
            txtLocation.Clear();
            rtbDescription.Clear();
            txtAttachment.Clear();
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
        }

        // rebuild the ListView with the latest issues (newest first)
        private void RefreshList()
        {
            lvIssues.Items.Clear();
            foreach (var i in AppState.Issues.OrderByDescending(x => x.CreatedAt))
            {
                var item = new ListViewItem(i.CreatedAt.ToString("yyyy-MM-dd HH:mm")); // first column
                item.SubItems.Add(i.Title);
                item.SubItems.Add(i.Category.ToString());
                item.SubItems.Add(i.Status.ToString());
                lvIssues.Items.Add(item);
            }
        }
    }
}
