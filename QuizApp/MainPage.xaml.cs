using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class MainPage : ContentPage
    {
        public QA CurrentQA { get; set; }
        public int CurrentQAIndex { get; set; }
        public MainPage()
        {
            InitializeComponent();
            SetQA(CurrentQAIndex);
        }

        private void FalseButton_OnClicked(object sender, EventArgs e)
        {
            CurrentQA.UserAnswer = false;
            NextQA();
        }

        private void TrueButton_OnClicked(object sender, EventArgs e)
        {
            CurrentQA.UserAnswer = true;
            NextQA();
        }

        private void NextQA()
        {
            CurrentQAIndex++;
            if (CurrentQAIndex < QA.NumQuestions)
            {
                SetQA(CurrentQAIndex);
            }
            else
            {
                // CurrentQAIndex = 0;
                // SetQA(CurrentQAIndex);
                ShowAnswer();
            }
        }

        private void SetQA(int index)
        {
            CurrentQA = QA.All[index];
            QuestionNumberLabel.Text = $"Question {index + 1}";
            QuestionLabel.Text = CurrentQA.Question;
            QuestionImage.Source = CurrentQA.ImageSource;
            FalseButton.Text = CurrentQA.AnswerFalse;
            TrueButton.Text = CurrentQA.AnswerTrue;
        }

        private void ShowAnswer()
        {
            var countTrue = QA.All.Count(qa => qa.UserAnswer);
            var answer = countTrue >= 3 ? "Vision" : "Wanda";
            var image = $"{answer.ToLower()}.jpg";

            QuestionNumberLabel.Text = "Result";
            QuestionLabel.Text = $"You got: {answer}!";
            QuestionImage.Source = image;

            FalseButton.IsVisible = false;
            TrueButton.IsVisible = false;
            RetakeQuizButton.IsVisible = true;
        }

        private void RetakeQuizButton_OnClicked(object sender, EventArgs e)
        {
            FalseButton.IsVisible = true;
            TrueButton.IsVisible = true;
            RetakeQuizButton.IsVisible = false;
            
            CurrentQAIndex = 0;
            SetQA(0);
        }
    }
}