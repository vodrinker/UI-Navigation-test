using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GUIController : MonoBehaviour
{

    #region singleton
    public static GUIController Insntace;

    private void Awake()
    {
        DisableOnStart.SetActive(false);
        Insntace = this;
    }
    #endregion

    [SerializeField] private GameObject DisableOnStart;

    [SerializeField] private RectTransform ViewsParent;
    [SerializeField] private GameObject InGameGui;
    [SerializeField] private PopUpView PopUp;
    [SerializeField] private PopUpScreenBlocker ScreenBlocker;

    private void Start()
    {
        if (ScreenBlocker)
            ScreenBlocker.InitBlocker();
    }


    private void ActiveInGameGUI(bool active)
    {
        InGameGui.SetActive(active);
    }


    public void ShowPopUpMessage(PopUpInformation popUpInfo)
    {

        PopUpView newPopUp = Instantiate(PopUp, ViewsParent) as PopUpView;
        newPopUp.ActivePopUpView(popUpInfo);
    }
   
    public void ActiveScreenBlocker(bool active,PopUpView popUpView)
    {
        if (active)
            ScreenBlocker.AddPopUpView(popUpView);
        else
            ScreenBlocker.RemovePopUpView(popUpView);
    }


    #region On Clicks
    public void InGameGUIButton_OnClick(UiView viewToActive)
    {
        viewToActive.ActiveView(() => ActiveInGameGUI(true));

        ActiveInGameGUI(false);
    }
    #endregion




}
