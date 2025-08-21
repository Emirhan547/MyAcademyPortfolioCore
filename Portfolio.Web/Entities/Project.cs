using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        [MinLength(5,ErrorMessage ="Proje Adı en az 5 karakter olmalıdır")]
        [MaxLength(50, ErrorMessage = "Proje Adı en fazla 100 karakter olmalıdır")]
        [Required(ErrorMessage = "Proje Adı boş geçilemez")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Proje Adı boş geçilemez")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Resim Adı boş geçilemez")]
        public string GithubUrl { get; set; }
        [Required(ErrorMessage = "Kategori Boş bırakılamaz")]
        public int CategoryId{ get; set; }

        public Category? Category { get; set; }
    }
}
