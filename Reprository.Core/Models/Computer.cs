using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Reprository.Core.Models
{
    public class Computer
    {
        [Key]
        [ForeignKey("MainProduct")]
        public int MainProductId { get; set; }
        public MainProduct MainProduct { get; set; }

        public double Weight { get; set; }
        public int RAM { get; set; }
        public int StorageCapacity { get; set; }
        public int USBPorts { get; set; }
        public int HDMIOutputs { get; set; }
        public int WarrantyPeriod { get; set; }
        public string? Model { get; set; }
        public string? Processor { get; set; }
        public string? GraphicsCard { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Material { get; set; }
        public string? CountryOfOrigin { get; set; }            
        public bool HasTouchscreen { get; set; }
        public bool HasKeyboard { get; set; }
        public bool HasMouse { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
