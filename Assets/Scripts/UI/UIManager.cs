using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // UI elements to reference in engine
    public TMP_InputField startPlayerNameInput;
    public Button playerInfoButton;
    public Toggle cloudSavesToggle;
    public TMP_Text playerNameResult;
    public TMP_Text playerLevelResult;
    public TMP_Text playerExperienceResult;
    public TMP_Text playerIncomeResult;
    public GameObject welcomeScreenPanel;
    public GameObject welcomePopupPanel;
    public GameObject playerInfoPanel;

    public PlayerMovement playerMovement;
    public CameraFollow cameraFollow;

    private bool useCloudStorage = false;

    // Start is called before the first frame update
    void Start()
    {
        welcomeScreenPanel.SetActive(true);
        welcomePopupPanel.SetActive(false);
        playerInfoPanel.SetActive(false);
        playerInfoButton.gameObject.SetActive(false);
        cloudSavesToggle.isOn = false;
    }

    public void OnStartButtonClick()
    {
        var playerData = SavesManager.Load(startPlayerNameInput.text, useCloudStorage);
        if (playerData != null)
        {
            playerMovement.playerData = playerData;
            
            welcomeScreenPanel.SetActive(false);
            playerInfoButton.gameObject.SetActive(true);
            playerMovement.SetEnabled(true);
            cameraFollow.SetEnabled(true);
        }
        else
        {
            welcomePopupPanel.SetActive(true);
        }
    }

    public void OnYesButtonClick()
    {
        var playerData = new PlayerData(startPlayerNameInput.text, 1, 0, 0);
        playerMovement.playerData = playerData;
        SavesManager.Save(startPlayerNameInput.text, playerData, useCloudStorage);
        welcomePopupPanel.SetActive(false);
        welcomeScreenPanel.SetActive(false);
        playerInfoButton.gameObject.SetActive(true);
        playerMovement.SetEnabled(true);
        cameraFollow.SetEnabled(true);
    }

    public void OnNoButtonClick()
    {
        welcomePopupPanel.SetActive(false);
    }

    public void OnPlayerInfoButtonClick()
    {
        if (playerInfoPanel.activeInHierarchy)
        {
            playerInfoPanel.SetActive(false);
            playerMovement.SetEnabled(true);
        }
        else
        {
            playerMovement.SetEnabled(false);
            playerInfoPanel.SetActive(true);
            AssignPlayerDataToLabels();
        }
    }

    public void OnSaveButtonClick()
    {
        SavesManager.Save(playerMovement.playerData.name, playerMovement.playerData, useCloudStorage);
    }

    public void OnLoadButtonClick()
    {
        playerMovement.playerData = SavesManager.Load(playerMovement.playerData.name, useCloudStorage);
        AssignPlayerDataToLabels();
    }

    public void OnToggleChanged()
    {
        useCloudStorage = cloudSavesToggle.isOn;
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void AssignPlayerDataToLabels()
    {
        playerNameResult.text = playerMovement.playerData.name;
        playerLevelResult.text = playerMovement.playerData.level.ToString();
        playerExperienceResult.text = playerMovement.playerData.experience.ToString();
        playerIncomeResult.text = playerMovement.playerData.income.ToString();
    }
}
