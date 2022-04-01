using System;
using System.Threading.Tasks;

using Microsoft.Maui.Controls;
using NetConfLatamApp.Models;
using NetConfLatamApp.Helpers;

namespace NetConfLatamApp.ViewModels
{
    internal class AttendeesListViewModel : ListBaseViewModel<Attendee>
    {
        protected override async Task GoToDetail(Type page)
        {
            if (SelectedData != null)
            {
                var newPage = (Page)Activator.CreateInstance(page);

                var vm = new AttendeeDetailViewModel(Constants.AttendeesController, Constants.SessionsController, SelectedData);
                vm.LoadItemsCommand.Execute(SelectedData.Id);
                newPage.BindingContext = vm;

                await navigation.PushAsync(newPage);
            }
        }

        public AttendeesListViewModel(INavigation navigation) : 
            base(Constants.AttendeesController, navigation)
        {
        }
    }
}
