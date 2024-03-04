namespace CoffeeBack.Data.Models
{
    public class SelectAnswerExersiseAnswer: Entity<SelectAnswerExersiseAnswer>
    {
        public string Answer { get; set; }
        public bool IsRightAnswer { get; set; }
        public SelectAnswerExercise SelectAnswerExercise { get; set; }
    }
}
