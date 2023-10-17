using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace do_an_ck.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int role_id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
