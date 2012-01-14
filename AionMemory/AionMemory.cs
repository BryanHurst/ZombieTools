using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MemoryLib;

//Reflects Aion v1.0.8 Client

namespace AionMemory
{
    public struct AionPlayer
    {
        public string Name;//Player Name
        public byte Level; //Player Level
        public byte Cast;  //Player Cast (0 is casting nothing, otherwise this value is the spellid)
        public int ID;     //Player GUID
        public int XP;     //Player Experience
        public int XPmax;  //Player Max Experience (next level)
        public int HP;     //Player Current HP
        public int HPmax;  //Player Maximum HP
        public int MP;     //Player Current MP
        public int MPmax;  //Player Maximum MP
        public Int16 DP;   //Player Current DP
        public Int16 DPmax;//Player Maximum DP
        public int CB;     //Player Current Inventory
        public int CBmax;  //Player Maximum Inventory
        public int Kinah;  //Player Kinah
        public float Xloc; //Player X Coordinate
        public float Yloc; //Player Y Coordinate
        public float Zloc; //Player Z Coordinate
        public string Region;  //Player Region (Current Zone, read bytes until \n)
        public float Rotation; //Player Rotation
        public int KinahPtr;   //Pointer to Kinah (offset 0x138 from this address)
        public string Macro1;  //Macro1 Text
        public AionInventory Inventory; //Player Inventory
    }

    public struct AionTarget
    {
        public string Name;    //Target Name
        public byte Level;     //Target Level
        public byte HP;        //Target HP (%)
        public int Type;       //Target Type
        public int Attitude;   //Target Attitude
        public int State;      //Target State
        public int ID;         //Target GUID
        public byte Live;      //Target Alive?
        public int HasTarget; //Target Has Target?
        public int TargetID;   //GUID of Target's Target
        public float Xloc;     //Target X Coordinate
        public float Yloc;     //Target Y Coordinate
        public float Zloc;     //Target Z Coordinate
        public int TargetPtr;  //Pointer to Target
        public int EntityPtr;  //Pointer to Entity

    }

    public struct AionInventory
    {
        public int Ptr;     //Pointer to Inventory
    }

    public struct AionChat
    {

    }

            /*-----Class for Reading Memory-----*/
    /*---Methods are broken up to coincide with structs*/
    public class AionUpdate
    {
        public static void Player(ref AionPlayer structure)
        {
            structure.KinahPtr = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8E3934));
            structure.Name = ReadUnicodeString(AionProcess.AionHandle, (AionProcess.GameDLL + 0x923F94), 40);
            structure.Macro1 = ReadUnicodeString(AionProcess.AionHandle, AionProcess.Macro1ADDR, 255);
            structure.Level = Memory.ReadByte(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEE98));
            structure.Cast = Memory.ReadByte(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8E4CC0));
            structure.ID = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8E444C));
            structure.XP = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEEB0));
            structure.XPmax = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEEA0));
            structure.HP = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEEC0));
            structure.HPmax = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEEBC));
            structure.MP = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEEC8));
            structure.MPmax = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEEC4));
            structure.DP = Memory.ReadShort(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEECE));
            structure.DPmax = Memory.ReadShort(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEECC));
            structure.CB = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEF00));
            structure.CBmax = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8EEF04));
            structure.Kinah = Memory.ReadInt(AionProcess.AionHandle, (structure.KinahPtr + 0x138));
            structure.Xloc = Memory.ReadFloat(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8E6948));
            structure.Yloc = Memory.ReadFloat(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8E694C));
            structure.Zloc = Memory.ReadFloat(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8E6950));
            structure.Region = ReadUnicodeString(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8E6D70),40);
            structure.Rotation = Memory.ReadFloat(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8E40D4));
        }

        public static void Target(ref AionTarget structure)
        {
            structure.TargetPtr = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x4F68FC));
            structure.EntityPtr = Memory.ReadInt(AionProcess.AionHandle, (structure.TargetPtr + 0x1C4));
            structure.Name = ReadUnicodeString(AionProcess.AionHandle, (structure.EntityPtr + 0x36),40);
            structure.Level = Memory.ReadByte(AionProcess.AionHandle, (structure.EntityPtr + 0x32));
            structure.HP = Memory.ReadByte(AionProcess.AionHandle, (structure.EntityPtr + 0x34));
            structure.Type = Memory.ReadInt(AionProcess.AionHandle, (structure.EntityPtr + 0x18));
            structure.Attitude = Memory.ReadInt(AionProcess.AionHandle, (structure.EntityPtr + 0x1C));
            structure.State = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x4F690C));
            structure.ID = Memory.ReadInt(AionProcess.AionHandle, (structure.EntityPtr + 0x20));
            structure.Live = Memory.ReadByte(AionProcess.AionHandle, (structure.TargetPtr + 0x8));
            structure.HasTarget = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x4F68FC));
            structure.TargetID = Memory.ReadInt(AionProcess.AionHandle, (structure.EntityPtr + 0x284));
            structure.Xloc = Memory.ReadFloat(AionProcess.AionHandle, (structure.TargetPtr + 0x28));
            structure.Yloc = Memory.ReadFloat(AionProcess.AionHandle, (structure.TargetPtr + 0x2C));
            structure.Zloc = Memory.ReadFloat(AionProcess.AionHandle, (structure.TargetPtr + 0x30));
        }

        public static void Inventory(ref AionPlayer structure)
        {
            //pass player structure in, and update the AionInventory element only.
        }

        public static void Chat(ref AionChat structure)
        {

        }

        public static string ReadUnicodeString(IntPtr process, long address, int size)
        {
            byte[] buf = new byte[size];
            UnicodeEncoding enc = new UnicodeEncoding();
            Memory.ReadMemory(process, address, ref buf, size);
            string ret = enc.GetString(buf);
            return ret;
        }

        public static void WriteMacro1(string input)
        {
            UnicodeEncoding unicode = new UnicodeEncoding();
            byte[] unicodeBytes = unicode.GetBytes(input);
            Memory.WriteMemory(AionProcess.AionHandle, AionProcess.Macro1ADDR, unicodeBytes);
        }

        public static void ReadMacro1(ref AionPlayer structure)
        {
            structure.Macro1 = ReadUnicodeString(AionProcess.AionHandle, AionProcess.Macro1ADDR, 255);
        }
    }
           /*-----Class for Process Handling-----*/
    public class AionProcess
    {
         public static int pid;
         public static IntPtr AionHandle;
         public static int GameDLL;
         public static int Macro1ADDR;

        public static bool Open()
        {
            pid = System.Diagnostics.Process.GetProcessesByName("Aion.bin")[0].Id;
            AionHandle = Memory.OpenProcess(pid);

            if((int)AionHandle != 0){
                return true;
            }
                return false;
        }

        public static bool Close()
        {
            return Memory.CloseHandle(AionProcess.AionHandle);
        }

        public static bool GetGameDLLBase()
        {

            Process[] HandleP = Process.GetProcessesByName("AION.bin");

            foreach (ProcessModule Module in HandleP[0].Modules)
            {
                if ("Game.dll" == Module.ModuleName)
                {
                    GameDLL = Module.BaseAddress.ToInt32();
                    return true;
                }
            }
            return false;
        }

        public static void GetMacro1Addr()
        {
            int addr = 0;
            addr = Memory.ReadInt(AionProcess.AionHandle, (AionProcess.GameDLL + 0x8E3934),false);
            addr = Memory.ReadInt(AionProcess.AionHandle, (addr + 0x7B0),false);
            addr = Memory.ReadInt(AionProcess.AionHandle, (addr + 0x0),false);
            addr = Memory.ReadInt(AionProcess.AionHandle, (addr + 0x10),false);
            addr = Memory.ReadInt(AionProcess.AionHandle, (addr + 0x9C),false);
            addr = Memory.ReadInt(AionProcess.AionHandle, (addr + 0x0),false);
            addr += 0x04;

            Macro1ADDR = addr;
        }

        public static int GetModuleBase(string modulename)
        {

            Process[] HandleP = Process.GetProcessesByName("AION.bin");

            foreach (ProcessModule Module in HandleP[0].Modules)
            {
                if (modulename == Module.ModuleName)
                {
                    return Module.BaseAddress.ToInt32();
                }
            }
            return 0;
        }
    }
}
