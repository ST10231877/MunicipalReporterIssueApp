using System.Windows.Forms;
using System.Drawing;

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

            this.AutoScaleMode = AutoScaleMode.Font;
            this.Text = "Municipal Reporter — Report Issue";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Font = new Font("Segoe UI", 9F);

            this.lblHeader.Text = "📝 Report an Issue";
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = Color.FromArgb(30, 58, 138);
            this.lblHeader.Location = new System.Drawing.Point(25, 25);

            this.lblTitle.Text = "Issue Title *";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblTitle.Location = new System.Drawing.Point(25, 80);

            this.txtTitle.Location = new System.Drawing.Point(25, 105);
            this.txtTitle.Width = 380;
            this.txtTitle.Height = 35;
            this.txtTitle.Font = new Font("Segoe UI", 10F);
            this.txtTitle.BorderStyle = BorderStyle.FixedSingle;
            this.txtTitle.BackColor = Color.White;

            this.lblLocation.Text = "Location *";
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLocation.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblLocation.Location = new System.Drawing.Point(25, 150);

            this.txtLocation.Location = new System.Drawing.Point(25, 175);
            this.txtLocation.Width = 380;
            this.txtLocation.Height = 35;
            this.txtLocation.Font = new Font("Segoe UI", 10F);
            this.txtLocation.BorderStyle = BorderStyle.FixedSingle;
            this.txtLocation.BackColor = Color.White;

            this.lblCategory.Text = "Category *";
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblCategory.Location = new System.Drawing.Point(25, 220);

            this.cboCategory.Location = new System.Drawing.Point(25, 245);
            this.cboCategory.Width = 380;
            this.cboCategory.Height = 35;
            this.cboCategory.Font = new Font("Segoe UI", 10F);
            this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCategory.BackColor = Color.White;

            this.lblDesc.Text = "Description * (minimum 10 characters)";
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDesc.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblDesc.Location = new System.Drawing.Point(25, 290);

            this.rtbDescription.Location = new System.Drawing.Point(25, 315);
            this.rtbDescription.Width = 380;
            this.rtbDescription.Height = 120;
            this.rtbDescription.Font = new Font("Segoe UI", 10F);
            this.rtbDescription.BorderStyle = BorderStyle.FixedSingle;
            this.rtbDescription.BackColor = Color.White;

            this.lblAttach.Text = "📎 Media Attachment (optional)";
            this.lblAttach.AutoSize = true;
            this.lblAttach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAttach.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblAttach.Location = new System.Drawing.Point(25, 450);

            this.txtAttachment.Location = new System.Drawing.Point(25, 475);
            this.txtAttachment.Width = 300;
            this.txtAttachment.Height = 35;
            this.txtAttachment.Font = new Font("Segoe UI", 9F);
            this.txtAttachment.ReadOnly = true;
            this.txtAttachment.BorderStyle = BorderStyle.FixedSingle;
            this.txtAttachment.BackColor = Color.FromArgb(249, 250, 251);

            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.Location = new System.Drawing.Point(335, 473);
            this.btnBrowse.Size = new Size(70, 35);
            this.btnBrowse.Font = new Font("Segoe UI", 9F);
            this.btnBrowse.BackColor = Color.FromArgb(107, 114, 128);
            this.btnBrowse.ForeColor = Color.White;
            this.btnBrowse.FlatStyle = FlatStyle.Flat;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.Cursor = Cursors.Hand;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);

            this.btnSubmit.Text = "✅ Submit Report";
            this.btnSubmit.Location = new System.Drawing.Point(25, 530);
            this.btnSubmit.Size = new System.Drawing.Size(140, 40);
            this.btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSubmit.BackColor = Color.FromArgb(34, 197, 94);
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74);
            this.btnSubmit.Cursor = Cursors.Hand;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);

            this.btnBack.Text = "← Back to Main";
            this.btnBack.Location = new System.Drawing.Point(175, 530);
            this.btnBack.Size = new System.Drawing.Size(130, 40);
            this.btnBack.Font = new Font("Segoe UI", 10F);
            this.btnBack.BackColor = Color.FromArgb(107, 114, 128);
            this.btnBack.ForeColor = Color.White;
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 85, 99);
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);

            this.progress.Location = new System.Drawing.Point(25, 580);
            this.progress.Width = 380;
            this.progress.Height = 8;
            this.progress.Style = ProgressBarStyle.Marquee;
            this.progress.MarqueeAnimationSpeed = 30;
            this.progress.Visible = false;

            this.lblEngage.Text = "Ready to submit your report";
            this.lblEngage.AutoSize = true;
            this.lblEngage.Font = new Font("Segoe UI", 9F);
            this.lblEngage.ForeColor = Color.FromArgb(107, 114, 128);
            this.lblEngage.Location = new System.Drawing.Point(25, 595);

            this.lblList.Text = "📋 Recent Reports (this session)";
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblList.ForeColor = Color.FromArgb(55, 65, 81);
            this.lblList.Location = new System.Drawing.Point(450, 80);

            this.lvIssues.View = View.Details;
            this.lvIssues.Location = new System.Drawing.Point(450, 110);
            this.lvIssues.Width = 520;
            this.lvIssues.Height = 460;
            this.lvIssues.FullRowSelect = true;
            this.lvIssues.GridLines = true;
            this.lvIssues.Font = new Font("Segoe UI", 9F);
            this.lvIssues.BackColor = Color.White;
            this.lvIssues.BorderStyle = BorderStyle.FixedSingle;

            this.colCreated.Text = "Created";
            this.colCreated.Width = 130;
            this.colTitle.Text = "Title";
            this.colTitle.Width = 180;
            this.colCategory.Text = "Category";
            this.colCategory.Width = 120;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 90;

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
