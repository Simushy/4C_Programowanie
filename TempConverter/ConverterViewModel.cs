using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConverter
{

    public class ConverterViewModel : BindableObject
    {
        public ObservableCollection<string> Temperatures { get; set; }
        public Command ConvertCommand { get; set; }
        
        public string SelectedTemperature { get; set; }
        private string resultTemperatureText;
        public double result;
        public string Value { get; set; }
        public string ResultTemperatureText { get { return resultTemperatureText; } set { resultTemperatureText = value; OnPropertyChanged(); } }
        public ConverterViewModel()
        {
            ConvertCommand = new Command(Convert);
            Temperatures = new ObservableCollection<string>();
            Temperatures.Add("C");
            Temperatures.Add("F");
        }
        private void Convert()
        {
            switch (SelectedTemperature) {
                case "C":
                    result = ((double.Parse(Value) * 1.8) + 32);
                    ResultTemperatureText = Math.Round(result, 2).ToString();
                    break;
                case "F":
                    result = ((double.Parse(Value) - 32) / 1.8);
                    ResultTemperatureText = Math.Round(result, 2).ToString();
                    break;
                default:
                    ResultTemperatureText = "Wybierz temperature";
                    break;
            }
        }
    }
}
