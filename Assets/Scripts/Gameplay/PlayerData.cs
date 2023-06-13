using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public string name;
    public ushort level;
    public int experience;
    public int income;

    public PlayerData() {}
    public PlayerData(string name, ushort level, int experience, int income)
    {
        this.name = name;
        this.level = level;
        this.experience = experience;
        this.income = income;
    }
}
