using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class TV
    {
        [Key]
        [ForeignKey("MainProduct")]
        public int MainProductId { get; set; }
        public MainProduct MainProduct { get; set; }

        public double ScreenSize { get; set; }     
        public int NumHDMIInputs { get; set; }
        public int NumUSBPorts { get; set; }
        public int Resolution { get; set; }
        public int RefreshRate { get; set; }
        public bool IsSmartTV { get; set; }
        public bool Is3D { get; set; }
        public bool HasHDR { get; set; }       
        public bool HasEthernet { get; set; }
        public bool IsCurved { get; set; }
        public bool HasBluetooth { get; set; }
        public bool HasWIFI { get; set; }
        
    }
}
