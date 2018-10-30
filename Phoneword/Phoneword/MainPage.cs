using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        Entry entry;
        Button btnCall;

        public MainPage()
        {
            entry = new Entry
            {
                Text = "1-855-XAMARIN"
            };

            Button btnTranslate = new Button
            {
                Text = "Translate"
            };
            btnTranslate.Clicked += OnTranslate;

            btnCall = new Button
            {
                Text = "Call",
                IsEnabled = false
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Enter a Phoneword:"
                    },
                    entry,
                    btnTranslate,
                    btnCall
                }
            };
        }

        private void OnTranslate(object sender, System.EventArgs e)
        {
            string translatedNumber = Core.PhonewordTranslator.ToNumber(entry.Text);

            if(string.IsNullOrEmpty(translatedNumber))
            {
                btnCall.Text = "Call";
                btnCall.IsEnabled = false;
            }
            else
            {
                btnCall.Text = "Call" + translatedNumber;
                btnCall.IsEnabled = true;
            }
        }
    }
}
