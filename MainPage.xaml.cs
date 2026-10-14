using StorageApp.Resources.Entities;

namespace StorageApp
{
    public partial class MainPage : ContentPage
    {
        private readonly Database _database;
        public MainPage()
        {
            InitializeComponent();
            _database = new Database();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var products = await _database.GetProductsAsync();

            ProductsList.ItemsSource = products;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var vsl = sender as VerticalStackLayout;
            var ctx = vsl.BindingContext;
            if (ctx is not Product selected)
            {
                return;
            }

            await Navigation.PushAsync(new ProductPage(selected));

        }

        private async void New_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage());
        }
    }
}
