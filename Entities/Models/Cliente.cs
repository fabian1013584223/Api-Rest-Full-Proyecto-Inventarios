using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cliente
    {
    [Column("ClienteId")]
    public Guid ClienteId { get; set; }
    public string? Numerodocumento { get; set; }
    public string? Tipodocumento { get; set; }
    public string? Nombre  { get; set; }
    public string? Apellido { get; set; }
    public string? Correo { get; set; }
    public long? Contacto { get; set; }


    [ForeignKey(nameof(Usuario))]
    public Guid UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }

    }

}
