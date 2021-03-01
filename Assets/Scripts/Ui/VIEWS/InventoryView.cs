using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : UiView
{

    [Header("Inventory Elements")]
    [SerializeField] private SoulInformation SoulItemPlaceHolder;
    [SerializeField] private Text Description;
    [SerializeField] private Text Name;
    [SerializeField] private Image Avatar;
    [SerializeField] private Button UseButton;
    [SerializeField] private Button DestroyButton;

    private RectTransform ContentParent;
    private GameObject CurrentSelectedItem;
    public override void Awake()
    {
        base.Awake();
        ContentParent = (RectTransform)SoulItemPlaceHolder.transform.parent;
        InitializeInventoryItems();      
    }

    private void InitializeInventoryItems()
    {
        for (int i = 0, j = SoulController.Instance.Souls.Count; i < j; i++)
        {
            SoulInformation newSoul = Instantiate(SoulItemPlaceHolder.gameObject, ContentParent).GetComponent<SoulInformation>();
            newSoul.SetSoulItem(SoulController.Instance.Souls[i], () => SoulItem_OnClick(newSoul));
        }
        SoulItemPlaceHolder.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ClearSoulInformation();
    }

    private void ClearSoulInformation()
    {
        Description.text = "";
        Name.text = "";
        Avatar.sprite = null;
        SetupUseButton(false);
        SetupDestroyButton(false);
        CurrentSelectedItem = null;

    }


    public void SoulItem_OnClick(SoulInformation soulInformation)
    {
        CurrentSelectedItem = soulInformation.gameObject;
        SetupSoulInformation(soulInformation.soulItem);
    }


    private void SetupSoulInformation(SoulItem soulItem)
    {
        Description.text = soulItem.Description;
        Name.text = soulItem.Name;
        Avatar.sprite = soulItem.Avatar;
        SetupUseButton(soulItem.CanBeUsed);
        SetupDestroyButton(soulItem.CanBeDestroyed);
    }

    private void UseCurrentSoul()
    {
        Destroy(CurrentSelectedItem);
        ClearSoulInformation();
    }

    private void DestroyCurrentSoul()
    {
        Destroy(CurrentSelectedItem);
        ClearSoulInformation();
    }

    private void SetupUseButton(bool active)
    {
        if (!active)
            UseButton.onClick.RemoveAllListeners();
        else
        {
            PopUpInformation popUpInfo = new PopUpInformation {
                Header = "USE ITEM",
                Message = "Are you sure you want to USE: " + Name.text + " ?",
                Confirm_OnClick = () => UseCurrentSoul()

            };
            UseButton.onClick.AddListener(() => GUIController.Insntace.PopUp.ActivePopUpView(popUpInfo));
        }



        UseButton.gameObject.SetActive(active);

    }

    private void SetupDestroyButton(bool active)
    {
        if (!active)
            DestroyButton.onClick.RemoveAllListeners();
        else
        {
            PopUpInformation popUpInfo = new PopUpInformation
            {
                Header = "DESTROY ITEM",
                Message = "Are you sure you want to DESTROY: " + Name.text + " ?",
                Confirm_OnClick = () => DestroyCurrentSoul()

            };
            DestroyButton.onClick.AddListener(() => GUIController.Insntace.PopUp.ActivePopUpView(popUpInfo));
        }

        DestroyButton.gameObject.SetActive(active);
    }



}
