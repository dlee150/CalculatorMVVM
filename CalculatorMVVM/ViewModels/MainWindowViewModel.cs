using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace CalculatorMVVM.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Members
        public event PropertyChangedEventHandler PropertyChanged;
        private double _value0;
        private double _value1;
        private double _result;

        #endregion

        #region Properties
        public double Value0
        {
            get
            {
                return _value0;
            }
            set
            {
                _value0 = value;
                NotifyPropertyChanged();
            }
        }
        public double Value1
        {
            get
            {
                return _value1;
            }
            set
            {
                _value1 = value;
                NotifyPropertyChanged();
            }
        }

        public double Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand<string> OperatorCommands { get; set; }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            Value0 = 0;
            OperatorCommands = new RelayCommand<string>((p) => SetOperation(p));
        }
        #endregion

        #region Commands
        private void SetOperation(string cmd)
        {
            switch (cmd)
            {
                case "Add":
                    Result = Value0 + Value1;
                    break;
                case "Subtract":
                    Result = Value0 - Value1;
                    break;
                case "Multiply":
                    Result = Value0 * Value1;
                    break;
                case "Divide":
                    if (Value1 == 0)
                    {
                        Result = 000000000000;
                    }
                    else
                    {
                        Result = Value0 / Value1;
                    }
                    break;
            }
        }

        #endregion

        #region Helpers
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



    }
}
