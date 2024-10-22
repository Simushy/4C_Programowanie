using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMauiApp
{
    public class CalculatorViewModel : BindableObject
    {
        private string calculatingResult = "";
        private Command numberCommand;
        public Command NumberCommand
        {
            get
            {
                if (numberCommand == null)
                {
                    numberCommand = new Command<string>((string number) =>
                    {
                        CalculatingResult = CalculatingResult + number;
                    });
                }
                return numberCommand;

            }
            set { numberCommand = value; }
        }
        public string CalculatingResult
        {
            get { return calculatingResult; }
            set
            {
                calculatingResult = value;
                OnPropertyChanged();
            }
        }
        public CalculatorViewModel()
        {


        }
    }
}
