<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowWizard.aspx.cs" Inherits="FreeQ_WA.Queues.ShowWizard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function MaxLength(sender, args) {
            args.IsValid = (args.Value.length <= 512);
        }
    </script>

    <h2><div runat="server" id="editQueue">Create a Queue</div></h2>
    
    <asp:Wizard
        id="WizardQueue"
        OnFinishButtonClick="WizardQueue_FinishButtonClick"
        DisplaySideBar="false"
        Runat="server" 
        Width="100%" ActiveStepIndex="0">

        <WizardSteps>
        <asp:WizardStep ID="WizardStep1" Title="General">
            <div class="illustrated clearfix">
                <div class="l calendar"></div>
                <div class="formPanel r">
                    <div class="spaceCBefore">
                        <p class="spaceDAfter"><label for="title" class="spaceDAfter h3">Name of the Queue</label></p>
                        <p><asp:TextBox ID="title" runat="server" MaxLength="64" CssClass="inputText"></asp:TextBox></p>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_title" 
                                runat="server" 
                                CssClass="error"
                                EnableClientScript="true" 
                                ControlToValidate="title"
                                ErrorMessage="Please specify this field." >
                            </asp:RequiredFieldValidator>
                        </p>
                    </div>
                    <div class="spaceCBefore">
                        <p class="spaceDAfter"><label for="description" class="h3">Description</label><span class="grey"> (facultatif)</span></p>
                        <p><asp:TextBox ID="description" runat="server" MaxLength="512" CssClass="inputText" Rows="7" TextMode="MultiLine" Width="528px"></asp:TextBox></p>
                        <p>
                        <asp:CustomValidator id="CustomValidator_description" 
                            runat="server"
                            CssClass="error"
                            ControlToValidate = "description"
                            ErrorMessage = "La valeur entrée dépasse la longueur maximale de 512 charactères."
                            ClientValidationFunction="MaxLength" 
                            Display="Dynamic" >
                        </asp:CustomValidator>
                        </p>
                    </div>
                    <div>
                        <p class="spaceDAfter"><label for="initiatorAlias" class="spaceDAfter h3">Your name or the name of your company</label></p>
                        <p><asp:TextBox ID="initiatorAlias" runat="server" MaxLength="64" CssClass="inputText"></asp:TextBox></p>
                        <p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_initiatorAlias" 
                                runat="server" 
                                CssClass="error"
                                EnableClientScript="true" 
                                ControlToValidate="initiatorAlias"
                                ErrorMessage="Please specify this field" >
                            </asp:RequiredFieldValidator>
                        </p>
                    </div>
                </div>
            </div>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep2" Title="Details">
            <div class="illustrated clearfix">
                <div class="formPanel r">
                    <div class="spaceCBefore spaceDAfter">
                        <p class="spaceDAfter"><label class="h3">Address</label><span class="grey"> (optional)</span></p>
                        <p><asp:TextBox ID="location" runat="server" MaxLength="64" CssClass="inputText" placeholder="Give the address."></asp:TextBox></p>
                    </div>
                    <div class="spaceCBefore">
                        <p class="spaceDAfter"><label class="spaceDAfter h3">Reset automatically the counter:</label></p>
                        <p><asp:CheckBox ID="minuit" runat="server" Text=" at midnight" /></p>
                        <p class="spaceDAfter"><asp:CheckBox ID="ticketsmaxopt" runat="server" Text=" after X tickets" /><asp:TextBox ID="ticketsmax" runat="server" MaxLength="64" CssClass="inputText"></asp:TextBox></p>
                        <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator_ticketsmax" 
                            runat="server" 
                            CssClass="error"
                            ControlToValidate="ticketsmax"
                            ErrorMessage="Please Enter Only Numbers" 
                            ValidationExpression="^\d+$" >
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="spaceDAfter">
                        <p class="spaceDAfter"><label class="spaceDAfter h3">Disable automatically the Queue:</label></p>
                        <p class="spaceDAfter">
                            <asp:CheckBox ID="desactiverqueue" runat="server" Text=" Yes, disable the Queue at the following date" /><br />
                            <asp:TextBox runat="server" ID="desactivateDate" />
                            <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" /><br />
                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="desactivateDate" 
                                PopupButtonID="Image1" />
                        </p>
                    </div>
                    <div class="spaceCBefore">
                        <p class="spaceDAfter"><label class="spaceDAfter h3">Estimated processing time (in minutes) per ticket:</label></p>
                        <p class="spaceDAfter"><asp:TextBox ID="handlingTime" runat="server" MaxLength="64" CssClass="inputText"></asp:TextBox></p>
                        <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator_handlingTime" 
                            runat="server" 
                            CssClass="error"
                            ControlToValidate="handlingTime"
                            ErrorMessage="Please Enter Only Numbers" 
                            ValidationExpression="^\d+$" >
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
            </div>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep3" Title="Confirm">
            <div class="clearfix">
                <div class="formPanel r">
                    <div class="spaceCBefore">
                        <p class="spaceDAfter">You are all set...</p>
                        <p class="spaceDAfter">To finalize the creation of your Queue, press "Finish"</p>
                    </div>
                </div>
            </div>
        </asp:WizardStep>
        </WizardSteps>
        <StartNavigationTemplate>
            <asp:Button ID="btnNext" runat="server" CssClass="BoutonStandard" CommandName="MoveNext" Text="Next"  />
        </StartNavigationTemplate>
        <StepNavigationTemplate>
            <asp:Button ID="btnPrevious" runat="server" CssClass="BoutonStandard" Text="Previous" CommandName="MovePrevious"  />
            <asp:Button ID="btnNext" runat="server" CssClass="BoutonStandard" CommandName="MoveNext" Text="Next" />
        </StepNavigationTemplate>
        <FinishNavigationTemplate>
            <asp:Button ID="btnPrevious" runat="server" CssClass="BoutonStandard" CommandName="MovePrevious" Text="Previous"  />
            <asp:Button ID="btnFinish" runat="server" CssClass="BoutonStandard" CommandName="MoveComplete"  Text="Finish" />
        </FinishNavigationTemplate>
        <HeaderTemplate>
            <ul id="wizHeader">
                <asp:Repeater ID="SideBarList" runat="server">
                    <ItemTemplate>
                        <li><a class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>">
                            <%# Eval("Name")%></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </HeaderTemplate>
    </asp:Wizard>

</asp:Content>
