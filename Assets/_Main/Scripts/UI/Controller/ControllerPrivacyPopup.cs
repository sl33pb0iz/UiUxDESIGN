using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPrivacyPopup 
{
    /*private readonly ModelPrivacy _checker;
    private readonly ICommand _commandHandled;

    public ControllerPrivacyPopup(ICommand command) 
    {
        _commandHandled = command;
        _checker = new ModelPrivacy();
    }

    public void HandlingClickButton(Enum @enum)
    {
        switch (@enum) {
            case (TypePrivacyButton.Accept):
                HandlingClickButtonAccept();
                break;
            case (TypePrivacyButton.Info):
                HandlingClickTermsOfService();
                break;
            case (TypePrivacyButton.TermsOfService):
                HandlingClickTermsOfService();
                break;
        }
    }

    public void HandlingClickButtonAccept()
    {
        _checker.Checked();
        _commandHandled.Execute(TypePrivacyButton.Accept);
    }

    public void HandlingClickTermsOfService()
    {
        _checker.OpenPrivacyURL();
        _commandHandled.Execute(TypePrivacyButton.TermsOfService);
    }

    public void HandlingClickInfo()
    {
        _checker.OpenPrivacyURL();
        _commandHandled.Execute(TypePrivacyButton.Info);
    }*/
}
