using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public partial class CourseRegistration
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int CourseId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDone { get; set; }
        public int TotalPoint { get; set; }
        public byte[] CertificateImage { get; set; }
        public string Comment { get; set; } 
        public virtual Course Course { get; set; } 
        public virtual Trainer Trainer { get; set; } 
    }

}
