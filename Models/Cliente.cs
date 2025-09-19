using System;
using System.Collections.Generic;

namespace caso2net.Models;

/// <summary>
/// Información de clientes empresariales
/// </summary>
public partial class Cliente
{
    public int IdCliente { get; set; }

    public string CodigoCliente { get; set; } = null!;

    public string NombreEmpresa { get; set; } = null!;

    public string? RucNit { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? EmailPrincipal { get; set; }

    public string? SitioWeb { get; set; }

    public string? SectorIndustria { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<ContactosCliente> ContactosClientes { get; set; } = new List<ContactosCliente>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
