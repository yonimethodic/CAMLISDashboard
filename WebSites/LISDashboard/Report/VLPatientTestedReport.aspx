<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="VLPatientTestedReport.aspx.cs" Inherits="CHAI.LISDashboard.Modules.Report.Views.VLPatientTestedReport" %>
<%@ MasterType TypeName="CHAI.LISDashboard.Modules.Shell.BaseMaster" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <script src="../js/libs/jquery-2.0.2.min.js"></script>
    <script type="text/javascript">
     $(document).ready(function () {
         $('#SrchNotDateFromPicker').datetimepicker({
            format: 'DD/MM/YYYY'
        });
         $('#SrchNotDateToPicker').datetimepicker({
            format: 'DD/MM/YYYY'
        });
                   
    });
</script>

    <style type="text/css">
      
      .clear {
  clear: both; /* At the very least, you must have this. All extra declarations are for fine-tuning */
  height: 0;
font-size: 0;
overflow: hidden;
margin: 0;
padding: 0;
width: 0;
line-height: 0;
}

.container {
    overflow:hidden;
	text-align: left;
	margin: 0px auto;
	padding: 0px;
	border:0;
	width: 1450px;
}
.item-1 {
	float: left;
	width: 700px;
    margin: 0;
}
.item-2 { 
	margin: 0;
	float: right;
	width: 700px;
	
}
.item-3 { 
	margin: 0;
	float:left;
	width: 250px;
 height:35px
	
}
      	
        #DefaultContent_CRVLPatientTested__UI {
            overflow: hidden;
            position: relative;
            width: 100% !important;
            height: 932px;            
        }

        </style>

    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>

	 <section id="widget-grid" class="">
	<div class="row">
		<!-- NEW WIDGET START -->
		<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
			<!-- Widget ID (each widget will need unique ID)-->   
               <div class="jarviswidget jarviswidget-color-blue" id="wid-id-0" data-widget-editbutton="false">
                    <header>
                        <span class="widget-icon"><i class="fa fa-table"></i></span>                        
                        <h2>HIV Viral Load Tested Summary</h2>
                    </header>
                   <div>
                        <div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->				
					   </div>
                        <div >
                            <table cellpadding="0" width="80%">
                    <tr>
                         <td style="width: 150px; padding: 2px" align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Laboratory"></asp:Label></td>
                                                            <td class="editDropDown" style="width: 200px; padding: 2px" align="left">
                                                                <asp:DropDownList ID="ddlLab" runat="server" AppendDataBoundItems="True" DataTextField="Description" DataValueField="LabCode" Height="26px" Width="100%" AutoPostBack="false">
                                                                    <asp:ListItem Value="">All</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding: 2px">
                            <asp:RadioButtonList ID="rdbDate" runat="server" AutoPostBack="False" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Collection" Selected="True">Sample Collection Date</asp:ListItem>
                                <asp:ListItem Value="Received">Sample Received Date</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>                         
                        <td style="width: 100px;">Date From:</td>
                        <td  style="width: 150px; padding: 2px" align="right" >                                            
                            <div class="input-group date" id='SrchNotDateFromPicker'>
					            <asp:TextBox ID="txtSrchNotDate" CssClass="form-control" data-dateformat="dd/mm/yy" runat="server" placeholder="Date To"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtSrchNotDate" Display="Dynamic" ErrorMessage="Date from is invalid" 
                                ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                ValidationGroup="1">*</asp:RegularExpressionValidator>
                            </div>                          
                        </td>
                        <td style="width: 100px;">Date To:</td>
                        <td  style="width: 150px; padding: 2px" align="right">
                           <div class="input-group date" id='SrchNotDateToPicker'>                               
					           <asp:TextBox ID="txtSrchNotDateTo" CssClass="form-control" data-dateformat="dd/mm/yy" runat="server" placeholder="Date To" ></asp:TextBox>
                               <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="txtSrchNotDateTo" Display="Dynamic" ErrorMessage="Date to is invalid" 
                                ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                ValidationGroup="1">*</asp:RegularExpressionValidator>
                          </div>
                          
                        </td>
                   
                    </tr>
                    <tr>                                    
                         <td  style=" padding: 2px" align="left"  >
                            <asp:Label ID="Label2" runat="server" Text="Report Showing:" ></asp:Label>
                             </td>
                         <td style=" padding: 2px" align="left">
                            <asp:DropDownList ID="ddlReportShowing" runat="server" AppendDataBoundItems="True" AutoPostBack="false" Height="26px">
                                <asp:ListItem Value="Age">Report Showing By Age</asp:ListItem>
                                <asp:ListItem Value="Gender">Report Showing By Gender</asp:ListItem>
                                <asp:ListItem Value="Reason">Report Showing By Reason For Test</asp:ListItem>
                            </asp:DropDownList>                             
                        </td> 
                         <td  style=" padding: 2px" align="left" >
                             <asp:Label ID="Label4" runat="server" Text="Copies/mL" ></asp:Label>
                         </td>
                         <td style=" padding: 2px" align="left">
                                 <asp:DropDownList ID="ddlCopiesml" runat="server" AppendDataBoundItems="True" AutoPostBack="false" width="280px" Height="26px">
                                <asp:ListItem Value="All">Show All Including Error/Invalid/No Result</asp:ListItem>
                                <asp:ListItem Value="ValidOutcome">Valid Outcome</asp:ListItem>
                                <asp:ListItem Value="<=1000"><=1000 Copies/mL</asp:ListItem>
                                <asp:ListItem Value=">1000">>1000 Copies/mL</asp:ListItem>
                            </asp:DropDownList>                               
                        </td>  
                    </tr>
                    <tr>                                    
                         <td  style=" padding: 2px" align="left"  >
                            <asp:Label ID="Label5" runat="server" Text="View Option:" ></asp:Label></td>
                         <td style=" padding: 2px" align="left">
                            <asp:DropDownList ID="ddlViewOption" runat="server" AppendDataBoundItems="True" AutoPostBack="false" width="150px" Height="26px">
                                <asp:ListItem Value="StateRegion">State/Region</asp:ListItem>                                
                                <asp:ListItem Value="FacilityType">Facility Type</asp:ListItem>                                                              
                            </asp:DropDownList>
                        </td> 
                         <td  style=" padding: 2px" align="left" colspan="2">                                                            
                        </td>  
                    </tr>
                </table>  

                       </div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                   <table cellpadding="0" >
                                       <tr>
                                           <td>
                                                 <asp:Label ID="Label1" runat="server" CssClass="label" Text="State/Region"></asp:Label>
                       
                                                <asp:CheckBox ID="chkAllRegion" runat="server" Text="Select All" oncheckedchanged="chkAllRegion_OnCheckedChanged" AutoPostBack="true" style="text-align: left" Checked="true" />
                                            </td>  
                        
                                           <td  style=" padding: 2px" align="left" >
                                            <asp:RadioButtonList ID="rdbFacilityType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbFacilityType_SelectedIndexChanged">
                                                <asp:ListItem Value="Public">Public</asp:ListItem>
                                                <asp:ListItem Value="Private">Private</asp:ListItem>
                                                <asp:ListItem Value="All">Select All</asp:ListItem>
                                            </asp:RadioButtonList>
                            
                            </td> 
                                                                              
                                       </tr>
                                       <tr>                            
                                             <td  style=" padding: 2px" align="left" >                       
                                                 <div style="BORDER: thin solid; OVERFLOW: auto; WIDTH: 200px; HEIGHT: 100px"> 
                                                    <asp:CheckBoxList ID="ddlProvince" runat="server" AutoPostBack="true" DataTextField="ProvinceName" DataValueField="Id" CssClass = "listbox"
                                                        OnSelectedIndexChanged = "ddlProvince_OnSelectedIndexChanged">
                                                    </asp:CheckBoxList>
                                                 </div>
                                             </td>
                                            <td  style=" padding: 2px" align="left" >
                                            <div style="BORDER: thin solid; OVERFLOW: auto; WIDTH: 200px; HEIGHT: 100px"> 
                                            <asp:CheckBoxList ID="ddlFacilityType" runat="server"    AppendDataBoundItems="False" DataTextField="FacilityTypeName" 
                                            DataValueField="Id">
                                            </asp:CheckBoxList>
                                            </div>                              
                                           </td>                            
                                      </tr>
                                   </table>
                                        </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chkAllRegion" EventName="CheckedChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlProvince" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>                
                        </div>
                        <div>
                            <table cellpadding="0" width="100%">
                                <tr style="float: right">
                                    <td>
                                        <%--<asp:UpdateProgress ID="updatePro" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                            <ProgressTemplate>
                                                <asp:Image ImageUrl="~/img/ajax-loader2.gif" runat="server" ID="waitsymbol" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>--%>
                                    </td>
                                    <td style="padding-left: 10px; padding: 5px" valign="middle" align="center">
                                        <asp:Button ID="btnFilter" runat="server" 
                                            CssClass="btn btn-primary" OnClick="btnFilter_Click" 
                                            Text="View Report" ValidationGroup="1"  />
                                    </td>
                                </tr>                                
                            </table>
                        </div>
                        <%--<div class="row">
		                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                                
		                    </article>
                        </div>--%>
					<!-- end widget content -->
				
				</div>
				<!-- end widget div -->
				
			    
        </article>
		<!-- WIDGET END -->

	</div>
    </section>   
    <cr:crystalreportviewer id="CRVLPatientTested" runat="server" autodatabind="true" visible="true" HasRefreshButton="false" />

    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

