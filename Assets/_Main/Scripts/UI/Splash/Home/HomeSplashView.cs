using Doozy.Runtime.UIManager.Components;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class HomeSplashView : MonoBehaviour
{
    [Title("BUTTON", titleAlignment: TitleAlignments.Centered)]
    [SerializeField] private UIButton _buttonGameCenterSignIn;
    [SerializeField] private UIButton _buttonFacebookSignIn;
    [SerializeField] private UIButton _buttonGoogleSignIn;
    [SerializeField] private UIButton _buttonGuestSignIn;
    [SerializeField] private UIButton _buttonTapToStart;

    [Inject] private HomeSplashViewController _homeSplashController;

    private ICommand _accountSignedInSignal;

    private void Awake()
    {
        _accountSignedInSignal = new RelayCommand<string>( _ => true, _ => 
        {
            SetSignInButtonsVisibility(false);
            SetTapToStartButtonVisibility(true);
        });
        _homeSplashController.SignedIn = _accountSignedInSignal;
    }

    private void OnEnable()
    {
        _buttonGameCenterSignIn.onClickEvent.AddListener(_homeSplashController.OnGuestSignIn);
        _buttonFacebookSignIn.onClickEvent.AddListener(_homeSplashController.OnFacebookSignIn);
        _buttonGoogleSignIn.onClickEvent.AddListener(_homeSplashController.OnGoogleSignIn);

        _buttonGuestSignIn.onClickEvent.AddListener(_homeSplashController.OnGameCenterSignIn);
    }

    private void OnDisable()
    {
        _buttonGameCenterSignIn.onClickEvent.RemoveListener(_homeSplashController.OnGuestSignIn);
        _buttonFacebookSignIn.onClickEvent.RemoveListener(_homeSplashController.OnFacebookSignIn);
        _buttonGoogleSignIn.onClickEvent.RemoveListener(_homeSplashController.OnGoogleSignIn);

        _buttonGuestSignIn.onClickEvent.RemoveListener(_homeSplashController.OnGameCenterSignIn);
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
}

