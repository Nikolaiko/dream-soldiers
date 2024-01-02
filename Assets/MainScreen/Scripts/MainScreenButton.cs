using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MainScreenButton : MonoBehaviour
{
    public String buttonTitle;

    public void Start()
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = buttonTitle;    
    }

    public void Update()
    {
        
    }
}
