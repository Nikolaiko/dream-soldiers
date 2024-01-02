using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsStorage : UserDataService
{
    public PlayerPrefsStorage() {        
        GameData g = new GameData(GameSlot.gameTwo, 6, DateTime.Now.Ticks);
        string json = JsonUtility.ToJson(g);
        Debug.Log(json);
    }

    public List<GameData> getAllSavedGames()
    {
        throw new System.NotImplementedException();
    }

    public GameData getLastPlayedGame()
    {
        throw new System.NotImplementedException();
    }

    public bool haveGameToContinue()
    {
        throw new System.NotImplementedException();
    }
}
