using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.src.sdk {
    internal class config {

        /* Saved elements */
        static List<CheckBox> checkBoxes = new List<CheckBox>( );
        static List<TrackBar> trackBars = new List<TrackBar>( );
        static FileStream FileStream = null;

        public static void SaveConfig( ) {

            if ( MessageBox.Show( "Are you sure?", "Saving", MessageBoxButtons.OKCancel ) != DialogResult.OK )
                return;

            /* Get Every element from groupboxes and main window */
            using ( StreamWriter sw = new StreamWriter( @"C:/CSExternal/config.ini", false, Encoding.UTF8 ) ) {

                sw.WriteLine( "[Checkboxes]" );
                foreach ( var item in checkBoxes )
                    sw.WriteLine( $"{item.Name} = {item.Checked.ToString( ).ToLower( )}" );

                sw.WriteLine( "[Sliders]" );
                foreach ( var item in trackBars )
                    sw.WriteLine( $"{item.Name} = {item.Value}" );
            }
        }

        public static void LoadConfig( ) {

            if ( MessageBox.Show( "Are you sure?", "Loading", MessageBoxButtons.OKCancel ) != DialogResult.OK )
                return;

            using ( StreamReader sr = new StreamReader( "C:/CSExternal/config.ini", Encoding.UTF8 ) ) {

                int bReachedType = -1;
                while ( !sr.EndOfStream ) {

                    string szLine = sr.ReadLine( );

                    // if new type reached read new line
                    if ( szLine.Contains( "[" ) ) {

                        szLine = sr.ReadLine( );
                        bReachedType++;

                        if ( sr.EndOfStream )
                            return;
                    }

                    string szName = szLine.Split( '=' )[ 0 ].Trim( );
                    string szValue = szLine.Split( '=' )[ 1 ].Trim( );

                    if ( bReachedType == ( int )SECTION.CHECKBOXES )
                        checkBoxes.Find( it => it.Name == szName ).CheckState = bool.Parse( szValue ) == true ? CheckState.Checked : CheckState.Unchecked;
                    else if ( bReachedType == ( int )SECTION.TRACKBARS )
                        trackBars.Find( it => it.Name == szName ).Value = int.Parse( szValue );
                }
            }
        }
        public static void Initialize( Control.ControlCollection collection ) {

            foreach ( var it in collection ) {

                if ( ( it as GroupBox ) != null ) {

                    foreach ( var item in ( it as GroupBox ).Controls ) {

                        if ( ( item as CheckBox ) != null )
                            checkBoxes.Add( item as CheckBox );

                        else if ( ( item as TrackBar ) != null )
                            trackBars.Add( item as TrackBar );
                    }
                }
                else if ( ( it as CheckBox ) != null )
                    checkBoxes.Add( it as CheckBox );

                else if ( ( it as TrackBar ) != null )
                    trackBars.Add( it as TrackBar );
            }
            Directory.CreateDirectory( @"C:/CSExternal" );
        }
    }
    enum SECTION : int {

        CHECKBOXES,
        TRACKBARS
    }
}
