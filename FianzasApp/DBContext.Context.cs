﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FianzasApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FinanzasAppDBEntities : DbContext
    {
        public FinanzasAppDBEntities()
            : base("name=FinanzasAppDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Caso> Caso { get; set; }
        public virtual DbSet<Fianza> Fianza { get; set; }
    
        public virtual ObjectResult<SPGetCasos_Result> SPGetCasos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetCasos_Result>("SPGetCasos");
        }
    
        public virtual ObjectResult<SPGetFianzas_Result> SPGetFianzas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGetFianzas_Result>("SPGetFianzas");
        }
    
        public virtual int SPInsertCaso(string descripcion, Nullable<int> cantidadImputados, Nullable<decimal> balanceFianza, string estado)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var cantidadImputadosParameter = cantidadImputados.HasValue ?
                new ObjectParameter("CantidadImputados", cantidadImputados) :
                new ObjectParameter("CantidadImputados", typeof(int));
    
            var balanceFianzaParameter = balanceFianza.HasValue ?
                new ObjectParameter("BalanceFianza", balanceFianza) :
                new ObjectParameter("BalanceFianza", typeof(decimal));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPInsertCaso", descripcionParameter, cantidadImputadosParameter, balanceFianzaParameter, estadoParameter);
        }
    
        public virtual int SPInsertFianza(string descripcion, Nullable<decimal> monto, string cedula, string nombres, string apellidos, string sexo, string estado)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("Monto", monto) :
                new ObjectParameter("Monto", typeof(decimal));
    
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("Nombres", nombres) :
                new ObjectParameter("Nombres", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("Apellidos", apellidos) :
                new ObjectParameter("Apellidos", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPInsertFianza", descripcionParameter, montoParameter, cedulaParameter, nombresParameter, apellidosParameter, sexoParameter, estadoParameter);
        }
    
        public virtual int SPUpsertCaso(string descripcion, Nullable<int> cantidadImputados, Nullable<decimal> balanceFianza, string estado)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var cantidadImputadosParameter = cantidadImputados.HasValue ?
                new ObjectParameter("CantidadImputados", cantidadImputados) :
                new ObjectParameter("CantidadImputados", typeof(int));
    
            var balanceFianzaParameter = balanceFianza.HasValue ?
                new ObjectParameter("BalanceFianza", balanceFianza) :
                new ObjectParameter("BalanceFianza", typeof(decimal));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPUpsertCaso", descripcionParameter, cantidadImputadosParameter, balanceFianzaParameter, estadoParameter);
        }
    
        public virtual int SPUpssertCaso(string descripcion, Nullable<int> cantidadImputados, Nullable<decimal> balanceFianza, string estado)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var cantidadImputadosParameter = cantidadImputados.HasValue ?
                new ObjectParameter("CantidadImputados", cantidadImputados) :
                new ObjectParameter("CantidadImputados", typeof(int));
    
            var balanceFianzaParameter = balanceFianza.HasValue ?
                new ObjectParameter("BalanceFianza", balanceFianza) :
                new ObjectParameter("BalanceFianza", typeof(decimal));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPUpssertCaso", descripcionParameter, cantidadImputadosParameter, balanceFianzaParameter, estadoParameter);
        }
    }
}