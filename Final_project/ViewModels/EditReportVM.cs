﻿using CommunityToolkit.Mvvm.ComponentModel;
using Domain.Models;
using Final_project.Commands;
using Final_project.Stores;
using Final_project.ViewModels.ReportComponentsVM;
using Final_project.ViewModels.TablesVM;
using System.Windows.Input;

namespace Final_project.ViewModels
{
    public class EditReportVM : ObservableObject
    {
        private readonly ReportStore _reportStore;

        public Guid ReportId { get; private set; }
        public ReportFormVM ReportFormVM { get; private set; }

        public EditReportVM(ReportModel reportModel, ReportStore reportStore, ModalNavigation modalNavigation, NavigationStore navigationStore, ModalNavigation modalWindowVM)
        {
            _reportStore = reportStore;
            if (reportModel == null)
            {
                throw new ArgumentNullException(nameof(reportModel));
            }

            ReportId = reportModel.Id;

            ICommand submitCommand = new EditReportCommand(modalWindowVM, this, reportStore, navigationStore);
            ICommand cancelCommand = new CloseModalCommand(navigationStore);

            // Pass ReportId to ReportFormVM
            ReportFormVM = new ReportFormVM(submitCommand, cancelCommand, reportStore, modalNavigation, ReportId)
            {
                Tittle = reportModel.Tittle,
                Status = reportModel.Status,
                Kunde = reportModel.Kunde,




            };




            foreach (var img in reportModel.Images)
            {
                var imageVM = new ImageVM(img);
                ReportFormVM.ImageCollectionViewModel.Images.Add(imageVM);
            }



            foreach (var prøve in reportModel.DataFraOppdragsgiverPrøver)
            {
                var prøveVM = new DataFraOppdragsgiverPrøverVM(prøve);
                ReportFormVM.DataFraOppdragsgiverTableVM.Prøver.Add(prøveVM);



                foreach (var trykktestingModel in prøve.TrykktestingModel)
                {
                    var trykktesting = new TrykktestingPrøveVM(trykktestingModel);
                    ReportFormVM.TrykktestingTableVM.Trykketester.Add(trykktesting);

                }


                foreach (var densityModel in prøve.ConcreteDensityModel)
                {
                    var densityPrøveVM = new ConcreteDensityPrøveVM(densityModel);
                    ReportFormVM.ConcreteDensityTableVM.Prøver.Add(densityPrøveVM);
                }


                foreach (var dataEtterKuttingOgSlipingModel in prøve.DataEtterKuttingOgSlipingModel)
                {
                    var dataEtterKuttingOgSlipingprøveVM = new DataEtterKuttingOgSlipingPrøveVM(dataEtterKuttingOgSlipingModel);
                    ReportFormVM.DataEtterKuttingOgSlipingTableVM.Prøver.Add(dataEtterKuttingOgSlipingprøveVM);
                }

            }





        }
    }
}