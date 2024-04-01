﻿using Final_project.Service;
using Final_project.Stores;
using Final_project.ViewModels;
using Report_Generator_Domain.Models;
using Firebase.Auth;
using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using UserInfo = Report_Generator_Domain.Models.UserInfo;

namespace Final_project.Commands
{

    public class LogInCommand : AsyncCommandBase
    {

        private readonly LoginVM _login;
        private readonly AccountStore _accountStore;
        private readonly FirebaseAuthProvider _firebaseAuthProvider;
        public INavigationService _navigationService { get; }

        public LogInCommand(LoginVM login, AccountStore accountStore, INavigationService navigationService, FirebaseAuthProvider firebaseAuthProvider)
        {
            _login = login;
            _accountStore = accountStore;
            _navigationService = navigationService;
            _firebaseAuthProvider = firebaseAuthProvider;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var auth = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(_login.Username, _login.Password);

                // Add a step here to retrieve the role from Firestore
                var userDocument = await FirestoreHelper.Database
                  .Collection("users")
                  .Document(auth.User.LocalId)
                  .GetSnapshotAsync();

                if (userDocument.Exists)
                {
                    var userInfo = userDocument.ConvertTo<UserInfo>();
                    Account account = new Account()
                    {
                        Email = auth.User.Email,
                        Username = auth.User.Email,
                        Role = userInfo.Role
                    };

                    _accountStore.CurrentAccount = account;
               
                _navigationService.Navigate();

                }

            }
            catch (Exception)
            {
                MessageBox.Show("LogIn failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
