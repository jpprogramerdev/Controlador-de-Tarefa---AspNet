using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoManager.Models {
    [Table("TiposUsuarios")]
    public class TipoUsuario {
        [Key]
        public int TPU_Id { get; set; }
        [Required]
        public string TPU_Descricao { get; set; }

        public List<Usuario> Usuario { get; set; }
    }
}
