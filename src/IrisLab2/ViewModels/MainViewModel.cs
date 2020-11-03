using IrisLab2.Commands;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VectorCollection;
using IrisLab2.Models;

namespace IrisLab2.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _fileName = "Not choosen";
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

        private string[] _graphicsNames;
        public string[] GraphicsNames
        {
            get => _graphicsNames;
            set
            {
                _graphicsNames = value;
                NotifyPropertyChanged();
            }
        }

        private SeriesCollection[] _graphicsSeriesCollections;
        public SeriesCollection[] GraphicsSeriesCollections
        {
            get => _graphicsSeriesCollections;
            set
            {
                _graphicsSeriesCollections = value;
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

        public string FilePath { get; set; } = "";

        private void LoadFile()
        {
            ChooseFile();

            FileLoaded = false;
            if (!File.Exists(FilePath))
                return;

            List<string> data = File.ReadAllLines(FilePath).ToList();
            GraphicsNames = DataManger.GetHeaders(data).ToArray();
            GraphicsSeriesCollections = ConvertToSeriesCollections(DataManger.GetIrisNames(data), DataManger.GetGraphicsValues(data));
            FileLoaded = true;
        }

        private void ChooseFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files|*.csv";
            if (dialog.ShowDialog() == true)
            {
                FilePath = dialog.FileName;
                FileName = dialog.SafeFileName;
            }
        }

        private static SeriesCollection ConvertToChartSeriesCollection(List<string> names, MathVector values)
        {
            var result = new SeriesCollection();
            for (int i = 0; i < values.Dimensions; i++)
            {
                result.Add(
                    new ColumnSeries
                    {
                        Title = names[i],
                        Values = new ChartValues<double>() { values[i] }
                    });
            }
            return result;
        }

        private static SeriesCollection ConvertToPieSeriesCollection(List<string> names, MathVector values)
        {
            var result = new SeriesCollection();
            for (int i = 0; i < values.Dimensions; i++)
            {
                result.Add(
                    new PieSeries
                    {
                        Title = names[i],
                        Values = new ChartValues<double>() { values[i] }
                    });
            }

            return result;
        }

        private static SeriesCollection[] ConvertToSeriesCollections(List<string> names, List<MathVector> values)
        {
            SeriesCollection[] result = new SeriesCollection[5];
            for (int i = 0; i < values.Count - 1; i++)
                result[i] = ConvertToChartSeriesCollection(names, values[i]);

            result[values.Count - 1] = ConvertToPieSeriesCollection(names, values[values.Count - 1]);

            return result;
        }
    }
}
