using System;
using System.Drawing;

namespace HideNow.Data
{
    class Window
    {
        public string Title { get; set; }

        public IntPtr Handle { get; set; }

        public Bitmap Icon { get; set; }
    }
}
