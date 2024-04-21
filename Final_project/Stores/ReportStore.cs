﻿using Domain.Models;
using Report_Generator_Domain.Commands;
using Report_Generator_Domain.ITables;
using Report_Generator_Domain.Models;
using Report_Generator_Domain.Queries;

namespace Final_project.Stores
{
    public class ReportStore

    {

        public IEnumerable<ReportModel> ReportModels => _reportmodel;
        public IEnumerable<ReportImageModel> ReportImageModels => _reportImagemodel;

        private readonly IGetAllReportsQuery _query;
        private readonly ICreateReportCommand _createReportCommand;
        private readonly IDeleteReportCommand _deleteReportCommand;
        private readonly IUpdateReportCommand _updateReportCommand;
        private readonly IGetReportDataCommand _getReportDataCommand;
        //private readonly IGetReportImageCommand _getReportImageCommand;
        private readonly IDeleteReportImageCommand _deleteReportImageCommand;
        //private readonly IGetImageForReportCommand _getImageForReporCommand;
        private readonly ICreateImageCommand _createImageCommand;
        private readonly ICreateDataFraOppdragsgiverPrøverModelCommand _iCreateDataFraOppdragsgiverPrøverModelCommand;



        private readonly List<ReportModel> _reportmodel;
        private readonly List<ReportImageModel> _reportImagemodel;

        public ReportStore(IGetAllReportsQuery query,
             ICreateReportCommand createReportCommand,
             IDeleteReportCommand deleteReportCommand,
             IUpdateReportCommand updateReportCommand,
             IGetReportDataCommand getReportDataCommand,
             //IGetReportImageCommand getReportImageCommand,
             IDeleteReportImageCommand deleteReportImageCommand,
            //IGetImageForReportCommand getImageForReportCommand,
            ICreateImageCommand createImageCommand,
            ICreateDataFraOppdragsgiverPrøverModelCommand createDataFraOppdragsgiverPrøverModelCommand

            )
        {
            _query = query;
            _createReportCommand = createReportCommand;
            _deleteReportCommand = deleteReportCommand;
            _updateReportCommand = updateReportCommand;
            _getReportDataCommand = getReportDataCommand;
            //_getReportImageCommand = getReportImageCommand;
            _deleteReportImageCommand = deleteReportImageCommand;
            //_getImageForReporCommand = getImageForReportCommand;
            _createImageCommand = createImageCommand;
            _iCreateDataFraOppdragsgiverPrøverModelCommand = createDataFraOppdragsgiverPrøverModelCommand;




            _reportmodel = new List<ReportModel>();
            _reportImagemodel = new List<ReportImageModel>();
        }

        public event Action ReportModelLoaded;
        public event Action<ReportModel> ReportAdded;
        public event Action<ReportModel> ReportUpdated;
        public event Action<Guid> ReportDeleted;

        public event Action<ReportImageModel> ImageAdded;
        public event Action<Guid> ImageDeleted;



        public async Task Load()
        {
            IEnumerable<ReportModel> reportModels = await _query.Execute();

            _reportmodel.Clear();
            _reportmodel.AddRange(reportModels);

            ReportModelLoaded?.Invoke();
        }

        public async Task Add(ReportModel reportModel)
        {
            await _createReportCommand.Execute(reportModel);

            _reportmodel.Add(reportModel);
            ReportAdded?.Invoke(reportModel);
        }



        public async Task AddImage(Guid reportModelïd, List<ReportImageModel> reportImageModels)
        {
            await _createImageCommand.Execute(reportModelïd, reportImageModels);

            //_reportImagemodel.Add(reportImageModel);
            //ImageAdded?.Invoke(reportImageModel);
        }


        public async Task AddDataFraOppdragsgiverPrøver(Guid tableid, List<DataFraOppdragsgiverPrøverModel> prove)
        {
            await _iCreateDataFraOppdragsgiverPrøverModelCommand.Execute(tableid, prove);

            //_reportImagemodel.Add(reportImageModel);
            //ImageAdded?.Invoke(reportImageModel);
        }




        public async Task Update(ReportModel reportModel)
        {

            await _updateReportCommand.Execute(reportModel);

            int currentIndex = _reportmodel.FindIndex(y => y.Id == reportModel.Id);
            if (currentIndex == -1)
            {
                _reportmodel[currentIndex] = reportModel;
            }
            else
            {
                _reportmodel.Add(reportModel);

            }

            ReportUpdated?.Invoke(reportModel);
        }



        public async Task Delete(Guid id)
        {
            await _deleteReportCommand.Execute(id);

            _reportmodel.RemoveAll(y => y.Id == id);

            ReportDeleted?.Invoke(id);
        }

        public async Task DeleteImage(Guid id)
        {
            await _deleteReportImageCommand.Execute(id);

            _reportImagemodel.RemoveAll(y => y.Id == id);

            ImageDeleted?.Invoke(id);
        }






        public async Task<(ReportModel report, List<ReportImageModel> images, List<DataFraOppdragsgiverPrøverModel> dataFraOppdragsgiverPrøverModels)> GetReportData(Guid reportId)
        {
            return await _getReportDataCommand.Execute(reportId);
        }



        //public async Task<ReportModel> GetImageReportData(Guid reportId)
        //{
        //    return await _getReportDataCommand.Execute(reportId);
        //}



    }




}


