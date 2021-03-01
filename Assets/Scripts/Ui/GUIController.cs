using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GUIController : MonoBehaviour
{

    #region singleton
    public static GUIController Insntace;

    private void Awake()
    {
        Insntace = this;
    }
    #endregion


    public GameObject InGameGui;
    public PopUpView PopUp;


    private void ActiveInGameGUI(bool active)
    {
        InGameGui.SetActive(active);
    }


    public void ShowPopUpMessage(PopUpInformation popUpInfo)
    {
        PopUp.ActivePopUpView(popUpInfo);
    }


    #region On Clicks
    public void InGameGUIButton_OnClick(UiView viewToActive)
    {
        viewToActive.ActiveView(() => ActiveInGameGUI(true));

        ActiveInGameGUI(false);
    }
    #endregion




}
