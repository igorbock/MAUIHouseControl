using WarehouseLib.Interfaces;
using WarehouseLib.Models;

namespace MAUIHouseControl
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IRepository<Produto> _repositoryProduto;

        public MainPage(IRepository<Produto> repositoryProduto)
        {
            InitializeComponent();
            _repositoryProduto = repositoryProduto;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            var produtoCount = 0;
            if(_repositoryProduto != null)
                produtoCount = _repositoryProduto.GetAll().Count;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time. Tem {produtoCount} produtos.";
            else
                CounterBtn.Text = $"Clicked {count} times. Tem {produtoCount} produtos.";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
