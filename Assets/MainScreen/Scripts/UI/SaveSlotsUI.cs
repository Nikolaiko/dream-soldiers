using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveSlotsUI : MonoBehaviour
{
    private Action<GameSlot> onGameSlotClick;
    private SaveSlotUI[] slots;

    public void Awake() {        
        slots = transform.GetComponentsInChildren<SaveSlotUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSlotClickCallback(Action<GameSlot> action) {
        onGameSlotClick = action;
    }

    public void setVisibility(bool isVisible) {
        gameObject.SetActive(isVisible);
    }

    public void initWithGameSaves(List<GameData> gameDatas) {
        
    }

    
}
