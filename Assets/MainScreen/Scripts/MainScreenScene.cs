using UnityEngine;

public class MainScreenScene : MonoBehaviour
{
    public MainScreenUI mainScreenUI;

    private MainScreenAction lastAction = MainScreenAction.notSet;
    private UserDataService userDataService = new PlayerPrefsStorage();

    public void Awake() {
        mainScreenUI.setNewGameCallback(newButtonClick);
        mainScreenUI.setLoadGameCallback(loadButtonClick);
        mainScreenUI.setContinueGameCallback(continueButtonClick);
        mainScreenUI.setExitGameCallback(exitButtonClick);
        mainScreenUI.setCloseSaveSlotsCallback(closeSlotsClick);
    }

    public void Start() {
        mainScreenUI.initWithGameSaves(userDataService.getAllSavedGames());

        mainScreenUI.setContinueVisibility(userDataService.haveGameToContinue());
        mainScreenUI.setSaveSlotsVisibility(false);
    }

    private void exitButtonClick() {
        Application.Quit();
    }

    private void continueButtonClick() {
        mainScreenUI.setButtonsVisibility(false);
        mainScreenUI.setSaveSlotsVisibility(true);
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
}
