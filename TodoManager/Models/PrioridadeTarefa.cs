using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoManager.Models {
    [Table("PrioridadesTarefas")]
    public class PrioridadeTarefa {
        [Key]
        public int PRD_Id{ get; set; }
        [Required(ErrorMessage = "É obrigado informar uma prioridade")]
        [Display(Name = "Descrição tarefa")]
        public string PRD_Descricao{ get; set; }

        
        public List<Tarefa> Tarefas { get; set; }

    }
}
