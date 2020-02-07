<%@ Page Title="Summary" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="frmSummery.aspx.cs" Inherits="CHAI.LISDashboard.Modules.EIDDashboard.Views.frmSummery" %>


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
                // EID Outcome
            $(function GetEIDOutcomedata() {
                var subject = JSON.parse('<%=JstringEIDOutcome%>');
                var series = [], No_Positive, No_Negative;
                
                for (var i in subject) {
                    
                    No_Positive = subject[i][0];
                    No_Negative = subject[i][1];
                    
                }
                series.push({
                    data: [
                {
                    name: 'Positive',
                    y: No_Positive
                },
                {
                    name: 'Negative',
                    y: No_Negative
                }]
                }
                );
                BindEIDOutcomeTrends(series, subject);
                function BindEIDOutcomeTrends(series, subject) {

                window.chart = new Highcharts.chart('EIDOutcome', {
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
                 
            // Test by Age
             
            $(function GetTestingbyAgedata() {
                var subject = JSON.parse('<%=JstringEIDTestByAge%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                   
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive
                },
                {
                    name: 'Negative',
                    data: No_Negative
                }

              
                );

                BindTestingbyAge(categories, series);
                function BindTestingbyAge(categories, series) {
                    window.chart = new Highcharts.chart('testbyAge', {
                        chart: {
                            type: 'column',
                           
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
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
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
            
             // Infant Feeding Status
             
            $(function GetInfantFeedingdata() {
                var subject = JSON.parse('<%=JstringInfantFeeding%>');
                var series = [], categories = [], No_Positive = [], Tested = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    No_Positive.push(subject[i][0]);
                    Tested.push(subject[i][1]);
                   
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive
                },
                {
                    name: 'Test',
                    data: Tested
                }

              
                );

                BindTestingbyInfantFeeding(categories, series);
                function BindTestingbyInfantFeeding(categories, series) {
                    window.chart = new Highcharts.chart('testbyInfantFeeding', {
                        chart: {
                            type: 'column',
                           
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
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
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
            // EID Intial PCR
             
            $(function GetEIDIntialPCRdata() {
                var subject = JSON.parse('<%=JstringEIDIntialPCR%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [], Positivity=[];
                
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive
                },
                {
                    name: 'Negative',
                    data: No_Negative
                },
                {
                type: 'spline',
                name: 'Positivity',
                data: Positivity,
                yAxis: 1,
                marker: {
                    lineWidth: 2,
                    lineColor: Highcharts.getOptions().colors[3],
                    fillColor: 'black'
                }
            }
              
                );

                BindIntialPCR(categories, series);
                function BindIntialPCR(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCR', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            }},{
                                title: {
                                    text: 'Positivity',
                              
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
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
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
            
            // EID Intial PCR by Province
             
            $(function GetEIDIntialPCRbyProvincedata() {
                var subject = JSON.parse('<%=JstringEIDIntialPCRbyProvince%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [], Positivity=[];
                
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive
                },
                {
                    name: 'Negative',
                    data: No_Negative
                },
                {
                type: 'spline',
                name: 'Positivity',
                data: Positivity,
                yAxis: 1,
                marker: {
                    lineWidth: 2,
                    lineColor: Highcharts.getOptions().colors[3],
                    fillColor: 'black'
                }
            }
              
                );

                BindIntialPCRbyProvince(categories, series);
                function BindIntialPCRbyProvince(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRbyProvince', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests'
                            }},{
                                title: {
                                    text: 'Positivity',
                              
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
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
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
            
           
           
           
            // Test by Mode of Delivery
             
            $(function GetTestingbyModeOfDelivery() {
                var subject = JSON.parse('<%=JstringEIDTestByModeOfDelivery%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                   
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive
                },
                {
                    name: 'Negative',
                    data: No_Negative
                }

              
                );

                BindTestingbyModeOfDelivery(categories, series);
                function BindTestingbyModeOfDelivery(categories, series) {
                    window.chart = new Highcharts.chart('testbyModeOfDelivery', {
                        chart: {
                            type: 'column',
                           
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
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
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
                 <asp:Button ID="btnFilter" class="btn btn-default btn-primary" runat="server" Text="Filter" OnClick="btnFilter_Click"  />								
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
						<h2>Intial PCR (<asp:Label ID="lblDatefromyear" runat="server" Text=""></asp:Label>-<asp:Label ID="lblDatetoyear" runat="server" Text=""></asp:Label>)</h2>
                       
                    </header>
                  
										<!-- add: non-hidden - to disable auto hide -->
                            
                    		<div role="content">
                                    
									<%--<div class="widget-body no-padding">
                                     <asp:DropDownList ID="ddltestreason" CssClass="form-control select bg-info" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="15">Routine VL</asp:ListItem>
                                            <asp:ListItem Value="0">All Tests</asp:ListItem>
                                     </asp:DropDownList><i></i>--%>
									
                                        <div id="testIntialPCR" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                       
									<%--</div>--%>
								</div>
			 </div>
             
		 </article>
		</div>
        		<!-- end row -->
        		
		<div class="row">
			<article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-2" data-widget-editbutton="false" role="widget" style="">
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>EID Outcome</h2>
                    </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                      <div id="EIDOutcome" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
       		</article>
			<article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-3" data-widget-editbutton="false" role="widget" style="">
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>Test by Infant Feeding</h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">                                        
                                       <div id="testbyInfantFeeding" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
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
						            <h2>EID Outcomes by Age</h2>
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
						            <h2>Mode of Delivery </h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                       <div id="testbyModeOfDelivery" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
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
                                        <asp:Label ID="lbloutcomeProFac" runat="server" Text="Country Outcomes"></asp:Label></h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                        
                                      <div id="testIntialPCRbyProvince" style="min-width: 1024px; height: 300px;  margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>
        		<!-- end row -->
     </section>
   </asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>

