using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class GuestSignInForm : MonoBehaviour
{
    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton _buttonClose;
    [SerializeField] private UIButton _buttonSignIn;
    [SerializeField] private UIButton _buttonSignUp;
    [SerializeField] private UIButton _forgotPassword;

    [Title("TOGGLE", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIToggle _rememberMe;

    [Title("INPUT FIELD", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private TMP_InputField _usernameID;
    [SerializeField] private TMP_InputField _passwordID;

    [Title("PREFAB", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIPopup _accountSignUpFormPrefab; 

    [HideInInspector] public GuestSignInFormController _guestSignInFormController;

    
    public IObjectResolver container;
    private ICommand _signedInSignal;
    
    private UIPopup _popupController; 

    public void Init()
    {
        _signedInSignal = new RelayCommand<string>(_ => true, _ => SignedIn());
        _guestSignInFormController.SignedInSignal = _signedInSignal;

        _buttonSignIn.onLeftClickEvent.AddListener(_guestSignInFormController.ControllerSignIn);
        _buttonSignUp.onLeftClickEvent.AddListener(SetGuestSignUpFormVisibility);
    }

    private void Awake()
    {
        _popupController = GetComponent<UIPopup>();
    }

    private void OnDisable()
    {
        _buttonSignIn.onLeftClickEvent.RemoveListener(_guestSignInFormController.ControllerSignIn);
        _buttonSignUp.onLeftClickEvent.RemoveListener(SetGuestSignUpFormVisibility);
    }

    private void OnDestroy()
    {
        _guestSignInFormController.Dispose();
    }


    private void SignedIn()
    {
        _popupController.Hide();
    }

    public void SetGuestSignUpFormVisibility()
    {
        var popup = UIPopup.Get(_accountSignUpFormPrefab.name);

        var form = popup.GetComponent<GuestSignUpForm>();
        using (var factory = new SignUpFormFactory(container, form))
        {
            factory.Create();
        }

        popup.Show();
        _popupController.Hide();

    }

}
