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

Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports System.Globalization

Public Class Task
    Implements IHydratable

    Private _taskId As Integer
    Private _taskName As String
    Private _taskDescription As String
    Private _assignedUserId As Integer
    Private _moduleId As Integer
    Private _targetCompletionDate As DateTime
    Private _completedOnDate As DateTime?

    Private _createdByUserId As Integer

    Private _lastModifiedByUserId As Integer
    Private _createdOnDate As DateTime
    Private _lastModifiedOnDate As DateTime

    Private _portalId As Integer


    Public Property TaskId() As Integer
        Get
            Return _taskId
        End Get
        Set(ByVal value As Integer)
            _taskId = value
        End Set
    End Property


    Public Property TaskName() As String
        Get
            Return _taskName
        End Get
        Set(ByVal value As String)
            _taskName = value
        End Set
    End Property

    Public Property TaskDescription() As String
        Get
            Return _taskDescription
        End Get
        Set(ByVal value As String)
            _taskDescription = value
        End Set
    End Property

    Public Overloads Property AssignedUserId() As Integer
        Get
            Return _assignedUserId
        End Get
        Set(ByVal value As Integer)
            _assignedUserId = value
        End Set
    End Property

    Public Overloads Property ModuleId() As Integer
        Get
            Return _moduleId
        End Get
        Set(ByVal value As Integer)
            _moduleId = value
        End Set
    End Property

    Public Overloads Property TargetCompletionDate() As DateTime
        Get
            Return _targetCompletionDate
        End Get
        Set(ByVal value As DateTime)
            _targetCompletionDate = value
        End Set
    End Property

    Public Overloads Property CompletedOnDate() As DateTime
        Get
            Return _completedOnDate
        End Get
        Set(ByVal value As DateTime)
            _completedOnDate = value
        End Set
    End Property


    Public Overloads Property CreatedByUserId() As Integer
        Get
            Return _createdByUserId
        End Get
        Set(ByVal value As Integer)
            _createdByUserId = value
        End Set
    End Property

    Public Overloads Property LastModifiedByUserId() As Integer
        Get
            Return _lastModifiedByUserId
        End Get
        Set(ByVal value As Integer)
            _lastModifiedByUserId = value
        End Set
    End Property

    Public Overloads Property CreatedOnDate() As DateTime
        Get
            Return _createdOnDate
        End Get
        Set(ByVal value As DateTime)
            _createdOnDate = value
        End Set
    End Property
    Public Overloads Property LastModifiedOnDate() As DateTime
        Get
            Return _lastModifiedOnDate
        End Get
        Set(ByVal value As DateTime)
            _lastModifiedOnDate = value
        End Set
    End Property

    Public Property PortalId() As Integer
        Get
            Return _portalId
        End Get
        Set(ByVal value As Integer)
            _portalId = value
        End Set
    End Property

    Public Overloads ReadOnly Property CreatedByUser() As String
        Get
            If CreatedByUserId > 0 Then
                Return Null.NullString
            End If
            Return Entities.Users.UserController.GetUserById(PortalId, CreatedByUserId).Username
        End Get
    End Property

    Public Overloads ReadOnly Property LastUpdatedByUser() As String
        Get
            If CreatedByUserId > 0 Then
                Return Null.NullString
            End If
            Return Entities.Users.UserController.GetUserById(PortalId, CreatedByUserId).Username
        End Get
    End Property



    Public Sub IHydratable_Fill(ByVal dr As IDataReader) Implements IHydratable.Fill
        If Not Null.IsNull(dr) Then
            TaskId = Null.SetNullInteger(dr("TaskId"))
            ModuleId = Null.SetNullInteger(dr("ModuleId"))
            TaskName = Null.SetNullString(dr("TaskName"))
            TaskDescription = Null.SetNullString(dr("TaskDescription"))
            AssignedUserId = Null.SetNullInteger(dr("AssignedUserId"))
            TargetCompletionDate = Null.SetNullDateTime(dr("TargetCompletionDate"))
            CompletedOnDate = Null.SetNullDateTime(dr("CompletedOnDate"))
            CreatedByUserId = Null.SetNullInteger(dr("CreatedByUserId"))
            LastModifiedByUserId = Null.SetNullInteger(dr("LastModifiedByUserId"))
            CreatedOnDate = Null.SetNullDateTime(dr("CreatedOnDate"))
            LastModifiedOnDate = Null.SetNullDateTime(dr("LastModifiedOnDate"))

        End If
    End Sub


    Public Property KeyID() As Integer Implements IHydratable.KeyID
        Get
            Return TaskId
        End Get
        Set(ByVal value As Integer)
            TaskId = value
        End Set
    End Property



End Class
