using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAU.Models
{
    public class Engineer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sorry! The engineer's name is required! :)")]
        public String Name { get; set; }

        public Engineer(int pId, String pName)
        {
            Id = pId;
            Name = pName;
        }

        public Engineer()
        {

        }
    }
}
