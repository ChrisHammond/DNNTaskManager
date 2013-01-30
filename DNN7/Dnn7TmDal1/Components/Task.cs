/*
' Copyright (c) 2013 DotNetNuke Corporation
'  All rights reserved.
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
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;

namespace DotNetNuke.Modules.Dnn7TmDal1.Components
{
    public class Task : IHydratable
    {

        ///<summary>
        /// TaskId identifies and individual task
        ///</summary>
        public int TaskId { get; set; }


        ///<summary>
        /// A string with the name of the Task
        ///</summary>
        public string TaskName { get; set; }

        ///<summary>
        /// A string with the description of the Task
        ///</summary>
        public string TaskDescription { get; set; }

        ///<summary>
        /// An integeger with the user id of the assigned user for the Task
        ///</summary>
        public int AssignedUserId { get; set; }

        ///<summary>
        /// The ModuleId of where the task was created and gets displayed
        ///</summary>
        public int ModuleId { get; set; }

        ///<summary>
        /// A date for the targetted completion date 
        ///</summary>
        public DateTime TargetCompletionDate { get; set; }

        ///<summary>
        /// A date for the actual completion date of the task
        ///</summary>
        public DateTime? CompletedOnDate { get; set; }

        ///<summary>
        /// An integer for the user id of the user who created the task
        ///</summary>
        public int CreatedByUserId { get; set; }
        ///<summary>
        /// An integer for the user id of the user who last updated the task
        ///</summary>
        public int LastModifiedByUserId { get; set; }
        ///<summary>
        /// The date the task was created
        ///</summary>
        public new DateTime CreatedOnDate { get; set; }
        ///<summary>
        /// The date the task was updated
        ///</summary>
        public new DateTime LastModifiedOnDate { get; set; }

        ///<summary>
        /// The portal where the article resides
        ///</summary>
        public int PortalId { get; set; }


        //Read Only Props
        ///<summary>
        /// The username of the user who created the task
        ///</summary>
        public string CreatedByUser
        {
            get
            {
                return CreatedByUserId != 0 ? Entities.Users.UserController.GetUserById(PortalId, CreatedByUserId).Username : Null.NullString;
            }
        }

        ///<summary>
        /// The username of the user who last updated the task
        ///</summary>
        public string LastUpdatedByUser
        {
            get
            {
                return LastModifiedByUserId != 0 ? Entities.Users.UserController.GetUserById(PortalId, LastModifiedByUserId).Username : Null.NullString;
            }
        }


        public void Fill(System.Data.IDataReader dr)
        {
            TaskId = Null.SetNullInteger(dr["TaskId"]);
            ModuleId = Null.SetNullInteger(dr["ModuleId"]);
            TaskName = Null.SetNullString(dr["TaskName"]);
            TaskDescription = Null.SetNullString(dr["TaskDescription"]);
            AssignedUserId = Null.SetNullInteger(dr["AssignedUserId"]);
            TargetCompletionDate = Null.SetNullDateTime(dr["TargetCompletionDate"]);
            CompletedOnDate = Null.SetNullDateTime(dr["CompletedOnDate"]);
            CreatedByUserId = Null.SetNullInteger(dr["CreatedByUserId"]);
            LastModifiedByUserId = Null.SetNullInteger(dr["LastModifiedByUserId"]);
            CreatedOnDate = Null.SetNullDateTime(dr["CreatedOnDate"]);
            LastModifiedOnDate = Null.SetNullDateTime(dr["LastModifiedOnDate"]);
        }

        public int KeyID
        {
            get { return TaskId; }
            set { TaskId = value; }
        }
    }
}