using System;
using System.Collections.Generic;

namespace CoffeeBack.Data.Models
{
    public class SelectAnswerExercise : Entity<SelectAnswerExercise>
    {
        public string Question { get; set; }
        public List<SelectAnswerExersiseAnswer> Answers { get; set; }
    }
}
