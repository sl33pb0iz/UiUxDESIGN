using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using VContainer;
using static Doozy.Editor.UIManager.UIMenu.UIMenuContextMenu.Scripts;

public class SignInFormFactory : IDisposable
{
    private IObjectResolver _container;
    private GuestSignInForm _form;

    public SignInFormFactory(IObjectResolver container, GuestSignInForm form)
    {
        _form = form;
        _container = container;
    }

    public GuestSignInFormController Create()
    {
        var service = _container.Resolve<IGuestAccountService>();
        var controller = new GuestSignInFormController(service);
        _form._guestSignInFormController = controller;
        _form.container = _container;
        _form.Init();
        return controller;
    }

    public void Dispose()
    {
    }
}
