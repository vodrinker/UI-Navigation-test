using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiView : MonoBehaviour
{

    [Header("UI VIEW elements")]

   
    [SerializeField] private bool CloseOnNewView = true;
    [SerializeField] private Button BackButon;

    private UiView ParentView;
    public virtual void Awake()


    {
        BackButon.onClick.AddListener(()=> DisableView_OnClick(this));
    }

    public void ActiveView_OnClick(UiView viewToActive)
    {
        viewToActive.SetParentView(this);
        viewToActive.ActiveView();
        this.ActiveView(!CloseOnNewView);
    }
   

    private void DisableView_OnClick(UiView viewToDisable)
    {
        viewToDisable.DisableView();
    }

    public void SetParentView(UiView parentView)
    {
        ParentView = parentView;
        
    }

    public void ActiveView(bool active)
    {
        this.gameObject.SetActive(active);
    }

    public void ActiveView(Action onBackButtonAction = null)
    {
        if (onBackButtonAction != null)
            BackButon.onClick.AddListener(() => onBackButtonAction());


        if(!gameObject.activeSelf)
            this.ActiveView(true);
    }

    public void DisableView()
    {
        if (ParentView != null)
        {
            ParentView.ActiveView();
        }

        this.ActiveView(false);      
    }

}




