using System;

[Serializable]
public struct GameData
{
    public GameSlot gameId;
    public int coins;
    public long updatedAtTicks;

    public GameData(GameSlot gameId, int coins, long updatedAtTicks) {
        this.gameId = gameId;
        this.coins = coins;
        this.updatedAtTicks = updatedAtTicks;
    }
}
