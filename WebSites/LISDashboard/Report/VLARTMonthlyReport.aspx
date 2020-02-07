<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="VLARTMonthlyReport.aspx.cs" Inherits="CHAI.LISDashboard.Modules.Report.Views.VLARTMonthlyReport" %>
<%@ MasterType TypeName="CHAI.LISDashboard.Modules.Shell.BaseMaster" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <script src="../js/libs/jquery-2.0.2.min.js"></script>
    <script type="text/javascript">
     $(document).ready(function () {
                   
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

    <script>
        EnableReportShowingOption(true);
        function EnableReportShowingOption(val) {
            //document.getElementById('#<%=ddlReportShowing.ClientID %>').disabled = val;
            $('#<%=ddlReportShowing.ClientID %>').attr('disabled', val);
            if (val)
                $('#<%=ddlReportShowing.ClientID %>').css("color", "#A9A9A9");                
            else
                $('#<%=ddlReportShowing.ClientID %>').css("color", "#000");
            return false;
        }
    </script>

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
                        <h2>HIV Viral Load ART Monthly</h2>
                    </header>
                   <div>
                        <div class="jarviswidget-editbox">
                        <!-- This area used as dropdown edit box -->
					   </div>
                        <div >
                            <table style="width: 65%">
                            <tr>
                                <td style="width: 15%; padding: 3px">
                                    <asp:Label ID="Label3" runat="server" CssClass="label" Text="Laboratory"></asp:Label>
                                </td>
                                <td class="editDropDown" style="width: 25%; padding: 3px">
                                    <asp:DropDownList ID="ddlLab" runat="server" AppendDataBoundItems="True" DataTextField="Description" DataValueField="LabCode" Height="26px" Width="100%" AutoPostBack="false">
                                        <asp:ListItem Value="">All</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                                
                            </tr>
                            <tr>                         
                                <td style="width: 15%; padding: 3px">
                                    <asp:Label ID="Label4" runat="server" CssClass="label" Text="Year / Month"></asp:Label>
                                </td>
                                <td style="width: 15%; padding: 3px">
                                    <div style="float: left">
                                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" CssClass="form-control" Width="80px"></asp:DropDownList>                                        
                                    </div>
                                    <div style="float: left; padding-left: 10px">
                                        <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="false" CssClass="form-control" Width="80px">
                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                        <asp:ListItem Value="3">Mar</asp:ListItem>
                                        <asp:ListItem Value="4">Apr</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">Jun</asp:ListItem>
                                        <asp:ListItem Value="7">Jul</asp:ListItem>
                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                        <asp:ListItem Value="9">Sep</asp:ListItem>
                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                                    <div style="clear: both">
                                    </div>                                    
                                </td>
                                <td style="width: 20%; text-align: right; padding: 3px">
                                    <asp:Label ID="Label6" runat="server" CssClass="label" Text="View Option"></asp:Label>
                                </td>
                                <td style="width: 15%; padding: 3px">
                                    <asp:RadioButtonList ID="rdbViewOption" runat="server" AutoPostBack="False" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="StateRegion" Selected="True" onclick="EnableReportShowingOption(false);">State & Region</asp:ListItem>
                                        <asp:ListItem Value="Indicator" onclick="EnableReportShowingOption(true);">Indicator</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>                                    
                                 <td style="width: 15%; padding: 3px">
                                    <asp:Label ID="Label2" runat="server" CssClass="label" Text="Report Showing:" ></asp:Label>
                                 </td>
                                 <td style="width: 50%; padding: 3px" colspan="3">                                   
                                     <asp:DropDownList ID="ddlReportShowing" runat="server" AppendDataBoundItems="True" AutoPostBack="False" width="800px" Height="26px">
                                        <asp:ListItem Value="1">No. of Patient on ART who received viral load test during this month</asp:ListItem>                                
                                        <asp:ListItem Value="2">No. of Patient on ART who received viral load test result during this month</asp:ListItem>
                                        <asp:ListItem Value="3">No. of Patient on ART with suppressed viral load (<=1,000 copies/ml) among those who received the test result during this month</asp:ListItem>
                                        <asp:ListItem Value="4">No. of people living with HIV on ART with viral load suppression (<=1,000 copies/ml) at 12 months after ART initiation</asp:ListItem>
                                        <asp:ListItem Value="5">No. of people living with HIV on ART at 12 months after ART initiation</asp:ListItem>                                        
                                    </asp:DropDownList>
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

