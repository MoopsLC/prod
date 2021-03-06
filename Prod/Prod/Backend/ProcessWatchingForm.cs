#region License
// // Copyright 2012 deweyvm, see also AUTHORS file.
// // Licenced under GPL v3
// // see LICENCE file for more information or visit http://www.gnu.org/licenses/gpl-3.0.txt
#endregion
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using Prod.Logging;
using Prod.Data;
using Prod.Graphing;

namespace Prod.Gui
{
    /// <summary>
    /// Container form to display time use graphically.
    /// </summary>
    public class ProcessWatchingForm : Form
    {
        protected Grapher grapher;
        public ProcessWatchingForm()
        {
            Settings.Load();
            initForm();
            ActivityInfoProcessor m = new ActivityInfoProcessor();
            grapher = new Grapher();
            /*Log log = new Log();
            m.InfoReceived += log.AcceptInfo;*/
            m.InfoReceived += grapher.AcceptInfo;

            m.Begin();
        }

        private void initForm()
        {
            StartPosition = FormStartPosition.Manual;
            Width = Settings.Options.Width;
            Height = Settings.Options.Height;
            Left = Settings.Options.Left;
            Top = Settings.Options.Top;
            TopMost = Settings.Options.AlwaysOnTop;
            FormBorderStyle = FormBorderStyle.None;

            SetStyle(ControlStyles.AllPaintingInWmPaint
                          | ControlStyles.UserPaint
                          | ControlStyles.DoubleBuffer, true);
            KeyPreview = true;
        }

        public void Add(Control control)
        {
            Controls.Add(control);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            base.OnKeyDown(e);
        }
    }
}