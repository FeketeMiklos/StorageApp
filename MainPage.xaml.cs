using StorageApp.Resources.Entities;


namespace StorageApp
{
    public partial class MainPage : ContentPage
    {
        private readonly Database _database;
        public List<Product> productsList;
        private CancellationTokenSource? _debounceCts;
        private string _nameQuery = string.Empty;
        private string _barcodeQuery = string.Empty;

        public MainPage()
        {
            InitializeComponent();
            _database = new Database();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var products = await _database.GetProductsAsync();

            productsList = products;

            ProductsList.ItemsSource = productsList;

            searchName.Text = "";
            searchCode.Text = "";
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

        private async void OnNameSearchTextChanged(object? sender, TextChangedEventArgs e)
        {
            _nameQuery = e.NewTextValue ?? string.Empty;
            await DebounceSearchAsync();
        }

        private async void OnBarcodeSearchTextChanged(object? sender, TextChangedEventArgs e)
        {
            _barcodeQuery = e.NewTextValue ?? string.Empty;
            await DebounceSearchAsync();
        }

        private async Task DebounceSearchAsync()
        {
            _debounceCts?.Cancel();
            _debounceCts?.Dispose();

            var cts = new CancellationTokenSource();
            _debounceCts = cts;

            try
            {
                await Task.Delay(500, cts.Token);

                if (_debounceCts == cts)
                {
                    ApplySearch();
                }
            }
            catch (OperationCanceledException)
            {}
            finally
            {
                if (_debounceCts == cts)
                {
                    _debounceCts = null;
                    cts.Dispose();
                }
            }
        }

        private void ApplySearch()
        {
            var nameQuery = _nameQuery.Trim();
            var barcodeQuery = _barcodeQuery.Trim();

            var filtered = productsList
                .Where(p =>
                    (string.IsNullOrEmpty(nameQuery) || (p.Name ?? string.Empty).Contains(nameQuery, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(barcodeQuery) || (p.Barcode ?? string.Empty).Contains(barcodeQuery, StringComparison.OrdinalIgnoreCase))
                ).ToList();

            ProductsList.ItemsSource = filtered;
        }
    }
}
