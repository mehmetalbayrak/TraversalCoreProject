using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string CommentUser { get; set; }
        public DateTime Date { get; set; }
        public string CommentContent { get; set; }
        public string State { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
