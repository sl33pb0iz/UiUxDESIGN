using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GuestSignUpFormController
{
    private IGuestAccountService GuestAccountService;

    public ICommand SignedUpSignal;

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
}
