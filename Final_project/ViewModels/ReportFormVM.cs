﻿using CommunityToolkit.Mvvm.ComponentModel;
using Domain.Models;
using Final_project.Stores;
using Final_project.ViewModels.TablesVM;
using System.Windows.Input;

namespace Final_project.ViewModels
{
    public partial class ReportFormVM : ObservableObject, IDisposable
    {
        private readonly ModalNavigation _modalNavigation;

        public ObservableObject CurrentVM => _modalNavigation.CurrentView;
        public bool IsFormOpen => _modalNavigation.IsOpen;

        public List<ReportImageModel> Images { get; set; }
        public ImageCollectionVM ImageCollectionViewModel { get; set; }
        public DataFraOppdragsgiverTableVM DataFraOppdragsgiverTableVM { get; set; }
        public DataFraOppdragsgiverPrøverVM DataFraOppdragsgiverPrøverVM { get; }


        [ObservableProperty]
        private string _tittle;

        [ObservableProperty]
        private bool _status;

        [ObservableProperty]
        private string _kunde;

        public ICommand AddReportTableCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ReportFormVM(ICommand submitCommand, ICommand cancelCommand, ReportStore reportStore, ModalNavigation modalNavigation, Guid reportid)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
            _modalNavigation = modalNavigation;

            //AddReportTableCommand = new OpenAddReportTableCommand(modalNavigation, reportStore);

            ImageCollectionViewModel = new ImageCollectionVM(reportStore, reportid);
            DataFraOppdragsgiverTableVM = new DataFraOppdragsgiverTableVM(reportStore, reportid);

            DataFraOppdragsgiverPrøverVM = new DataFraOppdragsgiverPrøverVM(reportStore, modalNavigation, reportid, DataFraOppdragsgiverTableVM);


            _modalNavigation.CurrentViewChanged += ModalNavigation_CurrentViewChanged;
        }

        private void ModalNavigation_CurrentViewChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
            OnPropertyChanged(nameof(IsFormOpen));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _modalNavigation.CurrentViewChanged -= ModalNavigation_CurrentViewChanged;
                // Clean up managed resources (if any)

            }
            // Clean up unmanaged resources (if any)
        }
    }
}
