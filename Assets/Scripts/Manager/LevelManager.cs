using UnityEngine;

public enum UpLevelType
{
    DOWN, NONE, UP
}

public class LevelManager : SingletonPure<LevelManager>
{
    private const string KEY_SAVE_LEVEL = "save_wave";
    private const string KEY_SAVE_LEVEL_DISPLAY = "save_wave_display";
    public int Level = 1;
    public int LevelDisplay = 1;

    public void Start()
    {
        Level = PlayerPrefs.GetInt(KEY_SAVE_LEVEL, 1);  
        LevelDisplay = PlayerPrefs.GetInt(KEY_SAVE_LEVEL_DISPLAY, 1);
    }
    public int UpLevel(UpLevelType type)
    {
        if(type == UpLevelType.DOWN)
            Level --;
        else if(type == UpLevelType.UP)
            Level ++;

        LevelDisplay++;
        PlayerPrefs.SetInt(KEY_SAVE_LEVEL, Level);
        PlayerPrefs.SetInt(KEY_SAVE_LEVEL_DISPLAY, LevelDisplay);

        return Level;
    } 
}