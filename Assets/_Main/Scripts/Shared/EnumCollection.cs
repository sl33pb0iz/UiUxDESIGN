using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Enum
{
    public enum UICatagory : byte
    {
        View, 
        Popup,
    }

    public enum PopupCatagory
    {
        Splash = 1 << 8,
        Master = 1 << 32, 
        Common = 1 << 16,
    }

    public enum SplashPopup : byte
    {
        Privacy = 1 << 0,
        UpdateVersion = 1 << 1,
        Checking = 1 << 2,
        GuestLogin = 1 << 3,
        SignUp = 1 << 4,
    }

    public enum SplashView : byte
    {
        Title = 1 << 0,
        Loading = 1 << 1,
    }

    public enum MasterPopup : Int16
    {

    }

    public enum MasterView
    {

    }

    public enum CommonPopup
    {
        NetworkError = 1 << 0,
    }

}

namespace UI.Command
{

}

