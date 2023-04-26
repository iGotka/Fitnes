using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public partial class Trainer { 
       public int TrainerId { get; set; }

    public string TrainerName { get; set; } 

    public string TrainerLastName { get; set; }

    public string TrainerSurName { get; set; }

    public virtual ICollection<CourseRegistration> CourseRegistrations { get; } = new List<CourseRegistration>();
}
}
