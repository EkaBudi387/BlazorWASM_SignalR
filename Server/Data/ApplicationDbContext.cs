﻿using BlazorWASM_SignalR.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWASM_SignalR.Shared;

namespace BlazorWASM_SignalR.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<InfoFASA> InfoFASAs { get; set; }
        public DbSet<List_FA_DetDefect> List_FA_DetDefects { get; set; }
        public DbSet<SharedBakingRecord> SharedBakingRecords { get; set; }

    }
}
