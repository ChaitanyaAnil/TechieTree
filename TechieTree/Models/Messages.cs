using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechieTree.Models
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageBody { get; set; }

        public DateTime DateTime { get; set; }
    public int? SenderTraineeId { get; set; }
    public int? SenderTrainerId { get; set; }
    public int? RecieverTraineeId { get; set; }
    public int? RecieverTrainerId { get; set; }
    public string SenderName { get; set; }
    public string RecieverName { get; set; }
}
}
