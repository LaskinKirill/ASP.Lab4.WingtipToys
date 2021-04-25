<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCreate.aspx.cs" Inherits="WingtipToys.ProductCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add new product</h1>
    <div runat="server" ID="CreateProductForm">
        <asp:Label ID="LabelName" runat="server" AssociatedControlID="Name" Text="Name:"></asp:Label>
        <br />
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NameValidator" runat="server" ControlToValidate="Name" ErrorMessage="Product name is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="PriceLabel" runat="server" AssociatedControlID="PriceInput" Text="Price:"></asp:Label>
        <br />
        <asp:TextBox ID="PriceInput" runat="server"></asp:TextBox>
        <asp:RangeValidator Type="Currency" ID="PriceValidator" runat="server" ControlToValidate="PriceInput" ErrorMessage="Price should be grater then zero. Maximum price is 600$" MaximumValue="600,00" MinimumValue="0,10" Display="Dynamic"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="PriceRequiredValidator" runat="server" ControlToValidate="PriceInput" EnableTheming="True" ErrorMessage="Price is required" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="CategoryLabel" runat="server" AssociatedControlID="CategoryList" Text="Category:"></asp:Label>
        <asp:DropDownList ID="CategoryList" runat="server" DataTextField="CategoryName" DataValueField="CategoryID" ItemType="WingtipToys.Data.Models.Category" SelectMethod="GetCategories"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="CategoryRequiredValidator" runat="server" ControlToValidate="CategoryList" ErrorMessage="Category is required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="DescriptionLabel" runat="server" AssociatedControlID="Description" Text="Description:"></asp:Label>
        <br />
        <textarea ID="Description" name="S1" runat="server"></textarea>
        <asp:RegularExpressionValidator ID="DescriptionLengthValidator" runat="server" ControlToValidate="Description" ErrorMessage="Description should be maximum 500 symbols long" ValidationExpression="^.{0,500}$" Display="Dynamic"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="WordsCountValidator" runat="server" ErrorMessage="Description should contain at least 3 words" ValidationExpression="^\s*\S+(?:\s+\S+){2,}\s*$" Display="Dynamic" ControlToValidate="Description"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="ImageUrlLabel" runat="server" AssociatedControlID="ImageUrlInput" Text="Product image URL:"></asp:Label>
        <br />
        <asp:TextBox ID="ImageUrlInput" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="UrlValidator" runat="server" ControlToValidate="ImageUrlInput" ErrorMessage="Image should be a valid URL" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" Display="Dynamic"></asp:RegularExpressionValidator>
        <asp:CustomValidator ID="ImageExistsValidator" runat="server" ControlToValidate="ImageUrlInput" ErrorMessage="Url should be an existing image" OnServerValidate="ValidationImageExistence" Display="Dynamic"></asp:CustomValidator>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Create product" OnClick="Button1_Click" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div runat="server" ID="SuccessBlock" Visible="False">
        <h2>Thank you! Your product <b><asp:Literal ID="MesageProductName" runat="server"></asp:Literal></b> (number: <b><asp:Literal ID="MessageProductID" runat="server"></asp:Literal></b>) was successfully added to our store. You could <a href="~/ProductList" runat="server">check catalog</a></h2>
    </div>
</asp:Content>
