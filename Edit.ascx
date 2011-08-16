<%@ Control language="C#" Inherits="DotNetNuke.Modules.TaskManager.Edit" AutoEventWireup="false"  Codebehind="Edit.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>


<dnn:label ID="lblName" runat="server" Text="Name" HelpText="Enter the name of your task" />
<asp:TextBox ID="txtName" runat="server" />
<br />
<dnn:label ID="lblDescription" runat="server" Text="Description" HelpText="Enter the description for your task" />
<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="20" />
<br />

<dnn:label ID="lblAssignedUser" runat="server" Text="Assigned User" HelpText="Choose a user for the task" />
<asp:DropDownList ID="ddlAssignedUser" runat="server" />
<br />
<dnn:label ID="lblTargetCompletionDate" runat="server" Text="Targeted Completion Date" HelpText="When should the task be completed" />
<asp:TextBox ID="txtTargetCompletionDate" runat="server" />
<br />
<dnn:label ID="lblCompletionDate" runat="server" Text="Actual Completion Date" HelpText="When did the task get completed" />
<asp:TextBox ID="txtCompletionDate" runat="server" />

<br />

<asp:LinkButton ID="btnSubmit" Text="Save Task" runat="server" 
    onclick="btnSubmit_Click" />
&nbsp;
<asp:LinkButton ID="btnCancel" Text="Cancel" runat="server" 
    onclick="btnCancel_Click"/>