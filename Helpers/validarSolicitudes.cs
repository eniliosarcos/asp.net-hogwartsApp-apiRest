using FluentValidation;
using hogwartsApi.Models;
using System.Linq;

public class validarSolicitudes : AbstractValidator<Solicitud>
{
    public validarSolicitudes()
    {
        RuleFor(x => x.Nombre).MaximumLength(20).WithMessage("El nombre debe ser maximo 20 caracteres")
                            .Must(x => x.All(char.IsLetter)).WithMessage("Solo se permiten letras en el nombre")
                            .NotEmpty().WithMessage("El nombre es obligatorio");

        RuleFor(x => x.Apellido).MaximumLength(20).WithMessage("El apellido debe ser maximo 20 caracteres")
                            .Must(x => x.All(char.IsLetter)).WithMessage("Solo se permiten letras en el apellido");

        RuleFor(x => x.Identificacion).MaximumLength(10).WithMessage("La identificacion debe tener maximo 10 digitos")
                            .Must(x => x.All(char.IsDigit)).WithMessage("Solo se permiten numeros en la identificacion");

        RuleFor(x => x.Edad).MaximumLength(2).WithMessage("La edad debe tener maximo 2 digitos")
                            .Must(x => x.All(char.IsDigit)).WithMessage("Solo se permiten numeros en la identificacion")
                            .NotEmpty().WithMessage("La edad es obligatoria");

        RuleFor(x => x.Casa).NotNull()
                            .Must(validarCasa).WithMessage("Casas validas: Gryffindor, Hufflepuff, Ravenclaw, Slytherin")
                            .NotEmpty().WithMessage("La casa es obligatorio");

    }

    private bool validarCasa(string casa)
    {
        string[] casasPermitidas = new string[] { "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin"};

        if(casasPermitidas.FirstOrDefault(check => check.Contains(casa)) == null)
        {
            return false;
        }

        return true;
    }
}

