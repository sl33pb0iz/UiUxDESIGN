using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicInfoService
{
    private string _name;
    private string _id;
    private int _level;
    private int _experience;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Experience
    {
        get { return _experience; }
        set { _experience = value; }
    }

    public void IncreaseExperience(int amount)
    {
        _experience += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int experienceNeededForNextLevel = CalculateExperienceForNextLevel();
        if (_experience >= experienceNeededForNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        int experienceNeededForNextLevel = CalculateExperienceForNextLevel();
        _level++;
        _experience -= experienceNeededForNextLevel;
        Debug.Log("Level up! Current level: " + _level);
    }

    private int CalculateExperienceForNextLevel()
    {
        return (_level * 100); 
    }

    public void SetPlayerInfo(string name, string id, int level, int experience)
    {
        _name = name;
        _id = id;
        _level = level;
        _experience = experience;
    }

    public string GetPlayerInfoAsString()
    {
        return "Name: " + _name + ", ID: " + _id + ", Level: " + _level + ", Experience: " + _experience;
    }

    public int GetExperienceForNextLevel()
    {
        return CalculateExperienceForNextLevel();
    }
}
