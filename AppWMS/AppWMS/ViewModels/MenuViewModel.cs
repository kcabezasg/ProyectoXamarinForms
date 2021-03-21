using AppWMS.Views;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppWMS.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {

        #region Commands

        public ICommand LogOutCommand { get; set; }


        #endregion

        public MenuViewModel()
        {
            InitCommands();

        }
        private void InitCommands()
        {
            LogOutCommand = new Command(LogOut);

        }





        public async void LogOut()
        {
            try
            {

                await Application.Current.MainPage.DisplayAlert("Success", "Log Out Successfully", "OK");
                App.Current.MainPage = new LoginView();
            }
            catch (System.Exception ex)
            {

                throw;
            }

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
