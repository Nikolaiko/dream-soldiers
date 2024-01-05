using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenUI : MonoBehaviour
{
    public Button continueButton;
    public Button loadButton;
    public Button newGameButton;
    public Button exitButton;
    public Button closeSaveSlotsButton;
    public SaveSlotsUI saveSlotsUI;
    public GameObject buttonsPanel;

    private Action continueButtonCallback;
    private Action newButtonCallback;
    private Action loadButtonCallback;
    private Action exitButtonCallback;
    private Action closeSaveSlotsCallback;

    public void Start()
    {
        continueButton.onClick.AddListener(onContinue);
        loadButton.onClick.AddListener(onLoad);
        newGameButton.onClick.AddListener(onNewGame);
        exitButton.onClick.AddListener(onExit);
        closeSaveSlotsButton.onClick.AddListener(onCloseSaveSlots);
    }

    public void initWithGameSaves(List<GameData> gameDatas) {
        saveSlotsUI.initWithGameSaves(gameDatas);
    }

    public void setContinueVisibility(bool visible) {
        continueButton.gameObject.SetActive(visible);
    }

    public void setSaveSlotsVisibility(bool visible) {
        saveSlotsUI.setVisibility(visible);
    }

    public void setButtonsVisibility(bool visible) {
        buttonsPanel.SetActive(visible);
    }

    public void setCloseSaveSlotsCallback(Action callback) {
        closeSaveSlotsCallback = callback;
    }

    public void setNewGameCallback(Action callback) {
        newButtonCallback = callback;
    }

    public void setLoadGameCallback(Action callback) {
        loadButtonCallback = callback;
    }

    public void setExitGameCallback(Action callback) {
        exitButtonCallback = callback;
    }

    public void setContinueGameCallback(Action callback) {
        continueButtonCallback = callback;
    }

    private void onContinue() {
        continueButtonCallback();
    }

    private void onNewGame() {
        newButtonCallback();
    }

    private void onLoad() {
        loadButtonCallback();
    }

    private void onExit() {
        exitButtonCallback();
    }

    private void onCloseSaveSlots() {
        closeSaveSlotsCallback();
    }
}
