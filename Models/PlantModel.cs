using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class PlantModel
    {
        [Key]
        public int PlantId { get; set; }

        public string Name { get; set; } = null!;

        public List<InstructionModel> Instructions { get; set; } = new();

    }
}
