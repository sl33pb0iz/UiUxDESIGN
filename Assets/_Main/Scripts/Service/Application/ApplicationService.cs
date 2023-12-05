using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ApplicationService : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void ApplicationQuit()
    {
#if UNITY_EDITOR
        AppHelper.Quit();
#else
        Application.Quit();
#endif
    }
    public void ApplicationPause()
    {
        Time.timeScale = 0;
        OnPropertyChanged(nameof(ApplicationPause));
    }

    public void ApplicationStart()
    {
        Time.timeScale = 1;
        OnPropertyChanged(nameof(ApplicationStart));
    }

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
