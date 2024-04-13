﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using Final_project.Commands;
using Final_project.Stores;

namespace Final_project.ViewModels
{
    public partial class ImageVM : ObservableObject
    {
        private readonly ImageCollectionVM _imageCollectionVM;
        private readonly ReportStore _reportStore;


        public ReportImageModel ReportImageModel { get; private set; }


        [ObservableProperty]
        private Uri _imageUri;


        public Guid ImageId { get; private set; }
        public string ImageName { get; private set; }

        public ImageVM(Guid imageId, string name, string imageUri, ImageCollectionVM imageCollectionVM, ReportStore reportStore)
        {
            ImageId = imageId;
            ImageName = name;
            ImageUri = new Uri(imageUri, UriKind.RelativeOrAbsolute);

            _imageCollectionVM = imageCollectionVM;
            _reportStore = reportStore;


        }


        [RelayCommand]
        private async Task RemoveImageAsync()
        {
            try
            {
                // Delete the image from the report store
                await _reportStore.DeleteImage(ImageId);

                // Remove the image from the UI collection
                _imageCollectionVM.RemoveImage(this);
            }
            catch (Exception)
            {
                // Handle exceptions or set error messages if needed
            }
        }








        //private void ReportStore_ImageDeleted(Guid id)
        //{
        //    ImageVM imageToRemove = _imageCollectionVM.Images.FirstOrDefault(image => image.ImageId == id);

        //    if (imageToRemove != null)
        //    {
        //        _imageCollectionVM.RemoveImage(imageToRemove);
        //    }
        //}

        ////public override void Dispose()
        ////{
        ////    _reportStore.ImageDeleted -= ReportStore_ImageDeleted;
        ////    base.Dispose();
        //}
    }
}
