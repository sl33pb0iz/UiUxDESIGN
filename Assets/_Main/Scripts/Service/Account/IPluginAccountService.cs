using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public interface IPluginAccountService : INotifyPropertyChanged
{
    bool IsSignedIn { get; set; }
    void ManualSignIn();
    void AutoSignIn();
    string GetUserInfo();
    void SignOut();
}
