using GeoQuiz.Models.QuizModels.Enums;

namespace GeoQuiz.Models.QuizModels
{
    public class Quiz
    {
        public string ImageSource { get; set; }
        public string Name { get; set; }
        public QuizCategory? Category { get; set; }
        public string? Description { get; set; }
        public int TimesTaken { get; set; }
        public int OwnerId { get; set; }


        public QuizType QuizFormat { get; set; }
        public int QuizId { get; set; }

        public Quiz()
        {

        }
    }

}
