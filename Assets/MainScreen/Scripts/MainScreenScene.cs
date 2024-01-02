using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenScene : MonoBehaviour
{
    private UserDataService userDataService;

    void Start()
    {
        userDataService = new PlayerPrefsStorage();    
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onContinue() {
        print("Continue");
    }

    public void onNewGame() {
        print("onNewGame");
    }

    public void onLoad() {
        print("onLoad");
    }

    public void onExit() {
        Application.Quit();
    }
}
