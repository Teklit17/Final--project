﻿using Domain.Models;
using Final_project.ViewModels;
using Report_Generator_Domain.Models;

namespace Final_project.Other
{
    public class ReportModelFactory
    {
        public static ReportModel CreateReportModel(ReportFormVM reportForm, Guid? reportId = null)
        {
            if (reportForm == null)
            {
                throw new ArgumentNullException(nameof(reportForm), "ReportFormVM cannot be null.");
            }

            // If reportId is not provided, generate a new GUID
            Guid id = reportId ?? Guid.NewGuid();


            ReportModel reportModel = new ReportModel(
                id,
                reportForm.Tittle,
                reportForm.Status,
                reportForm.Kunde
            );


            if (reportForm.ImageCollectionViewModel != null)
            {
                foreach (var imageVM in reportForm.ImageCollectionViewModel.Images)
                {
                    if (imageVM != null)
                    {
                        ReportImageModel imageModel = new ReportImageModel(
                            imageVM.ImageId,
                            imageVM.ImageName,
                            imageVM.ImageUri?.ToString(),
                            reportModel.Id
                        );
                        reportModel.Images.Add(imageModel);
                    }
                }
            }


            if (reportForm.DataFraOppdragsgiverTableVM != null)
            {
                foreach (var prøve in reportForm.DataFraOppdragsgiverTableVM.Prøver)
                {
                    if (prøve != null)
                    {
                        DataFraOppdragsgiverPrøverModel prøverModel = new DataFraOppdragsgiverPrøverModel(
                            Guid.NewGuid(),
                            prøve.Datomottatt,
                            prøve.Overdekningoppgitt,
                            prøve.Dmax,
                            prøve.KjerneImax,
                            prøve.KjerneImin,
                            prøve.OverflateOK,
                            prøve.OverflateUK,
                            reportModel.Id
                        );
                        reportModel.DataFraOppdragsgiverPrøver.Add(prøverModel);
                    }
                }
            }

            if (reportForm.DataEtterKuttingOgSlipingTableVM != null)
            {
                foreach (var prøve in reportForm.DataEtterKuttingOgSlipingTableVM.Prøver)
                {
                    if (prøve != null)
                    {
                        DataEtterKuttingOgSlipingModel prøverModel = new DataEtterKuttingOgSlipingModel(
                            Guid.NewGuid(),
                            prøve.IvannbadDato,
                            prøve.TestDato,
                            prøve.Overflatetilstand,
                            prøve.Dm,
                            prøve.Prøvetykke,
                            prøve.DmPrøvetykkeRatio,
                            prøve.TrykkfasthetMPa,
                            prøve.FasthetSammenligning,
                            prøve.FørSliping,
                            prøve.EtterSliping,
                            prøve.MmTilTopp,
                            reportModel.Id
                        );
                        reportModel.DataEtterKuttingOgSlipingModel.Add(prøverModel);
                    }
                }
            }

            // Create ConcreteDensityTable
            if (reportForm.ConcreteDensityTableVM != null)
            {
                foreach (var prøve in reportForm.ConcreteDensityTableVM.Prøver)
                {
                    if (prøve != null)
                    {
                        ConcreteDensityModel concreteDensityModel = new ConcreteDensityModel(
                            prøve.Provnr,
                            prøve.Dato,
                            prøve.MasseILuft,
                            prøve.MasseIVannbad,
                            prøve.Pw,
                            prøve.V,
                            prøve.Densitet,
                            reportModel.Id
                        );
                        reportModel.ConcreteDensityModel.Add(concreteDensityModel);
                    }
                }
            }

            // Create TrykktestingTable
            if (reportForm.TrykktestingTableVM != null)
            {
                foreach (var trykktesting in reportForm.TrykktestingTableVM.Trykketester)
                {
                    if (trykktesting != null)
                    {
                        TrykktestingModel trykktestingModel = new TrykktestingModel(
                            Guid.NewGuid(),
                            trykktesting.TrykkflateMm,
                            trykktesting.PalastHastighetMPas,
                            trykktesting.TrykkfasthetMPa,
                            trykktesting.TrykkfasthetMPaNSE,
                            reportModel.Id
                        );
                        reportModel.TrykktestingModel.Add(trykktestingModel);
                    }
                }
            }

            return reportModel;
        }
    }
}
