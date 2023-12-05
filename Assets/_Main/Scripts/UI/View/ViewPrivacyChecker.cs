using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UI.Enum;
using UnityEngine;
using UnityEngine.UIElements;

public class ViewPrivacyChecker : MonoBehaviour
{
    /*public UIPopup PopupPrivacyPrefab;

    private ControllerPrivacyChecker _viewModelPrivacyChecker;
    private ICommand _ShowPopupCommand;

    private void Awake()
    {
        _viewModelPrivacyChecker = new();
        _ShowPopupCommand = new RelayCommand<bool>(p => _viewModelPrivacyChecker.CanShowPrivacy(), p => ShowPopupPrivacy());
    } 

    private void Start()
    {
        if (_ShowPopupCommand.CanExecute(true))
        {
            _ShowPopupCommand.Execute(true);
        }
    }

    public void ShowPopupPrivacy()
    {
        var popup = UIPopup.Get(PopupPrivacyPrefab.name);
        popup.Show();
    }*/
}
