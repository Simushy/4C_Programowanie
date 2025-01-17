using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMauiApp
{
    public class Question : BindableObject
    {
        public string QuestionText { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }
        private int currentAnswer = -1;
        public int CurrentAnswer
        {
            get { return currentAnswer; }
            set
            {
                    currentAnswer = value;
                    OnPropertyChanged();
            }
        }

    }
    public class ViewModel : BindableObject
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        private int currentQuestionIndex = 0;
        public int CurrentQuestionIndex
        {
            get { return currentQuestionIndex; }
            set
            {
                currentQuestionIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentQuestion));


            }
        }
        private string resultLabelText;
        public string ResultLabelText
        {
            get { return resultLabelText; }
            set { resultLabelText = value; OnPropertyChanged(); }
        }
        public Question CurrentQuestion => Questions[CurrentQuestionIndex];
        public Command PreviousQuestionCommand { get; set; }
        public Command NextQuestionCommand { get; set; }
        public Command ResetCommand { get; set; }
        public Command CheckAnswersCommand { get; set; }
        public ViewModel()
        {
            PreviousQuestionCommand = new Command(PreviousQuestion);
            NextQuestionCommand = new Command(NextQuestion);
            CheckAnswersCommand = new Command(CheckAnswers);
            ResetCommand = new Command(Reset);
            Questions = new List<Question>
            {
                new Question { QuestionText = "Ile to 2+2", Answers=["2", "3","4","5"],CorrectAnswer = 2 },
                new Question { QuestionText = "Jaka jest stolica Polski?",Answers=["Warszawa","Pruszków","Wadowice","Podlasie"], CorrectAnswer = 0 },
                new Question { QuestionText = "Kto był w Paryżu",Answers=["Kali","Negro","Nigas","Midas"], CorrectAnswer = 2 },
                new Question { QuestionText = "Czy if to pętla?",Answers=["Tak","Nie","Może","Nie wiem"], CorrectAnswer = 0 },
                new Question { QuestionText = "Tak?",Answers=["tak","TAK","Tak","TaK"], CorrectAnswer = 1 },
                //new Question { QuestionText = "Ile wynosi masa Krzysia?", Answers=["Czarna dziura","2x Czarna dziura", "3x Czarna dziura", "4x Czarna dziura"], CorrectAnswer = 3}
            };
        }
        public void PreviousQuestion()
        {
            if (CurrentQuestionIndex > 0)
            {
                InsertAnswers();
                CurrentQuestionIndex--;
                RestoreRadioButtons();
            }

        }
        public void NextQuestion()
        {
            if (CurrentQuestionIndex < Questions.Count - 1)
            {
                InsertAnswers();
                CurrentQuestionIndex++;
                RestoreRadioButtons();
            }

        }
        public void Reset()
        {
            foreach (Question question in Questions)
            {
                question.CurrentAnswer = -1;
                Checked0 = false;
                Checked1 = false;
                Checked2 = false;
                Checked3 = false;
                ResultLabelText = "";
                InsertAnswers();
                RestoreRadioButtons();
            }
        }
        public void CheckAnswers()
        {
            InsertAnswers();
            RestoreRadioButtons();
            int score=0;

            for(int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].CurrentAnswer == Questions[i].CorrectAnswer)
                {
                    score++;
                }
            }
            ResultLabelText = $"Brawo, odpowiedziałeś poprawnie na {score}/{Questions.Count()} pytań!";

        }
        #region Obsluga radio boxow
        private bool checked0;
        private bool checked1;
        private bool checked2;
        private bool checked3;
        public bool Checked0 { get { return checked0; } set { checked0 = value; OnPropertyChanged(); } }
        public bool Checked1 { get { return checked1; } set { checked1 = value; OnPropertyChanged(); } }
        public bool Checked2 { get { return checked2; } set { checked2 = value; OnPropertyChanged(); } }
        public bool Checked3 { get { return checked3; } set { checked3 = value; OnPropertyChanged(); } }
        private void InsertAnswers()
        {
            if (checked0) { CurrentQuestion.CurrentAnswer = 0; }
            if (checked1) { CurrentQuestion.CurrentAnswer = 1; }
            if (checked2) { CurrentQuestion.CurrentAnswer = 2; }
            if (checked3) { CurrentQuestion.CurrentAnswer = 3; }
        }
        private void RestoreRadioButtons()
        {


            switch (CurrentQuestion.CurrentAnswer)
            {
                case 0:
                    Checked0 = true;
                    Checked1 = false;
                    Checked2 = false;
                    Checked3 = false;
                    break;

                case 1:
                    Checked1 = true;
                    Checked2 = false;
                    Checked3 = false;
                    Checked0 = false;
                    break;

                case 2:
                    Checked2 = true;
                    Checked3 = false;
                    Checked1 = false;
                    Checked0 = false;
                    break;

                case 3:
                    Checked3 = true;
                    Checked1 = false;
                    Checked2 = false;
                    Checked0 = false;
                    break;

                default:
                    Checked0 = false;
                    Checked1 = false;
                    Checked2 = false;
                    Checked3 = false;
                    break;
            }

        }
        #endregion
    }
}
