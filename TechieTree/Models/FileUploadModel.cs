using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechieTree.Models
{

    [Table("filesupload")]
    public class FileUploadModel
    {

    

        [Key]
            public int id { get; set; }
            public string FileName { get; set; }
            public string FilePath { get; set; }
        
    }
}
