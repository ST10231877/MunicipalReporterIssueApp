using System;
using System.Drawing;
using System.Windows.Forms;


namespace MunicipalReporterAppProg.Forms
{
    // "partial" because Visual Studio may also create a Designer file for this form
    public partial class MainMenuForm : Form
    {
        // buttons and labels we place on the form
        private Button btnReport;
        private Button btnEvents;
        private Button btnStatus;
        private Label lblTitle;
        private Label lblNote;

        public MainMenuForm()
        {
            // basic window settings
            Text = "Municipal Reporter — Main Menu";
            MinimumSize = new Size(720, 420);
            StartPosition = FormStartPosition.CenterScreen;

            // big title at the top
            lblTitle = new Label
            {
                Text = "Choose a task",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(24, 24)
            };

            // main button the user should click now
            btnReport = new Button
            {
                Text = "Report Issues",
                Font = new Font("Segoe UI", 11),
                Size = new Size(220, 48),
                Location = new Point(24, 90)
            };
            // open the Report form and hide this window
            btnReport.Click += (s, e) =>
            {
                new ReportIssueForm(this).Show();
                this.Hide();
            };

            // future feature: disabled for Part 1
            btnEvents = new Button
            {
                Text = "Local Events & Announcements (coming soon)",
                Enabled = false,
                Size = new Size(380, 40),
                Location = new Point(24, 160)
            };

            // future feature: disabled for Part 1
            btnStatus = new Button
            {
                Text = "Service Request Status (coming soon)",
                Enabled = false,
                Size = new Size(340, 40),
                Location = new Point(24, 210)
            };

            // small note explaining why the other buttons are off
            lblNote = new Label
            {
                Text = "Only 'Report Issues' is enabled for Part 1.",
                AutoSize = true,
                Location = new Point(28, 270)
            };

            // add everything to the window
            Controls.Add(lblTitle);
            Controls.Add(btnReport);
            Controls.Add(btnEvents);
            Controls.Add(btnStatus);
            Controls.Add(lblNote);
        }
    }
}
