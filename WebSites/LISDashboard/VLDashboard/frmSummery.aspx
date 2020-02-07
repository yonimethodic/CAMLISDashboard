<%@ Page Title="Summary" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="frmSummery.aspx.cs" Inherits="CHAI.LISDashboard.Modules.VLDashboard.Views.frmSummery" %>
<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">
    
    <script src="../js/libs/jquery-2.0.2.min.js"></script>
    <!-- HIGHCHART:  -->
    <script src="../js/plugin/HighCharts/highcharts.js"></script>
    <script src="../js/plugin/HighCharts/exporting.js"></script>
    <script src="../js/plugin/HighCharts/export-data.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'MM/DD/YYYY'
            });
            $('#datetimepicker2').datetimepicker({
                format: 'MM/DD/YYYY'
            });
                      // Testing Trends  
            $(function GetTestingTrenddata() {
                var subject = JSON.parse('<%=Jstring%>');
                var series = [],categories = [],DBS = [],WholeBlood = [],Plasma = [];
                
                for (var i in subject) {
                    categories.push(subject[i][4] + " " + subject[i][3]);
                    DBS.push(subject[i][0]);
                    WholeBlood.push(subject[i][1]);
                    Plasma.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'DBS',
                    data: DBS
                },
                {
                    name: 'Whole Blood',
                    data: WholeBlood
                },

                {
                    name: 'Plasma',
                    data: Plasma
                }
                );

                BindTestingTrends(categories, series);
                function BindTestingTrends(categories, series) {
                    window.chart = new Highcharts.chart('testtrend', {
                        chart: {
                            type: 'column',
                            marginRight: 120
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            },
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        },
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            x: 0,
                            verticalAlign: 'top',
                            y: 0,
                            floating: false,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series
                    });
                }
            });
            // VL Outcome
            $(function GetVLOutcomedata() {
                var subject = JSON.parse('<%=JstringVLOutcome%>');
                var series = [],Suppressed , Not_Suppressed , LDL;
                
                for (var i in subject) {
                    
                    Suppressed = subject[i][0];
                    Not_Suppressed = subject[i][1];
                    LDL = subject[i][2];
                    
                }
                series.push({
                    data: [
                {
                    name: 'Suppressed',
                    y: Suppressed
                },
                {
                    name: 'Not_Suppressed',
                    y: Not_Suppressed
                },

                {
                    name: 'LDL',
                    y: LDL
                }]
                }
                );
                BindVLOutcomeTrends(series, subject);
                function BindVLOutcomeTrends(series, subject) {

                window.chart = new Highcharts.chart('VLOutcome', {
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: null,
                        plotShadow: false,
                        type: 'pie'
                    },
                    title: {
                        text: ' '
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            cursor: 'pointer',
                            dataLabels: {
                                enabled: true,
                                format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                                style: {
                                    color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                                }
                            }
                        }
                    },
                    series: series
                });
            }
            });
            // Test by Gender
             
            $(function GetTestingbyGenderdata() {
                var subject = JSON.parse('<%=JstringVLTestBygender%>');
                var series = [],categories=[], Suppressed = [], Not_Suppressed = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    Suppressed.push(subject[i][0]);
                    Not_Suppressed.push(subject[i][1]);
                   
                    
                }
                series.push({
                    name: 'Suppressed',
                    data: Suppressed
                },
                {
                    name: 'Not Suppressed',
                    data: Not_Suppressed
                }

              
                );

                BindTestingbyGender(categories, series);
                function BindTestingbyGender(categories, series) {
                    window.chart = new Highcharts.chart('testbygender', {
                        chart: {
                            type: 'column',
                            height: 250,
                            marginBottom: 80
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: {
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            },
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        },
                        legend: {
                            
                            align: 'right',
                            x: 0,
                            verticalAlign: 'bottom',
                            y: 0,
                            floating: false,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series
                    });
                }
            });
            // Test by Age
             
            $(function GetTestingbyAgedata() {
                var subject = JSON.parse('<%=JstringVLTestByAge%>');
                var series = [],categories=[], Suppressed = [], Not_Suppressed = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    Suppressed.push(subject[i][0]);
                    Not_Suppressed.push(subject[i][1]);
                   
                    
                }
                series.push({
                    name: 'Suppressed',
                    data: Suppressed
                },
                {
                    name: 'Not Suppressed',
                    data: Not_Suppressed
                }

              
                );

                BindTestingbyAge(categories, series);
                function BindTestingbyAge(categories, series) {
                    window.chart = new Highcharts.chart('testbyAge', {
                        chart: {
                            type: 'column',
                            marginBottom: 100
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: {
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            },
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        },
                        legend: {
                            
                            align: 'right',
                            x: 0,
                            verticalAlign: 'bottom',
                            y: 0,
                            floating: false,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series
                    });
                }
            });
            // VL Reason for test
            $(function GetVLReasonforTestdata() {
                var subject = JSON.parse('<%=JstringVLTestBytest%>');
                var series = [], name = [], y = [];

                
                for (var i in subject) {
                    series.push({

                        
                        name: subject[i][1],
                        y: subject[i][0]

                   
                    }
                );
                }
                BindVLReasonforTest(series);
                function BindVLReasonforTest(series) {

                window.chart = new Highcharts.chart('VLReasonfortest', {
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: null,
                        plotShadow: false,
                        type: 'pie'
                    },
                    title: {
                        text: ' '
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            cursor: 'pointer',
                            dataLabels: {
                                enabled: true,
                                format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                                style: {
                                    color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                                }
                            }
                        }
                    },
                    series: [{
                        data: series
                    }]
                });
            }
            });
            // Test by Province
            $(function GetTestingbyProvincedata() {
                var subject = JSON.parse('<%=JstringVLTestByprovince%>');
                var series = [],categories=[], Suppressed = [], Not_Suppressed = [], LDL=[],SuppressionRate=[];
                
                for (var i in subject) {
                    Suppressed.push(subject[i][0]);
                    Not_Suppressed.push(subject[i][1]);
                    LDL.push(subject[i][2]);
                    SuppressionRate.push(subject[i][3]);
                    categories.push(subject[i][4]);                   
                    
                }
                series.push({
                    type: 'column',
                    name: 'Suppressed',
                    data: Suppressed
                },
                {
                    type: 'column',
                    name: 'Not Suppressed',
                    data: Not_Suppressed
                },

                {
                    type: 'column',
                    name: 'LDL',
                    data: LDL
                },
                {
                    type: 'spline',
                    name: 'Suppression Rate',
                    data: SuppressionRate,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'white'
                    }
                }
              
                );

                BindTestingbyProvince(categories, series);
                function BindTestingbyProvince(categories, series) {
                    window.chart = new Highcharts.chart('testbyprovince', {
                        chart: {
                            type: 'column',
                            height: 250,
                            marginBottom: 100
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: [{
                            title: {
                                text: 'Total Tests'
                            }
                        }, {
                            title: {
                                text: 'Supperssion Rate',
                              
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
                                             
                       
                        legend: {
                            
                            align: 'right',
                            x: 0,
                            verticalAlign: 'bottom',
                            y: 0,
                            floating: false,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#CCC',
                            borderWidth: 1,
                            shadow: false
                        },
                        tooltip: {
                            headerFormat: '<b>{point.x}</b><br/>',
                            pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                        },
                        plotOptions: {
                            column: {
                                stacking: 'normal',
                                dataLabels: {
                                    enabled: true,
                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                                }
                            }
                        },
                        series: series

                    });
                }
            });
      });
    </script>
    <div id="content">
  <div class="row">
					<div class="col-xs-12 col-sm-7 col-md-7 col-lg-2">
						<h1 class="page-title txt-color-blueDark"><i class="fa-fw fa fa-"></i> Summary </h1>
					</div>
					<div class="col-xs-12 col-sm-5 col-md-5 col-lg-10">
						<ul id="sparks" class="">
							<li class="sparks-info">
								<h5 style="margin:5px 0 0 0"> Total Tests <span class="txt-color-blue">
                                   <asp:Label ID="lblTotTests" runat="server" Text=""/></span></h5>
								
							</li>
							<li class="sparks-info">
								<h5 style="margin:5px 0 0 0"> Rejection <span class="txt-color-purple"><asp:Label ID="lblRejection" runat="server" Text=""/></span></h5>
								
							</li>
							<li class="sparks-info">
								<h5 style="margin:5px 0 0 0"> Tot Detected < 1000 <span class="txt-color-greenDark"><asp:Label ID="lblDetLes" runat="server" Text=""/></span></h5>
								
							</li>
                            <li class="sparks-info">
								<h5 style="margin:5px 0 0 0"> Tot Detected > 1000 <span class="txt-color-greenDark"><asp:Label ID="lbldetgre" runat="server" Text=""/></span></h5>
								
							</li>
                            <li class="sparks-info">
								<h5 style="margin:5px 0 0 0"> Superresion <span class="txt-color-purple"><asp:Label ID="lblSupp" runat="server" Text=""/></span></h5>
								
							</li>
                            <li class="sparks-info">
								<h5 style="margin:5px 0 0 0"> Invalid/Error/Noresult <span class="txt-color-purple"><asp:Label ID="lblError" runat="server" Text=""/></span></h5>
								
							</li>
						</ul>
					</div>
 </div>
     </div>
     <div class="well">
        <div class="row">
				<div class="col-sm-3 pull-left">                      
                      <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataTextField="ProvinceName" DataValueField="Id">
                                        <asp:ListItem Value="0">Select State/Region</asp:ListItem>
                      </asp:DropDownList><i></i>					
				</div>
            <div class="col-sm-3 pull-left"> 
            <h6> <span class="txt-color-blue">
                <asp:Label ID="lbllocation" runat="server" Text="National"></asp:Label></span></h6>
                </div>
             <div class="col-sm-2 pull-right">	
                 <asp:Button ID="btnFilter" class="btn btn-default btn-primary" runat="server" Text="Filter" OnClick="btnFilter_Click" />								
			 </div>				
			 <div class="col-sm-2 pull-right">
                     <div class="input-group date"  id='datetimepicker2'>
					        <asp:TextBox ID="txtdateto" CssClass="form-control" data-dateformat="mm/dd/yy" runat="server" placeholder="Date To"></asp:TextBox>
                            <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                     </div>
			 </div>
             <div class="col-sm-2 pull-right">
                    <div class="input-group date"  id='datetimepicker1'>
                         <asp:TextBox ID="txtdatefrom" CssClass="form-control" data-dateformat="mm/dd/yy" runat="server" placeholder="Date From"></asp:TextBox>
					         <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                   </div>
			</div>
               
		</div>
					
	</div>
    
    <section id="widget-grid" class="">
       
       <div class="row">
		 <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-0" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>Testing Trends for Routine VL (<asp:Label ID="lblDatefromyear" runat="server" Text=""></asp:Label>-<asp:Label ID="lblDatetoyear" runat="server" Text=""></asp:Label>)</h2>
                       
                    </header>
                  
										<!-- add: non-hidden - to disable auto hide -->
                            
                    			<div role="content">
                                    
									<div class="widget-body no-padding">
                                     <asp:DropDownList ID="ddltestreason" CssClass="form-control select bg-info" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddltestreason_SelectedIndexChanged">
                                            <asp:ListItem Value="15">Routine VL</asp:ListItem>
                                            <asp:ListItem Value="0">All Tests</asp:ListItem>
                                     </asp:DropDownList><i></i>
									
                                        <div id="testtrend" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                       
									</div>
								</div>
			 </div>
             
		 </article>
		</div>
        		<!-- end row -->
        		
		<div class="row">
			<article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-2" data-widget-editbutton="false" role="widget" style="">
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>VL Outcome</h2>
                    </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                      <div id="VLOutcome" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
       		</article>
			<article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-3" data-widget-editbutton="false" role="widget" style="">
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>Routine VLs Outcomes by Gender</h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">                                        
                                       <div id="testbygender" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>
        		<!-- end row -->

	    <div class="row">
            <article class="col-xs-12 col-sm-8 col-md-7 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-5" data-widget-editbutton="false" role="widget" style="">
								
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>Routine VLs Outcomes by Age</h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                      <div id="testbyAge" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
			<article class="col-xs-12 col-sm-4 col-md-5 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-6" data-widget-editbutton="false" role="widget" style="">
								
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>Reason for Tests </h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                       <div id="VLReasonfortest" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>
        
					<!-- row -->
		<div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-7" data-widget-editbutton="false" role="widget" style="">
								
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>
                                        <asp:Label ID="lbloutcomeProFac" runat="server" Text="Province Outcomes"></asp:Label></h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                        
                                      <div id="testbyprovince" style="min-width: 1024px; height: 300px;  margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>
           
        		<!-- end row -->
     </section>
       
   </asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>

