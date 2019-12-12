using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Countr.Core.Models;
using Countr.Core.ViewModels;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Countr.Core.ViewModels
{

    public class ViewModel4 : MvxViewModel
    {
        readonly IMvxNavigationService _navigationService;

        public ViewModel4(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ReturnToView2Command = new MvxAsyncCommand(ReturnToView2Clicked);
            CancelCommand = new MvxAsyncCommand(Cancel);
        }

        public IMvxAsyncCommand ReturnToView2Command { get; }


        async Task ReturnToView2Clicked()
        {
            await _navigationService.Navigate(typeof(ViewModel2), new Counter());
        }

        //----using a custom presenter and fragments to navigate the back stack. Not fully developed and seems to be a second choice to LaunchMode=SingleTask
        //public override void Show(MvxViewModelRequest request)
        //{
        //    if (vmRequest.PresentationValues != null)
        //    {
        //        if (request.PresentationValues.ContainsKey("NavigationMode") && request.PresentationValues["NavigationMode"] == "BackOrInPlace")
        //        {
        //            var hasFragmentTypeInStack =
        //                Enumerable.Range(0, _fragmentManager.BackStackEntryCount - 1)
        //                          .Reverse()
        //                          .Any(index => _fragmentManager.GetBackStackEntryAt(index).Name == fragmentType.Name);

        //            if (hasFragmentTypeInStack)
        //            {
        //                while (CurrentFragment.GetType() != fragmentType)
        //                    _fragmentManager.PopBackStackImmediate();

        //                return;
        //            }

        //            _fragmentManager.PopBackStackImmediate();
        //        }
        //    }


        //}

        public IMvxAsyncCommand CancelCommand { get; }

        async Task Cancel()
        {
            await _navigationService.Close(this);
        }
    }


}
