using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameLocalization
{
    SWAMPS,
    DUNGEON,
    CASTLE,
    CITY,
    TOWER
}

public class GameControlller : MonoBehaviour
{
    #region Singleton
    public static GameControlller Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private GameLocalization currentGameLocalization;

    public GameLocalization CurrentGameLocalization
    {
        get
        {
            return currentGameLocalization;
        }

        set
        {
            currentGameLocalization = value;
        }
    }


    public bool IsCurrentLocalization(GameLocalization localiztion)
    {
        return CurrentGameLocalization == localiztion;
    }
}
