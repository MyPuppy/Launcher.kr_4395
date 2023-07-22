using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using System.Net;
using Set_Data;

namespace KartRider
{
    public static class GameSupport
    {
        public static void PcFirstMessage()
        {
            uint first_val = 2919676295;
            uint second_val = 263300380;
            using (OutPacket outPacket = new OutPacket("PcFirstMessage"))
            {
                outPacket.WriteUShort(SessionGroup.usLocale);
                outPacket.WriteUShort(1);
                outPacket.WriteUShort(Program.Version);
                outPacket.WriteString("http://kart.dn.nexoncdn.co.kr/patch");
                outPacket.WriteUInt(first_val);
                outPacket.WriteUInt(second_val);
                outPacket.WriteByte(SessionGroup.nClientLoc);
                outPacket.WriteString("QyvKvO60jogWDupzJ7gm0kRQdooFjWRjSjlq0gu/x2k=");
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 0F 00 00 00 00 00 00 00 00 2E 31 2E 31 37 2E 36 00 00 00 00 00 00 00");
                outPacket.WriteString("GXQstj1A95XiHvjrOGuPkzdyL+7qxETl/cPlUZk2KA4=");
                RouterListener.MySession.Client.Send(outPacket);
            }
            RouterListener.MySession.Client._RIV = first_val ^ second_val;
            RouterListener.MySession.Client._SIV = first_val ^ second_val;
        }

        public static void OnDisconnect()
        {
            RouterListener.MySession.Client.Disconnect();
        }

        public static void SpRpLotteryPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpLotteryPacket"))
            {
                outPacket.WriteHexString("05 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrGetGameOption()
        {
            using (OutPacket outPacket = new OutPacket("PrGetGameOption"))
            {
                outPacket.WriteFloat(SetGameOption.Set_BGM);
                outPacket.WriteFloat(SetGameOption.Set_Sound);
                outPacket.WriteByte(SetGameOption.Old_BGM);
                outPacket.WriteByte(SetGameOption.Sound_effect);
                outPacket.WriteByte(SetGameOption.Full_screen);
                outPacket.WriteByte(SetGameOption.Unk1);
                outPacket.WriteByte(SetGameOption.Unk2);
                outPacket.WriteByte(SetGameOption.Unk3);
                outPacket.WriteByte(SetGameOption.Unk4);
                outPacket.WriteByte(SetGameOption.Unk5);
                outPacket.WriteByte(SetGameOption.Unk6);
                outPacket.WriteByte(SetGameOption.Unk7);
                outPacket.WriteByte(SetGameOption.Unk8);
                outPacket.WriteByte(SetGameOption.Unk9);
                outPacket.WriteByte(SetGameOption.Unk10);
                outPacket.WriteByte(SetGameOption.Unk11);
                outPacket.WriteByte(SetGameOption.BGM_Check);
                outPacket.WriteByte(SetGameOption.Sound_Check);
                outPacket.WriteByte(SetGameOption.Unk12);
                outPacket.WriteByte(SetGameOption.Unk13);
                outPacket.WriteBytes(new byte[40]);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRpEnterMyRoomPacket()
        {
            if (GameType.EnterMyRoomType == 0)
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString(SetRider.Nickname);
                    outPacket.WriteByte(0);
                    outPacket.WriteShort(SetMyRoom.MyRoom);
                    outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(SetMyRoom.UseItemPwd);
                    outPacket.WriteString(SetMyRoom.RoomPwd);
                    outPacket.WriteString("");
                    outPacket.WriteString(SetMyRoom.ItemPwd);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
            else
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString("");
                    outPacket.WriteByte(GameType.EnterMyRoomType);
                    outPacket.WriteShort(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(1);
                    outPacket.WriteString("");//RoomPwd
                    outPacket.WriteString("");
                    outPacket.WriteString("");//ItemPwd 
                    outPacket.WriteShort(0);
                    outPacket.WriteShort(0);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
        }

        public static void RmNotiMyRoomInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("RmNotiMyRoomInfoPacket"))
            {
                outPacket.WriteShort(SetMyRoom.MyRoom);
                outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                outPacket.WriteByte(0);
                outPacket.WriteByte(SetMyRoom.UseItemPwd);
                outPacket.WriteString(SetMyRoom.RoomPwd);
                outPacket.WriteString("");
                outPacket.WriteString(SetMyRoom.ItemPwd);
                outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrGetRiderInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrGetRiderInfo"))
            {
                outPacket.WriteByte(1);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteString(SetRider.Nickname);
                outPacket.WriteHexString("3C 9A 17 43");//2008.02.08
                for (int i = 1; i <= Program.MAX_EQP_P; i++)
                {
                    outPacket.WriteShort(0);
                }
                outPacket.WriteByte(0);
                outPacket.WriteString("");
                outPacket.WriteInt(SetRider.RP);
                outPacket.WriteInt(0);
                outPacket.WriteByte(6);//Licenses
                outPacket.WriteHexString(Program.DataTime);
                outPacket.WriteBytes(new byte[16]);
                outPacket.WriteShort(SetRider.Emblem1);
                outPacket.WriteShort(SetRider.Emblem2);
                outPacket.WriteShort(0);
                outPacket.WriteString(SetRider.RiderIntro);
                outPacket.WriteInt(SetRider.Premium);
                outPacket.WriteByte(1);
                if (SetRider.Premium == 0)
                    outPacket.WriteInt(0);
                else if (SetRider.Premium == 1)
                    outPacket.WriteInt(10000);
                else if (SetRider.Premium == 2)
                    outPacket.WriteInt(30000);
                else if (SetRider.Premium == 3)
                    outPacket.WriteInt(60000);
                else if (SetRider.Premium == 4)
                    outPacket.WriteInt(120000);
                else if (SetRider.Premium == 5)
                    outPacket.WriteInt(200000);
                else
                    outPacket.WriteInt(0);
                if (SetRider.ClubMark_LOGO == 0)
                {
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteString("");
                }
                else
                {
                    outPacket.WriteInt(SetRider.ClubCode);
                    outPacket.WriteInt(SetRider.ClubMark_LOGO);
                    outPacket.WriteString(SetRider.ClubName);
                }
                outPacket.WriteInt(0);
                outPacket.WriteByte(SetRider.Ranker);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteByte(0);
                outPacket.WriteByte(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrCheckMyClubStatePacket()
        {
            using (OutPacket outPacket = new OutPacket("PrCheckMyClubStatePacket"))
            {
                if (SetRider.ClubMark_LOGO == 0)
                {
                    outPacket.WriteInt(0);
                    outPacket.WriteString("");
                    outPacket.WriteInt(0);
                }
                else
                {
                    outPacket.WriteInt(SetRider.ClubCode);
                    outPacket.WriteString(SetRider.ClubName);
                    outPacket.WriteInt(SetRider.ClubMark_LOGO);
                }
                outPacket.WriteShort(5);//Grade
                outPacket.WriteString(SetRider.Nickname);
                outPacket.WriteInt(1);//ClubMember
                outPacket.WriteByte(5);//Level
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRequestChStaticReplyPacket()
        {
            using (OutPacket outPacket = new OutPacket("ChRequestChStaticReplyPacket"))
            {
                outPacket.WriteHexString("01 50 03 00 00 53 01 B8 BA BE FD F8 0F 00 00 78 DA A5 97 D9 53 DB 30 10 87 B7 90 00 85 DC 4E 42 12 20 40 EF 03 5A 5A E8 5D 3A E3 00 ED F0 D0 3E 40 DF 3B 40 02 65 C8 C1 24 A1 94 FE F5 FD AD 84 26 B6 23 5B 0A D8 33 B2 2D 7F 7B 68 B5 96 D6 9B 44 74 37 89 A6 47 E7 D4 C0 59 A7 9F 68 0F A8 45 5F D1 F6 A8 4F 63 13 78 DD A2 2B DA A3 0E CE 16 8D A7 D1 71 8A 37 0D 3C FC 40 7B 49 BB D7 4F 4A 36 16 8E EC 52 1B 46 4E 29 5E 35 6A 51 1E 34 44 FB 9A 76 20 7A 44 BF D1 DB C6 F3 44 D5 68 23 5A C1 64 C1 E8 81 EC 3D 04 D5 A0 A9 82 D1 9E 17 9F F6 47 35 E8 D2 4C 26 32 E8 D2 E3 44 26 52 87 84 92 69 AD 26 AF 2F A9 B4 56 8F 17 49 3B 91 FE 78 D1 8C 13 E9 95 17 CD CE 02 3D A1 0B 3C 34 05 24 E3 E5 9F 07 7F 2C 73 59 9F C8 C0 8E 7F D4 4E 0A 98 D4 D1 02 72 8A CC 6C E3 05 E7 E8 15 FA 9A 94 E7 B4 3D C4 6D 1F 67 13 52 85 29 74 1C E3 F6 00 EA D5 F8 8A DE 4E 35 92 59 7D D8 F9 7A 8C 6B 5B 8C A3 A4 9F 40 3F 54 4E 78 72 E6 FB 75 B7 D2 57 D1 BD 54 7A E6 4A C2 FD 0E 9D A1 BD 80 83 F2 7E 37 32 FF E6 47 11 52 96 16 72 5A A1 FD A1 F1 57 4D A0 D2 B8 58 B6 D4 E8 0F D6 52 D9 52 BF 5F 6C B9 1A 39 E8 5F C8 92 2E C4 FE 21 2F F4 01 B8 97 16 19 D7 15 E9 58 87 B5 2E F4 FE 85 E0 60 76 EF 17 B5 19 B1 2F F2 AF 0E 7B 97 01 A7 1E 14 B5 D9 11 2E F0 B0 10 E2 84 7F 34 CA F2 A3 62 24 3E 1C EA C7 8E 71 90 0A 7D 52 0E 41 A3 17 BF A7 A3 89 A9 90 3C AB 58 3B E6 8F D8 F3 25 6B C1 F0 B0 AF 98 AD EB B3 6E 95 27 A0 2F 16 B9 2E 3E 5E 5E 66 78 35 E2 D7 27 5A 1F 5E D8 0A 28 7B 2F E7 23 05 A2 27 63 ED 26 C2 CA F2 2B 76 F5 8F 10 ED E1 8B EA 41 41 07 5A 1B 42 50 BB B3 C6 C4 62 DC 04 7C 48 EB 29 CF C3 1E B8 23 21 39 18 E0 46 52 0B 28 9F DE E8 37 CE 6F 62 6A CE E9 2D 7F AD 5D 38 C4 13 5A 83 96 0E E4 CF 7C 06 DE A5 42 10 65 E2 3D 03 75 31 DA 3E A2 32 88 8F 8A C0 07 B9 61 F6 C5 63 53 40 C1 08 7F CC 0C 21 C3 5F DD A7 9C 67 89 F7 26 12 F7 C8 B4 EB 0B 81 CF 5E D0 9B EF 41 70 D3 09 DD 76 82 E8 17 27 74 1B 0B A2 CB 20 EF D0 64 60 C7 74 29 4F 5C 1F D2 6D 4B B5 38 AB 19 13 17 35 EF 2E 20 1C E3 94 8A 4C 06 97 36 18 8B 51 DA 90 54 2E AD 33 18 27 73 E5 C9 C9 4A 13 74 DB F2 91 EB 0B 84 6C B4 AA 90 CB 0D 34 E6 0A 7A 9C C1 69 1A AD 44 E5 09 A4 19 11 D2 F0 FA CC 85 5A 1C 09 03 56 93 58 92 B2 16 35 A8 4B 5C CB 40 63 D6 A2 72 72 89 AB 42 C4 C0 06 AE 49 38 63 05 6F 49 38 6B 05 6F 4B 38 47 E6 E2 98 23 45 4E 20 60 C1 D4 77 F1 A1 E0 C8 1B B0 9A C4 0A 01 1F F5 1F 92 8B D9 C4 51 B4 82 6B 12 9E B5 82 B7 24 5C 0A 81 83 33 C6 85 25 95 AD E0 9A 84 2B 56 F0 96 84 E7 AC E0 6D 09 CF 93 F9 8F 87 F7 10 5A 20 FB 9F 1A 56 89 25 C1 FE D7 86 97 7F 5A A4 51 CB 80 55 16 5B A2 DB 6C CF 6B AC 62 99 6E 5A B9 AC B0 F8 7F 0D C5 BA B9");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrDynamicCommand()
        {
            using (OutPacket outPacket = new OutPacket("PrDynamicCommand"))
            {
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrQuestUX2ndPacket()
        {
            int NormalQuest = 23;
            using (OutPacket outPacket = new OutPacket("PrQuestUX2ndPacket"))
            {
                outPacket.WriteInt(NormalQuest);
                for (int i = 427; i <= 449; i++)
                {
                    outPacket.WriteInt(i);
                    outPacket.WriteInt(i);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                }
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrLogin()
        {
            using (OutPacket outPacket = new OutPacket("PrLogin"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteHexString(Program.DataTime);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteByte(2);
                outPacket.WriteByte(1);
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteInt(1415577599);
                outPacket.WriteUInt(SetRider.pmap);
                for (int i = 0; i < 11; i++)
                {
                    outPacket.WriteInt(0);
                }
                outPacket.WriteByte(0);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39311);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39312);
                outPacket.WriteInt(0);
                outPacket.WriteString("");
                outPacket.WriteInt(0);
                outPacket.WriteByte(1);
                outPacket.WriteString("content");
                outPacket.WriteInt(0);
                outPacket.WriteInt(1);
                outPacket.WriteString("cc");
                outPacket.WriteString(SessionGroup.Service);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
    }
}
