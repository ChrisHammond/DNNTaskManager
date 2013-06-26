/*
' Copyright (c) 2013 Christoc.com Software Solutions
' All rights reserved.
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy of this
' software and associated documentation files (the "Software"), to deal in the Software 
' without restriction, including without limitation the rights to use, copy, modify, merge, 
' publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
' to whom the Software is furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in all copies or
' substantial portions of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING
' BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
' NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
' DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
*/

using System;
using System.Data;
using System.Data.SqlClient;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;
using Christoc.Modules.DnnTaskManagerDal1.Components;
using Microsoft.ApplicationBlocks.Data;

namespace Christoc.Modules.DnnTaskManagerDal1.Data
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// SQL Server implementation of the abstract DataProvider class
    /// 
    /// This concreted data provider class provides the implementation of the abstract methods 
    /// from data dataprovider.cs
    /// 
    /// In most cases you will only modify the Public methods region below.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public class SqlDataProvider : DataProvider
    {

        #region Private Members

        private const string ProviderType = "data";
        private const string ModuleQualifier = "DNNTaskManagerDal1_";

        private readonly ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType);
        private readonly string _connectionString;
        private readonly string _providerPath;
        private readonly string _objectQualifier;
        private readonly string _databaseOwner;

        #endregion

        #region Constructors

        public SqlDataProvider()
        {

            // Read the configuration specific information for this provider
            Provider objProvider = (Provider)(_providerConfiguration.Providers[_providerConfiguration.DefaultProvider]);

            // Read the attributes for this provider

            //Get Connection string from web.config
            _connectionString = Config.GetConnectionString();

            if (string.IsNullOrEmpty(_connectionString))
            {
                // Use connection string specified in provider
                _connectionString = objProvider.Attributes["connectionString"];
            }

            _providerPath = objProvider.Attributes["providerPath"];

            _objectQualifier = objProvider.Attributes["objectQualifier"];
            if (!string.IsNullOrEmpty(_objectQualifier) && _objectQualifier.EndsWith("_", StringComparison.Ordinal) == false)
            {
                _objectQualifier += "_";
            }

            _databaseOwner = objProvider.Attributes["databaseOwner"];
            if (!string.IsNullOrEmpty(_databaseOwner) && _databaseOwner.EndsWith(".", StringComparison.Ordinal) == false)
            {
                _databaseOwner += ".";
            }

        }

        #endregion

        #region Properties

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public string ProviderPath
        {
            get
            {
                return _providerPath;
            }
        }

        public string ObjectQualifier
        {
            get
            {
                return _objectQualifier;
            }
        }

        public string DatabaseOwner
        {
            get
            {
                return _databaseOwner;
            }
        }

        // used to prefect your database objects (stored procedures, tables, views, etc)
        private string NamePrefix
        {
            get { return DatabaseOwner + ObjectQualifier + ModuleQualifier; }
        }

        #endregion

        #region Private Methods

        private static object GetNull(object field)
        {
            return Null.GetNull(field, DBNull.Value);
        }

        #endregion

        #region Public Methods

        public override System.Data.IDataReader GetTasks(int moduleId)
        {
            return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "GetTasks",
                                           new SqlParameter("@ModuleId", moduleId));
        }

        public override System.Data.IDataReader GetTask(int taskId)
        {
            return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "GetTask",
                                           new SqlParameter("@TaskId", taskId));
        }

        public override void DeleteTask(int taskId)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, NamePrefix + "DeleteTask", new SqlParameter("@TaskId", taskId));
        }

        public override void DeleteTasks(int moduleId)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, NamePrefix + "DeleteTasks", new SqlParameter("@ModuleId", moduleId));
        }

        public override int AddTask(Task t)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, NamePrefix + "AddTask"
                , new SqlParameter("@TaskName", t.TaskName)
                , new SqlParameter("@TaskDescription", t.TaskDescription)
                , new SqlParameter("@AssignedUserId", t.AssignedUserId)
                , new SqlParameter("@ModuleId", t.ModuleId)
                , new SqlParameter("@TargetCompletionDate", t.TargetCompletionDate)
                , new SqlParameter("@CompletedOnDate", t.CompletedOnDate)
                , new SqlParameter("@CreatedByUserId", t.CreatedByUserId)
                ));
        }

        public override void UpdateTask(Task t)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, NamePrefix + "UpdateTask"
                                      , new SqlParameter("@TaskId", t.TaskId)
                                      , new SqlParameter("@TaskName", t.TaskName)
                                      , new SqlParameter("@TaskDescription", t.TaskDescription)
                                      , new SqlParameter("@AssignedUserId", t.AssignedUserId)
                                      , new SqlParameter("@ModuleId", t.ModuleId)
                                      , new SqlParameter("@TargetCompletionDate", t.TargetCompletionDate)
                                      , new SqlParameter("@CompletedOnDate", t.CompletedOnDate)
                                      , new SqlParameter("@LastModifiedByUserId", t.LastModifiedByUserId)
                );
        }



        #endregion

    }

}