using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoManager.Models {
    [Table("StatusTarefas")]
    public class StatusTarefa {
        [Key]
        public int STS_Id { get; set; }
        [Required]
        [Display(Name = "Status tarefa")]
        public string STS_Status { get; set; }

        public List<Tarefa> Tarefas { get; set; }
    }
}
