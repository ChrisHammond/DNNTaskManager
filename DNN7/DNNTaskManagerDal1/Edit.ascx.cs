﻿/*
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
using DotNetNuke.Entities.Users;
using Christoc.Modules.DnnTaskManagerDal1.Components;
using DotNetNuke.Services.Exceptions;

namespace Christoc.Modules.DnnTaskManagerDal1
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The EditDNNTaskManagerDal1 class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from DnnTaskManagerDal1ModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : DnnTaskManagerDal1ModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Implement your edit logic for your module
                if (!Page.IsPostBack)
                {
                    ddlAssignedUser.DataSource = UserController.GetUsers(PortalId);
                    ddlAssignedUser.DataTextField = "Username";
                    ddlAssignedUser.DataValueField = "UserId";
                    ddlAssignedUser.DataBind();

                    if (TaskId > 0)
                    {
                        var task = TaskController.GetTask(TaskId);
                        if (task != null)
                        {
                            txtName.Text = task.TaskName;
                            txtDescription.Text = task.TaskDescription;
                            txtTargetCompletionDate.Text = task.TargetCompletionDate.ToString();
                            txtCompletionDate.Text = task.CompletedOnDate.ToString();
                            ddlAssignedUser.Items.FindByValue(task.AssignedUserId.ToString()).Selected = true;
                        }
                    }
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Task t;

            if (TaskId > 0)
            {
                t = TaskController.GetTask(TaskId);
                t.TaskName = txtName.Text.Trim();
                t.TaskDescription = txtDescription.Text.Trim();
                t.LastModifiedByUserId = UserId;
                t.LastModifiedOnDate = DateTime.Now;
                t.AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue);
            }
            else
            {
                t = new Task
                {
                    AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue),
                    //CompletedOnDate = Convert.ToDateTime(txtCompletionDate.Text.Trim()),
                    CreatedByUserId = UserId,
                    CreatedOnDate = DateTime.Now,
                    //TargetCompletionDate = Convert.ToDateTime(txtTargetCompletionDate.Text.Trim()),
                    TaskName = txtName.Text.Trim(),
                    TaskDescription = txtDescription.Text.Trim(),
                    ModuleId = ModuleId
                };

            }

            //check for dates
            DateTime outputDate;
            if (DateTime.TryParse(txtCompletionDate.Text.Trim(), out outputDate))
            {
                t.CompletedOnDate = outputDate;
            }
            if (DateTime.TryParse(txtTargetCompletionDate.Text.Trim(), out outputDate))
            {
                t.TargetCompletionDate = outputDate;
            }
            TaskController.SaveTask(t, TabId);
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

    }

}