using SDK.dependencies.memory;
using SDK.src.offsets;
using SDK.src.sdk.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.src.sdk {
    public static class globals {

        public static long uEntityList;
        public static long uViewMatrix;
        public static IGlobalVars? uGlobalVariables;

        public static long uLocalController;
        public static CBaseEntity? uLocalPawn;

        public static bool Initialize( ) {

            uEntityList = memory.Read<long>( DLL.CLIENT, client_dll.dwEntityList );
            uViewMatrix = memory.Read<long>( DLL.CLIENT, client_dll.dwViewMatrix );
            uGlobalVariables = new( memory.Read<long>( DLL.CLIENT, client_dll.dwGlobalVars ) );

            uLocalController = memory.Read<long>( DLL.CLIENT, client_dll.dwLocalPlayerController );
            uLocalPawn = new( entities.GetPlayerPawn( memory.Read<long>( uLocalController + CCSPlayerController.m_hPlayerPawn ) ) );

            return true;
        }
    }
}
