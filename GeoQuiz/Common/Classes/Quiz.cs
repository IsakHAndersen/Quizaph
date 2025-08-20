using CommonModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels
{
    public class Quiz
    {
        public int QuizInfoId { get; set; } // Foreign key to QuizInfo
        public int CreaterNameId { get; set; } // Foreign key to User
        public int Id { get; set; }
    }

    public class QuizInfo
    {
        public int TimesTaken { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public QuizCategory QuizCategory { get; set; }
        public (int? minPlayers, int? maxPlayers) PlayersAvailable { get; set; }
        public List<QuizModes> QuizModes { get; set; } = new();
        public List<string> Rules { get; set; } = new();
        public string ImagePath { get; set; }
        public QuizType? QuizType { get; set; }
        public int QuizTypeId { get; set; }
    }
}
