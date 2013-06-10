/*
' Copyright (c) 2013 Christoc.com Software Solutions
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
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;

namespace Christoc.Modules.DnnTaskManagerDal2.Components
{
    [TableName("DnnTaskManagerDal2_Tasks")]
    //setup the primary key for table
    [PrimaryKey("TaskId", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Tasks", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    class Task
    {
        ///<summary>
        /// The ID of your object with the name of the TaskName
        ///</summary>
        public int TaskId { get; set; }
        ///<summary>
        /// A string with the name of the TaskName
        ///</summary>
        public string TaskName { get; set; }

        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string TaskDescription { get; set; }

        ///<summary>
        /// An integeger with the user id of the assigned user for the object
        ///</summary>
        public int AssignedUserId { get; set; }

        ///<summary>
        /// The ModuleId of where the object was created and gets displayed
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
        /// An integer for the user id of the user who created the object
        ///</summary>
        public int CreatedByUserId { get; set; }

        ///<summary>
        /// An integer for the user id of the user who last updated the object
        ///</summary>
        public int LastModifiedByUserId { get; set; }

        ///<summary>
        /// The date the object was created
        ///</summary>
        public DateTime CreatedOnDate { get; set; }

        ///<summary>
        /// The date the object was updated
        ///</summary>
        public DateTime LastModifiedOnDate { get; set; }
    }
}
