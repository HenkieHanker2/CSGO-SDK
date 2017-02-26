namespace csgo.sdk
{
    public class Player
    { 
        public static bool onGround(int m_dwLocalPlayer, int Flags)
        {
            // Get LocalPlayer
            int Me = Memory.ReadInt(Game.Client + m_dwLocalPlayer);
            // Flags of current player
            int flag = Memory.ReadInt(Me + Flags);
            // Check if player is on ground
            if (flag < 263 && flag != 257)
            {
                // Not on ground
                return false;
            }
            else
            {
                // On ground
                return true;
            }
        }

        public static void ForceJump(int m_dwForceJump, bool Value)
        {
            if (Value == true)
            {
                // Make player jump
                Memory.WriteInt(Game.Client + m_dwForceJump, 4);
            } else {
                // Stop jumping
                Memory.WriteInt(Game.Client + m_dwForceJump, 5);
            }
        }

        public static void ForceAttack(int m_dwForceAttack, bool Value)
        {
            if (Value == true)
            {
                // Start Shooting
                Memory.WriteInt(Game.Client + m_dwForceAttack, 1);
            }
            else
            {
                // Stop Shooting
                Memory.WriteInt(Game.Client + m_dwForceAttack, 0);
            }
        }

        public static int WeaponID(int m_dwLocalPlayer, int m_hActiveWeapon)
        {
            // Get LocalPlayer
            int Me = Memory.ReadInt(Game.Client + m_dwLocalPlayer);
            // Get Active Weapon of current player
            int WeaponID = Memory.ReadInt(Me + m_hActiveWeapon);
            // Get Entity ID
            int WeaponEntID = WeaponID & 0xFFF;
            // Return ID
            return WeaponEntID;
        }

        public static bool inCross(int m_dwLocalPlayer, int m_dwEntityList, int m_iCrossHairID, int m_iTeamNum, int m_iHealth)
        {
            // Get LocalPlayer
            int Me = Memory.ReadInt(Game.Client + m_dwLocalPlayer);
            // Get Crosshair index
            int CrosshairIndex = Memory.ReadInt(Me + m_iCrossHairID);
            // Check if Entity is in Crosshair
            if (CrosshairIndex > 0 && CrosshairIndex <= 64)
            {
                // Get Entity in Crosshair
                int CrosshairEntity = Memory.ReadInt(Game.Client + m_dwEntityList + ((CrosshairIndex - 1) * 0x10));
                // Get Friendly Players
                int Friendly = Memory.ReadInt(Me + m_iTeamNum);
                // Get Team of entity
                int TeamEntity = Memory.ReadInt(CrosshairEntity + m_iTeamNum);
                // Get Health from Entity in Crosshair
                int EntityHealth = Memory.ReadInt(CrosshairEntity + m_iHealth);
                // Health Check and Friendly Check
                if (EntityHealth > 0 && Friendly != TeamEntity)
                {
                    // Enemey in crosshair
                    return true;
                }
            }
            // Friendly or Nothing in Crosshair
            return false;
        }

        public static void SetMaxFlashAlpha(int m_dwLocalPlayer, int m_flFlashMaxAlpha, float Value)
        {
            // Get LocalPlayer
            int Me = Memory.ReadInt(Game.Client + m_dwLocalPlayer);
            // Write Max Flasha Alpha to Engine
            Memory.WriteFloat(Me + m_flFlashMaxAlpha, Value);
        }

        public static float GetMaxFlashAlpha(int m_dwLocalPlayer, int m_flFlashMaxAlpha)
        {
            // Get LocalPlayer
            int Me = Memory.ReadInt(Game.Client + m_dwLocalPlayer);
            // Read Max Flasha Alpha from Engine
            return Memory.ReadFloat(Me + m_flFlashMaxAlpha);
        }
    }
}


