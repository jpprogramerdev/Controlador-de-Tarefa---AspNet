using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoManager.Models {
    [Table("Tarefas")]
    public class Tarefa {
        [Key]
        public int TRF_Id { get; set; }
        [Required(ErrorMessage = "É obrigado informar um titulo para a tarefa")]
        [Display(Name = "Titulo tarefa")]
        public string TRF_Titulo { get; set; }
        [Required(ErrorMessage = "É obrigado informar uma descrição a para a tarefa")]
        [Display(Name = "Descrição tarefa")]
        public string TRF_Descrição { get; set; }
        [Required]
        public DateTime TRF_DataCriada { get; set; }
        [Required(ErrorMessage = "É obrigado informar uma data para a conclusão da tarefa")]
        [Display(Name = "Data de conclusão")]
        public DateTime TRF_DataFInalizada{ get; set; }//data que a tarefa foi finalizada
        
        [Display(Name = "Data limite")]
        public DateTime TRF_DataConclusao { get; set; }//data limite que a tarefa pode se concluida

        //relacionamentos com outras tabelas
        //Prioriodade
        [Required(ErrorMessage = "É obrigado informar uma prioridade da tarefa")]
        [Display(Name = "Prioridade da tarefa")]
        public int TRF_PRD_Id { get; set; }
        public virtual PrioridadeTarefa PrioridadeTarefa { get; set; }

        //Usuario
        [Required(ErrorMessage = "É obrigado informar um usuario para realizar a tarefa")]
        [Display(Name = "Usuario da tarefa")]
        public int TRF_USU_Id { get; set; }
        public virtual Usuario Usuario { get; set; }

        //Status tarefa
        [Required(ErrorMessage = "É obrigado informar o status da tarefa")]
        [Display(Name = "Status da tarefa")]
        public int TRF_STS_Id { get; set; }
        public virtual StatusTarefa StatusTarefa { get; set; }

    }
}
