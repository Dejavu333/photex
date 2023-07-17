using PHOTEX.MODEL.DOMAIN;
using PHOTEX.MODEL.REPOSITORY;
using PHOTEX.SERVICE;
using System.Collections.ObjectModel;

namespace PHOTEX;

public partial class SavedPage : ContentPage
{
    //properties
    ITextService<Text> _textService = MauiProgram._container.GetService<ITextService<Text>>();
    IPhotoService<Text, Photo> _photoService = MauiProgram._container.GetService<IPhotoService<Text, Photo>>();
    public ObservableCollection<Text> savedTexts { get; set; } = new ObservableCollection<Text>();

    //constructors
    public SavedPage()
    {
        InitializeComponent();
        setup();
    }

    private void setup()
    {
        var texts = _textService.allTexts();
        var datasource = new ObservableCollection<Text>(texts);
        savedTexts = datasource;
        BindingContext = this;
    }

    //methods

    //onload show every saved text in the collection view and click on it to open the text
    protected override void OnAppearing()
    {

        ////reload the savedpage
        //var page = new SavedPage();

        //Application.Current.MainPage.Navigation.PushAsync(page);

    }
}

