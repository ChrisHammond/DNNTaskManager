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

Imports DotNetNuke.Entities.Modules.Actions
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports DotNetNuke.Entities.Users

''' <summary>
''' The View class displays the content
''' 
''' Typically your view control would be used to display content or functionality in your module.
''' 
''' View may be the only control you have in your project depending on the complexity of your module
''' 
''' Because the control inherits from VBDnn7TmDal1ModuleBase you have access to any custom properties
''' defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
''' 
''' </summary>
Public Class Edit
    Inherits VBDnn7TmDal1ModuleBase


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Page_Load runs when the control is loaded
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                ddlAssignedUser.DataSource = UserController.GetUsers(PortalId)
                ddlAssignedUser.DataTextField = "Username"
                ddlAssignedUser.DataValueField = "UserId"
                ddlAssignedUser.DataBind()

                If TaskId > 0 Then
                    Dim task As Task = TaskController.GetTask(TaskId)
                    If Not (task Is Nothing) Then
                        txtName.Text = task.TaskName
                        txtDescription.Text = task.TaskDescription
                        txtTargetCompletionDate.Text = task.TargetCompletionDate.ToString()
                        txtCompletionDate.Text = task.CompletedOnDate.ToString()
                        ddlAssignedUser.Items.FindByValue(task.AssignedUserId.ToString()).Selected = True
                    End If
                End If
            End If

        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try

    End Sub


    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim t As Task
        If TaskId > 0 Then
            t = TaskController.GetTask(TaskId)
            t.TaskName = txtName.Text.Trim()
            t.TaskDescription = txtDescription.Text.Trim()
            t.LastModifiedByUserId = UserId
            t.LastModifiedOnDate = DateTime.Now
            t.AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue)
        Else
            t = New Task()
            t.AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue)
            t.CreatedByUserId = UserId
            t.CreatedOnDate = DateTime.Now
            t.TaskName = txtName.Text.Trim()
            t.TaskDescription = txtDescription.Text.Trim()
            t.ModuleId = ModuleId
        End If

        'check for dates
        Dim outputDate As DateTime
        If DateTime.TryParse(txtCompletionDate.Text.Trim(), outputDate) Then
            t.CompletedOnDate = outputDate
        End If
        If DateTime.TryParse(txtTargetCompletionDate.Text.Trim(), outputDate) Then
            t.TargetCompletionDate = outputDate
        End If

        TaskController.SaveTask(t, TabId)
        Response.Redirect(DotNetNuke.Common.Globals.NavigateURL())
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect(DotNetNuke.Common.Globals.NavigateURL())
    End Sub
End Class