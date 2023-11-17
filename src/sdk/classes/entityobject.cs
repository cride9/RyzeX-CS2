using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.src.sdk.classes {
    public class entityobject {

        public long lgPlayerController;
        public long lgPlayerPawn;
        public int iIndex;

        public entityobject(long controller, long pawn, int index) { 
        
            lgPlayerController = controller;
            lgPlayerPawn = pawn;
            iIndex = index;
        }
    }
}
