using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GuestSignUpFormController : IDisposable
{
    private IGuestAccountService GuestAccountService;

    public ICommand SignedUpSignal;

    private bool isDisposed;

    public GuestSignUpFormController(IGuestAccountService guestAccountService)
    {
        GuestAccountService = guestAccountService;
        GuestAccountService.PropertyChanged += SignUpAction;
    }

    public void ControllerSignIn()
    {
        GuestAccountService.SignIn();
    }

    private void SignUpAction(object sender, PropertyChangedEventArgs e)
    {
        
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
                    GuestAccountService.PropertyChanged -= SignUpAction;
                    GuestAccountService = null;
                }
            }
            isDisposed = true;
        }
    }

    ~GuestSignUpFormController()
    {
        Dispose(false);
    }
}
