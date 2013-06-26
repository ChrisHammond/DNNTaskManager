<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Christoc.Modules.DnnTaskManagerDal1.Edit" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>

<fieldset>
    <div class="dnnFormItem">
        <dnn:label ID="lblName" runat="server" Text="Name" HelpText="Enter the name of your task" />
        <asp:TextBox ID="txtName" runat="server" />
    </div>

    <div class="dnnFormItem">
        <dnn:label ID="lblDescription" runat="server" Text="Description" HelpText="Enter the description for your task" />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="20" />
    </div>

    <div class="dnnFormItem">

        <dnn:label ID="lblAssignedUser" runat="server" Text="Assigned User" HelpText="Choose a user for the task" />
        <asp:DropDownList ID="ddlAssignedUser" runat="server" />
    </div>

    <div class="dnnFormItem">
        <dnn:label ID="lblTargetCompletionDate" runat="server" Text="Targeted Completion Date" HelpText="When should the task be completed" />
        <asp:TextBox ID="txtTargetCompletionDate" runat="server" />
    </div>

    <div class="dnnFormItem">
        <dnn:label ID="lblCompletionDate" runat="server" Text="Actual Completion Date" HelpText="When did the task get completed" />
        <asp:TextBox ID="txtCompletionDate" runat="server" />
    </div>

</fieldset>

<asp:LinkButton ID="btnSubmit" Text="Save Task" runat="server"
    OnClick="btnSubmit_Click" CssClass="dnnPrimaryAction" />
&nbsp;
<asp:LinkButton ID="btnCancel" Text="Cancel" runat="server"
    OnClick="btnCancel_Click" CssClass="dnnSecondaryAction" />