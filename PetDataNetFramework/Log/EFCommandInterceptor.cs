using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDataNetFramework.Log
{
    public class EFCommandInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo("NonQueryExecuted", String.Format($" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}"));
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo("NonQueryExecuting", String.Format($" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}"));
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogInfo("ReaderExecuted", String.Format($" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}"));
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogInfo("ReaderExecuting", String.Format($" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}"));
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo("ScalarExecuted", String.Format($" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}"));
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo("ScalarExecuting", String.Format($" IsAsync: {interceptionContext.IsAsync}, Command Text: {command.CommandText}"));
        }
        
        private void LogInfo(string command, string commandText)
        {
            Console.WriteLine($"Intercepted on : {command} : - {commandText}");
        }
    }
}
