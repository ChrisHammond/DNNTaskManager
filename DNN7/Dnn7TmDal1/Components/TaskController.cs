﻿/*
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

using System.Collections.Generic;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Modules.Dnn7TmDal1.Data;


namespace DotNetNuke.Modules.Dnn7TmDal1.Components
{
    public class TaskController
    {
        public static Task GetTask(int taskId)
        {
            return CBO.FillObject<Task>(DataProvider.Instance().GetTask(taskId));
        }

        public static List<Task> GetTasks(int moduleId)
        {
            return CBO.FillCollection<Task>(DataProvider.Instance().GetTasks(moduleId));

        }

        public static void DeleteTask(int taskId)
        {
            DataProvider.Instance().DeleteTask(taskId);
        }

        public static void DeleteTasks(int moduleId)
        {
            DataProvider.Instance().DeleteTasks(moduleId);
        }

        public static int SaveTask(Task t, int tabId)
        {
            if (t.TaskId < 1)
            {
                t.TaskId = DataProvider.Instance().AddTask(t);
            }
            else
            {
                DataProvider.Instance().UpdateTask(t);
            }
            return t.TaskId;
        }
    }
}