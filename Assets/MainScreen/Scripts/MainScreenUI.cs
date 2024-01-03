using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenUI : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setContinueVisibility(bool visible) {
        continueButton.gameObject.SetActive(visible);
    }

    public void setSaveSlotsVisibility(bool visible) {
        
    }
}
