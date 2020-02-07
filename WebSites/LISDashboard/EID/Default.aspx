<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CHAI.LISDashboard.Modules.EID.Views.Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">
<script src="../js/libs/jquery-2.0.2.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#collectedDateFromPicker').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $('#collectedDateToPicker').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $('#receivedDateFromPicker').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $('#receivedDateToPicker').datetimepicker({
            format: 'DD/MM/YYYY'
        });
    });

    function CallPrint(strid) {
        var prtContent = document.getElementById(strid);
        var disp_setting = "toolbar=yes,location=no,directories=yes,menubar=yes,";
        disp_setting += "scrollbars=yes,width=1500, height=1000, left=100, top=10";
        var WinPrint = window.open('', '', disp_setting);
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        prtContent.innerHTML = strOldOne;
    }
</script>
<style>
    .dataTables_filter {
        display: none;
    }
    /*.dt-toolbar {
        display: block;
        position: relative;
        padding: 6px 7px 1px;
        width: 1150px;
        float: left;
        border-bottom: 1px solid #ccc;
        background: #fafafa;
    }
    .dt-toolbar-footer {
        background: #fafafa;
        font-size: 11px;
        overflow: hidden;
        padding: 5px 10px;
        border-top: 1px solid #ccc;
        -webkit-box-shadow: inset 0 1px #fff;
        -moz-box-shadow: inset 0 1px #fff;
        -ms-box-shadow: inset 0 1px #fff;
        box-shadow: inset 0 1px #fff;
        width: 1150px;
    }*/
</style>
            <!-- MAIN CONTENT -->
			<div id="content">
				<div class="row">
					<div class="col-xs-12 col-sm-7 col-md-7 col-lg-4">
						<h1 class="page-title txt-color-blueDark">
							<i class="fa fa-table fa-fw "></i> 
								EID 
							<span> >
								List All
							</span>
						</h1>
					</div>
					 <div class="col-xs-12 col-sm-5 col-md-5 col-lg-8">
						    <ul id="sparks" class="">
							    <li class="sparks-info">
								    <h5>HIV VIRALOAD Total Synced <span class="txt-color-blue"> <% Response.Write(GetSyncTotal("VL")); %></span></h5>								
							    </li>
							    <li class="sparks-info">
								    <h5> EID Total Synced <span class="txt-color-purple"><% Response.Write(GetSyncTotal("EID")); %></span></h5>								
							    </li>							
						    </ul>
		</div>   
				</div>

				<!-- widget grid -->
				<section id="widget-grid" class="">

					<!-- row -->
					<div class="row">

						<!-- NEW WIDGET START -->
		<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
			<!-- Widget ID (each widget will need unique ID)-->
			

             <div class="jarviswidget jarviswidget-color-blue" id="wid-id-0" data-widget-editbutton="false">
								<!-- widget options:
								usage: <div class="jarviswidget" id="wid-id-0" data-widget-editbutton="false">
				
								data-widget-colorbutton="false"
								data-widget-editbutton="false"
								data-widget-togglebutton="false"
								data-widget-deletebutton="false"
								data-widget-fullscreenbutton="false"
								data-widget-custombutton="false"
								data-widget-collapsed="true"
								data-widget-sortable="false"
				
								-->
								<header>
									<span class="widget-icon"> <i class="fa fa-table"></i> </span>
									<h2>EID List All </h2>
				
								</header>
				
								<!-- widget div-->
								<div>
				
									<!-- widget edit box -->
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->
				                    </div>
									<!-- end widget edit box -->
                                        <!-- Added by ZaySoe on 19_Nov_2018 -->

                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 120px; padding: 2px; text-align: left">
                                                    <asp:Label ID="lblProvince" runat="server" CssClass="label" Text="State/Region"></asp:Label>
                                                </td>
                                                <td style="width: 100%; padding: 2px; text-align: left">
                                                    <asp:DropDownList ID="ddlProvince" runat="server" AppendDataBoundItems="True" 
                                                        AutoPostBack="True" CssClass="textbox" 
                                                        onselectedindexchanged="ddlProvince_SelectedIndexChanged" 
                                                        DataTextField="ProvinceName" DataValueField="Id" ValidationGroup="1" Height="26px" Width="100%">
                                                        <asp:ListItem Value="0">ALL State/Region</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                                
                                                <td style="width: 100px; padding: 2px" align="left">
                                                    <asp:Label ID="lblCollectedDateFrom" runat="server" CssClass="label" 
                                                        Text="Collected Date From"></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="input-group date" id='collectedDateFromPicker'>
					                                    <asp:TextBox ID="txtCollectedDateFrom" CssClass="form-control" data-dateformat="DD/MM/YY" runat="server" placeholder="DD/MM/YY"></asp:TextBox>
                                                        <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                        ControlToValidate="txtCollectedDateFrom" Display="Dynamic" ErrorMessage="Collected date from is invalid" 
                                                        ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                                        ValidationGroup="1">*</asp:RegularExpressionValidator>
                                                    </div>
                                                </td>                                                
                                                <td style="width: 50px; padding: 2px" align="left">                             
                                                    <asp:Label ID="lblCollectedDateTo" runat="server" Text="To" CssClass="label"></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="input-group date" id='collectedDateToPicker'>
					                                    <asp:TextBox ID="txtCollectedDateTo" CssClass="form-control" data-dateformat="DD/MM/YY" runat="server" placeholder="DD/MM/YY"></asp:TextBox>
                                                        <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                        ControlToValidate="txtCollectedDateTo" Display="Dynamic" ErrorMessage="Collected date to is invalid" 
                                                        ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                                        ValidationGroup="1">*</asp:RegularExpressionValidator>
                                                    </div>                                                    
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td style="width: 120px;padding: 2px" align="left ">
                                                    <asp:Label ID="lblFacility" runat="server" CssClass="label" 
                                                        Text="Facility Name"></asp:Label>
                                                </td>
                                                <td style="width: 300px;padding: 2px" align="left ">
                                                    <asp:DropDownList ID="ddlFacility" runat="server" CssClass="textbox" 
                                                        DataTextField="FacilityName" DataValueField="Id" 
                                                        AppendDataBoundItems="True" AutoPostBack="False" ValidationGroup="1" Height="26px" Width="100%">
                                                        <asp:ListItem Value="0">ALL Facility Name</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                                
                                                <td style="width: 150px;padding: 2px" align="left ">
                                                    <asp:Label ID="lblReceivedDateFrom" runat="server" CssClass="label" 
                                                        Text="Received Date From"></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="input-group date" id='receivedDateFromPicker'>
					                                    <asp:TextBox ID="txtReceivedDateFrom" CssClass="form-control" data-dateformat="mm/dd/yy" runat="server" placeholder="DD/MM/YY"></asp:TextBox>
                                                        <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                        ControlToValidate="txtReceivedDateFrom" Display="Dynamic" ErrorMessage="Shipment date from is invalid" 
                                                        ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                                        ValidationGroup="1">*</asp:RegularExpressionValidator>
                                                    </div>                                                    
                                                </td>
                                                <td style="padding: 2px" align="left">                             
                                                    <asp:Label ID="lblReceivedDateTo" runat="server" CssClass="label" 
                                                        Text="To"></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="input-group date" id='receivedDateToPicker'>
					                                    <asp:TextBox ID="txtReceivedDateTo" CssClass="form-control" data-dateformat="mm/dd/yy" runat="server" placeholder="DD/MM/YY"></asp:TextBox>
                                                        <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                        ControlToValidate="txtReceivedDateTo" Display="Dynamic" ErrorMessage="Received date to is invalid" 
                                                        ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                                        ValidationGroup="1">*</asp:RegularExpressionValidator>
                                                    </div>                                                    
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td style="width: 120px;padding: 2px" align="left ">
                                                    <asp:Label ID="lblTests" runat="server" CssClass="label" Text="Tests"></asp:Label>
                                                </td>
                                                <td style="width: 300px;padding: 2px" align="left ">
                                                    <asp:DropDownList ID="ddlTests" runat="server" AppendDataBoundItems="True" 
                                                        AutoPostBack="false" CssClass="textbox" 
                                                        onselectedindexchanged="ddlTests_SelectedIndexChanged" ValidationGroup="1" Height="26px" Width="100%">
                                                        <asp:ListItem Value="0">ALL Tests</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                                
                                                <td style="width: 150px;padding: 2px" align="left ">
                                                    <asp:Label ID="Label1" runat="server" Text="Lab Number From :"  
                                                        CssClass="label"></asp:Label>  
                                                </td>
                                                <td style="width: 100px; padding: 2px" align="left">
                                                    <asp:TextBox ID="txtlabNumber" runat="server" CssClass="textboxVeryShort"></asp:TextBox>
                                                </td>
                                                <td style="padding: 2px" align="left">
                                                    <asp:Label ID="lblshipmentDateTo0" runat="server" CssClass="label" 
                                                        Text="To"></asp:Label>
                                                </td>
                                                <td style="padding: 2px" align="left">
                                                    <asp:TextBox ID="txtlabNumberTo" runat="server" CssClass="textboxVeryShort"></asp:TextBox>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td style="width: 120px; padding: 2px" align="left">
                                                    <asp:Label ID="lblPatientCode" runat="server" CssClass="label" Text="Patient Code"></asp:Label>
                                                </td>
                                                <td style="width: 200px;padding: 2px" align="left">
                                                    <asp:TextBox ID="txtPatientCode" runat="server" CssClass="textbox" Width="100%"
                                                     ></asp:TextBox>
                                                </td>                                                
                                                <td style="width: 150px; padding: 2px" align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="label" Text="Laboratory"></asp:Label></td>
                                                <td class="editDropDown" style="width: 200px; padding: 2px" align="left">
                                                    <asp:DropDownList ID="ddlLab" runat="server" AppendDataBoundItems="True" DataTextField="LaboratoryName" DataValueField="LabCode" Height="26px" Width="100%" AutoPostBack="false">
                                                        <asp:ListItem Value="0">All</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="padding: 2px" align="left">                                                    
                                                    <asp:Label ID="Label2" runat="server" CssClass="label" Text="Year"></asp:Label></td>
                                                </td>
                                                <td style="padding: 2px" align="left">
                                                    <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" DataTextField="YearName" DataValueField="YearName" Height="26px" Width="100%" AutoPostBack="false">
                                                        <asp:ListItem Value="0">All</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:TextBox ID="txtnumberOfTests" runat="server" CssClass="textboxToShort" Width="150px" Visible="false"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="txtnumberOfTests_FilteredTextBoxExtender" 
                                                        runat="server" Enabled="True" TargetControlID="txtnumberOfTests" 
                                                        ValidChars="0123456789">
                                                    </cc1:FilteredTextBoxExtender>                                 
                                                    <cc1:TextBoxWatermarkExtender ID="txtnumberOfTests_TextBoxWatermarkExtender" runat="server"
                                                      Enabled="True" TargetControlID="txtnumberOfTests" WatermarkText="Enter Number Of Tests" WatermarkCssClass="watermarked">
                                                    </cc1:TextBoxWatermarkExtender>                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding: 5px">
                                                    <asp:LinkButton ID="lnkSendAndPrint" runat="server"
                                                        OnClientClick="CallPrint('divPrint')"> Print List</asp:LinkButton>
                                                    &nbsp;|&nbsp;
                                                    <asp:LinkButton ID="lnkExportToExcel" runat="server" onclick="lnkExportToExcel_Click">Export List To Excel</asp:LinkButton>
                                                </td>                                                
                                                <td style="width: 73px; padding: 2px" align="left" class="editDropDown">
                                                    &nbsp;</td>
                                                <td style="width: 137px; padding: 2px" align="left">
                                                    &nbsp;</td>
                                                <td class="editDropDown" style="width: 200px;padding: 2px" align="left">                                                    
                                                </td>
                                                <td colspan="3" style="padding: 2px" align="right">
                                                    <asp:Button ID="btnFilter" runat="server" Text="Search" 
                                                        CssClass="btn btn-primary" onclick="btnFilter_Click" 
                                                        ValidationGroup="1"/>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td colspan="2">                                                    
                                                </td>                                                
                                                <td style="width: 73px; padding: 2px" align="left" class="editDropDown">
                                                    &nbsp;</td>
                                                <td style="width: 137px; padding: 2px" align="left">
                                                    &nbsp;</td>
                                                <td class="editDropDown" style="width: 200px;padding: 2px" align="left">                                                    
                                                </td>
                                                <td colspan="3" style="padding: 2px" align="right">                                                    
                                                </td>
                                            </tr>
                                        </table>

                                        <!-- ////////////////////////////// -->									
				
									<!-- widget content -->
									<%--<div class="widget-body no-padding" style="overflow: scroll;" runat="server">                                        
                                        <% Response.Write(BindingData()); %>                                        
									</div>--%>
                                    <div id="divPrint">
                                        <div class="widget-body no-padding" id="dvTableContent" style="overflow: scroll; width: 100%" runat="server">                                                                                
									    </div>
                                    </div>
									<!-- end widget content -->
				
								</div>
								<!-- end widget div -->
				
							</div>

          
			<!-- end widget -->
		</article>
		<!-- WIDGET END -->

					

					</div>

					<!-- end row -->

					

				</section>
				<!-- end widget grid -->
			</div>
			<!-- END MAIN CONTENT -->



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
   
</asp:Content>


