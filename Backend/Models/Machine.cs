using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Machine
    {
        [Key]
        public int machineId { get; set; }

        [Required]
        public string id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string deviceTypeId { get; set; }

        [Required]
        public bool failsafe { get; set; }

        [Required]
        public int tempMin { get; set; }

        [Required]
        public int tempMax { get; set; }

        [Required]
        public string installationPosition { get; set; }

        [Required]
        public bool insertInto19InchCabinet { get; set; }

        [Required]
        public bool motionEnable { get; set; }

        [Required]
        public bool siplusCatalog { get; set; }

        [Required]
        public bool simaticCatalog { get; set; }

        [Required]
        public int rotationAxisNumber { get; set; }

        [Required]
        public int positionAxisNumber { get; set; }

        public bool? terminalElement { get; set; }

        public bool? advancedEnvironmentalConditions { get; set; }
    }
}