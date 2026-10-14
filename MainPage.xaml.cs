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
    }
}
