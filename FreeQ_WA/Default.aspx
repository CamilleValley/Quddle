<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="FreeQ_WA._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Optimize your waiting lines</h2>
	<h3 class="spaceBAfter">Free and ready in a minute</h3>

    <div class="spaceBAfter">
    <a href="/queues/ShowWizard.aspx" class="bigButton">
        <div class="left"></div>
        <div class="center">Create a Queue</div>
        <div class="right"></div>
    </a>
    </div>

    <div class="spaceBBefore">
        <div id="ndhTHowItWorksBanner">
	        <div id="ndhTHowItWorksStep1Tag">Next?</div>
	        <div id="ndhTHowItWorksStep3Tag">Thanks!</div>
        </div>
    </div>

    <div class="fixedContent contentPart clearfix spaceBBefore dThreeColumns">
			<div class="dColumn">
				<div class="clearfix dTwoColumns ndhTHowItWorksDTwoColumns spaceDAfter">
					<p class="h4 ndhTHowItWorksBullet dColumn">1</p>
					<div class="dLastColumn">			
						<p class="h4">Create</p>
						<p class="h5">a queue</p>
					</div>
				</div>
			</div>
			<div class="dColumn">
				<div class="clearfix dTwoColumns ndhTHowItWorksDTwoColumns spaceDAfter">
					<p class="h4 ndhTHowItWorksBullet dColumn">2</p>
					<div class="dLastColumn">			
						<p class="h4">Manage</p>
						<p class="h5">the participants</p>
					</div>
				</div>
			</div>
			<div class="dLastColumn">
				<div class="clearfix dTwoColumns ndhTHowItWorksDTwoColumns spaceBAfter">
					<p class="h4 ndhTHowItWorksBullet dColumn">3</p>
					<div class="dLastColumn">			
						<p class="h4">Optimize</p>
						<p class="h5">the waiting time</p>
					</div>
				</div>
			</div>
		</div>
</asp:Content>
