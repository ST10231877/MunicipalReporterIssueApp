using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MunicipalReporterAppProg.Forms
{
    public partial class MainMenuForm : Form
    {
        private Button btnReport, btnEvents, btnStatus;
        private Label lblTitle, lblSubtitle;
        private Panel mainContainer, sidebarPanel, contentPanel, welcomePanel, quickActionsPanel;

        private static readonly Color DarkPrimary = Color.FromArgb(31, 41, 55);
        private static readonly Color DarkSidebar = Color.FromArgb(17, 24, 39);
        private static readonly Color PurpleAccent = Color.FromArgb(139, 92, 246);
        private static readonly Color LightBackground = Color.FromArgb(248, 250, 252);
        private static readonly Color TextGray = Color.FromArgb(107, 114, 128);

        public MainMenuForm()
        {
            InitializeForm();
            CreateSidebar();
            CreateContentArea();
            SetupResizeHandler();
        }

        private void InitializeForm()
        {
            Text = "Municipal Reporter";
            Size = new Size(1400, 900);
            MinimumSize = new Size(1200, 800);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = DarkPrimary;
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void SetHighQualityGraphics(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        }

        private void DrawRoundedRectWithShadow(Graphics g, Rectangle rect, int radius, Color fillColor, int shadowLayers = 4, float shadowOffset = 1f)
        {
            using (GraphicsPath path = CreateRoundedRectPath(rect, radius))
            {
                // Draw shadow layers
                for (int i = shadowLayers; i >= 1; i--)
                {
                    using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(Math.Max(1, 12 - i), 0, 0, 0)))
                    {
                        GraphicsPath shadowPath = (GraphicsPath)path.Clone();
                        Matrix matrix = new Matrix();
                        matrix.Translate(0, i * shadowOffset);
                        shadowPath.Transform(matrix);
                        g.FillPath(shadowBrush, shadowPath);
                    }
                }
                // Fill main shape
                using (SolidBrush brush = new SolidBrush(fillColor))
                    g.FillPath(brush, path);
            }
        }

        private GraphicsPath CreateRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        private void CreateSidebar()
        {
            sidebarPanel = new Panel { Size = new Size(320, 900), Location = new Point(0, 0), Dock = DockStyle.Left, BackColor = DarkSidebar };
            sidebarPanel.Paint += (s, e) => {
                SetHighQualityGraphics(e.Graphics);
                using (LinearGradientBrush brush = new LinearGradientBrush(sidebarPanel.ClientRectangle, DarkSidebar, DarkPrimary, LinearGradientMode.Horizontal))
                    e.Graphics.FillRectangle(brush, sidebarPanel.ClientRectangle);
                using (Pen accentPen = new Pen(PurpleAccent, 3))
                    e.Graphics.DrawLine(accentPen, sidebarPanel.Width - 3, 0, sidebarPanel.Width - 3, sidebarPanel.Height);
            };

            lblTitle = new Label
            {
                Text = "Municipal" + Environment.NewLine + "Reporter",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(280, 120),
                Location = new Point(20, 40),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };

            lblSubtitle = new Label
            {
                Text = "Digital Civic Platform",
                Font = new Font("Segoe UI", 12),
                ForeColor = PurpleAccent,
                AutoSize = false,
                Size = new Size(280, 30),
                Location = new Point(20, 170),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };

            CreateNavigationPanel();
            sidebarPanel.Controls.AddRange(new Control[] { lblTitle, lblSubtitle });
            Controls.Add(sidebarPanel);
        }

        private void CreateNavigationPanel()
        {
            Panel navPanel = new Panel { Size = new Size(280, 400), Location = new Point(20, 250), BackColor = Color.Transparent };
            Label navTitle = new Label
            {
                Text = "NAVIGATION",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = TextGray,
                AutoSize = false,
                Size = new Size(280, 30),
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };

            Button[] navButtons = {
                CreateNavButton("   🏠  Dashboard", 40, PurpleAccent, Color.White, true),
                CreateNavButton("   📋  My Reports", 100, Color.Transparent, Color.FromArgb(156, 163, 175), false),
                CreateNavButton("   ⚙️  Settings", 160, Color.Transparent, Color.FromArgb(156, 163, 175), false)
            };

            navPanel.Controls.Add(navTitle);
            navPanel.Controls.AddRange(navButtons);
            sidebarPanel.Controls.Add(navPanel);
        }

        private Button CreateNavButton(string text, int y, Color backColor, Color foreColor, bool isActive)
        {
            Button btn = new Button
            {
                Size = new Size(280, 50),
                Location = new Point(0, y),
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, isActive ? FontStyle.Bold : FontStyle.Regular),
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            if (!isActive) btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 65, 81);
            return btn;
        }

        private void CreateContentArea()
        {
            contentPanel = new Panel { Size = new Size(1080, 900), Location = new Point(320, 0), BackColor = LightBackground };
            CreateWelcomePanel();
            CreateQuickActionsPanel();
            contentPanel.Controls.AddRange(new Control[] { welcomePanel, quickActionsPanel });
            Controls.Add(contentPanel);
        }

        private void CreateWelcomePanel()
        {
            welcomePanel = new Panel { Size = new Size(1000, 280), Location = new Point(40, 40), BackColor = Color.White };
            welcomePanel.Paint += (s, e) => {
                SetHighQualityGraphics(e.Graphics);
                DrawRoundedRectWithShadow(e.Graphics, new Rectangle(0, 0, welcomePanel.Width, welcomePanel.Height), 28, Color.White, 16, 0.8f);

                // Purple accent bar
                using (LinearGradientBrush accentBrush = new LinearGradientBrush(new Rectangle(0, 0, welcomePanel.Width, 10),
                    Color.FromArgb(147, 51, 234), Color.FromArgb(79, 70, 229), LinearGradientMode.Horizontal))
                using (GraphicsPath accentPath = CreateRoundedRectPath(new Rectangle(0, 0, welcomePanel.Width, 10), 28))
                    e.Graphics.FillPath(accentBrush, accentPath);

                DrawWelcomeText(e.Graphics);
                DrawStatistics(e.Graphics);
            };
        }

        private void DrawWelcomeText(Graphics g)
        {
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(17, 24, 39)))
            {
                g.DrawString("Welcome to Municipal Reporter", new Font("Segoe UI", 34, FontStyle.Bold), textBrush, new PointF(45, 55));
                g.DrawString("Your voice matters. Report issues, track progress, and help build a better community.",
                    new Font("Segoe UI", 17), textBrush, new RectangleF(45, 120, 920, 80));
            }
        }

        private void DrawStatistics(Graphics g)
        {
            using (SolidBrush statsBrush = new SolidBrush(TextGray))
            using (SolidBrush statsNumberBrush = new SolidBrush(PurpleAccent))
            using (Pen dividerPen = new Pen(Color.FromArgb(229, 231, 235), 2))
            {
                Font statsFont = new Font("Segoe UI", 18, FontStyle.Bold);
                Font statsLabelFont = new Font("Segoe UI", 13);

                g.DrawLine(dividerPen, 180, 205, 180, 245);
                g.DrawLine(dividerPen, 360, 205, 360, 245);

                string[] numbers = { "1,247", "98%", "24hrs" };
                string[] labels = { "Issues Resolved", "Satisfaction Rate", "Avg Response Time" };
                int[] xPositions = { 45, 200, 380 };

                for (int i = 0; i < 3; i++)
                {
                    g.DrawString(numbers[i], statsFont, statsNumberBrush, new PointF(xPositions[i], 205));
                    g.DrawString(labels[i], statsLabelFont, statsBrush, new PointF(xPositions[i], 235));
                }
            }
        }

        private void CreateQuickActionsPanel()
        {
            quickActionsPanel = new Panel { Size = new Size(1000, 500), Location = new Point(40, 360), BackColor = Color.Transparent };

            btnReport = CreateReportButton();
            btnEvents = CreateSecondaryButton("Local Events", 50, 280);
            btnStatus = CreateSecondaryButton("Track Status", 380, 280);

            quickActionsPanel.Controls.AddRange(new Control[] { btnReport, btnEvents, btnStatus });
        }

        private Button CreateReportButton()
        {
            Button btn = new Button
            {
                Size = new Size(600, 180),
                Location = new Point(200, 40),
                BackColor = PurpleAccent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Text = ""
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(124, 58, 237);
            btn.Paint += DrawReportButton;
            btn.Click += (s, e) => { new ReportIssueForm(this).Show(); this.Hide(); };
            return btn;
        }

        private void DrawReportButton(object sender, PaintEventArgs e)
        {
            SetHighQualityGraphics(e.Graphics);
            DrawRoundedRectWithShadow(e.Graphics, new Rectangle(0, 0, btnReport.Width, btnReport.Height), 32, PurpleAccent, 20, 0.6f);

            // Gradient overlay
            using (LinearGradientBrush brush = new LinearGradientBrush(btnReport.ClientRectangle,
                Color.FromArgb(147, 51, 234), Color.FromArgb(99, 102, 241), 45f))
            using (GraphicsPath path = CreateRoundedRectPath(new Rectangle(0, 0, btnReport.Width, btnReport.Height), 32))
                e.Graphics.FillPath(brush, path);

            DrawReportIcon(e.Graphics);
            DrawReportText(e.Graphics);
        }

        private void DrawReportIcon(Graphics g)
        {
            Rectangle iconRect = new Rectangle(65, 45, 90, 90);

            // Icon glow effect
            for (int i = 8; i >= 1; i--)
                using (SolidBrush glowBrush = new SolidBrush(Color.FromArgb(Math.Max(1, 20 - i * 2), 255, 255, 255)))
                    g.FillEllipse(glowBrush, new Rectangle(iconRect.X - i, iconRect.Y - i, iconRect.Width + i * 2, iconRect.Height + i * 2));

            g.FillEllipse(Brushes.White, iconRect);

            // Centered exclamation mark
            using (SolidBrush iconTextBrush = new SolidBrush(PurpleAccent))
            {
                Font iconFont = new Font("Segoe UI", 42, FontStyle.Bold);
                SizeF textSize = g.MeasureString("!", iconFont);
                float centerX = iconRect.X + (iconRect.Width - textSize.Width) / 2;
                float centerY = iconRect.Y + (iconRect.Height - textSize.Height) / 2;
                g.DrawString("!", iconFont, iconTextBrush, new PointF(centerX, centerY));
            }
        }

        private void DrawReportText(Graphics g)
        {
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                g.DrawString("Report an Issue", new Font("Segoe UI", 26, FontStyle.Bold), textBrush, new PointF(190, 55));
                g.DrawString("Submit municipal concerns and help improve", new Font("Segoe UI", 15), textBrush, new PointF(190, 95));
                g.DrawString("your community infrastructure", new Font("Segoe UI", 15), textBrush, new PointF(190, 120));
            }
        }

        private Button CreateSecondaryButton(string title, int x, int y)
        {
            Button btn = new Button
            {
                Size = new Size(300, 120),
                Location = new Point(x, y),
                BackColor = Color.White,
                ForeColor = TextGray,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Default,
                Font = new Font("Segoe UI", 14),
                Text = "",
                Enabled = false
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Paint += (s, e) => DrawSecondaryButton(e.Graphics, btn, title);
            return btn;
        }

        private void DrawSecondaryButton(Graphics g, Button btn, string title)
        {
            SetHighQualityGraphics(g);
            DrawRoundedRectWithShadow(g, new Rectangle(0, 0, btn.Width, btn.Height), 20, Color.White);

            using (Pen borderPen = new Pen(Color.FromArgb(229, 231, 235), 1))
            using (GraphicsPath path = CreateRoundedRectPath(new Rectangle(0, 0, btn.Width, btn.Height), 20))
                g.DrawPath(borderPen, path);

            g.FillEllipse(new SolidBrush(Color.FromArgb(156, 163, 175)), new Rectangle(30, 20, 50, 50));

            using (SolidBrush textBrush = new SolidBrush(TextGray))
            {
                g.DrawString(title, new Font("Segoe UI", 16, FontStyle.Bold), textBrush, new PointF(110, 30));
                g.DrawString("Coming Soon", new Font("Segoe UI", 12), textBrush, new PointF(110, 60));
            }
        }

        private void SetupResizeHandler()
        {
            this.Resize += (s, e) => {
                contentPanel.Size = new Size(this.Width - 320, this.Height);
                welcomePanel.Size = new Size(contentPanel.Width - 80, 280);
                quickActionsPanel.Size = new Size(contentPanel.Width - 80, 500);
                btnReport.Location = new Point((quickActionsPanel.Width - btnReport.Width) / 2, 40);
            };
        }
    }
}
