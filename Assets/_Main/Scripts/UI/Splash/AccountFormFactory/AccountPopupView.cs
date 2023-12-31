using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class AccountPopupView : MonoBehaviour
{
    [Title("POPUP", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIPopup _popupSignInFormPrefab;
    [SerializeField] private UIPopup _popupSignUpFormPrefab; 

    private AccountPopupController _splashPopupController;

    private ICommand _showPopupSignInForm;
    private ICommand _showPopupSignUpForm; 

    [Inject] private IObjectResolver _container;
    [Inject] private Func<IAccountService, IPopupService, IPopupService, SignInFormController> _signInFormFactory;
    [Inject] private Func<IAccountService, IPopupService, IPopupService, SignUpFormController> _signUpFormFactory;

    private void Start()
    {
        _splashPopupController = _container.Resolve<AccountPopupController>();
        
        _showPopupSignInForm = new RelayCommand<string>(_ => true, _ => ShowSignInForm());
        _showPopupSignUpForm = new RelayCommand<string>(_ => true, _ => ShowSignUpForm());

        _splashPopupController.ShowPopupSignInForm = _showPopupSignInForm;
        _splashPopupController.ShowPopupSignUpForm = _showPopupSignUpForm;
    }

    private void ShowSignInForm()
    {
        var popup = UIPopup.Get(_popupSignInFormPrefab.name);
        var form = popup.GetComponent<SignInForm>();

        //Init MVC
        var accountService = _container.Resolve<IAccountService>();
        var signInPopupService = _container.Resolve<SignInPopupService>();
        var signUpPopupService = _container.Resolve<SignUpPopupService>();
        var controller = _signInFormFactory(accountService, signInPopupService, signUpPopupService);
        form._signInFormController = controller;

        popup.Show();
    }


    private void ShowSignUpForm()
    {
        var popup = UIPopup.Get(_popupSignUpFormPrefab.name);
        var form = popup.GetComponent<SignUpForm>();

        //Init MVC
        var accountService = _container.Resolve<IAccountService>();
        var signInPopupService = _container.Resolve<SignInPopupService>();
        var signUpPopupService = _container.Resolve<SignUpPopupService>();
        var controller = _signUpFormFactory(accountService, signInPopupService, signUpPopupService);
        form._controller = controller;

        popup.Show();
    }
}
