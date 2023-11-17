﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.src.offsets {

    /*
     * Created using https://github.com/a2x/cs2-dumper
     * Fri, 17 Nov 2023 15:04:57 +0000
    */

    public static class client_dll { // client.dll
        public const nint dwBaseEntityModel_setModel = 0x584250;
        public const nint dwEntityList = 0x17B0D00;
        public const nint dwForceBackward = 0x16B56E0;
        public const nint dwForceCrouch = 0x16B59B0;
        public const nint dwForceForward = 0x16B5650;
        public const nint dwForceJump = 0x16B5920;
        public const nint dwForceLeft = 0x16B5770;
        public const nint dwForceRight = 0x16B5800;
        public const nint dwGameEntitySystem = 0x18DC3E0;
        public const nint dwGameEntitySystem_getBaseEntity = 0x607820;
        public const nint dwGameEntitySystem_getHighestEntityIndex = 0x5F9550;
        public const nint dwGameRules = 0x180C9B0;
        public const nint dwGlobalVars = 0x16B14F0;
        public const nint dwGlowManager = 0x180C9D8;
        public const nint dwInterfaceLinkList = 0x190A078;
        public const nint dwLocalPlayerController = 0x1800018;
        public const nint dwLocalPlayerPawn = 0x16BC4B0;
        public const nint dwPlantedC4 = 0x1813F78;
        public const nint dwPrediction = 0x16BC380;
        public const nint dwViewAngles = 0x186E398;
        public const nint dwViewMatrix = 0x180F340;
        public const nint dwViewRender = 0x180FBC0;
    }

    public static class engine2_dll { // engine2.dll
        public const nint dwBuildNumber = 0x48A514;
        public const nint dwNetworkGameClient = 0x489AC0;
        public const nint dwNetworkGameClient_getLocalPlayer = 0xF0;
        public const nint dwNetworkGameClient_maxClients = 0x250;
        public const nint dwNetworkGameClient_signOnState = 0x240;
        public const nint dwWindowHeight = 0x540CE4;
        public const nint dwWindowWidth = 0x540CE0;
    }

    public static class inputsystem_dll { // inputsystem.dll
        public const nint dwInputSystem = 0x35760;
    }
}
