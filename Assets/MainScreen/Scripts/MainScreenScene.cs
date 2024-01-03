using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenScene : MonoBehaviour
{
    public MainScreenUI mainScreenUI;

    private UserDataService userDataService = new PlayerPrefsStorage();

    void Start()
    {
        mainScreenUI.setContinueVisibility(userDataService.haveGameToContinue());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onContinue() {
        print("Continue");
    }

    public void onNewGame() {
        mainScreenUI.setSaveSlotsVisibility(true);
    }

    public void onLoad() {
        mainScreenUI.setSaveSlotsVisibility(true);
    }

    public void onExit() {
        Application.Quit();
    }
}
