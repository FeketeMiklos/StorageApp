using StorageApp.Resources.Entities;

namespace StorageApp;

public partial class ProductPage : ContentPage
{
    private Product productFromMain;
    private readonly Database _database;
    public ProductPage()
	{
		InitializeComponent();
        _database = new Database();
        Title = "Add new product";
        deleteBtn.Text = "Cancel";
    }

    public ProductPage(Product product)
    {
        InitializeComponent();
        _database = new Database();
        Title = "Edit product data";
        deleteBtn.Text = "Delete";

        productFromMain = product;
        productName.Text = product.Name;
        productBarcode.Text = product.Barcode;
        productPrice.Text = product.Price.ToString();
        productQuantity.Text = product.Quantity.ToString();

    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        if (productFromMain == null)
        {
            await Navigation.PopAsync();
        }
        else 
        {
            bool delete = await DisplayAlertAsync("Delete", "Are you sure you want to delete this product?", "Delete", "Cancel");
            if (delete)
            {
                await _database.DeleteProductAsync(productFromMain);
                await Navigation.PopAsync();
            }
        }
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (productFromMain == null)
        {
            Product product = new Product(productName.Text, productBarcode.Text, decimal.Parse(productPrice.Text), decimal.Parse(productQuantity.Text));
            await _database.SaveProductAsync(product);
            await Navigation.PopAsync();
        }
        else
        {
            productFromMain.Name = productName.Text;
            productFromMain.Barcode = productBarcode.Text;
            productFromMain.Price = decimal.Parse(productPrice.Text);
            productFromMain.Quantity = decimal.Parse(productQuantity.Text);
            await _database.SaveProductAsync(productFromMain);
            await Navigation.PopAsync();
        }
    }
}