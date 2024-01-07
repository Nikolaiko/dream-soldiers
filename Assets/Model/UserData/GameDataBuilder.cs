using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataBuilder
{
    private static int initialCoins = 100;
    private static GameSlot defaultSlot = GameSlot.gameOne;

    private int coins = initialCoins;
    private GameSlot slot = defaultSlot;
    private long updatedAtTicks = DateTime.Now.Ticks;

    public GameDataBuilder setSlot(GameSlot slotId) {
        slot = slotId;
        return this;
    }

    public GameDataBuilder setCoins(int coins) {
        this.coins = coins;
        return this;
    }

    public GameDataBuilder setUpdatedAt(long ticks) {
        updatedAtTicks = ticks;
        return this;
    }

    public GameData build() {
        return new GameData(slot, coins, updatedAtTicks);
    }
}
