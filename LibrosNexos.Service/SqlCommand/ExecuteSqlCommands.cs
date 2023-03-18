using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrosNexos.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LibrosNexos.Service.SqlCommand
{
    public static class ExecuteSqlCommands
    {
        public static async Task<string> ExcuteSqlStoredProcedure(this LibrosNexosContext context, string query, Microsoft.Data.SqlClient.SqlParameter[] parameterList)
        {
            string JSON = string.Empty;
            if (context.ChangeTracker.LazyLoadingEnabled != false)
                context.ChangeTracker.LazyLoadingEnabled = false;
            using (DbCommand command = context.Database.GetDbConnection().CreateCommand())
            {
                if (parameterList != null)
                    command.Parameters.AddRange(parameterList);

                command.CommandText = query;
                command.CommandType = CommandType.StoredProcedure;

                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                DbDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                        JSON += reader.GetTextReader(0).ReadToEnd();
                }
                try { reader.Dispose(); } catch (Exception e) { }
                command.Connection.Close();
            }

            return JSON;
        }
    }
}
