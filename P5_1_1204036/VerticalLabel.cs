using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_1_1204036
{
    [ToolboxBitmap(typeof(VerticalLabel), "P5_1_1204036.VerticalLabel.ico")]
    public partial class VerticalLabel : Control
    {
        public VerticalLabel()
        {
            InitializeComponent();
        }
        private string labelText;
        //Overriding Text Property 
        // Adding attribute for Text Property in design time support 
        [Category("VerticalLabel"), Description("Text is displayed in container")]
        public override string Text
        {
            get
            { return labelText; }
            set
                {
                    labelText = value;
                    Invalidate();
                }
        }

        //Overriding OnPaint event
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        { 

        float sngControlwidth;
        float sngControlHeight;

        float sngTransformX;
        float sngTransformY;

        Color labelColor = new Color();
        Pen labelBorderPen = new Pen(labelColor, 0);
        SolidBrush labelBackColorBrush = new SolidBrush(labelColor);
        SolidBrush labelForeColorBrush = new SolidBrush(base.ForeColor);

            if (this.DesignMode)
                base.ResizeRedraw = true;

            base.OnPaint(e);

            sngControlwidth = this.Size.Width;
            sngControlHeight = this.Size.Height;

            e.Graphics.DrawRectangle(labelBorderPen, 0, 0, sngControlwidth, sngControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, sngControlwidth, sngControlHeight);

            //set the translation point for the graphics object - the new (0,0) location 
            sngTransformX = 0;
            sngTransformY = sngControlHeight;

            // translate the origin used for rotation and drawing 
            e.Graphics.TranslateTransform(sngTransformX, sngTransformY); // (@, textwidth);

            // set the rotation angle for vertical text 
            e.Graphics.RotateTransform(270);

            // draw the text on the control
            e. Graphics.DrawString(labelText, Font, labelForeColorBrush, 0, 0);


        }
    }

}
