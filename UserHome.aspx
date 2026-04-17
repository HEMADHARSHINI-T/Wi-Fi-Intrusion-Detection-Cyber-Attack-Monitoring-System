<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .main-container {
            padding: 30px;
        }

        .card {
            background-color: #e6e6e6;
            border-radius: 15px;
            padding: 20px;
            width: 80%;
            margin: auto;
            box-shadow: 0px 4px 10px rgba(0,0,0,0.3);
        }

        .card img {
            width: 100%;
            height: auto;
            border-radius: 10px;
        }

        .title {
            color: #4fc3f7;
            font-size: 26px;
            font-weight: bold;
            margin-bottom: 15px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="main-container">

        <div class="title">User Panel</div>

        <div class="card">
            <img src="images/2.jpg" alt="Cyber Image" />
        </div>

    </div>

</asp:Content>