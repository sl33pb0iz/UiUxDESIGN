using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class AccountService : IAccountService
{
    private bool _isSignedIn = false;
    private bool _isRememberMe = false; 

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

    public bool IsRememberMe
    {
        get
        {
            return _isRememberMe;
        }
        set
        {
            _isRememberMe = value;
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
        if (IsRememberMe)
        {
            // Lấy giá trị đã được lưu trữ 
            // Thực hiện tự động đăng nhập 
            // Thông báo đã đăng nhập thành công
            IsSignedIn = true;
        }
        else
        {
            IsSignedIn = false;
        }
    }

    public string GetUserInfo()
    {
        throw new System.NotImplementedException();
    }

    public void IsAccountExist()
    {
        throw new System.NotImplementedException();
    }

    public void SignIn()
    {
        // sign in vào
        IsSignedIn = true;
    }

    public void SignOut()
    {
        throw new System.NotImplementedException();
    }

    public void SignUp()
    {
        
    }
}
