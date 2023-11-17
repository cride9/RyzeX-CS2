using SDK.dependencies.memory;
using SDK.src;
using SDK.src.esp;
using SDK.src.movement;
using SDK.src.offsets;
using SDK.src.sdk;

namespace SDK {
    public partial class Window : Form {
        public Window( ) {
            InitializeComponent( );
            Region = Region.FromHrgn( functions.CreateRoundRectRgn( 0, 0, Width, Height, 20, 20 ) );
            Timer.Tick += MenuOpener;
        }

        private static System.Windows.Forms.Timer Timer = new( ) { Interval = 2 };
        private static Pen BorderPen = new Pen( Color.FromArgb( 120, 7, 0, 13 ), 1f ),
        PanelBorderPen = new Pen( Color.FromArgb( 255, 52, 51, 77 ), 1f );
        static bool bVisible = true;

        private IntPtr targetWindowHandle;

        private static playeresp esp = new( );
        private static bunnyhop bhop = new( );

        private void Init( object sender, EventArgs e ) {

            Timer.Start( );
            InitializeOverlay( );

            if ( !memory.AttachToGame( "cs2.exe" ) )
                throw new Exception( "Failed to attach to Counter-Strike 2" );

            if ( !globals.Initialize( ) )
                throw new Exception( "Failed to get globals" );

            esp.Run( true );
            bhop.Run( true );
        }

        private void MenuOpener( object? sender, EventArgs e ) {

            globals.Initialize( );
            if ( ( functions.GetAsyncKeyState( Keys.Insert ) & 1 ) > 0 )
                bVisible = !bVisible;

            if ( bVisible ) {

                Visible = true;
                BringToFront( );
                Focus( );
                TopMost = true;
                Activate( );
                Opacity += 0.2;
            }
            else {

                Opacity -= 0.2;
                if ( Opacity == 0 )
                    Visible = false;
            }
        }

        private void DragHandle( object sender, MouseEventArgs e ) {

            if ( e.Button == MouseButtons.Left ) {

                functions.ReleaseCapture( );
                functions.SendMessage( Handle, functions.WM_NCLBUTTONDOWN, functions.HT_CAPTION, 0 );
            }
        }

        private void OnPaint( object sender, PaintEventArgs e ) =>
            e.Graphics.DrawRectangle( BorderPen, new( new Point( 0, 0 ), new Size( Size.Width - 1, Size.Height - 1 ) ) );
        
        private void PanelBorder( object sender, PaintEventArgs e ) {

            Panel panel = ( sender as Panel )!;
            if ( panel == null )
                return;

            e.Graphics.DrawRectangle( PanelBorderPen, new( new( 0, 0 ), new( panel.Size.Width - 1, panel.Size.Height - 1 ) ) );
        }

        private void InitializeOverlay() {

            targetWindowHandle = functions.FindWindowByTitle( "Counter-Strike 2" );

            if ( targetWindowHandle == IntPtr.Zero ) {
                MessageBox.Show( "Target window not found." );
                Close( );
            }

            overlay overlay = new overlay( targetWindowHandle );
            overlay.Show( );

        }
    }
}
