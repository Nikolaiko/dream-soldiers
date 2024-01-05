using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveSlotUI : MonoBehaviour
{
    public GameSlot slotId;
    public TextMeshProUGUI slotName;
    public TextMeshProUGUI slotDate;

    public void Start() {
        slotName.text = slotId.slotName();
    }
}
