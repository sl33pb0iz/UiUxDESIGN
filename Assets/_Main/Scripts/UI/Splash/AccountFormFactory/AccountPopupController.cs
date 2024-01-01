using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AccountPopupController 
{
    //Service Create Popup
    private IPopupService _signInPopup;
    private IPopupService _signUpPopup;

    //Signal
    public ICommand ShowPopupSignInForm;
    public ICommand ShowPopupSignUpForm;

    public AccountPopupController(SignInPopupService signInPopup, SignUpPopupService signUpPopup)
    {
        _signInPopup = signInPopup;
        _signUpPopup = signUpPopup;

        _signInPopup.PropertyChanged += OnAccountPropertyChanged; 
        _signUpPopup.PropertyChanged += OnAccountPropertyChanged;
    }

    private void OnAccountPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if(sender is SignInPopupService)
        {
            if (_signInPopup.IsPopup == true)
            {
                ShowPopupSignInForm.Execute(null);
                _signUpPopup.IsPopup = false;
            }
        }

        else
        if(_signUpPopup.IsPopup == true)
        {
            ShowPopupSignUpForm.Execute(null);
            _signInPopup.IsPopup= false;
        }
    }
}
