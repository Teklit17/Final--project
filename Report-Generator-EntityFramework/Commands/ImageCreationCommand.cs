﻿using Domain.Models;
using Report_Generator_Domain.Commands;

namespace Report_Generator_EntityFramework.Commands
{
    public class ImageCreationCommand : ICreateImageCommand
    {
        private readonly ReportModelDbContextFactory _contextFactory;

        public ImageCreationCommand(ReportModelDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid reportId, List<ReportImageModel> reportImageModels)
        {
            using (var context = _contextFactory.Create())
            {
                var report = await context.ReportModels.FindAsync(reportId);
                if (report == null)
                {
                    throw new ArgumentException("Report not found.", nameof(reportId));
                }

                foreach (var image in reportImageModels)
                {
                    image.ReportModelId = reportId;
                    context.ReportImageModels.Add(image);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
