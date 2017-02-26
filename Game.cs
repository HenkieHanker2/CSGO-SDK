using System.Diagnostics;
using System.Runtime.InteropServices;
namespace csgo.sdk
{
    public class Game
    {
        [DllImport("kernel32.dll")]
        private static extern int OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        public static int TargetProcess;
        // Client.dll
        public static int Client;
        // Engine.dll
        public static int Engine;
    
        public static bool isRunning()
        {

            foreach (Process Proc in Process.GetProcesses())
            {
                // Check if Process name is csgo
                if (Proc.ProcessName.Equals("csgo"))
                {
                    // Set target Process if named csgo
                    TargetProcess = OpenProcess(2035711, false, Proc.Id);
                    // For Modules in Process
                    foreach (ProcessModule Module in Proc.Modules)
                    {
                        // Get Client.dll
                        if (Module.ModuleName.Equals("client.dll"))
                        {
                            Client = (int)Module.BaseAddress;
                        }
                        // Get Engine.dll
                        if (Module.ModuleName.Equals("engine.dll"))
                        {
                            Engine = (int)Module.BaseAddress;
                        }
                    }
                    // Return true if csgo is running
                    return true;
                }
            }
            // Return false if csgo is not running
            return false;
        }

        public static bool inGame(int m_dwClientState,int m_dwInGame) 
        {
            // Get Engine + Pointer
            int EngineBase = Memory.ReadInt(Engine + m_dwClientState);
            if (Memory.ReadInt(EngineBase + m_dwInGame) >= 6)
            {
                // Player is in game
                return true;
            }
            else
            {
                // Player is NOT in game
                return false;
            }
        }
    }
}
