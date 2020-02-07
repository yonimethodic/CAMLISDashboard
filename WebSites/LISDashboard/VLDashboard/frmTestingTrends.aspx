<%@ Page Title="Trends" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="frmTestingTrends.aspx.cs" Inherits="CHAI.LISDashboard.Modules.VLDashboard.Views.frmTestingTrends" %>
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
            
            $(function GetTestingTrendsdata() {
                var subject = JSON.parse('<%=JstringVLTestingTrends%>');
                var series = [],categories=[], Suppressed = [], Not_Suppressed = [],SuppressionRate=[];
                
                for (var i in subject) {
                    Suppressed.push(subject[i][0]);
                    Not_Suppressed.push(subject[i][1]);
                    SuppressionRate.push(subject[i][2]);
                    if(<%=ddlDate.SelectedValue%> == 1)
                        categories.push(subject[i][3] + " " + subject[i][4]);
                    else
                        categories.push(subject[i][3]);
                    
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
                    type: 'spline',
                    name: 'Supperssion Rate',
                    data: SuppressionRate,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'white'
                    }
                }
              
                );

                BindGetTestingTrends(categories, series);
                function BindGetTestingTrends(categories, series) {
                    window.chart = new Highcharts.chart('TestingTrends', {
                        chart: {
                            type: 'column',
                            height: 250,
                            marginRight: 200
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
                                text: 'Percentage',
                              
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
            // Testing Trends by Age and year  
            
            $(function GetTestingbyAgeTrendssdata() {
                var subject = JSON.parse('<%=JstringVLTestingbyAgeTrends%>');
                var series = [],categories=[], NoTests_0_6 = [], NoTests_7_14 = [],NoTests_15_21=[],NoTests_22_39=[],NoTests_40_60=[],NoTests_60=[],Less_21_Contribution=[],TestYear=[];
                
                for (var i in subject) {
                    NoTests_0_6.push(subject[i][0]);
                    NoTests_7_14.push(subject[i][1]);
                    NoTests_15_21.push(subject[i][2]);
                    NoTests_22_39.push(subject[i][3]);
                    NoTests_40_60.push(subject[i][4]);
                    NoTests_60.push(subject[i][5]);
                    Less_21_Contribution.push(subject[i][6]);   
                    categories.push(subject[i][7]);
                 
                    
                }
                series.push({
                    type: 'column',
                    name: '0-6',
                    data: NoTests_0_6
                },
                {
                    type: 'column',
                    name: '7-14',
                    data: NoTests_7_14
                },
                {
                    type: 'column',
                    name: '15-21',
                    data: NoTests_15_21
                },
                {
                    type: 'column',
                    name: '22-39',
                    data: NoTests_22_39
                },
                {
                    type: 'column',
                    name: '40-60',
                    data: NoTests_40_60
                },
                {
                    type: 'column',
                    name: '60+',
                    data: NoTests_60
                },
                {
                    type: 'spline',
                    name: 'Less 21 Contribution',
                    data: Less_21_Contribution,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'white'
                    }
                }
              
                );

                BindTestingbyAgeTrends(categories, series);
                function BindTestingbyAgeTrends(categories, series) {
                    window.chart = new Highcharts.chart('AgeTestingTrends', {
                        chart: {
                            type: 'column',
                            height: 250,
                            marginRight: 200
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
                                text: 'Percentage',
                              
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
            // Testing Trends by Supperssion 
            
            $(function GetVLSuppressionTrends() {
                var subject = JSON.parse('<%=JstringVLSuppressionTrends%>');
                var series = [],categories=[],data=[],name=[];
                
                if(<%=ddlDate.SelectedValue%> == 0)
                {
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
                }
                else
                {
                    categories=['Q1','Q2','Q3','Q4']
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][4],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3]]

                   
                        }
                    );
                    }
                    
                 }
               

                BindVLSuppressionTrends(categories, series);
                function BindVLSuppressionTrends(categories, series) {
                    window.chart = new Highcharts.chart('SuppressionTrends', {
                        chart: {
                            type: 'spline',
                            height: 250,
                            marginBottom: 70
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            title: {
                                text: 'Suppression Rate %'
                            }
                        },
                         
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
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

            // Testing Trends by Valid Test 
            
            $(function GetVLValidTestTrends() {
                var subject = JSON.parse('<%=JstringVLValidTestingTrends%>');
                var series = [],categories=[],data=[],name=[];
                
                if(<%=ddlDate.SelectedValue%> == 0)
                {
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
                }
                else
                {
                    categories=['Q1','Q2','Q3','Q4']
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][4],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3]]

                   
                        }
                    );
                    }
                    
                 }
               

                BindVLValidTestTrends(categories, series);
                function BindVLValidTestTrends(categories, series) {
                    window.chart = new Highcharts.chart('ValidTestTrends', {
                        chart: {
                            type: 'spline',
                            height: 250,
                            marginBottom: 70
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            title: {
                                text: 'Number of valid Tests'
                            }
                        },
                         
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
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
             // Testing Trends by Rejection 
            
            $(function GetVLRejectedTrends() {
                var subject = JSON.parse('<%=JstringVLRejectedTrends%>');
                var series = [],categories=[],data=[],name=[];
                
                if(<%=ddlDate.SelectedValue%> == 0)
                {
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                    
                }
                else
                {
                    categories=['Q1','Q2','Q3','Q4']
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][4],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3]]

                   
                        }
                    );
                    }
                    
                 }
               

                BindVLRejectedTrends(categories, series);
                function BindVLRejectedTrends(categories, series) {
                    window.chart = new Highcharts.chart('RejectionTrends', {
                        chart: {
                            type: 'spline',
                            height: 250,
                            marinBottom: 70
                        },
                        title: {
                            text: ' '
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            title: {
                                text: 'Rejection %'
                            }
                        },
                         
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
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
            <div class="col-sm-3 pull-left">                      
                      <asp:DropDownList ID="ddlDate" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">Yearly</asp:ListItem>
                                        <asp:ListItem Value="1">Quarterly</asp:ListItem>
                      </asp:DropDownList><i></i>					
				</div>
             <div class="col-sm-2 pull-right">	
                 <asp:Button ID="btnFilter" class="btn btn-default btn-primary" runat="server" Text="Filter" OnClick="btnFilter_Click" />								
			 </div>				
			              
		</div>
					
	</div>
    <section id="widget-grid" class="">
       <div class="row">
		 <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-0" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>Outcomes</h2>
                       
                    </header>
                  
										<!-- add: non-hidden - to disable auto hide -->
                            
                    			<div role="content">
                                    
									<div class="widget-body no-padding">
                                     									
                                        <div id="TestingTrends" style="min-width: 1024px; height: 250px; margin: 0 auto"></div>
                                       
									</div>
								</div>
			 </div>
             
		 </article>
		</div>
        		<!-- end row -->
         <div class="row">
		 <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-1" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>Test Grouped By Age (Yearly)</h2>
                       
                    </header>
                  
										<!-- add: non-hidden - to disable auto hide -->
                            
                    			<div role="content">
                                    
									<div class="widget-body no-padding">
                                     									
                                        <div id="AgeTestingTrends" style="min-width: 1024px; height: 250px; margin: 0 auto"></div>
                                       
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
						<h2>Suppression Trends</h2>
                    </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                      <div id="SuppressionTrends" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
       		</article>
			<article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-3" data-widget-editbutton="false" role="widget" style="">
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>Testing Trends</h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">                                        
                                       <div id="ValidTestTrends" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
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
						            <h2>Rejection Rate Trends</h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                      <div id="RejectionTrends" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
			<article class="col-xs-12 col-sm-4 col-md-5 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-6" data-widget-editbutton="false" role="widget" style="">
								
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>Turn Around Time(Collection - Dispatch)</h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                       <div id="TAT" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>
        
					<!-- row -->
		
        		<!-- end row -->
     </section>
   </asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>

