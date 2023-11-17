using SDK.dependencies.memory;
using SDK.src.offsets;
using SDK.src.sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.src.movement {
    public class bunnyhop {

        public bool bStopThread = false;
        public static Thread Thread;

        private static memory forceJump = new memory( DLL.CLIENT, client_dll.dwForceJump );

        public bunnyhop( ) => Thread = new Thread( BunnyHop ) { Priority = ThreadPriority.Highest };

        public void Run( bool bCurrentCheckbox ) {

            if ( bCurrentCheckbox && Thread.ThreadState == ThreadState.Suspended )
                Thread.Resume( );
            else if ( Thread.ThreadState == ThreadState.Running && !bCurrentCheckbox )
                Thread.Suspend( );
            else if ( Thread.ThreadState == ThreadState.Unstarted && bCurrentCheckbox )
                Thread.Start( );
        }

        public void BunnyHop( ) {

            while ( true ) {

                Thread.Sleep( 1 );
                if ( functions.GetAsyncKeyState( Keys.Space ) >= 0 || !globals.uLocalPawn.IsValid( ) )
                    continue;

                int iFlags = globals.uLocalPawn.GetFlags( );
                bool bIsOnGround = iFlags == 65665 || iFlags == 65667;

                if ( bIsOnGround ) {

                    Thread.Sleep( 1 );
                    forceJump.Write<int>( 65536 );
                    Thread.Sleep( 20 );
                    forceJump.Write<int>( 256 );
                }
                else {

                    forceJump.Write<int>( 256 );
                }
            }
        }
    }
}
