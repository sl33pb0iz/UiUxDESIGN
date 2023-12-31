using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


public class HomeSplashViewController
{
    // Service SignIn
    private readonly IPluginAccountService _gameCenterAccountService;
    private readonly IPluginAccountService _facebookAccountService;
    private readonly IPluginAccountService _googleAccountService;
    private readonly IAccountService _accountService; 

    // Service Create Form 
    private readonly SignInPopupService _signInPopupService;

    // Command to sign in view
    public ICommand SignedIn;

    // Dependencies

    public HomeSplashViewController(IReadOnlyList<IPluginAccountService> pluginServices, IAccountService accountServices, SignInPopupService signInPopupService)
    {
        //Inject model into controller
        _gameCenterAccountService = pluginServices.FirstOrDefault(s => s.GetType() == typeof(GameCenterAccountService));
        _facebookAccountService = pluginServices.FirstOrDefault(s => s.GetType() == typeof(FacebookAccountService));
        _googleAccountService = pluginServices.FirstOrDefault(s => s.GetType() == typeof(GoogleAccountService));
        _accountService = accountServices;

        // Register methods into plugins Account propertyChanged action
        _gameCenterAccountService.PropertyChanged += AccountSignedIn;
        _facebookAccountService.PropertyChanged += AccountSignedIn;
        _googleAccountService.PropertyChanged += AccountSignedIn;

        // Register methods into guestAccount propertyChanged action
        _accountService.PropertyChanged += OnSignIn;
        _signInPopupService = signInPopupService;
    }

    //SendSignal to models (Services)
    public void OnGameCenterSignIn() => _gameCenterAccountService.AutoSignIn();
    public void OnFacebookSignIn() => _facebookAccountService.AutoSignIn();
    public void OnGoogleSignIn() => _googleAccountService.AutoSignIn();
    public void OnGuestSignIn() => _accountService.AutoSignIn();

    // PropertyChanged event in model invoke this
    private void AccountSignedIn(object sender, PropertyChangedEventArgs e)
    {
        SignedIn.Execute(sender.ToString());
    }

    private void OnSignIn(object sender, PropertyChangedEventArgs e)
    {
        if (_accountService.IsSignedIn)
        {
            SignedIn.Execute(e.ToString());
        }
        else
        {
            _signInPopupService.IsPopup = true; 
        }
    }

}


