using IrisLab2.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IrisLab2.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string FilePath { get; set; } = "";

        private string _fileName = "Not chosed";
        public string FileName 
        { 
            get
            {
                return $"Name of file: {_fileName}";
            }
            set
            {
                _fileName = value;
                NotifyPropertyChanged();
            } 
        }

        private bool _fileLoaded = false;
        public bool FileLoaded 
        {
            get => _fileLoaded;
            set
            {
                _fileLoaded = value;
                NotifyPropertyChanged();
            } 
        }

        DelegateCommand _loadFileCommand;
        public ICommand LoadFileCommand
        {
            get
            {
                if (_loadFileCommand == null)
                {
                    _loadFileCommand = new DelegateCommand(execute: o => LoadFile(), 
                                                           canExecute: o => true);
                }
                return _loadFileCommand;
            }
        }

        private void LoadFile()
        {
            ChooseFile();

            FileLoaded = false;
            if (!File.Exists(FilePath))
                return;

            string[] data = File.ReadAllLines(FilePath);
        }

        private void ChooseFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == true)
            {
                FilePath = dialog.FileName;
                FileName = dialog.SafeFileName;
            }
        }
    }
}
