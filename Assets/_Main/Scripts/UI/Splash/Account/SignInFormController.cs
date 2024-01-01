using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class SignInFormController : IDisposable
{
    // Service SignUp
    private IAccountService _accountService;

    //Service CreatePopup
    private IPopupService _signInPopupService;
    private IPopupService _signUpPopupService;

    public ICommand HideSignInForm;

    private bool _disposed;

    public SignInFormController(IAccountService accountService, IPopupService signInPopupService, IPopupService signUpPopupService)
    {
        _accountService = accountService;
        _accountService.PropertyChanged += OnPropertyChanged;

        _signUpPopupService = signUpPopupService;
        _signInPopupService = signInPopupService;

        _signInPopupService.PropertyChanged += OnPropertyChanged;
    }

    public void SignIn()
    {
        _accountService.SignIn();
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
    {
        if (sender is IAccountService)
        {
            if (_accountService.IsSignedIn)
            {
                HideSignInForm.Execute(sender.ToString());
            }
        }
        else
        {
            if(_signInPopupService.IsPopup == false)
            {
                HideSignInForm.Execute(sender.ToString());
            }
        }
    }

    public void SetShowPopupSignUpForm()
    {
        _signUpPopupService.IsPopup = true;
    }

    public void SetHidePopupSignInForm()
    {
        _signInPopupService.IsPopup = false;
    }

    public void Dispose()
    {

            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            HideSignInForm = null;
            _accountService.PropertyChanged -= OnPropertyChanged;
            _signInPopupService.PropertyChanged -= OnPropertyChanged;

            _signInPopupService = null;
            _signUpPopupService = null;
            _accountService = null;


        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
    }

    ~SignInFormController() 
    {
        Dispose(false);
    }
}
