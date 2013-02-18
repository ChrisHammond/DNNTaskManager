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

Imports DotNetNuke
Imports DotNetNuke.Entities.Modules.Actions
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.UI.Utilities

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
Public Class View
    Inherits VBDnn7TmDal1ModuleBase
    Implements IActionable

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
            rptTaskList.DataSource = TaskController.GetTasks(ModuleId)
            rptTaskList.DataBind()
        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Registers the module actions required for interfacing with the portal framework
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property ModuleActions() As ModuleActionCollection Implements IActionable.ModuleActions
        Get
            Dim Actions As New ModuleActionCollection
            Actions.Add(GetNextActionID, Localization.GetString("EditModule", LocalResourceFile), Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
            Return Actions
        End Get
    End Property

    Protected Sub rptTaskListOnItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)

        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then

            Dim lnkEdit As LinkButton = e.Item.FindControl("lnkEdit")
            Dim lnkDelete As LinkButton = e.Item.FindControl("lnkDelete")
            Dim pnlAdminControls As Panel = e.Item.FindControl("pnlAdmin")
            Dim curTask As Task = e.Item.DataItem

            If IsEditable AndAlso Not lnkDelete Is Nothing AndAlso Not lnkEdit Is Nothing And Not pnlAdminControls Is Nothing Then
                pnlAdminControls.Visible = True
                lnkDelete.CommandArgument = lnkEdit.CommandArgument = curTask.TaskId.ToString()
                lnkDelete.Enabled = True
                lnkEdit.Enabled = True
                lnkDelete.Visible = True
                lnkEdit.Visible = True

                ClientAPI.AddButtonConfirm(lnkDelete, Localization.GetString("ConfirmDelete", LocalResourceFile))
            Else
                pnlAdminControls.Visible = False
            End If

        End If


    End Sub

    Protected Sub rptTaskListOnItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs)
        If e.CommandName = "Edit" Then
            'TODO: this doesn't work when popups are enabled. we need to make the buttons hyperlinks and bind during on item data bound
            Response.Redirect(EditUrl(String.Empty, String.Empty, "Edit", "tid=" + e.CommandArgument))
        End If
        If e.CommandName = "Delete" Then
            TaskController.DeleteTask(e.CommandArgument)
        End If
        Response.Redirect(DotNetNuke.Common.Globals.NavigateURL())
    End Sub
End Class