<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="Lab_25_ASP_Website.HelloWorld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>hello World</h1>
       
       <ul>
            <li>One </li>
           <li>Two</li>  
       </ul>
    <asp:Label ID="Label1" runat="server" Text="Label">This is a Label</asp:Label>
    <br/>
    <asp:TextBox ID="TextBox1" runat="server">This is a textbox</asp:TextBox>
    <br/>
    <asp:ListBox ID="ListBox1" runat="server"> </asp:ListBox>
    <br/>
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <br/>
    <asp:Button ID="Button1" runat="server" Text="ASP Submit Button" OnClick="Button1_Click" />
    <br/>
    <form method="get" action="processdata.cs"> 
        
        First Name <input type="text" placeholder="type here" name="First Name"/>#
                    <br />
                 <button type =" ">

    </form>

</asp:Content>
