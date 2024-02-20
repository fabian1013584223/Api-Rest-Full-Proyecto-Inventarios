using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Usuario
    {
        [Column("IdUsuario")]
        [Key]
        public Guid IdUsuario { get; set; }


        [Required(ErrorMessage = "Usuario nombre is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Usuario direccion is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "Usuario contraseña is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? Contraseña { get; set; }
        [Required(ErrorMessage = "Usuario apellido is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "Usuario correo is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Usuario numero de documento is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public long NumeroDocumento { get; set; }
        public long Contacto { get; set; }
        public string? Pais { get; set; }
        public ICollection<Cliente>? Clientes { get; set; }
    }
}