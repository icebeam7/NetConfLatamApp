using System;
using System.Threading.Tasks;

using Microsoft.Maui.Controls;
using NetConfLatamApp.Models;
using NetConfLatamApp.Helpers;

namespace NetConfLatamApp.ViewModels
{
    internal class SessionsListViewModel : ListBaseViewModel<Session>
    {
        protected override async Task GoToDetail(Type page)
        {
            if (SelectedData != null)
            {
                var newPage = (Page)Activator.CreateInstance(page);

                var vm = new SessionDetailViewModel(Constants.SessionsController, Constants.SessionsController, SelectedData);
                newPage.BindingContext = vm;

                await navigation.PushAsync(newPage);
            }
        }

        public SessionsListViewModel(INavigation navigation) :
            base(Constants.SessionsController, navigation)
        {
        }

    }
}
