using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public string name;
    public ushort level;
    public int experience;
    public int income;
    public List<Quest> quests;

    public PlayerData(string name, ushort level, int experience, int income, List<Quest> quests)
    {
        this.name = name;
        this.level = level;
        this.experience = experience;
        this.income = income;
        this.quests = quests;
    }
}

[Serializable]
public class Quest
{
    public string title;
    public string description;
    public bool isActive;

    public Quest(string title, string description, bool isActive = false)
    {
        this.title = title;
        this.description = description;
        this.isActive = isActive;
    }
}
