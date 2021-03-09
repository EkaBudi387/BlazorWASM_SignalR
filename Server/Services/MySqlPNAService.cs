using BlazorWASM_SignalR.Server.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Server.Services
{
    public interface IMySqlPNA
    {
        Task<List<ServerModelMySqlPNA>> PNAModelList();
    }

    public class MySQLPNAServices : IMySqlPNA
    {
        private readonly IConfiguration configuration2;

        public MySQLPNAServices(IConfiguration configurationPNA)
        {
            configuration2 = configurationPNA;
        }

        public string GetConnectionPNA()
        {
            var connection = configuration2.GetSection("ConnectionStrings").GetSection("MySqlConnection").Value;
            return connection;
        }

        public async Task<List<ServerModelMySqlPNA>> PNAModelList()
        {

            var connectionString = this.GetConnectionPNA();

            List<ServerModelMySqlPNA> list = new List<ServerModelMySqlPNA>();

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var com = new MySqlCommand(sql, con)
                    {
                        CommandType = CommandType.Text
                    };
                    var reader = (MySqlDataReader)await com.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        list.Add(new ServerModelMySqlPNA
                        {
                            SN = reader["SN"].ToString(),
                            PN = reader["PN"].ToString(),
                            Remark = reader["Remark"].ToString()
                        });
                    }

                    return list.ToList();

                }
                finally { con.Close(); }

            }
        }

        public string sql =
            "select distinct SN, PN, State, Remark " +
            "from sfcm_pna " +
            "where time >= now() - interval 7 day and State = \"NG\" " +
            "order by Time desc";
    }
}
