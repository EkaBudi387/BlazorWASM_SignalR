using BlazorWASM_SignalR.Server.Models;
using BlazorWASM_SignalR.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Server.Controllers
{
    [Route("api/[controller]")]
    public class MySqlController : Controller
    {
        readonly IMySql imySql;

        public MySqlController(IMySql mySql)
        {
            imySql = mySql;
        }

        [HttpGet("[action]")]
        public async Task<List<ServerModelMySql>> ModelList()
        {
            var model = await imySql.ModelList();
            return model;
        }
    }
}
