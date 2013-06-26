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
using DotNetNuke.Entities.Users;
using Christoc.Modules.DnnTaskManagerDal2.Components;
using DotNetNuke.Services.Exceptions;

namespace Christoc.Modules.DnnTaskManagerDal2
{
    /// -----------------------------------------------------------------------------
    /// <summary>   
    /// The Edit class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from DnnTaskManagerDal2ModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : DnnTaskManagerDal2ModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Implement your edit logic for your module
                if (!Page.IsPostBack)
                {
                    //get a list of users to assign the user to the Object
                    ddlAssignedUser.DataSource = UserController.GetUsers(PortalId);
                    ddlAssignedUser.DataTextField = "Username";
                    ddlAssignedUser.DataValueField = "UserId";
                    ddlAssignedUser.DataBind();

                    //check if we have an ID passed in via a querystring parameter, if so, load that Task to edit.
                    //TaskId is defined in the TaskModuleBase.cs file
                    if (TaskId > 0)
                    {
                        var tc = new TaskController();

                        var t = tc.GetTask(TaskId, ModuleId);
                        if (t != null)
                        {
                            txtName.Text = t.TaskName;
                            txtDescription.Text = t.TaskDescription;
                            txtTargetCompletionDate.Text = t.TargetCompletionDate.ToString();
                            txtCompletionDate.Text = t.CompletedOnDate.ToString();
                            ddlAssignedUser.Items.FindByValue(t.AssignedUserId.ToString()).Selected = true;
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
            var t = new Task();
            var tc = new TaskController();

            if (TaskId > 0)
            {
                t = tc.GetTask(TaskId, ModuleId);
                t.TaskName = txtName.Text.Trim();
                t.TaskDescription = txtDescription.Text.Trim();
                t.LastModifiedByUserId = UserId;
                t.LastModifiedOnDate = DateTime.Now;
                t.AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue);
            }
            else
            {
                t = new Task()
                {
                    AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue),
                    CreatedByUserId = UserId,
                    CreatedOnDate = DateTime.Now,
                    TaskName = txtName.Text.Trim(),
                    TaskDescription = txtDescription.Text.Trim(),

                };
            }

            t.LastModifiedOnDate = DateTime.Now;
            t.LastModifiedByUserId = UserId;
            t.ModuleId = ModuleId;

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


            if (t.TaskId > 0)
            {
                tc.UpdateTask(t);
            }
            else
            {
                tc.CreateTask(t);
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }
    }
}