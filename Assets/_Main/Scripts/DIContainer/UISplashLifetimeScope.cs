using Doozy.Editor.Reactor.Components;
using Doozy.Runtime.UIManager;
using Doozy.Runtime.UIManager.Containers;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class UISplashLifetimeScope : LifetimeScope
{
    [Title("VIEW", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] SignInView _signInView;
    [SerializeField] UISplashPopupFactory _signInManager;


    protected override void Configure(IContainerBuilder builder)
    {
        #region Model        

        //Account
        builder.Register<IPluginAccountService, GameCenterAccountService>(Lifetime.Singleton);
        builder.Register<IPluginAccountService, FacebookAccountService>(Lifetime.Singleton);
        builder.Register<IPluginAccountService, GoogleAccountService>(Lifetime.Singleton);
        builder.Register<IGuestAccountService, GuestAccountService>(Lifetime.Singleton);

        //Network Connection
        builder.Register<NetworkConnectionService>(Lifetime.Singleton).As<ITickable>().AsSelf();

        //Application 
        builder.Register<ApplicationService>(Lifetime.Singleton);

        //Policy
        builder.Register<EULAPolicyService>(Lifetime.Singleton);
        #endregion

        #region Controller
        builder.Register<SignInViewController>(Lifetime.Singleton);
        builder.Register<CheckConnectionController>(Lifetime.Singleton);
        builder.Register<CheckEULAPolicyController>(Lifetime.Singleton).As<IPostStartable>().AsSelf();
        #endregion

        #region View
        builder.RegisterComponent(_signInView);
        builder.RegisterComponent(_signInManager);
        #endregion

        #region Factory
        builder.RegisterFactory<IGuestAccountService, GuestSignInFormController>(container =>
        {
            return service =>
            {
                return new GuestSignInFormController(service);
            };
        }, Lifetime.Singleton);


        builder.RegisterFactory<IGuestAccountService, GuestSignUpFormController>(container =>
        {
            return service =>
            {
                return new GuestSignUpFormController(service);
            };
        }, Lifetime.Singleton);

        builder.RegisterFactory<NetworkConnectionService, ApplicationService, NetworkErrorNotifyController>(container =>
        {
            return (networkService, applicationService) => new NetworkErrorNotifyController(networkService, applicationService);
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
