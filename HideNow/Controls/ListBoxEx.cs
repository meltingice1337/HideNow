using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using HideNow.Data;

namespace HideNow
{
    public class ListBoxEx : ListBox
    {
        private int LastIndex = 0;
        private Point MouseLocation;
        private const int WM_LBUTTONDOWN = 0x201;

        public ListBoxEx()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.ItemHeight = 35;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= this.Items.Count || e.Index <= -1)
                return;

            Window item = (Window)this.Items[e.Index];
            if (item == null)
                return;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);

            string text = item.Title;
            int offset = 3;
            SizeF stringSize = e.Graphics.MeasureString(text, this.Font);

            e.Graphics.DrawString(text, this.Font, new SolidBrush(Color.Black),  new PointF(item.Icon.Width + offset, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2));
            e.Graphics.DrawImage(item.Icon, new PointF(offset, e.Bounds.Y + (e.Bounds.Height - item.Icon.Height) / 2));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MouseLocation = e.Location;
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                bool contains = false;
                for (int i = 0; i < Items.Count; i++)
                {
                    var rect = GetItemRectangle(i);
                    if (rect.Contains((MouseLocation))) contains = true;
                }
                if (!contains) return;
                LastIndex = SelectedIndex;
            }
            base.WndProc(ref m);
        }
    }
}
