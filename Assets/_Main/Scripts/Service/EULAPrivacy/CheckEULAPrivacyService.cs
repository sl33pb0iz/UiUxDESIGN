using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CheckEULAPrivacyService : INotifyPropertyChanged
{
    private bool isPrivacyChecked;
    public bool IsPrivacyChecked
    {
        get
        {
            return isPrivacyChecked;
        }
        set
        {
            isPrivacyChecked = value;
            OnPropertyChanged(nameof(IsPrivacyChecked));
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
    }

    public void OpenPrivacyURL()
    {
        Application.OpenURL("https://www.facebook.com/");
    }
}
