using CommonModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.Models
{
    public class Quiz
    {
        public int CreatorId { get; set; } // Foreign key to User
        public int Id { get; set; }
        public int TimesTaken { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public (int? minPlayers, int? maxPlayers) MinMaxPlayers { get; set; }
        public List<string> Rules { get; set; } = new();
        public string ImagePath { get; set; }

        public QuizCategory QuizCategory { get; set; }
        public List<QuizModes> QuizModes { get; set; } = new();
        public QuizType? QuizType { get; set; }
        public int QuizTypeId { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuizCompletion> QuizCompletions { get; set; } = new List<QuizCompletion>();

    }

    public class QuizCompletion
    {
        public int QuizTypeId { get; set; }
        public QuizModes QuizModes { get; set; }
        public string FastestTime { get; set; }
    }
}
