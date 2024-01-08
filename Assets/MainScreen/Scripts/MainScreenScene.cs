using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainScreenScene : MonoBehaviour
{
    [Inject]
    private MainScreenUI mainScreenUI;

    private MainScreenAction lastAction = MainScreenAction.notSet;

    [Inject]
    private UserDataService userDataService;
    private List<GameData> savedGames = new List<GameData>();

    public void Awake() {
        mainScreenUI.setNewGameCallback(newButtonClick);
        mainScreenUI.setLoadGameCallback(loadButtonClick);
        mainScreenUI.setContinueGameCallback(continueButtonClick);
        mainScreenUI.setExitGameCallback(exitButtonClick);
        mainScreenUI.setCloseSaveSlotsCallback(closeSlotsClick);
        mainScreenUI.setSlotClickCallback(slotClick);
    }

    public void Start() {
        savedGames = userDataService.getAllSavedGames();
        mainScreenUI.initWithGameSaves(savedGames);

        mainScreenUI.setContinueVisibility(userDataService.haveGameToContinue());
        mainScreenUI.setSaveSlotsVisibility(false);
    }

    private void exitButtonClick() {
        print(userDataService);
        Application.Quit();
    }

    private void continueButtonClick() {
        GameData? data = userDataService.getLastPlayedGame();        
        if (data == null) {
            Debug.Log("No last saved data.");
        } else {
            startGameWithData((GameData)data);
        }
    }

    private void newButtonClick() {
        mainScreenUI.setButtonsVisibility(false);
        mainScreenUI.setSaveSlotsVisibility(true);

        lastAction = MainScreenAction.newGame;
    }

    private void loadButtonClick() {
        mainScreenUI.setButtonsVisibility(false);
        mainScreenUI.setSaveSlotsVisibility(true);

        lastAction = MainScreenAction.loadGame;
    }

    private void closeSlotsClick() {
        mainScreenUI.setButtonsVisibility(true);
        mainScreenUI.setSaveSlotsVisibility(false);

        lastAction = MainScreenAction.notSet;
    }

    private void slotClick(GameSlot slotId) {
        switch (lastAction) {
            case MainScreenAction.newGame: {
                startNewGame(slotId);
                break;
            }
            case MainScreenAction.loadGame: {
                loadGame(slotId);
                break;
            }
            default: {
                Debug.Log("Wrong action!");
                break;
            }
        }
    }

    private void startNewGame(GameSlot slotId) {
        GameDataBuilder builder = new GameDataBuilder();
        GameData data = builder
                            .setSlot(slotId)
                            .build();
        
        startGameWithData(data);
    }

    private void loadGame(GameSlot slotId) {        
        try {
            GameData data = savedGames.First(gameData => gameData.gameId == slotId);            
            startGameWithData(data);
        } catch (InvalidOperationException) {
            Debug.Log("No save data for : " + slotId.slotName());
        }
    }

    private void startGameWithData(GameData data) {
        MapScreenScene.initialGameData = data;
        userDataService.saveGame(data);
        SceneManager.LoadScene(Convert.ToInt32(SceneIndexes.mapScene));
    }
}
