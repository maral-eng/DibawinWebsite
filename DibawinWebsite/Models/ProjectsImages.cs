using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models
{
    public class ProjectsImages : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LatinTitle { get; set; }
        public bool Status { get; set; }
        public DateTime RegDateTime { get; set; }
        public string DefinedByUserId { get; set; }
        //===============================================

        public int ProjectId { get; set; }

        public byte[] BigImage { get; set; }
        public string BigImagePath { get; set; } //2000x2000 size
        public byte[] Image { get; set; }
        public string ImagePath { get; set; } //1000x1000 size
        public byte[] ImageThumbnail { get; set; }
        public string ImageThumbnailPath { get; set; } //275x275 size
        public byte[] ImageTinyThumbnail { get; set; }
        public string ImageTinyThumbnailPath { get; set; } //85x85 size
        public string VolumeSize { get; set; }
        public string DimensionSize { get; set; }
        public bool GrayScale { get; set; }
        public bool Compressed { get; set; }
        public bool IsMainImage { get; set; }
        public string ImageFormat { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Projects Projects { get; set; }

        [ForeignKey("DefinedByUserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
