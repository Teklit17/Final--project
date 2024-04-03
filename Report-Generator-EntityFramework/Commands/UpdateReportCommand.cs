﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Report_Generator_Domain.Commands;
using Report_Generator_EntityFramework.DTOs;

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
                var existingReport = await context.ReportModels
                    .Include(r => r.Images)
                    .FirstOrDefaultAsync(r => r.Id == reportModel.Id);

                if (existingReport != null)
                {
                    existingReport.Tittle = reportModel.Tittle;
                    existingReport.Status = reportModel.Status;
                    existingReport.Kunde = reportModel.Kunde;

                    // Update existing images and add new images
                    foreach (var image in reportModel.Images)
                    {
                        var existingImage = existingReport.Images
                            .FirstOrDefault(i => i.Id == image.Id);

                        if (existingImage != null)
                        {
                            existingImage.Name = image.Name;
                            existingImage.ImageUrl = image.ImageUrl;
                        }
                        else
                        {
                            // Add new image
                            existingReport.Images.Add(new ReportImageModelDto
                            {
                                Id = Guid.NewGuid(),
                                Name = image.Name,
                                ImageUrl = image.ImageUrl
                            });
                        }
                    }

                    // Remove any images not present in the updated report
                    var imageIds = reportModel.Images.Select(i => i.Id).ToList();
                    existingReport.Images.RemoveAll(i => !imageIds.Contains(i.Id));

                    context.ReportModels.Update(existingReport);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
