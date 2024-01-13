namespace GörselÖdev2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public partial class HavaDurumu : ContentPage
{
	public HavaDurumu()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, System.EventArgs e)
    {
        string sehir = textBox.Text;
        sehir = sehir.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
        sehir = sehir.Replace('Ç', 'C');
        sehir = sehir.Replace('Ğ', 'G');
        sehir = sehir.Replace('İ', 'I');
        sehir = sehir.Replace('Ö', 'O');
        sehir = sehir.Replace('Ü', 'U');
        sehir = sehir.Replace('Ş', 'S');

        string imageUrl = $"https://www.mgm.gov.tr/sunum/tahmin-klasik-5070.aspx?m={sehir}&basla=1&bitir=5&rC=111&rZ=fff";


        ImageButton newImage = new ImageButton
        {
            Source = imageUrl,
            HeightRequest = 200,
            WidthRequest = 400

        };



        newImage.Clicked += DeleteButton_Clicked;
        newImage.IsVisible = true;
        StackLayout imageLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 10
        };
        imageLayout.Children.Add(newImage);

        imageStackLayout.Children.Add(imageLayout);
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs e)
    {
        ImageButton deleteButton = (ImageButton)sender;
        StackLayout imageLayout = (StackLayout)deleteButton.Parent;
        imageStackLayout.Children.Remove(imageLayout);
    }
}

   
