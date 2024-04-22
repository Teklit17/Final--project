﻿using Domain.Models;
using Final_project.Stores;
using Final_project.ViewModels;
using Final_project.Views;
using Report_Generator_Domain.Models;

namespace Final_project.Commands
{
    public class AddReportCommand : AsyncCommandBase
    {
        private readonly AddReportVM _addReportVM;
        private readonly ReportStore _reportStore;
        private readonly NavigationStore _navigationStore;
        private readonly ModalWindow _modalWindow;


        public AddReportCommand(ModalWindow modalWindow, AddReportVM addReportVM, ReportStore reportStore, NavigationStore navigationStore)
        {
            _modalWindow = modalWindow;
            _addReportVM = addReportVM;
            _reportStore = reportStore;
            _navigationStore = navigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            ReportFormVM reportForm = _addReportVM.ReportFormVM;

            ReportModel reportModel = new ReportModel(
                Guid.NewGuid(),
                reportForm.Tittle, // Ensure 'Tittle' is the intended property name (commonly 'Title')
                reportForm.Status,
                reportForm.Kunde

            );

            // Assuming the ImageCollectionVM is part of your ReportFormVM
            foreach (var imageVM in reportForm.ImageCollectionViewModel.Images)
            {
                ReportImageModel imageModel = new ReportImageModel(
                    imageVM.ImageId,
                    imageVM.ImageName,
                    imageVM.ImageUri.ToString(),
                    reportModel.Id); // Use 'reportModel' instead of 'newReport'
                reportModel.Images.Add(imageModel);
            }

            foreach (var Prøver in reportForm.DataFraOppdragsgiverTableVM.Prøver)
            {
                DataFraOppdragsgiverPrøverModel prøverModel = new DataFraOppdragsgiverPrøverModel(
                       Guid.NewGuid(),
                       Prøver.Datomottatt,
                       Prøver.Overdekningoppgitt,
                       Prøver.Dmax,
                       Prøver.KjerneImax,
                       Prøver.KjerneImin,
                       Prøver.OverflateOK,
                       Prøver.OverflateUK,
                       reportModel.Id); // Use 'reportModel' instead of 'newReport'
                reportModel.DataFraOppdragsgiverPrøver.Add(prøverModel);
            }


            foreach (var Prøver in reportForm.DataEtterKuttingOgSlipingTableVM.Prøver)
            {
                // Check if Prøver is null before creating a new DataEtterKuttingOgSlipingModel
                if (Prøver != null)
                {
                    DataEtterKuttingOgSlipingModel prøverModel = new DataEtterKuttingOgSlipingModel(
                        Guid.NewGuid(),
                        Prøver.IvannbadDato,
                        Prøver.TestDato,
                        Prøver.Overflatetilstand,
                        Prøver.Dm,
                        Prøver.Prøvetykke,
                        Prøver.DmPrøvetykkeRatio,
                        Prøver.TrykkfasthetMPa,
                        Prøver.FasthetSammenligning,
                        Prøver.FørSliping,
                        Prøver.EtterSliping,
                        Prøver.MmTilTopp,
                        reportModel.Id
                    );

                    reportModel.DataEtterKuttingOgSlipingModel.Add(prøverModel);
                }
                else
                {
                    // Handle the case where Prøver is null
                    // (e.g., log an error, display a message to the user)
                    Console.WriteLine("Prøver object is null.");
                }
            }





            try
            {
                await _reportStore.Add(reportModel);

                //// Assuming modalWindow is the instance of ModalWindow
                //_modalWindow.Dispatcher.Invoke(() =>
                //{
                //    _modalWindow.DialogResult = true; // or false depending on the scenario
                //    _modalWindow.Close();
                //});



            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                throw;
            }
        }
    }
}
