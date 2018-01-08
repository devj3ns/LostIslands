﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour {

    public GameObject EscPanel;

    public Text SaveButtonText;
    public GameObject NormalEsc;
    public GameObject SettingsEsc;

    public bool inEsc;

	void Start () {
        EscPanel.SetActive(false);
        NormalEsc.SetActive(true);
        SettingsEsc.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerController.instance.Pause = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inEsc) 
            {
                CloseEsc();
            }
            else
            {
                OpenEsc();
            }

        }
        SaveButtonText.text = "SAVE (Slot:" + SaveLoadManager.instance.currentSlot + ")";
    }

    public void toMenu()
    {
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.Disconnect();
        }
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(0);
    }
        
    public void Save()
    {
        SaveLoadManager.instance.Save(PhotonNetwork.offlineMode);
    }

    public void ToSettings()
    {
        NormalEsc.SetActive(false);
        SettingsEsc.SetActive(true);
    }

    public void BacktoEsc()
    {
        NormalEsc.SetActive(true);
        SettingsEsc.SetActive(false);
    }

    public void Close()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.offlineMode = false;
        Application.Quit();
    }

    public void OpenEsc()
    {
        InventoryManager.instance.CloseInventory();
        UIManager.instance.HideHealthbar();
        UIManager.instance.HideChat();
        UIManager.instance.HideCrosshair();
        UIManager.instance.HideMiddleinfo();
        
        
        Cursor.lockState = CursorLockMode.None;
        PlayerController.instance.Pause = true;
        inEsc = true;

        EscPanel.SetActive(true);
        NormalEsc.SetActive(true);
        SettingsEsc.SetActive(false);
    }

    public void CloseEsc()
    {
        UIManager.instance.ShowHealthbar();
        UIManager.instance.ShowChat();
        UIManager.instance.ShowCrosshair();
        UIManager.instance.ShowMiddleinfo();

        
        PlayerController.instance.Pause = false;
        inEsc = false;

        EscPanel.SetActive(false);
        NormalEsc.SetActive(true);
        SettingsEsc.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Continue()
    {
        EscPanel.SetActive(false);
        NormalEsc.SetActive(true);
        SettingsEsc.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerController.instance.Pause = false;

        UIManager.instance.ShowChat();
        UIManager.instance.ShowCrosshair();
        UIManager.instance.ShowHealthbar();
        UIManager.instance.ShowMiddleinfo();
        
    }
}
