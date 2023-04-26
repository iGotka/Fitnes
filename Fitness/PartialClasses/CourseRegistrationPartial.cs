using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.Models;
using Fitness.Controllers;

namespace Fitness.Models
{/// <summary>
/// 
/// </summary>
    public partial class CourseRegistration
    {/// <summary>
    /// 
    /// </summary>
        public string IsDoneString => IsDone ? "Завершен" : "В процессе";
    }
}
