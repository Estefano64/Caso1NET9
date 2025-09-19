using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace caso2net.Models;

public partial class Consultariacaso2Context : DbContext
{
    public Consultariacaso2Context()
    {
    }

    public Consultariacaso2Context(DbContextOptions<Consultariacaso2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriasGasto> CategoriasGastos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ComunicacionesCliente> ComunicacionesClientes { get; set; }

    public virtual DbSet<ContactosCliente> ContactosClientes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadosProyecto> EstadosProyectos { get; set; }

    public virtual DbSet<EstadosTarea> EstadosTareas { get; set; }

    public virtual DbSet<GastosProyecto> GastosProyectos { get; set; }

    public virtual DbSet<HitosProyecto> HitosProyectos { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<ProyectoEmpleado> ProyectoEmpleados { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<TiposComunicacion> TiposComunicacions { get; set; }

    public virtual DbSet<TiposProyecto> TiposProyectos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=localhost;database=consultariacaso2;uid=root;pwd=root;port=3306",
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CategoriasGasto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categorias_gasto");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes", tb => tb.HasComment("Información de clientes empresariales"));

            entity.HasIndex(e => e.CodigoCliente, "codigo_cliente").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.CodigoCliente)
                .HasMaxLength(20)
                .HasColumnName("codigo_cliente");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.EmailPrincipal)
                .HasMaxLength(150)
                .HasColumnName("email_principal");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(200)
                .HasColumnName("nombre_empresa");
            entity.Property(e => e.RucNit)
                .HasMaxLength(20)
                .HasColumnName("ruc_nit");
            entity.Property(e => e.SectorIndustria)
                .HasMaxLength(100)
                .HasColumnName("sector_industria");
            entity.Property(e => e.SitioWeb)
                .HasMaxLength(200)
                .HasColumnName("sitio_web");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<ComunicacionesCliente>(entity =>
        {
            entity.HasKey(e => e.IdComunicacion).HasName("PRIMARY");

            entity.ToTable("comunicaciones_cliente", tb => tb.HasComment("Registro de todas las comunicaciones con clientes"));

            entity.HasIndex(e => e.IdContactoCliente, "id_contacto_cliente");

            entity.HasIndex(e => e.IdEmpleado, "id_empleado");

            entity.HasIndex(e => e.IdTipoComunicacion, "id_tipo_comunicacion");

            entity.HasIndex(e => e.FechaComunicacion, "idx_comunicaciones_fecha");

            entity.HasIndex(e => e.IdProyecto, "idx_comunicaciones_proyecto");

            entity.Property(e => e.IdComunicacion).HasColumnName("id_comunicacion");
            entity.Property(e => e.ArchivoAdjunto)
                .HasMaxLength(500)
                .HasColumnName("archivo_adjunto");
            entity.Property(e => e.Asunto)
                .HasMaxLength(250)
                .HasColumnName("asunto");
            entity.Property(e => e.Contenido)
                .HasColumnType("text")
                .HasColumnName("contenido");
            entity.Property(e => e.DuracionMinutos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("duracion_minutos");
            entity.Property(e => e.EsImportante)
                .HasDefaultValueSql("'0'")
                .HasColumnName("es_importante");
            entity.Property(e => e.EstadoSeguimiento)
                .HasDefaultValueSql("'pendiente'")
                .HasColumnType("enum('pendiente','en_progreso','completado','cancelado')")
                .HasColumnName("estado_seguimiento");
            entity.Property(e => e.FechaComunicacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_comunicacion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FechaSeguimiento).HasColumnName("fecha_seguimiento");
            entity.Property(e => e.IdContactoCliente).HasColumnName("id_contacto_cliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.IdTipoComunicacion).HasColumnName("id_tipo_comunicacion");
            entity.Property(e => e.RequiereSeguimiento)
                .HasDefaultValueSql("'0'")
                .HasColumnName("requiere_seguimiento");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(200)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdContactoClienteNavigation).WithMany(p => p.ComunicacionesClientes)
                .HasForeignKey(d => d.IdContactoCliente)
                .HasConstraintName("comunicaciones_cliente_ibfk_2");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.ComunicacionesClientes)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comunicaciones_cliente_ibfk_3");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.ComunicacionesClientes)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comunicaciones_cliente_ibfk_1");

            entity.HasOne(d => d.IdTipoComunicacionNavigation).WithMany(p => p.ComunicacionesClientes)
                .HasForeignKey(d => d.IdTipoComunicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comunicaciones_cliente_ibfk_4");
        });

        modelBuilder.Entity<ContactosCliente>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PRIMARY");

            entity.ToTable("contactos_cliente");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Cargo)
                .HasMaxLength(100)
                .HasColumnName("cargo");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.EsPrincipal)
                .HasDefaultValueSql("'0'")
                .HasColumnName("es_principal");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.NombreContacto)
                .HasMaxLength(150)
                .HasColumnName("nombre_contacto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ContactosClientes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contactos_cliente_ibfk_1");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PRIMARY");

            entity.ToTable("departamentos");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(100)
                .HasColumnName("nombre_departamento");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleados", tb => tb.HasComment("Información de empleados de la empresa"));

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.IdDepartamento, "idx_empleados_departamento");

            entity.HasIndex(e => e.NumeroEmpleado, "numero_empleado").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
            entity.Property(e => e.NumeroEmpleado)
                .HasMaxLength(20)
                .HasColumnName("numero_empleado");
            entity.Property(e => e.Puesto)
                .HasMaxLength(100)
                .HasColumnName("puesto");
            entity.Property(e => e.SalarioBase)
                .HasPrecision(10, 2)
                .HasColumnName("salario_base");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("empleados_ibfk_1");
        });

        modelBuilder.Entity<EstadosProyecto>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity.ToTable("estados_proyecto");

            entity.HasIndex(e => e.NombreEstado, "nombre_estado").IsUnique();

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.ColorHex)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#007bff'")
                .HasColumnName("color_hex");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(50)
                .HasColumnName("nombre_estado");
            entity.Property(e => e.OrdenVisualizacion).HasColumnName("orden_visualizacion");
        });

        modelBuilder.Entity<EstadosTarea>(entity =>
        {
            entity.HasKey(e => e.IdEstadoTarea).HasName("PRIMARY");

            entity.ToTable("estados_tarea");

            entity.HasIndex(e => e.NombreEstado, "nombre_estado").IsUnique();

            entity.Property(e => e.IdEstadoTarea).HasColumnName("id_estado_tarea");
            entity.Property(e => e.ColorHex)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#6c757d'")
                .HasColumnName("color_hex");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EsEstadoFinal)
                .HasDefaultValueSql("'0'")
                .HasColumnName("es_estado_final");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(50)
                .HasColumnName("nombre_estado");
        });

        modelBuilder.Entity<GastosProyecto>(entity =>
        {
            entity.HasKey(e => e.IdGasto).HasName("PRIMARY");

            entity.ToTable("gastos_proyecto", tb => tb.HasComment("Control de gastos y presupuesto por proyecto"));

            entity.HasIndex(e => e.IdAprobadoPor, "id_aprobado_por");

            entity.HasIndex(e => e.IdCategoria, "id_categoria");

            entity.HasIndex(e => e.IdRegistradoPor, "id_registrado_por");

            entity.HasIndex(e => e.FechaGasto, "idx_gastos_fecha");

            entity.HasIndex(e => e.IdProyecto, "idx_gastos_proyecto");

            entity.Property(e => e.IdGasto).HasColumnName("id_gasto");
            entity.Property(e => e.Concepto)
                .HasMaxLength(200)
                .HasColumnName("concepto");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EsAprobado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("es_aprobado");
            entity.Property(e => e.FechaAprobacion).HasColumnName("fecha_aprobacion");
            entity.Property(e => e.FechaGasto).HasColumnName("fecha_gasto");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdAprobadoPor).HasColumnName("id_aprobado_por");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.IdRegistradoPor).HasColumnName("id_registrado_por");
            entity.Property(e => e.Monto)
                .HasPrecision(12, 2)
                .HasColumnName("monto");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(50)
                .HasColumnName("numero_factura");
            entity.Property(e => e.Proveedor)
                .HasMaxLength(150)
                .HasColumnName("proveedor");

            entity.HasOne(d => d.IdAprobadoPorNavigation).WithMany(p => p.GastosProyectoIdAprobadoPorNavigations)
                .HasForeignKey(d => d.IdAprobadoPor)
                .HasConstraintName("gastos_proyecto_ibfk_4");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.GastosProyectos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("gastos_proyecto_ibfk_2");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.GastosProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gastos_proyecto_ibfk_1");

            entity.HasOne(d => d.IdRegistradoPorNavigation).WithMany(p => p.GastosProyectoIdRegistradoPorNavigations)
                .HasForeignKey(d => d.IdRegistradoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gastos_proyecto_ibfk_3");
        });

        modelBuilder.Entity<HitosProyecto>(entity =>
        {
            entity.HasKey(e => e.IdHito).HasName("PRIMARY");

            entity.ToTable("hitos_proyecto");

            entity.HasIndex(e => e.IdProyecto, "id_proyecto");

            entity.HasIndex(e => e.IdResponsable, "id_responsable");

            entity.Property(e => e.IdHito).HasColumnName("id_hito");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EsCompletado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("es_completado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaPlanificada).HasColumnName("fecha_planificada");
            entity.Property(e => e.FechaReal).HasColumnName("fecha_real");
            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.IdResponsable).HasColumnName("id_responsable");
            entity.Property(e => e.NombreHito)
                .HasMaxLength(200)
                .HasColumnName("nombre_hito");
            entity.Property(e => e.Notas)
                .HasColumnType("text")
                .HasColumnName("notas");
            entity.Property(e => e.PorcentajePeso)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("porcentaje_peso");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.HitosProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hitos_proyecto_ibfk_1");

            entity.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.HitosProyectos)
                .HasForeignKey(d => d.IdResponsable)
                .HasConstraintName("hitos_proyecto_ibfk_2");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PRIMARY");

            entity.ToTable("proyectos", tb => tb.HasComment("Tabla principal de proyectos de consultoría"));

            entity.HasIndex(e => e.CodigoProyecto, "codigo_proyecto").IsUnique();

            entity.HasIndex(e => e.IdTipoProyecto, "id_tipo_proyecto");

            entity.HasIndex(e => e.IdCliente, "idx_proyectos_cliente");

            entity.HasIndex(e => e.IdEstado, "idx_proyectos_estado");

            entity.HasIndex(e => new { e.FechaInicio, e.FechaFinEstimada }, "idx_proyectos_fechas");

            entity.HasIndex(e => e.IdResponsable, "idx_proyectos_responsable");

            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.CodigoProyecto)
                .HasMaxLength(50)
                .HasColumnName("codigo_proyecto");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFinEstimada).HasColumnName("fecha_fin_estimada");
            entity.Property(e => e.FechaFinReal).HasColumnName("fecha_fin_real");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.GastoReal)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("gasto_real");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdResponsable).HasColumnName("id_responsable");
            entity.Property(e => e.IdTipoProyecto).HasColumnName("id_tipo_proyecto");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(200)
                .HasColumnName("nombre_proyecto");
            entity.Property(e => e.Objetivos)
                .HasColumnType("text")
                .HasColumnName("objetivos");
            entity.Property(e => e.PorcentajeAvance)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("porcentaje_avance");
            entity.Property(e => e.PresupuestoEstimado)
                .HasPrecision(15, 2)
                .HasColumnName("presupuesto_estimado");
            entity.Property(e => e.Prioridad)
                .HasDefaultValueSql("'media'")
                .HasColumnType("enum('baja','media','alta','critica')")
                .HasColumnName("prioridad");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectos_ibfk_1");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectos_ibfk_4");

            entity.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdResponsable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectos_ibfk_3");

            entity.HasOne(d => d.IdTipoProyectoNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdTipoProyecto)
                .HasConstraintName("proyectos_ibfk_2");
        });

        modelBuilder.Entity<ProyectoEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PRIMARY");

            entity.ToTable("proyecto_empleados");

            entity.HasIndex(e => e.IdEmpleado, "id_empleado");

            entity.HasIndex(e => new { e.IdProyecto, e.IdEmpleado, e.Activo }, "unique_proyecto_empleado_activo").IsUnique();

            entity.Property(e => e.IdAsignacion).HasColumnName("id_asignacion");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.FechaAsignacion).HasColumnName("fecha_asignacion");
            entity.Property(e => e.FechaDesasignacion).HasColumnName("fecha_desasignacion");
            entity.Property(e => e.HorasAsignadasSemanales)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("horas_asignadas_semanales");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.RolEnProyecto)
                .HasMaxLength(100)
                .HasColumnName("rol_en_proyecto");
            entity.Property(e => e.TarifaPorHora)
                .HasPrecision(8, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("tarifa_por_hora");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.ProyectoEmpleados)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyecto_empleados_ibfk_2");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.ProyectoEmpleados)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyecto_empleados_ibfk_1");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PRIMARY");

            entity.ToTable("tareas", tb => tb.HasComment("Tareas específicas dentro de cada proyecto"));

            entity.HasIndex(e => e.IdCreador, "id_creador");

            entity.HasIndex(e => e.IdAsignado, "idx_tareas_asignado");

            entity.HasIndex(e => e.IdEstadoTarea, "idx_tareas_estado");

            entity.HasIndex(e => e.IdProyecto, "idx_tareas_proyecto");

            entity.Property(e => e.IdTarea).HasColumnName("id_tarea");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFinEstimada).HasColumnName("fecha_fin_estimada");
            entity.Property(e => e.FechaFinReal).HasColumnName("fecha_fin_real");
            entity.Property(e => e.FechaInicioEstimada).HasColumnName("fecha_inicio_estimada");
            entity.Property(e => e.FechaInicioReal).HasColumnName("fecha_inicio_real");
            entity.Property(e => e.HorasEstimadas)
                .HasPrecision(8, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("horas_estimadas");
            entity.Property(e => e.HorasTrabajadas)
                .HasPrecision(8, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("horas_trabajadas");
            entity.Property(e => e.IdAsignado).HasColumnName("id_asignado");
            entity.Property(e => e.IdCreador).HasColumnName("id_creador");
            entity.Property(e => e.IdEstadoTarea).HasColumnName("id_estado_tarea");
            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.NombreTarea)
                .HasMaxLength(200)
                .HasColumnName("nombre_tarea");
            entity.Property(e => e.Notas)
                .HasColumnType("text")
                .HasColumnName("notas");
            entity.Property(e => e.PorcentajeCompletado)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("porcentaje_completado");
            entity.Property(e => e.Prioridad)
                .HasDefaultValueSql("'media'")
                .HasColumnType("enum('baja','media','alta','critica')")
                .HasColumnName("prioridad");

            entity.HasOne(d => d.IdAsignadoNavigation).WithMany(p => p.TareaIdAsignadoNavigations)
                .HasForeignKey(d => d.IdAsignado)
                .HasConstraintName("tareas_ibfk_2");

            entity.HasOne(d => d.IdCreadorNavigation).WithMany(p => p.TareaIdCreadorNavigations)
                .HasForeignKey(d => d.IdCreador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tareas_ibfk_3");

            entity.HasOne(d => d.IdEstadoTareaNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdEstadoTarea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tareas_ibfk_4");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tareas_ibfk_1");
        });

        modelBuilder.Entity<TiposComunicacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoComunicacion).HasName("PRIMARY");

            entity.ToTable("tipos_comunicacion");

            entity.HasIndex(e => e.NombreTipo, "nombre_tipo").IsUnique();

            entity.Property(e => e.IdTipoComunicacion).HasColumnName("id_tipo_comunicacion");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .HasColumnName("icono");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .HasColumnName("nombre_tipo");
        });

        modelBuilder.Entity<TiposProyecto>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PRIMARY");

            entity.ToTable("tipos_proyecto");

            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(100)
                .HasColumnName("nombre_tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
