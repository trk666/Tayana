<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="tayanaBackend.Backend.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-md-4">
                    <div class="card card-user">
                        <div class="card-image">
                            <img src="https://ununsplash.imgix.net/photo-1431578500526-4d9613015464?fit=crop&amp;fm=jpg&amp;h=300&amp;q=75&amp;w=400" alt="...">
                        </div>
                        <div class="card-body">
                            <div class="author">
                                <asp:Image ID="Photo" runat="server" class="avatar border-gray"/>
                                <h5 class="title"><asp:Label ID="Name" runat="server" Text="Label"></asp:Label></h5>
                                Welcome!
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
