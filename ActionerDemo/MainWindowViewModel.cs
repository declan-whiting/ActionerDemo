using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ActionerDemo.Annotations;
using Microsoft.Practices.Prism.Commands;

namespace ActionerDemo
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Private Fields
        private string _output;
        private readonly Actioner _actioner;
        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            ShortCommand = new DelegateCommand(ShortCommandExecute);
            MediumCommand = new DelegateCommand(MediumCommandExecute);
            LongCommand = new DelegateCommand(LongCommandExecute);
            _actioner = new Actioner();
        }

        #endregion

        #region Properties

        public string Output
        {
            get => _output;
            set
            {
                _output = value;
               OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public DelegateCommand ShortCommand { get; set; }
        public DelegateCommand MediumCommand { get; set; }
        public DelegateCommand LongCommand { get; set; }

        #endregion

        #region Private Methods
        private void ShortCommandExecute()
        {
            _actioner.DoAction(new Task(ShortProcess));
        }
        public void ShortProcess()
        {
           
                Output += $"{DateTime.Now.ToLongTimeString()} Short command started\r\n";
                Thread.Sleep(1000);
                Output += $"{DateTime.Now.ToLongTimeString()}  Short Command finished\r\n";
           
        }
        private void MediumCommandExecute()
        {
            _actioner.DoAction(new Task(MediumProcess));
        }
        public void MediumProcess()
        {
            Output += $"{DateTime.Now.ToLongTimeString()} Medium command started\r\n";
            Thread.Sleep(3000);
            Output += $"{DateTime.Now.ToLongTimeString()}  Medium Command finished\r\n";

        }
        private void LongCommandExecute()
        {
            _actioner.DoAction(new Task(LongProcess));
        }
        public void LongProcess()
        {
            Output += $"{DateTime.Now.ToLongTimeString()} Long command started\r\n";
            Thread.Sleep(5000);
            Output += $"{DateTime.Now.ToLongTimeString()}  Long Command finished\r\n";
           
        }
        #endregion

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
