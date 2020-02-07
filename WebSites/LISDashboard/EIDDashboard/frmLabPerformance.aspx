<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="frmLabPerformance.aspx.cs" Inherits="CHAI.LISDashboard.Modules.EIDDashboard.Views.frmLabPerformance" %>


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
            // Test Outcome
             
            $(function GetEIDValidOutcomedata() {
                var subject = JSON.parse('<%=JstringLabEIDValidOutcome%>');
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

                BindEIDValidOutcome(categories, series);
                function BindEIDValidOutcome(categories, series) {
                    window.chart = new Highcharts.chart('testOutcomes', {
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
             // Rejection Rate
             $(function GetLabEIDRejectinByYeardata() {
                var subject = JSON.parse('<%=JstringLabEIDRejectionbyYear%>');
                var series = [],categories=[],data=[],name=[];
               
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                 
               

                    BindLabEIDRejectinByYear(categories, series);
                    function BindLabEIDRejectinByYear(categories, series) {
                        window.chart = new Highcharts.chart('rejectionbyYear', {
                        chart: {
                            type: 'spline',
                            height: 250
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
                                text: 'Rejection Rate'
                            }
                        },
                         
                        legend: {
                            layout: 'vertical',
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
           
            
            // Test Trend
            $(function GetLabEIDTestTrendbyYeardata() {
                var subject = JSON.parse('<%=JstringLabEIDTestTrendbyYear%>');
                var series = [],categories=[],data=[],laboratoryName=[];
               
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            laboratoryName: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                 
               

                    BindLabEIDTestTrendbyYear(categories, series);
                    function BindLabEIDTestTrendbyYear(categories, series) {
                        window.chart = new Highcharts.chart('testTrendbyYear', {
                        chart: {
                            type: 'spline',
                            height: 250
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
                                text: 'Test Rate'
                            }
                        },
                         
                        legend: {
                            layout: 'vertical',
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
             //  Rejection 
             
            $(function GetLabRejectedSamplebyCountrydata() {
                var subject = JSON.parse('<%=JstringLabRejectedSamplebyCountry%>');
                var series = [], categories = [], RejectedSamples = [], Rejected = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    RejectedSamples.push(subject[i][0]);
                    Rejected.push(subject[i][1]);
                    
                }
                series.push({
                    name: 'RejectedSamples',
                    data: RejectedSamples
                },
                {
                type: 'spline',
                name: '%Rejected',
                data: Rejected,
                yAxis: 1,
                marker: {
                    lineWidth: 2,
                    lineColor: Highcharts.getOptions().colors[3],
                    fillColor: 'black'
                }
            }
              
                );

                BindLabRejectedSamplebyCountry(categories, series);
                function BindLabRejectedSamplebyCountry(categories, series) {
                    window.chart = new Highcharts.chart('rejectedSamples', {
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
                                text: 'Tests'
                            }},{
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
           
             // Postivity  Trend
            $(function GetLabEIDPoitivityTrendbyYeardata() {
                var subject = JSON.parse('<%=JstringLabEIDPoitivityTrendbyYear%>');
                var series = [],categories=[],data=[],name=[];
               
                    categories=['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
                    for (var i in subject) {
                        series.push({
                        
                            name: subject[i][12],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3],subject[i][4],subject[i][5],subject[i][6],subject[i][7],subject[i][8],subject[i][9],subject[i][10],subject[i][11],]

                   
                        }
                    );
                    }
                 
               

                    BindLabEIDPoitivityTrendByYear(categories, series);
                    function BindLabEIDPoitivityTrendByYear(categories, series) {
                        window.chart = new Highcharts.chart('postivitybyYear', {
                        chart: {
                            type: 'spline',
                            height: 250
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
                                text: 'Positivity'
                            }
                        },
                         
                        legend: {
                            layout: 'vertical',
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
                      <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataTextField="LaboratoryName" DataValueField="Id">
                                        <asp:ListItem Value="0">Select Laboratory</asp:ListItem>
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
						<h2>Lab Performance (<asp:Label ID="lblDatefromyear" runat="server" Text=""></asp:Label>-<asp:Label ID="lblDatetoyear" runat="server" Text=""></asp:Label>)</h2>
                       
                    </header>
                  
										<!-- add: non-hidden - to disable auto hide -->
                            
                    		<div role="content">
                                    
									    <div class="widget-body no-padding">
                                           <%-- <div class="dt-toolbar"><div class="col-xs-12 col-sm-6"><div id="dt_basic_filter" class="dataTables_filter"><label><span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span><asp:TextBox ID="txtLabName" CssClass="form-control" aria-controls="dt_basic" placeholder="Lab Name" runat="server" OnTextChanged="txtLabName_TextChanged" ></asp:TextBox></label></div></div><div class="col-sm-6 col-xs-12 hidden-xs"><div class="dataTables_length" id="dt_basic_length"></div></div></div>--%>
                                           <div class="table-responsive">                      		
                                                <asp:GridView ID="gvLabStats" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" Width="100%" ShowFooter="True" AllowPaging="True" OnPageIndexChanging="gvLabStats_PageIndexChanging">
                                                 <Columns>
                                                    <asp:BoundField HeaderText="LaboratoryName" DataField="LaboratoryName" />
                                                    <asp:BoundField HeaderText="Facilities Sending Samples" DataField="Facility" />
                                                     <asp:BoundField HeaderText="Rejected Samples" DataField="RejectedSamples" />
                                                     <asp:BoundField HeaderText="Test Done" DataField="TestDone" />
                                                     <asp:BoundField HeaderText="Intial PCR" DataField="IntialPCR" />
                                                     <asp:BoundField HeaderText="Intial Positive" DataField="IntialPositive" />
                                                     <asp:BoundField HeaderText="Confirmatory PCR" DataField="ConfirmatoryPCR" />
                                                     
                                                </Columns>
                                                    <PagerSettings
                                                     Mode="NextPreviousFirstLast" PageButtonCount="5" />
                                            </asp:GridView>
                                        
                                      </div>
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
						<h2>Positivity Trend</h2>
                    </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                      <div id="postivitybyYear" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
       		</article>
			<article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-3" data-widget-editbutton="false" role="widget" style="">
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>Rejection Rate</h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">                                        
                                       <div id="rejectionbyYear" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
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
						            <h2e>Tests with valid outcomes (Trends)</h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                      <div id="testTrendbyYear" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
			<article class="col-xs-12 col-sm-4 col-md-5 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-6" data-widget-editbutton="false" role="widget" style="">
								
								<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						            <h2>Tests with valid outcomes</h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                       <div id="testOutcomes" style="min-width: 310px; height: 300px; max-width: 600px; margin: 0 auto"></div>
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
                                        <asp:Label ID="lbloutcomeProFac" runat="server" Text="National Rejection"></asp:Label></h2>
                                </header>
                 				<div role="content">
                                    <div class="widget-body no-padding">
                                        
                                      <div id="rejectedSamples" style="min-width: 1024px; height: 300px;  margin: 0 auto"></div>
                                    </div>
								</div>
				</div>
			</article>
		</div>
        		<!-- end row -->
     </section>
   </asp:Content>
