﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fonte
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FONTEEntitiesDias : DbContext
    {
        public FONTEEntitiesDias()
            : base("name=FONTEEntitiesDias")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<GetDiasFonte_Result> GetDiasFonte()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDiasFonte_Result>("GetDiasFonte");
        }
    }
}
