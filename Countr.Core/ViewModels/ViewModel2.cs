using System.Threading.Tasks;
using Countr.Core.Models;
using Countr.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Countr.Core.ViewModels
{
    public class ViewModel2 : MvxViewModel<Counter>
    {
        Counter counter;
        readonly ICountersService service;
        readonly IMvxNavigationService navigationService;

        public ViewModel2(ICountersService service, IMvxNavigationService navigationService) //this is the real code
        {
            this.service = service; 
            this.navigationService = navigationService;
            IncrementCommand = new MvxAsyncCommand(IncrementCounter);
            DeleteCommand = new MvxAsyncCommand(DeleteCounter);
            CancelCommand = new MvxAsyncCommand(Cancel);
            SaveCommand = new MvxAsyncCommand(Save);
            ShowView3Command = new MvxAsyncCommand(ShowView3Clicked);
        }

        public IMvxAsyncCommand IncrementCommand { get; }


        async Task IncrementCounter()
        {
            await service.IncrementCounter(counter);
            RaisePropertyChanged(() => Count);
        }

        public IMvxAsyncCommand DeleteCommand { get; }

        async Task DeleteCounter()
        {
            await service.DeleteCounter(counter);
        }

        public override void Prepare(Counter counter)
        {
            this.counter = counter;
        }

        public string Name
        {
            get { return counter.Name; }
            set
            {
                if (Name == value) return;
                counter.Name = value;
                RaisePropertyChanged();
            }
        }

        public int Count => counter.Count;

        public IMvxAsyncCommand CancelCommand { get; }
        public IMvxAsyncCommand SaveCommand { get; }
        public MvxAsyncCommand ShowView3Command { get; }

        async Task Cancel()
        {
            await navigationService.Close(this);                            
        }

        async Task Save()
        {
            await service.AddNewCounter(counter.Name);                      
            await navigationService.Close(this);                            
        }

        async Task ShowView3Clicked()
        {
            await navigationService.Navigate(typeof(ViewModel3));
        }
    }
}