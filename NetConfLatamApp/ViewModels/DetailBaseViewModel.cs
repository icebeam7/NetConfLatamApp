using Microsoft.Maui.Controls;
using NetConfLatamApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetConfLatamApp.ViewModels
{
    internal class DetailBaseViewModel<U, V> : BaseViewModel where U : new()
    {
        private U currentItem;

        public U CurrentItem
        {
            get { return currentItem; }
            set { SetProperty(ref currentItem, value); }
        }

        public ObservableCollection<V> SubItems { get; }

        public ICommand AddItemCommand { get; private set; }
        public ICommand LoadItemsCommand { get; private set; }

        public ICommand LoadItemCommand { get; private set; }

        private string controller;
        private string subController;

        private async Task AddItem()
        {
            await ApiService.AddItem(controller, CurrentItem);
        }

        private async Task LoadItems(int id)
        {
            if (id > 0)
            {
                var path = $"{controller}/{id}";
                var items = await ApiService.GetItems<V>(path);

                while (SubItems.Count > 0)
                    SubItems.RemoveAt(0);

                foreach (var item in items)
                    SubItems.Add(item);
            }
        }

        public DetailBaseViewModel(string controller, string subcontroller, U item)
        {
            this.controller = controller;
            this.subController = subcontroller;
            CurrentItem = item;

            AddItemCommand = new Command(async () => await AddItem());
            SubItems = new ObservableCollection<V>();
            LoadItemsCommand = new Command<int>(async (id) => await LoadItems(id));
        }
    }
}
