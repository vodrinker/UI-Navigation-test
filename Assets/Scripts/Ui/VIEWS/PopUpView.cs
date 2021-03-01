using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpView : UiView
{

    public GameObject PopUpScreenBlocker;


    private void OnEnable()
    {
        PopUpScreenBlocker.SetActive(true);
    }
    private void OnDisable()
    {
        PopUpScreenBlocker.SetActive(false);
    }

    [Header("Pop Up Elements")]
    public Text LabelText;
    public Text MessageText;
    public Button YesButton;

    
    public void ActivePopUpView(PopUpInformation popUpInfo )
    {
        ClearPopUp();
        LabelText.text = popUpInfo.Header;
        MessageText.text = popUpInfo.Message;
        YesButton.onClick.AddListener(() => popUpInfo.Confirm_OnClick());
        YesButton.onClick.AddListener(() => DisableView());
        ActiveView();

    }


    private void ClearPopUp()
    {
        LabelText.text = "";
        MessageText.text = "";
        YesButton.onClick.RemoveAllListeners();
    }
}

public struct PopUpInformation
{
    public string Header;
    public string Message;
    public Action Confirm_OnClick;
}