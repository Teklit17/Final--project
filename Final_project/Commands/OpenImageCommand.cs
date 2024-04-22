﻿using Final_project.Stores;
using Final_project.ViewModels;

namespace Final_project.Commands
{
    class OpenImageCommand : CommandBase
    {
        private readonly ReportStore _reportStore;
        private readonly NavigationStore _navigationStore;
        private readonly Guid _reportid;

        public OpenImageCommand(ReportListingItemVM reportListingItemVM, ReportStore reportStore, NavigationStore navigationStore)
        {
            _reportStore = reportStore;
            _navigationStore = navigationStore;


            _reportid = reportListingItemVM.ReportModel.Id;
        }

        public override void Execute(object parameter)
        {
            ImageCollectionVM imageReportVM = new ImageCollectionVM(_reportStore, _reportid);
            _navigationStore.CurrentViewModel = imageReportVM;
        }
    }
}
