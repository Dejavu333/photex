using PHOTEX.MODEL.DOMAIN;
using PHOTEX.MODEL.REPOSITORY;
using PHOTEX.SERVICE;

namespace PHOTEX;

public partial class SettingsPage : ContentPage
{
    //properties

    //constructors
    public SettingsPage()
    {
        InitializeComponent();
    }

    //methods
    void Switch_Toggled1(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            Application.Current.MainPage.DisplayAlert("test", "on", "ok");
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("test", "off", "ok");
        }
    }

    void Switch_Toggled2(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            Application.Current.MainPage.DisplayAlert("test", "on", "ok");
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("test", "off", "ok");
        }
    }

    void Switch_Toggled3(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            Application.Current.MainPage.DisplayAlert("test", "on", "ok");
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("test", "off", "ok");
        }
    }

    void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            Application.Current.MainPage.DisplayAlert("test", "on", "ok");
            x.Text = "Checked";
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("test", "off", "ok");
            x.Text = "Unchecked";
        }
    }
}

