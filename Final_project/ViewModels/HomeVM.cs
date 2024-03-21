﻿using Final_project.Commands;
using Final_project.Stores;
using System.Windows.Input;

namespace Final_project.ViewModels
{
    public class HomeVM : ViewModelBase
    {
        private readonly ModalNavigation _navigationStore;
        public ViewModelBase CurrentVM => _navigationStore.CurrentView;
        public bool IsFormOpen => _navigationStore.IsOpen;

        public ReportDetailsVM ReportDetailsVM { get; }
        public ReportListVM ReportListVM { get; }
        public ICommand AddReportCommand { get; }

        public HomeVM(ReportStore reportStore, SelectedReportStore selectedReportStore, ModalNavigation navigationStore)
        {
            _navigationStore = navigationStore;
            ReportDetailsVM = new ReportDetailsVM(selectedReportStore);
            ReportListVM = ReportListVM.loadViewModel(reportStore, selectedReportStore, navigationStore);

            AddReportCommand = new OpenAddCommand(reportStore, navigationStore);

            _navigationStore.CurrentViewChanged += ModalNavigation_CurrentViewChanged;
        }

        private void ModalNavigation_CurrentViewChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
            OnPropertyChanged(nameof(IsFormOpen));
        }

        protected override void Dispose()
        {
            _navigationStore.CurrentViewChanged -= ModalNavigation_CurrentViewChanged;
            base.Dispose();
        }


        public static HomeVM LoadHome(ReportStore reportStore, SelectedReportStore selectedReportStore, ModalNavigation navigationStore)
        {
            HomeVM viewModel = new HomeVM(reportStore, selectedReportStore, navigationStore);

            //viewModel.HomeVMCommand.Execute(null);

            return viewModel;
        }
    }
}
