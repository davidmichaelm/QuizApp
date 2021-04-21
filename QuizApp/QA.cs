using System;
using System.Collections.Generic;

namespace QuizApp
{
    public class QA
    {
        public string Question { get; set; }
        public bool UserAnswer { get; set; }
        public string AnswerTrue { get; set; }
        public string AnswerFalse { get; set; }
        public string ImageSource { get; set; }

        public QA(string question, string answerTrue, string answerFalse, string imageSource)
        {
            Question = question;
            AnswerTrue = answerTrue;
            AnswerFalse = answerFalse;
            ImageSource = imageSource;
        }
        
        static QA()
        {
            All = new List<QA>()
            {
                new QA("Which superpower would you choose?", "Energy beam", "Telekinesis", "question1.jpg"),
                new QA("Who would you rather battle?", "Ultron", "Thanos", "question2.jpg"),
                new QA("Who would you rather hang out with?", "Captain America", "Hawkeye", "question3.jpg"),
                new QA("Which is your biggest pet peeve?", "Constant interruptions", "People who don't follow the rules", "question4.jpg"),
                new QA("Which word best describes you?", "Even-tempered", "Misunderstood", "question5.jpg"),
            };

            NumQuestions = 5;
        }

        public static List<QA> All;
        public static int NumQuestions;
    }
}