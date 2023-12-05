using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewPrivacyPopup : MonoBehaviour
{
    /*public UIButton ButtonAccept;
    public UIButton ButtonTermsOfService;
    public UIButton ButtonInfo;

    private ControllerPrivacyPopup _controllerPrivacyPopup;

    private ICommand _handlingClickButton;
    private ICommand _clickButtonHandled;


    private void Awake()
    {
        _clickButtonHandled = new RelayCommand<Enum>(p => true, ClickButtonHandled);
        _controllerPrivacyPopup = new ControllerPrivacyPopup(_clickButtonHandled);
        _handlingClickButton = new RelayCommand<Enum>(p => true, _controllerPrivacyPopup.HandlingClickButton);
    }

    private void OnEnable()
    {
        ButtonAccept.onLeftClickEvent.AddListener(() => _handlingClickButton.Execute(TypePrivacyButton.Accept));
        ButtonTermsOfService.onLeftClickEvent.AddListener(() => _handlingClickButton.Execute(TypePrivacyButton.TermsOfService));
        ButtonInfo.onLeftClickEvent.AddListener(() => _handlingClickButton.Execute(TypePrivacyButton.Info));
    }

    private void OnDisable()
    {
        ButtonAccept.onLeftClickEvent.RemoveListener(() => _handlingClickButton.Execute(TypePrivacyButton.Accept));
        ButtonTermsOfService.onLeftClickEvent.RemoveListener(() => _handlingClickButton.Execute(TypePrivacyButton.TermsOfService));
        ButtonInfo.onLeftClickEvent.RemoveListener(() => _handlingClickButton.Execute(TypePrivacyButton.Info));
    }

    private void ClickButtonHandled(Enum @enum)
    {
        switch (@enum)
        {
            case (TypePrivacyButton.Accept):
                ClickButtonAcceptHandled();
                break;
            case (TypePrivacyButton.Info):
                ClickInfoHandled();
                break;
            case (TypePrivacyButton.TermsOfService):
                ClickTermsOfServiceHandled();
                break;
        }
    }

    public void ClickButtonAcceptHandled()
    {
        var popup = UIPopup.visiblePopups.Where(x => x.name == this.name);
        foreach (var item in popup)
        {
            item.Hide();
        }
    }

    public void ClickTermsOfServiceHandled()
    {
        Debug.Log("Handled Terms of service");
    }

    public void ClickInfoHandled()
    {
        Debug.Log("Handled");
    }*/
}

public enum TypePrivacyButton
{
    Accept,
    Info,
    TermsOfService,
}
