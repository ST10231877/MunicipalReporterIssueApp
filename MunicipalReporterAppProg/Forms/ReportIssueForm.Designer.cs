using System.Windows.Forms;

namespace MunicipalReporterAppProg.Forms
{
    partial class ReportIssueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblHeader;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblDesc;
        private RichTextBox rtbDescription;
        private Label lblAttach;
        private TextBox txtAttachment;
        private Button btnBrowse;
        private Button btnSubmit;
        private Button btnBack;
        private ProgressBar progress;
        private Label lblEngage;
        private Label lblList;
        private ListView lvIssues;
        private ColumnHeader colCreated;
        private ColumnHeader colTitle;
        private ColumnHeader colCategory;
        private ColumnHeader colStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new Label();
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblLocation = new Label();
            this.txtLocation = new TextBox();
            this.lblCategory = new Label();
            this.cboCategory = new ComboBox();
            this.lblDesc = new Label();
            this.rtbDescription = new RichTextBox();
            this.lblAttach = new Label();
            this.txtAttachment = new TextBox();
            this.btnBrowse = new Button();
            this.btnSubmit = new Button();
            this.btnBack = new Button();
            this.progress = new ProgressBar();
            this.lblEngage = new Label();
            this.lblList = new Label();
            this.lvIssues = new ListView();
            this.colCreated = new ColumnHeader();
            this.colTitle = new ColumnHeader();
            this.colCategory = new ColumnHeader();
            this.colStatus = new ColumnHeader();
            this.SuspendLayout();
            // 
            // Form
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Text = "Municipal Reporter — Report Issue";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(920, 600);
            // 
            // lblHeader
            // 
            this.lblHeader.Text = "Report an Issue";
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(18, 18);
            // 
            // lblTitle / txtTitle
            // 
            this.lblTitle.Text = "Title:";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(18, 70);

            this.txtTitle.Location = new System.Drawing.Point(18, 92);
            this.txtTitle.Width = 360;
            // 
            // lblLocation / txtLocation
            // 
            this.lblLocation.Text = "Location:";
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocation.Location = new System.Drawing.Point(18, 130);

            this.txtLocation.Location = new System.Drawing.Point(18, 152);
            this.txtLocation.Width = 360;
            // 
            // lblCategory / cboCategory
            // 
            this.lblCategory.Text = "Category:";
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(18, 190);

            this.cboCategory.Location = new System.Drawing.Point(18, 212);
            this.cboCategory.Width = 360;
            this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // lblDesc / rtbDescription
            // 
            this.lblDesc.Text = "Description:";
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesc.Location = new System.Drawing.Point(18, 250);

            this.rtbDescription.Location = new System.Drawing.Point(18, 272);
            this.rtbDescription.Width = 360;
            this.rtbDescription.Height = 120;
            // 
            // lblAttach / txtAttachment / btnBrowse
            // 
            this.lblAttach.Text = "Media Attachment (optional):";
            this.lblAttach.AutoSize = true;
            this.lblAttach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAttach.Location = new System.Drawing.Point(18, 402);

            this.txtAttachment.Location = new System.Drawing.Point(18, 424);
            this.txtAttachment.Width = 300;
            this.txtAttachment.ReadOnly = true;

            this.btnBrowse.Text = "Browse…";
            this.btnBrowse.Location = new System.Drawing.Point(326, 422);
            this.btnBrowse.Width = 70;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btnSubmit / btnBack
            // 
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(18, 468);
            this.btnSubmit.Size = new System.Drawing.Size(120, 34);
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);

            this.btnBack.Text = "Back to Main";
            this.btnBack.Location = new System.Drawing.Point(150, 468);
            this.btnBack.Size = new System.Drawing.Size(120, 34);
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // progress / lblEngage
            // 
            this.progress.Location = new System.Drawing.Point(18, 510);
            this.progress.Width = 360;
            this.progress.Height = 12;
            this.progress.Style = ProgressBarStyle.Marquee;
            this.progress.MarqueeAnimationSpeed = 30;
            this.progress.Visible = false;

            this.lblEngage.Text = "Ready to submit your report.";
            this.lblEngage.AutoSize = true;
            this.lblEngage.Location = new System.Drawing.Point(18, 530);
            // 
            // Right panel list
            // 
            this.lblList.Text = "Recent Reports (this session)";
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblList.Location = new System.Drawing.Point(420, 70);

            this.lvIssues.View = View.Details;
            this.lvIssues.Location = new System.Drawing.Point(420, 92);
            this.lvIssues.Width = 460;
            this.lvIssues.Height = 430;
            this.lvIssues.FullRowSelect = true;
            this.lvIssues.GridLines = true;

            this.colCreated.Text = "Created";
            this.colCreated.Width = 120;
            this.colTitle.Text = "Title";
            this.colTitle.Width = 160;
            this.colCategory.Text = "Category";
            this.colCategory.Width = 120;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 80;

            this.lvIssues.Columns.AddRange(new ColumnHeader[] {
                this.colCreated, this.colTitle, this.colCategory, this.colStatus
            });

            // Add controls to Form
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblAttach);
            this.Controls.Add(this.txtAttachment);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lblEngage);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.lvIssues);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}