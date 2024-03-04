using CoffeeBack.Data.Models;
using System.Collections.Generic;

namespace CoffeeBack.Services.Models
{
    public record PersonProgress(Person Person, IEnumerable<int> watchedVideoLectureIds, IEnumerable<int> readTextLectureIds);
}
