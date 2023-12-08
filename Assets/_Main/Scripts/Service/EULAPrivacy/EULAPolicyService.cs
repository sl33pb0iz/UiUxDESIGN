using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EULAPolicyService : INotifyPropertyChanged
{
    private bool isPolicyChecked ;
    public bool IsPolicyChecked
    {
        get
        {
            return isPolicyChecked;
        }
        set
        {
            isPolicyChecked = value;
            OnPropertyChanged(nameof(IsPolicyChecked));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool IsChecked()
    {
        if (PlayerPrefs.GetInt("showGDPR", 0) == 1)
        {
            return true;
        }
        return false;
    }

    public void Checked()
    {
        PlayerPrefs.SetInt("showGDPR", 1);
        IsPolicyChecked = true;
    }

    public void OpenPolicyURL()
    {
        Application.OpenURL("https://www.facebook.com/");
    }
}
