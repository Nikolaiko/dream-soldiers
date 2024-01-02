using System;

[Serializable]
public enum GameSlot
{
    gameOne,
    gameTwo,
    gameTree,
    gameFour
}

public static class GameSlotExtensions {
    public static string slotName(this GameSlot gameSlot) {
        switch(gameSlot) {
            case GameSlot.gameOne:
                return "Game 1";
            case GameSlot.gameTwo:
                return "Game 2";
            case GameSlot.gameTree:
                return "Game 3";
            case GameSlot.gameFour:
                return "Game 4";
            default:                
                return "Unknown Slot";
        }
    }
}

