﻿using Doozy.Runtime.Signals;
using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Build.Pipeline;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class SignInView : MonoBehaviour
{
    private SignInViewState viewState;

    public SignInViewState ViewState
    {
        get 
        { 
            return viewState; 
        }
        private set
        {
            viewState = value;
            UpdateState();
        }
    }

    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton _buttonGameCenterSignIn;
    [SerializeField] private UIButton _buttonFacebookSignIn;
    [SerializeField] private UIButton _buttonGoogleSignIn;
    [SerializeField] private UIButton _buttonGuestSignIn;
    [SerializeField] private UIButton _buttonTapToStart;

    [Title("PREFAB", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIPopup AccountSignInPopupPrefab;

    [Inject]
    private SignInViewController _loginFormController;

    [Inject]
    private readonly IObjectResolver _container;

    private ICommand _accountSignedInSignal;
    private ICommand _onGuestAccountSignInSignal;

    [Inject]
    private Func<IGuestAccountService, GuestSignInFormController> _factory; 

    private void Awake()
    {
        _accountSignedInSignal = new RelayCommand<string>( _ => true, _ => ViewState = SignInViewState.TapToStart);
        _onGuestAccountSignInSignal = new RelayCommand<string>( _ => true, _ => SetGuestSignInFormVisibility());

        _loginFormController.AccountSignedInSignal = _accountSignedInSignal;
        _loginFormController.OnGuestAccountSignInSignal = _onGuestAccountSignInSignal;

    }

    private void Start()
    {
        ViewState = SignInViewState.SignIn;
        
    }

    private void OnEnable()
    {
        _buttonGameCenterSignIn.onLeftClickEvent.AddListener(_loginFormController.OnGameCenterSignIn);
        _buttonFacebookSignIn.onLeftClickEvent.AddListener(_loginFormController.OnFacebookSignIn);
        _buttonGoogleSignIn.onLeftClickEvent.AddListener(_loginFormController.OnGoogleSignIn);

        _buttonGuestSignIn.onLeftClickEvent.AddListener(_loginFormController.OnGuestSignIn);
    }

    private void OnDisable()
    {
        _buttonGameCenterSignIn.onLeftClickEvent.RemoveListener(_loginFormController.OnGameCenterSignIn);
        _buttonFacebookSignIn.onLeftClickEvent.RemoveListener(_loginFormController.OnFacebookSignIn);
        _buttonGoogleSignIn.onLeftClickEvent.RemoveListener(_loginFormController.OnGoogleSignIn);

        _buttonGuestSignIn.onLeftClickEvent.RemoveListener(_loginFormController.OnGuestSignIn);
    }

    private void UpdateState()
    {
        switch (ViewState)
        {
            case SignInViewState.SignIn:
                SetSignInButtonsVisibility(true);
                SetTapToStartButtonVisibility(false);
                break;
            case SignInViewState.TapToStart:
                SetSignInButtonsVisibility(false);
                SetTapToStartButtonVisibility(true);
                break;
            default:
                throw new System.Exception("Bug o sign in view roi");
        }
    }

    private void SetSignInButtonsVisibility(bool show)
    {
        _buttonGameCenterSignIn.gameObject.SetActive(show);
        _buttonFacebookSignIn.gameObject.SetActive(show);
        _buttonGoogleSignIn.gameObject.SetActive(show);
        _buttonGuestSignIn.gameObject.SetActive(show);
    }

    private void SetTapToStartButtonVisibility(bool show)
    {
        _buttonTapToStart.gameObject.SetActive(show);
    }

    public void SetGuestSignInFormVisibility()
    {
        var popup = UIPopup.Get(AccountSignInPopupPrefab.name);
        var form = popup.GetComponent<GuestSignInForm>();

        //Init MVC
        var controller = _factory(_container.Resolve<IGuestAccountService>());
        form._guestSignInFormController = controller;
        _container.Inject(form);

        popup.Show();
    }

}

public enum SignInViewState
{
    SignIn,
    TapToStart,
    Loading,
}
