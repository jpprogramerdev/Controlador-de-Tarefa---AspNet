using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoManager.Models {
    [Table("Usuarios")]
    public class Usuario {
        [Key]
        public int USU_Id { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o nome do usuario")]
        [Display(Name = "Nome")]
        public string USU_Name { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o email do usuario")]
        [Display(Name = "Email")]
        public string USU_Email { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a senha ")]
        [Display(Name = "Senha")]
        public string USU_Senha { get; set; }

        //relacionamentos
        public List<Tarefa> Tarefas { get; set; }

        public int USU_TPU_Id { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
