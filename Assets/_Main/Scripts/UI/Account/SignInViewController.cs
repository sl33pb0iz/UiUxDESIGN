using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using UnityAtoms.Tags;
using VContainer;
using VContainer.Unity;

public class SignInViewController 
{
    // Service
    private readonly IPluginAccountService GameCenterAccountService;
    private readonly IPluginAccountService FacebookAccountService;
    private readonly IPluginAccountService GoogleAccountService;
    private readonly IGuestAccountService GuestAccountService; 

    // Command to sign in view
    public ICommand AccountSignedInSignal;
    public ICommand OnGuestAccountSignInSignal;

    // Dependencies

    public SignInViewController(IReadOnlyList<IPluginAccountService> services, IGuestAccountService inGameServices)
    {
        //Inject model into controller
        GameCenterAccountService = services.FirstOrDefault(s => s.GetType() == typeof(GameCenterAccountService));
        FacebookAccountService = services.FirstOrDefault(s => s.GetType() == typeof(FacebookAccountService));
        GoogleAccountService = services.FirstOrDefault(s => s.GetType() == typeof(GoogleAccountService));
        GuestAccountService = inGameServices;

        // Register methods into plugins Account propertyChanged action
        GameCenterAccountService.PropertyChanged += PluginAccountSignedIn;
        FacebookAccountService.PropertyChanged += PluginAccountSignedIn;
        GoogleAccountService.PropertyChanged += PluginAccountSignedIn;

        // Register methods into guestAccount propertyChanged action
        GuestAccountService.PropertyChanged += GuestAccountSignInSignal;
    }

    //SendSignal to models (Services)
    public void OnGameCenterSignIn() => GameCenterAccountService.AutoSignIn();
    public void OnFacebookSignIn() => FacebookAccountService.AutoSignIn();
    public void OnGoogleSignIn() => GoogleAccountService.AutoSignIn();
    public void OnGuestSignIn() => GuestAccountService.AutoSignIn();

    // PropertyChanged event in model invoke this
    private void PluginAccountSignedIn(object sender, PropertyChangedEventArgs e)
    {
        AccountSignedInSignal.Execute(sender.ToString());
    }

    private void GuestAccountSignInSignal(object sender, PropertyChangedEventArgs e)
    {
        if (GuestAccountService.IsSignedIn)
        {
            AccountSignedInSignal.Execute(e.ToString());
        }
        else
        {
            OnGuestAccountSignInSignal.Execute(e.ToString());
        }
    }
}


