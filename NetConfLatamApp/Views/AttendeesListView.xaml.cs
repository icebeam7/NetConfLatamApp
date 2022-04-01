using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

using NetConfLatamApp.ViewModels;

namespace NetConfLatamApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttendeesListView : ContentPage
    {
        AttendeesListViewModel vm;

        public AttendeesListView()
        {
            InitializeComponent();

            vm = new AttendeesListViewModel(Navigation);
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.LoadDataCommand.Execute(null);
        }
    }
}