'//DotNetNuke - http://www.dotnetnuke.com
'// Copyright (c) 2013
'// by DotNetNuke Corporation
'//
'// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
'// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
'// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
'// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'//
'// The above copyright notice and this permission notice shall be included in all copies or substantial portions
'// of the Software.
'//
'// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
'// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
'// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
'// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
'// DEALINGS IN THE SOFTWARE.
Imports DotNetNuke.Modules.VBDnn7TmDal1.Data
Imports DotNetNuke.Common.Utilities

Public Class TaskController

    Public Shared Function GetTask(ByVal taskId As Integer) As Task
        Return CBO.FillObject(Of Task)(DataProvider.Instance().GetTask(taskId))
    End Function

    Public Shared Function GetTasks(ByVal taskId As Integer) As List(Of Task)
        Return CBO.FillCollection(Of Task)(DataProvider.Instance().GetTasks(taskId))
    End Function

    Public Shared Sub DeleteTask(ByVal taskId As Integer)
        DataProvider.Instance().DeleteTask(taskId)
    End Sub

    Public Shared Sub DeleteTasks(ByVal moduleId As Integer)
        DataProvider.Instance().DeleteTasks(moduleId)
    End Sub

    Public Shared Function SaveTask(ByVal t As Task, ByVal tabId As Integer) As Integer
        If t.TaskId < 1 Then
            t.TaskId = DataProvider.Instance().AddTask(t)
        Else
            DataProvider.Instance().UpdateTask(t)
        End If
        Return t.TaskId
    End Function


End Class
