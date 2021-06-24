﻿using NLua;

namespace ESO_Discord_RichPresence_Client
{
    class EsoCharacter
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }

        private int genderInt;
        public string Gender
        {
            get
            {
                switch (this.genderInt)
                {
                    case 1:
                        return "Female";
                    default:
                        return "Male";
                }
            }
        }

        private int allianceInt;
        public string Alliance
        {
            get
            {
                switch (this.allianceInt)
                {
                    case 1:
                        return "Aldmeri Dominion";
                    case 2:
                        return "Ebonheart Pact";
                    default:
                        return "Daggerfall Covenant";
                }
            }
        }
        public string ParentZone { get; set; }
        public string Zone { get; set; }
        public string SubZone { get; set; }

        public bool IsChampion { get; set; }
        public int Level { get; set; }
        
        public bool IsGrouped { get; set; }
        public int GroupSize { get; set; }

        private int groupRoleInt;
        public string GroupRole
        {
            get
            {
                switch (this.groupRoleInt)
                {
                    case 1:
                        return "DPS";
                    case 2:
                        return "Tank";
                    case 4:
                        return "Healer";
                    default:
                        return null;
                }
            }
        }

        public bool InDungeon { get; set; }
        public string Dungeon { get; set; }

        private int dungeonDifficultyInt;
        public string DungeonDifficulty
        {
            get
            {
                switch (this.dungeonDifficultyInt)
                {
                    case 1:
                        return "Normal";
                    case 2:
                        return "Veteran";
                    default:
                        return "";
                }
            }
        }

        public int Battlegrounds_GameType { get; set; }
        public string Battlegrounds_Name { get; set; }
        public string Battlegrounds_Description { get; set; }

        public string QuestName { get; set; }

        public EsoCharacter(LuaTable character)
        {
            this.Name = (string)character["name"];
            this.Account = (string)character["account"];
            this.Race = (string)character["race"];
            this.Class = (string)character["class"];
            this.genderInt = (int)(long)character["gender"];
            this.allianceInt = (int)(long)character["alliance"];
            this.ParentZone = (string)character["parentZone"];
            this.Zone = (string)character["zone"];
            this.SubZone = (string)character["subZone"];
            this.IsChampion = (bool)character["isChampion"];
            this.Level = (int)(long)character["level"];

            this.IsGrouped = (bool)character["isGrouped"];
            this.GroupSize = (int)(long)character["groupSize"];
            this.groupRoleInt = (int)(long)character["groupRole"];
            this.InDungeon = (bool)character["inDungeon"];
            this.dungeonDifficultyInt = (int)(long)character["isDungeonVeteran"];

            this.Battlegrounds_GameType = (int)(long)character["bg_GameType"];
            this.Battlegrounds_Name = (string)character["bg_Name"];
            this.Battlegrounds_Description = (string)character["bg_Description"];

            this.QuestName = (string)character["activeQuest"];

            if (this.InDungeon)
            {
                this.Dungeon = this.Zone;
                this.Zone = (string)character["parentZone"];
            }
        }
    }
}
