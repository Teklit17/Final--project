﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Report_Generator_Domain.Models;
using Report_Generator_Domain.Queries;


namespace Report_Generator_EntityFramework.Queries
{
    public class GetReportQuery : IGetReportQuery
    {
        private readonly ReportModelDbContextFactory _contextFactory;

        public GetReportQuery(ReportModelDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<(
             ReportModel report, TestUtførtAvModel testUtførtAvModel, KontrollertAvførtAvModel KontrollertAvførtAvModel,
            List<DataFraOppdragsgiverPrøverModel> dataFraOppdragsgiverPrøverModels,
            List<ReportImageModel> images,
            List<DataEtterKuttingOgSlipingModel> dataEtterKuttingOgSlipingModels,
            List<ConcreteDensityModel> concreteDensityModels,
            List<TrykktestingModel> trykktestingModels,
            List<TestModel> tests,
            List<verktøyModel> verktøyer
            )> Execute(Guid reportId)
        {
            using (var context = _contextFactory.Create())
            {
                var report = await context.ReportModels
                     .Include(r => r.Images)
                    .Include(r => r.Test)
                    .Include(r => r.Verktøy)
                    .Include(r => r.DataFraOppdragsgiverPrøver)
                    .Include(r => r.DataEtterKuttingOgSlipingModel)
                     .Include(r => r.ConcreteDensityModel)
                     .Include(r => r.TrykktestingModel)
                     .Include(r => r.TestUtførtAvModel)
                     .Include(r => r.KontrollertAvførtAvModel)

                       .FirstOrDefaultAsync(r => r.Id == reportId);

                if (report == null)
                    return (null, null, null, null, null, null, null, null, null, null);

                var images = report.Images.ToList();
                var testUtførtAvModel = report.TestUtførtAvModel;
                var kontrollertav = report.KontrollertAvførtAvModel;
                var tests = report.Test.ToList();
                var verktøies = report.Verktøy.ToList();
                var dataFraOppdragsgiverPrøverModels = report.DataFraOppdragsgiverPrøver.ToList();
                var concreteDensityModels = report.ConcreteDensityModel.ToList();
                var trykktestingModels = report.TrykktestingModel.ToList();
                var dataEtterKuttingOgSlipingModels = report.DataEtterKuttingOgSlipingModel.ToList();

                var dataFraOppdragsgiverPrøverModel = dataFraOppdragsgiverPrøverModels.FirstOrDefault();

                return (
                    report,
                    testUtførtAvModel,
                    kontrollertav,
                    dataFraOppdragsgiverPrøverModels,
                    images,
                    dataEtterKuttingOgSlipingModels,
                    concreteDensityModels,
                    trykktestingModels,
                    tests,
                    verktøies

                );
            }
        }
    }
}
