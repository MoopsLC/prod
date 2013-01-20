﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Deweyvm.AltClock
{
    class ClockLabel : Label
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public ClockLabel()
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;

            

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                Control topMost = Parent;
                while (topMost.Parent != null)
                {
                    topMost = topMost.Parent;
                }
                SendMessage(topMost.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}