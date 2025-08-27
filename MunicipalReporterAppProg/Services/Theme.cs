using System.Drawing;
using System.Windows.Forms;

namespace MunicipalReporterAppProg.Services
{
    public static class Theme
    {
        // Colors & fonts (tweak as you like)
        public static readonly Color Bg = Color.White;
        public static readonly Color HeaderBg = Color.FromArgb(243, 244, 246);   // light gray
        public static readonly Color Accent = Color.FromArgb(25, 118, 210);    // blue
        public static readonly Color Card = Color.FromArgb(250, 250, 250);   // near white

        public static readonly Font TitleFont = new Font("Segoe UI", 18, FontStyle.Bold);
        public static readonly Font SubFont = new Font("Segoe UI", 10, FontStyle.Regular);
        public static readonly Font BtnFont = new Font("Segoe UI", 10, FontStyle.Bold);   


        public static void StylePrimary(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = BtnFont;
            b.BackColor = Accent;
            b.ForeColor = Color.White;
            b.Height = 40;
        }

        public static void StyleSecondary(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = BtnFont;
            b.BackColor = Color.FromArgb(230, 242, 255);
            b.ForeColor = Color.Black;
            b.Height = 36;
        }

        public static Panel MakeCard(int width, int height)
        {
            var p = new Panel
            {
                BackColor = Card,
                Width = width,
                Height = height,
                Padding = new Padding(16),
                BorderStyle = BorderStyle.FixedSingle
            };
            return p;
        }
    }
}
