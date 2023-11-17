using SDK.src.sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.src.esp {
    public class playeresp {

        public bool bStopThread = false;
        public static Thread Thread;
        public playeresp( ) => Thread = new Thread( ESP ) { Priority = ThreadPriority.Highest };

        public void Run( bool bCurrentCheckbox ) {

            if ( bCurrentCheckbox && Thread.ThreadState == ThreadState.Suspended )
                Thread.Resume( );
            else if ( Thread.ThreadState == ThreadState.Running && !bCurrentCheckbox )
                Thread.Suspend( );
            else if ( Thread.ThreadState == ThreadState.Unstarted && bCurrentCheckbox )
                Thread.Start( );
        }

        public void ESP() {

            while ( true ) {

                //const bool bIsEnemy = globals.uLocalPlayerPawn.GetTeam() == ;
            }
        }
    }
}
