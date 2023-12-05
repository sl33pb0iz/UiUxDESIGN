using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class SignUpFormFactory : IDisposable
{
    private IObjectResolver _container; 
    private GuestSignUpForm _form;
    
    public SignUpFormFactory(IObjectResolver container, GuestSignUpForm form)
    {
        _container = container;
        _form = form;
    }

    public GuestSignUpFormController Create()
    {
        var service = _container.Resolve<IGuestAccountService>();
        var controller = new GuestSignUpFormController(service);
        _form._guestSignUpFormController = controller;
        _form.Init();
        return controller;
    }

    public void Dispose()
    {
       
    }

    /* public GuestSignInFormController Create()
     {

     }*/
}
