using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace MelodyFitMobile.ViewModels
{  
    public class SignUpViewModel : INotifyPropertyChanged
    {
        // Fields
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private DateTime? _birthDate;
        private string? _gender;
        private double? _weightKg;
        private double? _heightCm;
        private bool _isBusy;

        // UI backing fields for numeric
        private string _weightKgText = string.Empty;
        private string _heightCmText = string.Empty;

        // Properties
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string FirstName
        {
            get => _firstName;
            set=>SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public DateTime? BirthDate
        {
            get => _birthDate;
            set => SetProperty(ref _birthDate, value);
        }

        public DateTime BirthDateValue
        {
            get => BirthDate ?? DateTime.Today;
            set => BirthDate = value;
        }

        public string? Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }
        public double? WeightKg
        {
            get => _weightKg;
            set => SetProperty(ref _weightKg, value);
        }
        public double? HeightCm
        {
            get => _heightCm;
            set => SetProperty(ref _heightCm, value);
        }

        public string WeightKgText
        {
            get => _weightKgText;
            set
            {
                if(SetProperty(ref _weightKgText, value))
                {
                    if (double.TryParse(value, out var weight))
                        WeightKg = weight;
                    else
                        WeightKg = null;
                }
            }
        }

        public string HeightCmText
        {
            get => _heightCmText;
            set
            {
                if(SetProperty(ref _heightCmText, value))
                {
                    if(double.TryParse(value,out var height))
                        HeightCm = height;
                    else 
                        HeightCm = null;
                }
            }
        }

        // 
        public event PropertyChangedEventHandler? PropertyChanged;

        //SetProperty method
        protected bool SetProperty<T>(
            ref T backingStore,
            T value,
            [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public bool IsBusy
        {
            get => _isBusy;
            private set
            {
                SetProperty(ref _isBusy, value);
                ((Command)RegisterCommand).ChangeCanExecute();
            }
        }

        // Commands
        public ICommand RegisterCommand { get; }

        public SignUpViewModel()
        {
            RegisterCommand = new Command(
                execute: OnRegister,
                canExecute: () => !IsBusy
                );
        }

        private async void OnRegister()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                await Task.Delay(1500);
            }
            finally
            {
                IsBusy = false; 
            }
        }


        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
