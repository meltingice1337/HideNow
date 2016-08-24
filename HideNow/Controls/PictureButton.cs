using System;
using System.Drawing;
using System.Windows.Forms;

namespace HideNow.Controls
{
    public class PictureButton : PictureBox
    {
        Image backgroundImage, pressedImage, hoverImage;
        bool pressed = false, over = false;
        // Property for the background image to be drawn behind the button text. 
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public Image BackgroundImage
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            get
            {
                return this.backgroundImage;
            }
            set
            {
                this.backgroundImage = value;
            }
        }

        // Property for the background image to be drawn behind the button text when 
        // the button is pressed. 
        public Image PressedImage
        {
            get
            {
                return this.pressedImage;
            }
            set
            {
                this.pressedImage = value;
            }
        }

        public Image HoverImage
        {
            get
            {
                return this.hoverImage;
            }
            set
            {
                this.hoverImage = value;
            }
        }

        // When the mouse button is pressed, set the "pressed" flag to true  
        // and invalidate the form to cause a repaint.  The .NET Compact Framework  
        // sets the mouse capture automatically. 
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.pressed = true;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        // When the mouse is released, reset the "pressed" flag 
        // and invalidate to redraw the button in the unpressed state. 
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.pressed = false;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.over = true;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.over = false;
            this.Invalidate();
            base.OnMouseLeave(e);   
        }
        // Override the OnPaint method to draw the background image and the text. 
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            if (this.pressed && this.pressedImage != null)
                e.Graphics.DrawImage(this.pressedImage, 0, 0);
            else if (this.over && this.hoverImage != null)
                e.Graphics.DrawImage(this.hoverImage, 0, 0, Width, Height);
            else if(this.backgroundImage != null)
                e.Graphics.DrawImage(this.backgroundImage, 0, 0, Width, Height);

            // Draw the text if there is any. 
            if (this.Text.Length > 0)
            {
                SizeF size = e.Graphics.MeasureString(this.Text, this.Font);

                // Center the text inside the client area of the PictureButton.
                e.Graphics.DrawString(this.Text,
                    this.Font,
                    new SolidBrush(this.ForeColor),
                    (this.ClientSize.Width - size.Width) / 2,
                    (this.ClientSize.Height - size.Height) / 2);
            }

            base.OnPaint(e);
        }
    }
}
