using System.ComponentModel.DataAnnotations;
using TuProyecto.Enums;

public class MedicoCreateDTO
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
    public string Nombre { get; set; } = "";

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
    public string Apellido { get; set; } = "";

    [Required(ErrorMessage = "El DNI es obligatorio")]
    [StringLength(8,MinimumLength = 8, ErrorMessage = "El DNI debe tener exactamente 8 caracteres")]
    public string Dni { get; set; } = "";

    [Required]
    [Range(1, 100, ErrorMessage = "La edad debe estar entre 1 y 100")]
    public int Edad{get;set;}

    [Required(ErrorMessage = "El Telefono es obligatorio")]
    [StringLength(9,MinimumLength = 9, ErrorMessage = "El teléfono debe tener exactamente 9 caracteres")]
    public string Telefono{get;set;} = "";

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
    public string Correo{get;set;} = "";

    [Required(ErrorMessage = "La especialidad es obligatorio")]
    public Especialidad especialidad{get;set;}

    public List<string> palabrasClave{get;set;} = new List<string>();
}