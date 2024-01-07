using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotUI : MonoBehaviour
{
    public GameSlot slotId;
    public TextMeshProUGUI slotName;
    public TextMeshProUGUI slotDate;
    public Button slotButton;

    private Action<GameSlot> slotCallback;

    public void Start() {
        slotName.text = slotId.slotName();
        slotButton.onClick.AddListener(onClick);
    }

    public void setSlotClickCallback(Action<GameSlot> callback) {
        slotCallback = callback;
    }

    private void onClick() {
        slotCallback(slotId);
    }    
}
