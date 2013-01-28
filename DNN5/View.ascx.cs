/*
' Copyright (c) 2010  DotNetNuke Corporation
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.UI.WebControls;
using DotNetNuke.Modules.TaskManager.Components;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;
using DotNetNuke.UI.Utilities;


namespace DotNetNuke.Modules.TaskManager
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The ViewTaskManager class displays the content
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : TaskManagerModuleBase, IActionable
    {

        #region Event Handlers

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Page_Load runs when the control is loaded
        /// </summary>
        /// -----------------------------------------------------------------------------
        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                rptTaskList.DataSource = TaskController.GetTasks(ModuleId);
                rptTaskList.DataBind();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        protected void rptTaskListOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var lnkEdit = e.Item.FindControl("lnkEdit") as LinkButton;
                var lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;

                var pnlAdminControls = e.Item.FindControl("pnlAdmin") as Panel;

                var curTask = (Task)e.Item.DataItem;

                if (IsEditable && lnkDelete!=null && lnkEdit != null && pnlAdminControls != null)
                {
                    pnlAdminControls.Visible = true;
                    lnkDelete.CommandArgument = lnkEdit.CommandArgument = curTask.TaskId.ToString();
                    lnkDelete.Enabled = lnkDelete.Visible=lnkEdit.Enabled = lnkEdit.Visible = true;

                    ClientAPI.AddButtonConfirm(lnkDelete,Localization.GetString("ConfirmDelete",LocalResourceFile));


                }
                else
                {
                    pnlAdminControls.Visible = false;
                }
            }
        }


        public void rptTaskListOnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect(EditUrl(string.Empty, string.Empty, "Edit", "tid=" + e.CommandArgument));
            }

            if (e.CommandName == "Delete")
            {
                TaskController.DeleteTask(Convert.ToInt32(e.CommandArgument));
            }

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }


        #endregion

        #region Optional Interfaces

        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString("EditModule", this.LocalResourceFile), "", "", "", EditUrl(), false, SecurityAccessLevel.Edit, true, false);
                return Actions;
            }
        }

        #endregion

    }

}
