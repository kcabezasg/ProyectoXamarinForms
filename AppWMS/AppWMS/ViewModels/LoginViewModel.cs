using AppWMS.Models;
using AppWMS.Views;
using Realms;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppWMS.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Properties

        private UserModel _User = new UserModel();
        public UserModel User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
                OnPropertyChanged("User");
            }
        }
        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        public ICommand CreateAccountCommand { get; set; }


        #endregion


        #region Singleton

        private static LoginViewModel instance = null;

        private LoginViewModel()
        {
            InitCommands();
            InitClass();
        }

        private void InitClass()
        {
          
        }

        public static LoginViewModel GetInstance()
        {
            if (instance == null)
                instance = new LoginViewModel();

            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
                instance = null;
        }
        #endregion

        private void InitCommands()
        {
            LoginCommand = new Command(Login);
            //CreateAccountCommand = new Command(CreateAccount);
        }

        public async void CreateAccount()
        {

            try
            {
                var realm = Realm.GetInstance();
                UserModel UserModel = new UserModel();
           
                var users = realm.All<UserModel>();

                User.Id = users.Count() + 1;

                realm.Write(() =>
                {
                    realm.Add(User);
                });

                Clean();

                await Application.Current.MainPage.DisplayAlert("Success", "User created Successfully", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Login Error: " + ex.Message, "OK");
            }
            finally
            {
                App.Current.MainPage = new LoginView();
            }

        }

        public async void Login()
        {
            try
            {
                //var realm = Realm.GetInstance();

                //var dbUser = realm.All<UserModel>().Where(u => u.Email == User.Email).FirstOrDefault();

                //if (User.Password == dbUser.Password)
                //{
                   NavigationPage navigation = new NavigationPage(new HomeView());

                    App.Current.MainPage = new MasterDetailPage
                    {
                        Master = new MenuView(),
                        Detail = navigation
                    };

                    Clean();
               // }
               // else
                //{
                 //   await Application.Current.MainPage.DisplayAlert("Error", "Wrong Credentials", "OK");
                //}
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Login Error: " + ex.Message, "OK");
            }
        }

        private void Clean()
        {
            User = new UserModel();
        }
        #region INotifyPropertyChanged Implentation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
