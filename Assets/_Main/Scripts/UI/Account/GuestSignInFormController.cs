using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GuestSignInFormController : IDisposable
{
    private IGuestAccountService GuestAccountService;

    public ICommand SignedInSignal;

    private bool isDisposed;

    public GuestSignInFormController(IGuestAccountService guestAccountService)
    {
        GuestAccountService = guestAccountService;
        GuestAccountService.PropertyChanged += SignInAction;
    }

    public void ControllerSignIn()
    {
        GuestAccountService.SignIn();
    }

    private void SignInAction(object sender, PropertyChangedEventArgs e)
    {
        if (GuestAccountService.IsSignedIn)
        {
            SignedInSignal.Execute(sender.ToString());
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                if (GuestAccountService != null)
                {
                    
                    GuestAccountService.PropertyChanged -= SignInAction;
                    GuestAccountService = null;
                }
            }
            isDisposed = true;
        }
    }

    ~GuestSignInFormController()
    {
        Dispose(false);
    }

}
