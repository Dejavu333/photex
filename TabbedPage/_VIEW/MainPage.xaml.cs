using PHOTEX.MODEL.DOMAIN;
using PHOTEX.MODEL.REPOSITORY;
using PHOTEX.SERVICE;

namespace PHOTEX;

public partial class MainPage : ContentPage
{
    //properties
    ITextService<Text> _textService = MauiProgram._container.GetService<ITextService<Text>>();
    IPhotoService<Text,Photo> _photoService = MauiProgram._container.GetService<IPhotoService<Text,Photo>>();

    //constructors
    public MainPage()
    {
        InitializeComponent();
    }

    //methods
    private async void photoToText(object sender, EventArgs e)
    {
        Photo p = await _photoService.shotPhoto();

        Text t = _photoService.textFromPhoto(p);
        
        controll(t);
    }

    View layout;
    private void controll(Text t)
    {
        ////Application.Current.MainPage.DisplayAlert("test", t.name, "ok");
        
        //save this page layout
        layout = this.Content;

        //add a button
        Application.Current.MainPage.Dispatcher.Dispatch(() =>
        {
            var label = new Label
            {
                Margin = new Thickness(10, 10, 10, 10),
                Text = t.content,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            
            var saveButton = new Button
            {
                Text = "Save",
                HorizontalOptions = LayoutOptions.Center
            };
                saveButton.Clicked += (sender, e) =>
                {
                    _textService.saveTextLocally(t);
                };

            var copyButton = new Button
            {
                Text = "Copy",
                HorizontalOptions = LayoutOptions.Center
            };
            copyButton.Clicked += (sender, e) =>
                {
                    _textService.copyText(t);

                    copyButton.Text = "Succes";
                    copyButton.Opacity = 0.5;
                    Device.StartTimer(TimeSpan.FromSeconds(2), () =>
                    {
                        copyButton.Text = "Copy";
                        copyButton.Opacity = 1;
                        return false;
                    });
                };

            var cancelButton = new Button
            {
                Text = "Cancel",
                HorizontalOptions = LayoutOptions.Center,
            };
                cancelButton.Clicked += (sender, e) =>
                {
                    this.Content = layout;
                };

            //place buttons next to each other
            var stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            stackLayout.Children.Add(saveButton);
            stackLayout.Children.Add(copyButton);
            stackLayout.Children.Add(cancelButton);

            //add the label and the buttons to the main layout
            var mainLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            mainLayout.Children.Add(label);
            mainLayout.Children.Add(stackLayout);

            //add the main layout to the page
            Content = mainLayout;

        });

        

    }

    private void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
    {
        Application.Current.MainPage.DisplayAlert("Favorite", "Favorite invoked", "OK");
    }

    private void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
    {
        Application.Current.MainPage.DisplayAlert("Delete", "Delete invoked", "OK");
    }

}


public class TextController
{
    public readonly ITextService<Text> _textService;

    public TextController(ITextService<Text> p_textService)
    {
        this._textService = p_textService;
    }
}


public class PhotoController
{
    public readonly IPhotoService<Text, Photo> _photoService;

    public PhotoController(IPhotoService<Text, Photo> p_photoService)
    {
        this._photoService = p_photoService;
    }
}