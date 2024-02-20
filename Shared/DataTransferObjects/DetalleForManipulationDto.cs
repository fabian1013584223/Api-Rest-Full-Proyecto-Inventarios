using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record DetalleForManipulationDto
{
  

    [Required(ErrorMessage = "ValorUnitario es un campo requerido.")]
    public float ValorUnitario { get; set; }

    [Required(ErrorMessage = "Cantidad es un campo requerido.")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "IVA es un campo requerido.")]
    public float IVA { get; set; }

    [Required(ErrorMessage = "ValorDescuento es un campo requerido.")]
    public float ValorDescuento { get; set; }
}

