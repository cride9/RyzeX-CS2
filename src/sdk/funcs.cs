using SDK.dependencies.memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SDK.src.offsets;
using SDK.src.sdk.classes;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace SDK.src.sdk {

    public static class globals {

        public static bool Initialize( ) {

            return true;
        }
    }

    public static class functions {

        [DllImport( "user32.dll" )]
        public static extern short GetAsyncKeyState( Keys vKey );
        [DllImport( "user32.dll" )]
        public static extern short GetKeyState( Keys vKey );
        [DllImport( "user32.dll" )]
        public static extern int SendMessage( IntPtr hWnd, int Msg, int wParam, int lParam );
        [DllImport( "user32.dll" )]
        public static extern bool ReleaseCapture( );
        [DllImport( "Gdi32.dll", EntryPoint = "CreateRoundRectRgn" )]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        [DllImport( "user32.dll", SetLastError = true )]
        public static extern void mouse_event( int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo );
        // Import necessary functions from user32.dll
        [DllImport( "user32.dll", SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        public static extern bool GetWindowRect( IntPtr hWnd, out RECT lpRect );
        [DllImport( "user32.dll", SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        public static extern bool SetWindowLong( IntPtr hWnd, int nIndex, uint dwNewLong );

        [DllImport( "user32.dll", SetLastError = true )]
        public static extern uint GetWindowLong( IntPtr hWnd, int nIndex );

        public static IntPtr FindWindowByTitle( string windowTitle ) {
            IntPtr hWnd = IntPtr.Zero;
            foreach ( Process process in Process.GetProcesses( ) ) {
                if ( process.MainWindowTitle == windowTitle ) {
                    hWnd = process.MainWindowHandle;
                    break;
                }
            }
            return hWnd;
        }

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;

        [StructLayout( LayoutKind.Sequential )]
        public struct RECT {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
