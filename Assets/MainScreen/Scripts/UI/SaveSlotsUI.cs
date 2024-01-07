using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

public class SaveSlotsUI : MonoBehaviour
{
    private Action<GameSlot> onGameSlotClick;
    private SaveSlotUI[] slots;

    public void Awake() {        
        slots = transform.GetComponentsInChildren<SaveSlotUI>();
        foreach(SaveSlotUI currentSlot in slots) {
            currentSlot.setSlotClickCallback(onSlotClick);
        }
    }

    public void setSlotClickCallback(Action<GameSlot> action) {
        onGameSlotClick = action;
    }

    public void setVisibility(bool isVisible) {
        gameObject.SetActive(isVisible);
    }

    public void initWithGameSaves(List<GameData> gameDatas) {        
        foreach (SaveSlotUI currentSlot in slots) {
            currentSlot.slotDate.text = currentSlot.slotId.slotName();
            try {
                GameData gameData = gameDatas.First(game => game.gameId == currentSlot.slotId);
                DateTime dateTime = new DateTime(gameData.updatedAtTicks);
                currentSlot.slotDate.text = dateTime.ToLongTimeString();
            } catch(InvalidOperationException) {
                currentSlot.slotDate.text = "Empty";
            }
            
        }
    }

    private void onSlotClick(GameSlot slotId) {
        onGameSlotClick(slotId);
    }
}
