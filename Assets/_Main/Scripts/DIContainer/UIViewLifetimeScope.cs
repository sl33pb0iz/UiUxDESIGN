using Doozy.Runtime.UIManager;
using Doozy.Runtime.UIManager.Containers;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class UIViewLifetimeScope : LifetimeScope
{
    [Title("VIEW", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] SignInView _signInView;

    protected override void Configure(IContainerBuilder builder)
    {
        // Model
        builder.Register<IPluginAccountService, GameCenterAccountService>(Lifetime.Singleton);
        builder.Register<IPluginAccountService, FacebookAccountService>(Lifetime.Singleton);
        builder.Register<IPluginAccountService, GoogleAccountService>(Lifetime.Singleton);
        builder.Register<IGuestAccountService, GuestAccountService>(Lifetime.Singleton);

        // Controller
        builder.Register<SignInViewController>(Lifetime.Singleton);

        //View
        builder.RegisterComponent(_signInView);
    }
}
