using System.Collections.Generic;

public interface UserDataService
{
    bool haveGameToContinue();
    GameData getLastPlayedGame();
    List<GameData> getAllSavedGames();
}
