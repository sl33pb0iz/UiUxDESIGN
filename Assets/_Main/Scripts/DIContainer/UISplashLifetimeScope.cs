using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class UISplashLifetimeScope : LifetimeScope
{
    [Title("VIEW", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] HomeSplashView _homeSplashView;
    [SerializeField] AccountPopupView _splashPopupView;


    protected override void Configure(IContainerBuilder builder)
    {
        #region Model        

        //Account
        builder.Register<IPluginAccountService, GameCenterAccountService>(Lifetime.Singleton);
        builder.Register<IPluginAccountService, FacebookAccountService>(Lifetime.Singleton);
        builder.Register<IPluginAccountService, GoogleAccountService>(Lifetime.Singleton);
        builder.Register<IAccountService, AccountService>(Lifetime.Singleton);

        //Network Connection
        builder.Register<NetworkConnectionService>(Lifetime.Singleton).As<ITickable>().AsSelf();

        //Application 
        builder.Register<ApplicationService>(Lifetime.Singleton);

        //Policy
        builder.Register<EULAPolicyService>(Lifetime.Singleton);

        //Create Popup
        builder.Register<SignInPopupService>(Lifetime.Singleton).As<IPopupService>().AsSelf();
        builder.Register<SignUpPopupService>(Lifetime.Singleton).As<IPopupService>().AsSelf();

        #endregion

        #region Controller
        builder.Register<HomeSplashViewController>(Lifetime.Singleton);
        builder.Register<NetworkErrorPopupController>(Lifetime.Transient);
        builder.Register<CheckEULAPolicyController>(Lifetime.Transient).As<IPostStartable>().AsSelf();
        builder.Register<AccountPopupController>(Lifetime.Singleton);
        #endregion

        #region View
        builder.RegisterComponent(_homeSplashView);
        builder.RegisterComponent(_splashPopupView);
        #endregion

        #region Factory
        builder.RegisterFactory<IAccountService, IPopupService, IPopupService, SignInFormController>(container =>
        {
            return (accountService, signInPopupService, signUpPopupService) =>
            {
                return new SignInFormController(accountService, signInPopupService, signUpPopupService);
            };
        }, Lifetime.Singleton);


        builder.RegisterFactory<IAccountService, IPopupService, IPopupService, SignUpFormController>(container =>
        {
            return (accountService, signInPopupService, signUpPopupService) =>
            {
                return new SignUpFormController(accountService, signInPopupService, signUpPopupService);
            };
        }, Lifetime.Singleton);

        builder.RegisterFactory<NetworkConnectionService, ApplicationService, NetworkErrorFormController>(container =>
        {
            return (networkService, applicationService) => new NetworkErrorFormController(networkService, applicationService);
        }, Lifetime.Singleton);

        builder.RegisterFactory<EULAPolicyService, EULAPolicyNotifyController>(container =>
        {
            return service =>
            {
                return new EULAPolicyNotifyController(service);
            };
        }, Lifetime.Singleton);
        #endregion
    }
}
