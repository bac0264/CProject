using UnityEngine;
using System.Collections;

public class KeySave
{
    public const string IS_THE_FIRST_TIME = "IS_THE_FIRST_TIME";
    public const string ALL_RESOURCE = "ALL_RESOURCE";
    public const string DAILY_REWARD = "DAILY_REWARD";
    public const string STAGE_DATA = "STAGE_DATA";
    public const string INDEX_FREE_REWARD = "FreeReward";
    public const string CONTAINER_POPUP = "ContainerPopup";
    public const string SOUND = "SOUND";
    public const string MUSIC = "MUSIC";
    public const string HINT = "HINT";
    public const string CURRENT_SCENE = "CURRENT_SCENE";
    public const int SCEME_MENU = 0;
    public const int SCENE_STAGE = 1;
    public const int STAGE_AMOUNT = 6;
    public const int SIZE_OF_BLOCK = 12;
    public static int Get_Index_Block(int indexUnitStage)
    {
        int i = indexUnitStage / SIZE_OF_BLOCK;
        return i;
    }
    public static int Get_Index_UnitStage(int indexUnitStage)
    {
        int i = indexUnitStage % SIZE_OF_BLOCK;
        return i;
    }
}
