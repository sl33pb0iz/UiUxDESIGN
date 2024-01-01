using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignUpForm : MonoBehaviour
{
    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton _buttonSignIn;

    [Title("TOGGLE", titleAlignment: TitleAlignments.Centered)]

    [Title("INPUT FIELD", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private TMP_InputField _usernameID;
    [SerializeField] private TMP_InputField _passwordID;

    [HideInInspector] public SignUpFormController _controller;

    private ICommand _hideSignUpForm;

    private UIPopup _uiPopup;

    private void Awake()
    {
        _uiPopup = GetComponent<UIPopup>();
    }

    private void Start()
    {
        _hideSignUpForm = new RelayCommand<string>(_ => true, _ => HideSideUpForm());
        _controller.HideSignUpForm = _hideSignUpForm;
    }

    private void OnEnable()
    {
        _buttonSignIn.onClickEvent.AddListener(() => _controller.SetShowPopupSignInForm());
    }

    private void OnDisable()
    {
        _buttonSignIn.onClickEvent.AddListener(() => _controller.SetShowPopupSignInForm());
    }

    private void HideSideUpForm()
    {
        _uiPopup.Hide();
    }

    private void OnDestroy()
    {
        _controller.Dispose();
    }



}
