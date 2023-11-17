using SDK.dependencies.memory;
using SDK.src.offsets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SDK.src.sdk {
    public static class entities {

        public static List<CBaseEntity> entityAddresses = new( );
        public static long GetBaseEntity( uint nIdx ) {

            long uListEntry = memory.Read<long>( globals.uEntityList + ( 0x8 * ( nIdx & 0x7FFF ) >> 9 ) + 16 );
            if ( uListEntry == 0 )
                return 0!;

            long pEntity = memory.Read<long>( uListEntry + 120 * ( nIdx & 0x1FF ) );
            return pEntity;
        }
        public static long GetPawnAddress( long uEntity ) {

            int uPlayerPawn = memory.Read<int>( uEntity, CCSPlayerController.m_hPlayerPawn );
            return GetPlayerPawn( uPlayerPawn );
        }
        public static long GetPlayerPawn( long uPawnHandle ) {

            long uListEntry = memory.Read<long>( globals.uEntityList + 0x8 * ( ( uPawnHandle & 0x7FFF ) >> 9 ) + 16 );
            if ( uListEntry == 0 )
                return 0;

            long uCSPlayerPawn = memory.Read<long>( uListEntry + 120 * ( uPawnHandle & 0x1FF ) );
            return uCSPlayerPawn;
        }
        public static void GetEntities() {

            for ( uint i = 0; i < globals.uGlobalVariables.iMaxClients(); i++ ) {

                entityAddresses.Clear( );

                long uBaseEntity = GetBaseEntity( i );
                if (uBaseEntity == 0 ) continue;

                long uPlayerPawn = GetPawnAddress( uBaseEntity );
                if (uPlayerPawn == 0 ) continue;

                entityAddresses.Add( new( uPlayerPawn ) );
            }
        }
        public static void GetEntities( List<CBaseEntity> entityList ) {

            entityList.Clear( );
            for ( uint i = 0; i < globals.uGlobalVariables!.iMaxClients( ); i++ ) {

                long uBaseEntity = GetBaseEntity( i );
                if ( uBaseEntity == 0 ) continue;

                long uPlayerPawn = GetPawnAddress( uBaseEntity );
                if ( uPlayerPawn == 0 ) continue;

                entityList.Add( new( uPlayerPawn ) );
            }
        }
    }

    public class CBaseEntity {

        public long uBaseAdr;
        public CBaseEntity( long _ ) => uBaseAdr = _;
        public T GetT<T>( nint _ ) => memory.Read<T>( uBaseAdr, _ );
        public T GetT<T>( long _ ) => memory.Read<T>( uBaseAdr, _ );
        public long GetBodyComponent() => GetT<long>( C_BaseEntity.m_CBodyComponent );
        public long GetRenderComponent( ) => GetT<long>( C_BaseEntity.m_pRenderComponent );
        public long GetCollision( ) => GetT<long>( C_BaseEntity.m_pCollision );
        public int GetMaxHealth( ) => GetT<int>( C_BaseEntity.m_iMaxHealth );
        public int GetHealth( ) => GetT<int>( C_BaseEntity.m_iHealth );
        public int GetLifeState( ) => GetT<int>( C_BaseEntity.m_lifeState );
        public int GetEFlags( ) => GetT<int>( C_BaseEntity.m_iEFlags );
        public long GetSubClassID( ) => GetT<long>( C_BaseEntity.m_nSubclassID );
        public int GetSimulationTick( ) => GetT<int>( C_BaseEntity.m_nSimulationTick );
        public float GetSimulationTime( ) => GetT<float>( C_BaseEntity.m_flSimulationTime );
        public int GetTeam( ) => GetT<int>( C_BaseEntity.m_iTeamNum );
        public int GetFlags( ) => GetT<int>( C_BaseEntity.m_fFlags );
        public float[ ] GetAbsVelocity( ) => new float[ ] { 
            GetT<float>( C_BaseEntity.m_vecAbsVelocity ), 
            GetT<float>( C_BaseEntity.m_vecAbsVelocity + sizeof( float ) ), 
            GetT<float>( C_BaseEntity.m_vecAbsVelocity + sizeof( float ) * 2 ) 
        };
        public float[ ] GetVelocity( ) => new float[ ] {
            GetT<float>( C_BaseEntity.m_vecVelocity),
            GetT<float>( C_BaseEntity.m_vecVelocity + sizeof( float ) ),
            GetT<float>( C_BaseEntity.m_vecVelocity + sizeof( float ) * 2 )
        };
        public double[ ] GetOldOrigin( ) => new double[ ] {
            GetT<double>( C_BasePlayerPawn.m_vOldOrigin),
            GetT<double>( C_BasePlayerPawn.m_vOldOrigin + sizeof( double ) ),
            GetT<double>( C_BasePlayerPawn.m_vOldOrigin + sizeof( double ) * 2 )
        };
        public int GetMoveType( ) => GetT<int>( C_BaseEntity.m_MoveType );
        public int GetEffects( ) => GetT<int>( C_BaseEntity.m_fEffects );
        public long GetGroundEntity( ) => GetT<long>( C_BaseEntity.m_hGroundEntity );
        public bool IsSimuationTimeCHanged( ) => GetT<bool>( C_BaseEntity.m_bSimulationTimeChanged );
        public long GetSceneNode( ) => memory.Read<long>( C_BaseEntity.m_pGameSceneNode ); // thats equalent to ( this + offset )
        public double[ ] GetAbsOrigin( ) => new double[ ] {
            memory.Read<double>(GetSceneNode() + CGameSceneNode.m_vecAbsOrigin),
            memory.Read<double>(GetSceneNode() + CGameSceneNode.m_vecAbsOrigin + 0x4),
            memory.Read<double>(GetSceneNode() + CGameSceneNode.m_vecAbsOrigin + 0x8)
        };

        public bool IsValid( ) => uBaseAdr != 0;
    }
}
