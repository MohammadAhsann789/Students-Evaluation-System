using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Students_Evaluation_System.Utility
{
    class Theme_Color
    {
        public static Color primary_color { get; set; }
        public static Color secondary_color { get; set; }

        public static List<string> reserved_list = new List<string>() 
        { 
            "#3F51B5", "#009688", "#FF5722", "#607D8B", "#FF9800", "#9C27B0",
            "#2196F3", "#EA676C", "#E41A4A", "#5978BB", "#018790", "#0E3441",
            "#00B0AD", "#721D47", "#EA4833", "#EF937E", "#F37521", "#A12059",
            "#126881", "#8BC240", "#364D5B", "#C7DC5B", "#0094BC", "#E4126B",
            "#43B76E", "#7BCFE9", "#B71C46"
        };

        public static List<string> color_list = new List<string>()
        {
            "#009688", "#9C27B0", "#2196F3", "#E41A4A", "#00B0AD", "#EA4833",
            "#F37521", "#0094BC", "#43B76E", "#B71C46"
        };

        public static Color Change_Color_Brightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            //If correction factor is less than 0, darken color.
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            //If correction factor is greater than zero, light in color.
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }

        public static void Apply_Color(ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    Button btn = (Button)ctrl;
                    btn.BackColor = Theme_Color.primary_color;
                }

                if (controls.Count > 0)
                {
                    Apply_Color(ctrl.Controls);
                }
            }
        }
    }

}
