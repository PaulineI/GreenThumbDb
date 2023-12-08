using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class InstructionModel
    {
        [Key]
        public int Id { get; set; }

        public string Instruction { get; set; } = null!;

        public int PlantId { get; set; }

        public PlantModel Plant { get; set; } = null!;


    }
}
