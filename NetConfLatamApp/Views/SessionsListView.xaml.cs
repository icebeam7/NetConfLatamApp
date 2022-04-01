using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

using NetConfLatamApp.ViewModels;

namespace NetConfLatamApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SessionsListView : ContentPage
    {
        SessionsListViewModel vm;

        public SessionsListView()
        {
            InitializeComponent();

            vm = new SessionsListViewModel(Navigation);
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.LoadDataCommand.Execute(null);
        }
    }
}