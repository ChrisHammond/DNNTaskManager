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

using System.Collections.Generic;
using DotNetNuke.Data;

namespace Christoc.Modules.DnnTaskManagerDal2.Components
{
    class TaskController
    {
        public void CreateTask(Task t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Task>();
                rep.Insert(t);
            }
        }

        public void DeleteTask(int taskId, int moduleId)
        {
            var t = GetTask(taskId, moduleId);
            DeleteTask(t);
        }

        public void DeleteTask(Task t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Task>();
                rep.Delete(t);
            }
        }

        public IEnumerable<Task> GetTasks(int moduleId)
        {
            IEnumerable<Task> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Task>();
                t = rep.Get(moduleId);
            }
            return t;
        }

        public Task GetTask(int taskId, int moduleId)
        {
            Task t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Task>();
                t = rep.GetById(taskId, moduleId);
            }
            return t;
        }

        public void UpdateTask(Task t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Task>();
                rep.Update(t);
            }
        }

    }
}
