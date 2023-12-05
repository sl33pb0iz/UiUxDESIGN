using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GoogleAccountService : IPluginAccountService
{
    private bool _isSignedIn;

    public bool IsSignedIn
    {
        get
        {
            return _isSignedIn;
        }
        set
        {
            _isSignedIn = value;
            OnPropertyChanged(value.ToString());
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void AutoSignIn()
    {
        // Thực hiện tự động đăng nhập
        IsSignedIn = true;
    }
    public void ManualSignIn()
    {
        IsSignedIn = true;
    }

    public string GetUserInfo()
    {
        throw new System.NotImplementedException();
    }


    public void SignOut()
    {
        throw new System.NotImplementedException();
    }
}
