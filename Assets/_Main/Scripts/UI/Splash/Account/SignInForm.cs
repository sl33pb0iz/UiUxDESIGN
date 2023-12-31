using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class SignInForm : MonoBehaviour
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
    
    public SignInFormController _signInFormController;

    private ICommand _hideSignInForm;
    
    private UIPopup _popupController; 
    private void Awake()
    {
        _popupController = GetComponent<UIPopup>();
    }

    private void Start()
    {
        _hideSignInForm = new RelayCommand<string>(_ => true, _ => HideSignInForm());
        _signInFormController.HideSignInForm = _hideSignInForm;
        _buttonSignIn.onClickEvent.AddListener(_signInFormController.SignIn);
        _buttonSignUp.onClickEvent.AddListener(_signInFormController.SetShowPopupSignUpForm);
    }

    private void OnDisable()
    {
        _buttonSignIn.onClickEvent.RemoveListener(_signInFormController.SignIn);
        _buttonSignUp.onClickEvent.RemoveListener(_signInFormController.SetShowPopupSignUpForm);
    }

    private void HideSignInForm()
    {
        _popupController.Hide();
    }

    private void OnDestroy()
    {
        _signInFormController.SetHidePopupSignInForm();
        _signInFormController.Dispose();
    }
}
