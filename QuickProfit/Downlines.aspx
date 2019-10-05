<%@ Page Title="" Language="C#" MasterPageFile="~/UserAdmin.Master" Async="true" AutoEventWireup="true" CodeBehind="Downlines.aspx.cs" Inherits="QuickProfit.Downlines" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="box">
            <div class="box box-primary">
                <asp:GridView ID="UsersList" CssClass="table table-striped" BorderWidth="0px" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="users_PageIndexChanging" AllowPaging="true" PageSize="20">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <%#Eval("Id")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("Name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Primary PhoneNo">
                            <ItemTemplate>
                                <%#Eval("PrimaryPhoneNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Primary EmailId">
                            <ItemTemplate>
                                <%#Eval("PrimaryEmailId")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Referal Id">
                            <ItemTemplate>
                                <%#Eval("ReferalId")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
