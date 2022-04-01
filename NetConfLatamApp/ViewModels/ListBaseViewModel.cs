using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.Maui.Controls;
using NetConfLatamApp.Services;

namespace NetConfLatamApp.ViewModels
{
    internal abstract class ListBaseViewModel<U> : BaseViewModel
    {
        private IEnumerable<U> data;

        public ObservableCollection<U> DataCollection { get; }

        private U selectedData;

        public U SelectedData
        {
            get => selectedData;
            set => SetProperty(ref selectedData, value);
        }

        public ICommand LoadDataCommand { get; private set; }

        public ICommand GoToDetailCommand { get; private set; }


        private string controller;
        protected INavigation navigation;

        private async Task LoadData()
        {
            if (DataCollection.Count == 0)
            {
                IsBusy = true;

                data = await ApiService.GetItems<U>(controller);

                while (DataCollection.Count > 0)
                    DataCollection.RemoveAt(0);

                foreach (var item in data)
                    DataCollection.Add(item);

                IsBusy = false;
            }
        }

        protected abstract Task GoToDetail(Type page);

        public ListBaseViewModel(string controller, INavigation navigation)
        {
            this.controller = controller;
            this.navigation = navigation;

            DataCollection = new();

            LoadDataCommand = new Command(async () => await LoadData());
            GoToDetailCommand = new Command<Type>(async (page) => await GoToDetail(page));
        }
    }
}
