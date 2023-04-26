using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public enum ScreenType
    {
        IPS,
        OLED,
        AMOLED,
        ULTRA_AMOLED
    }
    public class Mobile
    {
        [Key]
        [ForeignKey("MainProduct")]
        public int MainProductId { get; set; }
        public MainProduct MainProduct { get; set; }

        public double ScreenSize { get; set; }
        public int RAM { get; set; }
        public int NumSIMCards { get; set; }
        public int BatteryLife { get; set; }
        public int StorageCapacity { get; set; }
        public int Weight { get; set; }
        public bool HasFingerprintScanner { get; set; }
        public int? NumberOfCamera { get; set; }
        public bool HasFrontCamera { get; set; }
        public bool HasBackCamera { get; set; }
        public bool HasNFC { get; set; }
        public bool HasBluetooth { get; set; }
        public bool IsWaterproof { get; set; }
        public string? OperatingSystem { get; set; }
        public ScreenType? Screentype { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }




    }
}
