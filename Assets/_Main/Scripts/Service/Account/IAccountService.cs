using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public interface IAccountService : INotifyPropertyChanged
{
    bool IsSignedIn { get; set; }
    void SignUp();
    void SignIn();
    void AutoSignIn();
    string GetUserInfo();
    void SignOut();

}
