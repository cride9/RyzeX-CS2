using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SDK.src.sdk;

namespace SDK.src {
    public partial class overlay : Form {
        public overlay( IntPtr targetWindowHandle ) {
            InitializeComponent( );
            this.targetWindowHandle = targetWindowHandle;

            // Set form styles for overlay
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            ShowInTaskbar = false;
            BackColor = Color.LimeGreen; // Set your desired transparent color
            functions.SetWindowLong( 
                Handle, 
                functions.GWL_EXSTYLE, 
                functions.GetWindowLong( 
                    Handle, 
                    functions.GWL_EXSTYLE ) |
                    functions.WS_EX_LAYERED |
                    functions.WS_EX_TRANSPARENT );

            // Make the form transparent
            TransparencyKey = Color.LimeGreen;
        }

        private Pen White = new Pen( Color.FromArgb( 255, 255, 255, 255 ), 1f );
        private Pen Black = new Pen( Color.FromArgb( 255, 0, 0, 0 ), 1f );

        private IntPtr targetWindowHandle; 

        private void UpdateOverlayPosition( ) {
            if ( functions.GetWindowRect( targetWindowHandle, out functions.RECT targetRect ) ) {
                // Set the overlay position and size based on the target window
                Location = new Point( targetRect.Left, targetRect.Top );
                Size = new Size( targetRect.Right - targetRect.Left, targetRect.Bottom - targetRect.Top );
            }
            Refresh( );
        }

        protected override void OnLoad( EventArgs e ) {
            base.OnLoad( e );

            // Start a timer to update overlay position periodically
            System.Windows.Forms.Timer timer = new( );
            timer.Interval = 10; // Adjust the interval as needed
            timer.Tick += ( sender, args ) => UpdateOverlayPosition( );
            timer.Start( );
        }

        private void PanelBorder( object sender, PaintEventArgs e ) {

            Panel panel = ( sender as Panel )!;
            if ( panel == null )
                return;

            e.Graphics.DrawRectangle( Black, new( new( 0, 0 ), new( panel.Size.Width, panel.Size.Height ) ) );
            e.Graphics.DrawRectangle( White, new( new( 1, 1 ), new( panel.Size.Width - 2, panel.Size.Height - 2 ) ) );
            e.Graphics.DrawRectangle( Black, new( new( 2, 2 ), new( panel.Size.Width - 4, panel.Size.Height - 4 ) ) );
        }
    }
}
