

namespace MauiApp1
{
    public class Unit
    {
        public string Name { get; set; }
        public int Value { get; set; }
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
            Units.Add(new Unit { Name = "mm", Value = 1 });
            Units.Add(new Unit { Name = "cm", Value = 10 });
            Units.Add(new Unit { Name = "dm", Value = 100});
            Units.Add(new Unit { Name = "m", Value = 1000});
            Units.Add(new Unit { Name = "km", Value = 1000000 });
            InitializeComponent();
        }
        private void OnClick(object sender, EventArgs e)
        {
            double ResultValue = double.Parse(Value);
            ResultValue = ResultValue * ConvertUnitFrom.Value;
            ResultValue = ResultValue / ConvertUnitTo.Value;
            int Accuracy = (ConvertUnitTo.Value / ConvertUnitFrom.Value).ToString().Length-1;
            ResultValueText = $"{Value} {ConvertUnitFrom.Name} is {ResultValue.ToString($"F{Accuracy}")} {ConvertUnitTo.Name}";

        }
    }
    

}
