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
    public interface IMySql
    {
        Task<List<ServerModelMySql>> ModelList();
    }

    public class MySQLServices : IMySql
    {
        private readonly IConfiguration configuration1;

        public MySQLServices(IConfiguration configuration)
        {
            configuration1 = configuration;
        }

        public string GetConnection()
        {
            var connection = configuration1.GetSection("ConnectionStrings").GetSection("MySqlConnection").Value;
            return connection;
        }

        public async Task<List<ServerModelMySql>> ModelList()
        {

            var connectionString = this.GetConnection();

            List<ServerModelMySql> list = new List<ServerModelMySql>();

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
                        list.Add(new ServerModelMySql
                        {
                            SA_SN = reader["SA_SN"].ToString(),
                            SA_PN = reader["SA_PN"].ToString(),
                            State = reader["State"].ToString(),
                            SO    = reader["so"].ToString(),
                            Staff = reader["Staff"].ToString(),
                            Station = reader["Station"].ToString(),
                            Line = reader["Line"].ToString(),
                            Time = Convert.ToDateTime(reader["Time"].ToString()),
                            Tool = reader["MACH_No"].ToString()
                        });
                    }

                    return list.ToList();

                }
                finally { con.Close(); }

            }
        }

        public string sql =
            "select Time, Station, SA_SN, SA_PN, so, Line, Staff, MACH_No, State " +
            "from sfcs_alstripping " +
            "where time >= now() - interval 4 day and State NOT LIKE \"OK\" " +

            "UNION " +

            "select Time, Station, SA_SN, SA_PN, so, Line, Staff, MACH_No, State " +
            "from sfcs_spotsoldering " +
            "where time >= now() - interval 4 day and State NOT LIKE \"OK\" " +

            "UNION " +

            "select Time, Station, SA_SN, SA_PN, so, Line, Staff, MACH_No, State " +
            "from sfcs_solderinginspection " +
            "where time >= now() - interval 4 day and State NOT LIKE \"OK\" " +

            "UNION " +

            "select Time, Station, SA_SN, SA_PN, so, Line, Staff, MACH_No, State " +
            "from sfcs_semi_fgtest " +
            "where time >= now() - interval 4 day and State NOT LIKE \"OK\" " +

            "UNION " +

            "select Time, Station, SA_SN, SA_PN, so, Line, Staff, MACH_No, State " +
            "from sfcs_backshellassembly " +
            "where time >= now() - interval 4 day and State NOT LIKE \"OK\" " +

            "UNION " +

            "select Time, Station, SA_SN, SA_PN, so, Line, Staff, MACH_No, State " +
            "from sfcs_fgtest " +
            "where time >= now() - interval 4 day and State NOT LIKE \"OK\" " +

            "order by Time desc " +
            "limit 100";
    }
}
