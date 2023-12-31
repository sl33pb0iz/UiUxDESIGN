using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SignUpFormController : IDisposable
{
    private IAccountService _accountService;

    public ICommand HideSignUpForm;

    private IPopupService _signInPopupService;
    private IPopupService _signUpPopupService;

    private bool _isDisposed;

    public SignUpFormController(IAccountService accountService, IPopupService signInPopupService, IPopupService signUpPopupService)
    {
        _accountService = accountService;
        _accountService.PropertyChanged += OnPropertyChanged;

        _signUpPopupService = signUpPopupService;
        _signInPopupService = signInPopupService;

        signInPopupService.PropertyChanged += OnPropertyChanged;
    }

    public void SignUp() => _accountService.SignUp();


    public void SetShowPopupSignInForm()
    {
        _signInPopupService.IsPopup = true;
    }

    public void HidePopupSignUpForm()
    {
        _signUpPopupService.IsPopup = false;
        HideSignUpForm.Execute(null);
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (sender is IPopupService)
        {
            if (_signInPopupService.IsPopup == true)
            {
                HidePopupSignUpForm();
            }
        }
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
        if (_isDisposed)
        {
            return;
        }

        if (disposing)
        {
            _accountService.PropertyChanged -= OnPropertyChanged;
            _signInPopupService.PropertyChanged -= OnPropertyChanged;

            _accountService = null;
            _signInPopupService = null;
            _signUpPopupService = null; 
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _isDisposed = true;
    }

    ~SignUpFormController()
    {
        Dispose(false);
    }
}
