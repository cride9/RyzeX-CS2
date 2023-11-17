using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.dependencies.memory {
    /// <summary>
    /// Information about the opened process.
    /// </summary>
    public class Proc {
        public Process Process { get; set; }
        public IntPtr Handle { get; set; }
        public bool Is64Bit { get; set; }
        //public ConcurrentDictionary<string, IntPtr> Modules { get; set; } // Use mProc.Process.Modules instead
        public ProcessModule MainModule { get; set; }
    }
}
