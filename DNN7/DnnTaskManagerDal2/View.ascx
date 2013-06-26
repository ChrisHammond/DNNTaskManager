<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.DnnTaskManagerDal2.View" %>
<asp:Repeater ID="rptTaskList" runat="server" OnItemDataBound="rptTaskListOnItemDataBound" OnItemCommand="rptTaskListOnItemCommand">
    <HeaderTemplate>
        <ul class="tm_tl">
    </HeaderTemplate>

    <ItemTemplate>
        <li class="tm_t">
            <h3>
                <asp:Label ID="lblTaskName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TaskName").ToString() %>' />
            </h3>
            <asp:Label ID="lblTaskDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TaskDescription").ToString() %>' CssClass="tm_td" />

            <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
                <asp:HyperLink ID="lnkEdit" runat="server" ResourceKey="EditTask.Text" Visible="false" Enabled="false" />
                <asp:LinkButton ID="lnkDelete" runat="server" ResourceKey="DeleteTask.Text" Visible="false" Enabled="false" CommandName="Delete" />
            </asp:Panel>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
