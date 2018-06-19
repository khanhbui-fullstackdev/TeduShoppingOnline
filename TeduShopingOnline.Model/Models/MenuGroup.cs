using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShopingOnline.Common.Constants;


namespace TeduShopingOnline.Model.Models
{
    [Table("MenuGroups")]
    public class MenuGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
            MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
            MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
            Column(TypeName = "varchar")]
        public string Name { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
