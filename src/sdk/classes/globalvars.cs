using SDK.dependencies.memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.src.sdk.classes {
    public class IGlobalVars {

        private long uBase = 0;
        public IGlobalVars(long adr) => uBase = adr;

        public int iMaxClients() => memory.Read<int>( uBase, 0x0010);

        public bool IsValid( ) =>
            uBase != 0;
    };
}
