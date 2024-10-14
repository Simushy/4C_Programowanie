

namespace MauiApp1
{
    public class Unit
    {
        public string name { get; set; }
        public int value { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        public List<Unit> Units { get; set; }
        public Unit ConvertUnitFrom { get; set; }
        public Unit ConvertUnitTo { get; set; }
        public string Value { get; set; }
        private string resultvaluetext;
        public string ResultValueText
        { 
            get { return resultvaluetext; } 
            set { resultvaluetext = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            Units = new List<Unit>();
            Units.Add(new Unit { name = "mm", value = 1 });
            Units.Add(new Unit { name = "cm", value = 10 });
            Units.Add(new Unit { name = "dm", value = 100});
            Units.Add(new Unit { name = "m", value = 1000});
            Units.Add(new Unit { name = "km", value = 1000000 });
            InitializeComponent();
        }
        private void OnClick(object sender, EventArgs e)
        {
            double ResultValue = double.Parse(Value);
            ResultValue = ResultValue * ConvertUnitFrom.value;
            ResultValue = ResultValue / ConvertUnitTo.value;
            int Accuracy = (ConvertUnitTo.value / ConvertUnitFrom.value).ToString().Length-1;
            ResultValueText = $"{Value} {ConvertUnitFrom.name} is {ResultValue.ToString($"F{Accuracy}")} {ConvertUnitTo.name}";

        }
    }
    

}
