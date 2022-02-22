using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Task_9_1
{
    public class Repository
    {
        public void DeleteEmployees()
        {
            using var con = GetConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Employee";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertEmployees(List<VacationRecord> list)
        {
            using var con = GetConnection();
            var insertEmployeeCmd = PrepareInsertEmployeeCommand(con);
            var insertVacationCmd = PrepareInsertVacationCommand(con);
            con.Open();
            foreach (var group in list.GroupBy(x => x.Person))
            {
                var employeeId = Guid.NewGuid();
                var (first, last) = SplitName(group.Key);

                insertEmployeeCmd.Parameters["@id"].Value = employeeId;
                insertEmployeeCmd.Parameters["@email"].Value = $"{first}{last}@issoft.by";
                insertEmployeeCmd.Parameters["@first"].Value = first;
                insertEmployeeCmd.Parameters["@last"].Value = last;
                insertEmployeeCmd.ExecuteNonQuery();

                foreach (var item in group)
                {
                    insertVacationCmd.Parameters["@id"].Value = Guid.NewGuid();
                    insertVacationCmd.Parameters["@start"].Value = item.Start;
                    insertVacationCmd.Parameters["@end"].Value = item.End;
                    insertVacationCmd.Parameters["@employeeId"].Value = employeeId;
                    insertVacationCmd.ExecuteNonQuery();
                }
            }

            con.Close();

            static (string, string) SplitName(string name)
            {
                var parts = name.Split(' ');
                return (parts[0], parts[1]);
            }
        }

        private static SqlCommand PrepareInsertEmployeeCommand(SqlConnection con)
        {
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Employee VALUES (@id, @email, @first, @last);";
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 128);
            cmd.Parameters.Add("@first", SqlDbType.NVarChar, 128);
            cmd.Parameters.Add("@last", SqlDbType.NVarChar, 128);
            return cmd;
        }

        private static SqlCommand PrepareInsertVacationCommand(SqlConnection con)
        {
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Vacation VALUES (@id, @start, @end, @employeeId);";
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier);
            cmd.Parameters.Add("@start", SqlDbType.Date);
            cmd.Parameters.Add("@end", SqlDbType.Date);
            cmd.Parameters.Add("@employeeId", SqlDbType.UniqueIdentifier);
            return cmd;
        }

        private static SqlConnection GetConnection()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connection = config.GetConnectionString("DefaultConnection");
            return new SqlConnection(connection);
        }
    }
}