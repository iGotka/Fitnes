using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Fitness.Controllers;

namespace Fitness.Models
{/// <summary>
/// 
/// </summary>
    public partial class Course
    {/// <summary>
    /// 
    /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CourseRegistration> CourseRegistrations { get; } = new List<CourseRegistration>();
    }
}
