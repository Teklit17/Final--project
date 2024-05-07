﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Report_Generator_Domain.Commands;

namespace Report_Generator_EntityFramework.Commands
{
    public class UpdateReportCommand : IUpdateReportCommand
    {
        private readonly ReportModelDbContextFactory _contextFactory;

        public UpdateReportCommand(ReportModelDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(ReportModel reportModel)
        {
            using (var context = _contextFactory.Create())
            {
                // Fetch the existing report including all related entities
                var existingReport = await context.ReportModels
                    .Include(r => r.Images)
                    .Include(r => r.Test)
                    .Include(r => r.Verktøy)
                    .Include(r => r.DataFraOppdragsgiverPrøver)
                    .Include(r => r.DataEtterKuttingOgSlipingModel)
                     .Include(r => r.ConcreteDensityModel)
                     .Include(r => r.TrykktestingModel)

                    .FirstOrDefaultAsync(r => r.Id == reportModel.Id);

                if (existingReport != null)
                {
                    // Update primary fields of the main report
                    existingReport.Tittle = reportModel.Tittle;
                    existingReport.Status = reportModel.Status;
                    existingReport.Kunde = reportModel.Kunde;

                    // Update related collections
                    UpdateImages(context, existingReport, reportModel);
                    UpdatePrøver(context, existingReport, reportModel);
                    UpdateVerktøy(context, existingReport, reportModel);
                    UpdateTest(context, existingReport, reportModel);
                    UpdateEtterKuttingPrøver(context, existingReport, reportModel);
                    UpdateConcreteDensity(context, existingReport, reportModel);
                    Updatetrykketessting(context, existingReport, reportModel);


                    // Save all changes to the database
                    await context.SaveChangesAsync();
                }
            }
        }



        private void UpdateImages(DbContext context, ReportModel existingReport, ReportModel newReport)
        {
            foreach (var existingImage in existingReport.Images.ToList())
            {
                if (!newReport.Images.Any(p => p.Id == existingImage.Id))
                {
                    context.Remove(existingImage);
                }
            }

            if (newReport.Images.Any())
            {
                foreach (var newImage in newReport.Images)
                {
                    if (!existingReport.Images.Any(p => p.Id == newImage.Id))
                    {
                        context.Add(newImage);
                    }
                }
            }
            else
            {
                context.RemoveRange(existingReport.Images);
            }

            context.SaveChanges();
        }


        private void UpdatePrøver(DbContext context, ReportModel existingReport, ReportModel newReport)
        {
            foreach (var existingPrøve in existingReport.DataFraOppdragsgiverPrøver.ToList())
            {
                if (!newReport.DataFraOppdragsgiverPrøver.Any(p => p.Id == existingPrøve.Id))
                {
                    context.Remove(existingPrøve);
                }
            }

            if (newReport.DataFraOppdragsgiverPrøver.Any())
            {
                foreach (var newPrøve in newReport.DataFraOppdragsgiverPrøver)
                {
                    if (!existingReport.DataFraOppdragsgiverPrøver.Any(p => p.Id == newPrøve.Id))
                    {
                        context.Add(newPrøve);
                    }
                }
            }
            else
            {
                context.RemoveRange(existingReport.DataFraOppdragsgiverPrøver);
            }

            context.SaveChanges();
        }

        private void UpdateEtterKuttingPrøver(DbContext context, ReportModel existingReport, ReportModel newReport)
        {
            foreach (var existingPrøve in existingReport.DataEtterKuttingOgSlipingModel.ToList())
            {
                if (!newReport.DataEtterKuttingOgSlipingModel.Any(p => p.Id == existingPrøve.Id))
                {
                    context.Remove(existingPrøve);
                }
            }

            if (newReport.DataEtterKuttingOgSlipingModel.Any())
            {
                foreach (var newPrøve in newReport.DataEtterKuttingOgSlipingModel)
                {
                    if (!existingReport.DataEtterKuttingOgSlipingModel.Any(p => p.Id == newPrøve.Id))
                    {
                        context.Add(newPrøve);
                    }
                }
            }
            else
            {
                context.RemoveRange(existingReport.DataEtterKuttingOgSlipingModel);
            }

            context.SaveChanges();
        }


        private void UpdateVerktøy(DbContext context, ReportModel existingReport, ReportModel newReport)
        {
            foreach (var existingverktøy in existingReport.Verktøy.ToList())
            {
                if (!newReport.Verktøy.Any(p => p.Id == existingverktøy.Id))
                {
                    context.Remove(existingverktøy);
                }
            }

            if (newReport.Verktøy.Any())
            {
                foreach (var newVerktøy in newReport.Verktøy)
                {
                    if (!existingReport.Verktøy.Any(p => p.Id == newVerktøy.Id))
                    {
                        context.Add(newVerktøy);
                    }
                }
            }
            else
            {
                context.RemoveRange(existingReport.Verktøy);
            }

            context.SaveChanges();
        }


        private void UpdateTest(DbContext context, ReportModel existingReport, ReportModel newReport)
        {
            foreach (var existingTest in existingReport.Test.ToList())
            {
                if (!newReport.Test.Any(p => p.Id == existingTest.Id))
                {
                    context.Remove(existingTest);
                }
            }

            if (newReport.Test.Any())
            {
                foreach (var newTest in newReport.Test)
                {
                    if (!existingReport.Test.Any(p => p.Id == newTest.Id))
                    {
                        context.Add(newTest);
                    }
                }
            }
            else
            {
                context.RemoveRange(existingReport.Test);
            }

            context.SaveChanges();
        }


        private void UpdateConcreteDensity(DbContext context, ReportModel existingReport, ReportModel newReport)
        {
            foreach (var existingPrøve in existingReport.ConcreteDensityModel.ToList())
            {
                if (!newReport.ConcreteDensityModel.Any(p => p.Id == existingPrøve.Id))
                {
                    context.Remove(existingPrøve);
                }
            }

            if (newReport.ConcreteDensityModel.Any())
            {
                foreach (var newPrøve in newReport.ConcreteDensityModel)
                {
                    if (!existingReport.ConcreteDensityModel.Any(p => p.Id == newPrøve.Id))
                    {
                        context.Add(newPrøve);
                    }
                }
            }
            else
            {
                context.RemoveRange(existingReport.ConcreteDensityModel);
            }

            context.SaveChanges();
        }



        private void Updatetrykketessting(DbContext context, ReportModel existingReport, ReportModel newReport)
        {
            // Remove existing prøver that are not present in the newReport
            foreach (var existingPrøve in existingReport.TrykktestingModel.ToList())
            {
                if (!newReport.TrykktestingModel.Any(p => p.Id == existingPrøve.Id))
                {
                    context.Remove(existingPrøve);
                }
            }

            // Check if the newReport has any prøver, and remove all existing if no new prøver are provided
            if (newReport.TrykktestingModel.Any())
            {
                // Add new prøver from newReport, only if there are any
                foreach (var newPrøve in newReport.TrykktestingModel)
                {
                    if (!existingReport.TrykktestingModel.Any(p => p.Id == newPrøve.Id))
                    {
                        context.Add(newPrøve);
                    }
                }
            }
            else
            {
                // If newReport has no prøver, remove all existing ones
                context.RemoveRange(existingReport.TrykktestingModel);
            }

            // Save changes to the database after updates
            context.SaveChanges();
        }

    }
}
