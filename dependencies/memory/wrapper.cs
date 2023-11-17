using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SDK.dependencies.memory {

    public class memory {
        
        private static Mem Memory = new Mem();

        private static string[ ] Modules = { "client.dll", "engine2.dll" };
        public static string _( int iNumber ) => ( ( $"0x{iNumber:X}" ) );
        public static string _( long lgNumber ) => ( ( $"0x{lgNumber:X}" ) );

        private static Dictionary<Type, string> dicTypes = new Dictionary<Type, string>( ) {
            { typeof(float), "float" },
            { typeof(int), "int" },
            { typeof(string), "string" },
            { typeof(double), "double" },
            { typeof(long), "long" },
        };

        private string szAddress = string.Empty;
        /* Address decleration (every possible solution) */
        public memory( string input ) =>
            szAddress = input;
        public memory( DLL iModule, long uOffset ) =>
            szAddress = $"{Modules[ ( int )iModule ]}+{_( uOffset )}";
        public memory( long uBase, long uOffset ) =>
            szAddress = _( uBase + uOffset );
        public memory( long uBase ) =>
            szAddress = _( uBase );

        /* Decleared address functions (dynamic) */
        public T Read<T>( ) => Memory.ReadMemory<T>( szAddress );
        public bool Write<T>( long lgNumber ) => Memory.WriteMemory( szAddress, dicTypes[ typeof( T ) ], lgNumber.ToString( ) );
        public bool Write<T>( float flValue ) => Memory.WriteMemory( szAddress, dicTypes[ typeof( T ) ], flValue.ToString( ) );
        public bool Write<T>( double dbValue ) => Memory.WriteMemory( szAddress, dicTypes[ typeof( T ) ], dbValue.ToString( ) );

        /* Non-decleared address functions (static) */
        public static T Read<T>( string read ) => Memory.ReadMemory<T>( read );
        public static T Read<T>( long uOffset ) => Memory.ReadMemory<T>( $"{_( uOffset )}" );
        public static T Read<T>( long uOffset, long uPadding ) => Memory.ReadMemory<T>( $"{_( uOffset + uPadding )}" );
        public static T Read<T>( DLL iModule, long uOffset ) => Memory.ReadMemory<T>( $"{Modules[ ( int )iModule ]}+{_( uOffset )}" );
        public static bool Write<T>( DLL iModule, long uOffset, long value ) => Memory.WriteMemory( $"{Modules[ ( int )iModule ]}+{_( uOffset )}", dicTypes[ typeof( T ) ], value.ToString( ) );
        public static bool Write<T>( DLL iModule, long uOffset, float value ) => Memory.WriteMemory( $"{Modules[ ( int )iModule ]}+{_( uOffset )}", dicTypes[ typeof( T ) ], value.ToString( ) );
        public static bool Write<T>( DLL iModule, long uOffset, double value ) => Memory.WriteMemory( $"{Modules[ ( int )iModule ]}+{_( uOffset )}", dicTypes[ typeof( T ) ], value.ToString( ) );
        public static Task<IEnumerable<long>> PatternScan( DLL iModule, string szPattern ) => Memory.AoBScan( szPattern, false, true, Modules[ ( int )iModule ] );
        public static bool AttachToGame(string szGameName) {

            while ( Memory.GetProcIdFromName( szGameName ) == 0 )
                continue;

            Memory.OpenProcess( Memory.GetProcIdFromName( szGameName ) );

            return true;
        }
    }
    public enum DLL {

        CLIENT,
        ENGINE
    }
}
