using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsStorage : UserDataService
{
    private const string lastGameKeyName = "last_saved_game_id";
    private const string defaultString = "";

    public List<GameData> getAllSavedGames()
    {
        List<GameData> savedData = new List<GameData>();
        foreach (GameSlot slotId in Enum.GetValues(typeof(GameSlot))) {
            string slotName = slotId.slotName();
            string jsonString = PlayerPrefs.GetString(slotName, defaultString);
            if (jsonString != defaultString) {                
                savedData.Add(JsonUtility.FromJson<GameData>(jsonString));
            }
        }
        return savedData;
    }

    public GameData? getLastPlayedGame()
    {
        string lastGameId = PlayerPrefs.GetString(lastGameKeyName, defaultString);
        if (lastGameId == defaultString) { 
            return null; 
        }
        else {
            string jsonString = PlayerPrefs.GetString(lastGameId);
            return JsonUtility.FromJson<GameData>(jsonString);
        }
    }

    public bool haveGameToContinue()
    {
        return !(PlayerPrefs.GetString(lastGameKeyName, defaultString) == defaultString);
    }

    public bool saveGame(GameData gameData) {
        try {
            string slotName = gameData.gameId.slotName();
            string json = JsonUtility.ToJson(gameData);

            PlayerPrefs.SetString(slotName, json);
            PlayerPrefs.SetString(lastGameKeyName, slotName);

            return true; 
        } 
        catch(PlayerPrefsException) { return false; }
        catch(ArgumentNullException) { return false; } 
        catch(ArgumentException) { return false; }
    }
}
