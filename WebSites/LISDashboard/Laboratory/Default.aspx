<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CHAI.LISDashboard.Modules.EID.Views.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <script src="../js/libs/jquery-2.0.2.min.js"></script>
      <!-- HIGHCHART:  -->
    <script src="../js/plugin/HighCharts/highcharts.js"></script>
    <script src="../js/plugin/HighCharts/series-label.js"></script>
    <script src="../js/plugin/HighCharts/exporting.js"></script>
    <script src="../js/plugin/HighCharts/export-data.js"></script>    
    <script type="text/javascript">
        function RedrawLabDataEntryPerformance(jsonString) {            
            BindLabDataEntryPerformance(JSON.stringify(jsonString));
        }

        function RedrawLabTestingPerformance(jsonString) {            
            BindLabTestingPerformance(JSON.stringify(jsonString));
        }

        $(document).ready(function () {            
            BindLabDataEntryPerformance('<%= JstringLabDataEntry %>');
            BindLabTestingPerformance('<%= JstringLabTestingPerformance %>');
        });

        function BindLabDataEntryPerformance(jsonString) {
            var subject = JSON.parse(jsonString);
            var series = [], labs = [], categories = [], data = [], name = [];
            var colors = ['#27AE60', '#2980B9', '#F4D03F', '#FF5733']; //#C0392B

            for (var i in subject) {
                var found = false;
                for (var c = 0 ; c < categories.length ; c++) {
                    if (categories[c] == subject[i][1]) {
                        found = true;
                        break;
                    }                        
                }
                if (!found)
                    categories.push(subject[i][1]);

                //search for lab_name
                found = false;
                for (var labIdx = 0 ; labIdx < labs.length ; labIdx++) {
                    if (labs[labIdx] == subject[i][2]) {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    labs.push(subject[i][2]);
            }
                
            for (var labIdx in labs) {
                var data = [];                    
                for (var c in categories) {
                    cat_found = false;
                    for (var i in subject) {                                                
                        if (subject[i][2] == labs[labIdx] && subject[i][1] == categories[c]) {
                            data.push(subject[i][0]);
                            cat_found = true;
                        }
                    }
                    if (!cat_found)
                        data.push(0);
                }                    

                series.push({
                    //color: selColor,
                    name: labs[labIdx],
                    data: data,
                    //showInLegend: false,
                });
            }

            window.chart = new Highcharts.chart('LabDataEntryPerformance', {
                chart: {
                    type: 'spline',
                    height: 500
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: categories,
                    gridLineWidth: 1
                },
                yAxis: {
                    min: 0,
                    tickInterval: 50,
                    title: {
                        text: 'No. of Records'
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
                    shadow: false,
                },
                tooltip: {                    
                    formatter: function () {
                        var s = '<b>' + this.x + '</b>',
                            sum = 0;

                        $.each(this.points, function (i, point) {
                            if (point.y > 0) {
                                s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name + ': ' +
                                    point.y;
                                sum += point.y;
                            }
                        });
                        s += '<br/>Total: ' + sum;
                        return s;
                    },
                    shared: true
                },
                plotOptions: {
                    column: {
                        stacking: 'normal',
                        dataLabels: {
                            enabled: false,
                            color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                        }
                    },
                    series: {
                        label: {
                            connectorAllowed: false,
                            enabled: false,
                        },
                        //pointStart: 2010
                    }
                },
                series: series,

                responsive: {
                    rules: [{
                        condition: {
                            maxWidth: 500
                        },
                        chartOptions: {
                            legend: {
                                layout: 'horizontal',
                                align: 'center',
                                verticalAlign: 'bottom'
                            }
                        }
                    }]
                }

            });
        }

        function BindLabTestingPerformance(jsonString) {            
            var subject = JSON.parse(jsonString);
            var series = [], labs = [], categories = [], data = [], name = [];
            var colors = ['#27AE60', '#2980B9', '#F4D03F', '#FF5733']; //#C0392B

            for (var i in subject) {
                var found = false;
                for (var c = 0 ; c < categories.length ; c++) {
                    if (categories[c] == subject[i][1]) {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    categories.push(subject[i][1]);

                //search for lab_name
                found = false;
                for (var labIdx = 0 ; labIdx < labs.length ; labIdx++) {
                    if (labs[labIdx] == subject[i][2]) {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    labs.push(subject[i][2]);
            }

            for (var labIdx in labs) {
                var data = [];
                for (var c in categories) {
                    cat_found = false;
                    for (var i in subject) {
                        if (subject[i][2] == labs[labIdx] && subject[i][1] == categories[c]) {
                            data.push(subject[i][0]);
                            cat_found = true;
                        }
                    }
                    if (!cat_found)
                        data.push(0);
                }

                series.push({
                    //color: selColor,
                    name: labs[labIdx],
                    data: data,
                    //showInLegend: false,
                });
            }

            window.chart = new Highcharts.chart('LabTestingPerformance', {
                chart: {
                    type: 'spline',
                    height: 500
                },
                title: {
                    text: ''
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: categories,
                    gridLineWidth: 1
                },
                yAxis: {
                    min: 0,
                    tickInterval: 50,
                    title: {
                        text: 'No. of Records'
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
                    shadow: false,
                },
                tooltip: {
                    formatter: function () {
                        var s = '<b>' + this.x + '</b>',
                            sum = 0;

                        $.each(this.points, function (i, point) {
                            if (point.y > 0) {
                                s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name + ': ' +
                                    point.y;
                                sum += point.y;
                            }
                        });
                        s += '<br/>Total: ' + sum;
                        return s;
                    },
                    shared: true
                },
                plotOptions: {
                    column: {
                        stacking: 'normal',
                        dataLabels: {
                            enabled: false,
                            color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                        }
                    },
                    series: {
                        label: {
                            connectorAllowed: false,
                            enabled: false,
                        },
                        //pointStart: 2010
                    }
                },
                series: series,

                responsive: {
                    rules: [{
                        condition: {
                            maxWidth: 500
                        },
                        chartOptions: {
                            legend: {
                                layout: 'horizontal',
                                align: 'center',
                                verticalAlign: 'bottom'
                            }
                        }
                    }]
                }

            });
        }
    </script>
    <style>
        
    </style>

    		<!-- MAIN CONTENT -->
			<div id="content">
				<div class="row">
                    <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">                
		                <h1 class="page-title txt-color-blueDark">
                            <i class="fa fa-table fa-fw "></i>
                            Laboratory <span>&gt; Data Sync Summary</span>
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
						<article class="col-sm-12 col-md-12 col-lg-6">

							<!-- Widget ID (each widget will need unique ID)-->
							<div class="jarviswidget jarviswidget-color-greenDark" id="wid-id-0" data-widget-editbutton="false">
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
									<h2>Upload Datetime by Laboratory </h2>
								</header>

								<!-- widget div-->
								<div>

									<!-- widget edit box -->
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->

									</div>
									<!-- end widget edit box -->

									<!-- widget content -->
									<div class="widget-body no-padding">
										
										<div class="alert alert-info no-margin fade in">
											<button class="close" data-dismiss="alert">
												×
											</button>
											<i class="fa-fw fa fa-info"></i>
											Upload Datetime by Laboratory 
										</div>
										<div id="divLastUploadDateimeData" class="table-responsive" style="overflow: scroll; width: 100%" runat="server">	
										 <%--<% Response.Write(BindingLastUploadDateimeData()); %>--%>
										</div>
									</div>
									<!-- end widget content -->

								</div>
								<!-- end widget div -->

							</div>
							<!-- end widget -->

						</article>
						<!-- WIDGET END -->

						<!-- NEW WIDGET START -->
						<article class="col-sm-12 col-md-12 col-lg-6">

							<!-- Widget ID (each widget will need unique ID)-->
							<div class="jarviswidget jarviswidget-color-greenLight" id="wid-id-1" data-widget-editbutton="false">                                
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
									<h2>Total Upload Records</h2>

								</header>

								<!-- widget div-->
								<div>

									<!-- widget edit box -->
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->

									</div>
									<!-- end widget edit box -->

									<!-- widget content -->
									<div class="widget-body no-padding">
										
										<div class="alert alert-info no-margin fade in">
											<button class="close" data-dismiss="alert">
												×
											</button>
											<i class="fa-fw fa fa-info"></i>
											Total Upload Records
										</div>										
                                        <div id="divTotalUploadRecordsData" class="table-responsive" style="overflow: scroll; width: 100%" runat="server">	
                                            <%--<% Response.Write(BindingTotalUploadRecordsData()); %>--%>											
										</div>
									</div>
									<!-- end widget content -->

								</div>
								<!-- end widget div -->

							</div>
							<!-- end widget -->

						</article>
						<!-- WIDGET END -->
                        
                        <article class="col-xs-24 col-sm-12 col-md-12 col-lg-12">
                            <!-- Widget ID (each widget will need unique ID)-->
							<div class="jarviswidget jarviswidget-color-greenDark" id="wid-id-2" data-widget-editbutton="false">								
                                <header>
									<span class="widget-icon"> <i class="fa fa-table"></i> </span>
									<h2>Data Entry Performance</h2>
								</header>
								<!-- widget div-->
								<div>

									<!-- widget edit box -->
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->

									</div>
									<!-- end widget edit box -->

									<!-- widget content -->
									<div class="widget-body no-padding">										
										<div class="alert alert-info no-margin fade in">
											<button class="close" data-dismiss="alert">
												×
											</button>
											<i class="fa-fw fa fa-info"></i>
											Data Entry Performance 
										</div>
										<div id="dvTableDataEntryPerformance" class="table-responsive" style="overflow: scroll; width: 100%" runat="server">
										    <%--<% Response.Write(BindingDataEntryPerformance()); %>--%>
										</div>
									</div>
									<!-- end widget content -->
								</div>
								<!-- end widget div -->
							</div>
							<!-- end widget -->
                        </article>                                               				
					</div>
					<!-- end row -->

                    <div class="row">                    
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>                            
		                    <article class="col-xs-24 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                            <div class="jarviswidget jarviswidget-color-greenDark jarviswidget-sortable" id="wid-id-data-entry-performance" data-widget-editbutton="false" role="widget">
				                <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
					                <h2>Data Entry Performance</h2>                    
                                </header>                
                                <div role="content">
                                    <div class="widget-body-toolbar">
                                        <div class="row">
                                            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 pull-left">
							                    <span>Year & Month:&nbsp;</span>
						                    </div>
                                            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 pull-left">
                                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 pull-left">
                                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1 pull-left">
                                                <asp:Label ID="Label1" runat="server" Text="Laboratory:"></asp:Label>
                                            </div>
                                            <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3 pull-left">
                                                <asp:DropDownList ID="ddlLab" runat="server" AutoPostBack="false" CssClass="form-control">
                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>                                            
                                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1 pull-left">
                                                <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-default btn-primary" OnClick="btnFilter_Click" />
                                            </div>
                                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1 pull-left">
                                                <asp:UpdateProgress ID="updatePro" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                    <ProgressTemplate>
                                                        <asp:Image ImageUrl="~/img/ajax-loader2.gif" runat="server" ID="waitsymbolDataEntry" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widget-body no-padding">                                        
                                        <div id="LabDataEntryPerformance" style="min-width: 1024px; height: 500px; margin: 0 auto"></div>
                                    </div>
				                </div>
			                </div>
       	                </article>
                        </ContentTemplate>
                    </asp:UpdatePanel>                    
                    </div>

                    <div class="row">                    
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>                            
		                    <article class="col-xs-24 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                            <div class="jarviswidget jarviswidget-color-greenDark jarviswidget-sortable" id="wid-id-data-testing-performance" data-widget-editbutton="false" role="widget">
				                <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
					                <h2>Testing Performance</h2>                    
                                </header>                
                                <div role="content">
                                    <div class="widget-body-toolbar">
                                        <div class="row">
                                            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 pull-left">
							                    <span>Year & Month:&nbsp;</span>
						                    </div>
                                            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 pull-left">
                                                <asp:DropDownList ID="ddlYear2" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 pull-left">
                                                <asp:DropDownList ID="ddlMonth2" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1 pull-left">
                                                <asp:Label ID="Label2" runat="server" Text="Laboratory:"></asp:Label>
                                            </div>
                                            <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3 pull-left">
                                                <asp:DropDownList ID="ddlLab2" runat="server" AutoPostBack="false" CssClass="form-control">
                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>                                            
                                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1 pull-left">
                                                <asp:Button ID="btnTestingPerformanceFilter" runat="server" Text="Filter" CssClass="btn btn-default btn-primary" OnClick="btnTestingPerformanceFilter_Click" />
                                            </div>
                                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1 pull-left">
                                                <asp:UpdateProgress ID="UpdateProgress2" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                                    <ProgressTemplate>
                                                        <asp:Image ImageUrl="~/img/ajax-loader2.gif" runat="server" ID="waitsymbolTestingPerformance" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widget-body no-padding">                                        
                                        <div id="LabTestingPerformance" style="min-width: 1024px; height: 500px; margin: 0 auto"></div>
                                    </div>
				                </div>
			                </div>
       	                </article>
                        </ContentTemplate>
                    </asp:UpdatePanel>                    
                    </div>
				</section>
				<!-- end widget grid -->
			</div>
			<!-- END MAIN CONTENT -->



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
   
</asp:Content>


