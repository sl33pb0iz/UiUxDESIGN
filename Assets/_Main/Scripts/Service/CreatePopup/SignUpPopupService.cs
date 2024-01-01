using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SignUpPopupService : IPopupService
{
    private bool _isPopup = false;
    public bool IsPopup 
    { 
        get 
        { 
            return _isPopup; 
        }
        set
        {
            if (_isPopup == value) return;
            _isPopup = value;
            OnPropertyChanged(nameof(IsPopup));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
