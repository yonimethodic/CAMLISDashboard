<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="FrmOnlineStatus.aspx.cs" Inherits="CHAI.LISDashboard.Modules.EID.Views.FrmOnlineStatus" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <script src="../js/libs/jquery-2.0.2.min.js"></script>
      <!-- HIGHCHART:  -->
    <script src="../js/plugin/HighCharts/highcharts.js"></script>
    <script src="../js/plugin/HighCharts/series-label.js"></script>
    <script src="../js/plugin/HighCharts/exporting.js"></script>
    <script src="../js/plugin/HighCharts/export-data.js"></script>
        
    <script type="text/javascript">
        
        function RedrawOnlineStatusHistory(jsonString) {            
            BindOnlineStatusHistory(JSON.stringify(jsonString));
        }

        $(document).ready(function () {

            $('#datetimepicker1').datetimepicker({
                format: 'MM/DD/YYYY'
            });
            $('#datetimepicker2').datetimepicker({
                format: 'MM/DD/YYYY'
            });

            BindOnlineStatusByDateRange();
            BindOnlineStatusHistory('<%= jsonLabPerformanceHistory %>');
        });

        // OnlineStatus by Date Range
        function BindOnlineStatusByDateRange() {
            var subject = JSON.parse('<%= jsonLabPerformance %>');                
            var series = [], categories = [], data = [], name = [];
            var cat1_total = 0, cat2_total = 0, cat3_total = 0, cat4_total = 0;
            var cat1_data = [], cat2_data = [], cat3_data = [], cat4_data = [];
            var sites = [];
            categories = ['0-7 days', '8-14 days', '15-30 days', '>30 days'];
            var colors = ['#27AE60', '#2980B9', '#F4D03F', '#FF5733']; //#C0392B

            for (var i in subject) {
                cat1_total += subject[i][0];
                cat2_total += subject[i][1];
                cat3_total += subject[i][2];
                cat4_total += subject[i][3];

                cat1_data[i] = subject[i][0];
                cat2_data[i] = subject[i][1];
                cat3_data[i] = subject[i][2];
                cat4_data[i] = subject[i][3];

                sites[i] = subject[i][4];
            }

            data.push({
                name: categories[0],
                y: cat1_total,
                color: colors[0],
                drilldown: {
                    name: categories[0],
                    categories: sites,
                    data: cat1_data
                }
            });
            data.push({
                name: categories[1],
                y: cat2_total,
                color: colors[1],
                drilldown: {
                    name: categories[1],
                    categories: sites,
                    data: cat2_data
                }
            });
            data.push({
                name: categories[2],
                y: cat3_total,
                color: colors[2],
                drilldown: {
                    name: categories[2],
                    categories: sites,
                    data: cat3_data
                }
            });
            data.push({
                name: categories[3],
                y: cat4_total,
                color: colors[3],
                drilldown: {
                    name: categories[3],
                    categories: sites,
                    data: cat4_data
                }
            });

            for (var i in subject) {
                series.push({
                    name: subject[i][4],
                    data: [subject[i][0], subject[i][1], subject[i][2], subject[i][3],],
                });
            }

            window.chart = new Highcharts.chart('LabPerformanceByDateRange', {
                chart: {
                    renderTo: 'chart',
                    type: 'pie',
                    height: 350,
                    spacingTop: 50
                },
                title: {
                    text: ''
                },
                //subtitle: {
                //    text: 'Source: <a href="http://statcounter.com" target="_blank">statcounter.com</a>'
                //},
                'labelFormatter': function () {
                    var total = 0, percentage;
                    $.each(this.series.data, function () {
                        total += this.y;
                    });

                    percentage = ((this.y / total) * 100).toFixed(1);
                    return this.name + ' ' + percentage + '%';
                },
                yAxis: {
                    title: {
                        text: 'Percent'
                    }
                },
                tooltip: {
                    //valuesuffix: '%'
                    pointFormat: '<span style="color:{series.color}">{point.name} days</span>: <b>{point.percentage:.1f}%</b>',
                    split: false
                },
                //legend:{                            
                //    align: 'left',
                //    layout: 'vertical',
                //    verticalAlign: 'top',
                //    x: 40,
                //    y: 0
                //},
                plotOptions: {
                    pie: {
                        shadow: false,
                        borderWidth: 0,
                        depth: 50
                    },
                    series: {
                        cursor: 'pointer',
                        point: {
                            events: {
                                click: function () {
                                    //alert('Category: ' + this.drilldown.categories[0] + ', value: ' + this.y);
                                    var detail = '<table id="dt_online_basic" class="table table-striped table-bordered table-hover"  style="margin-bottom: 0px">' +
                                        '<thead><tr><th>Sr.</th><th>Laboratory Name</th></tr></thead><tbody>';
                                    var sr = 1;
                                    for (var i in this.drilldown.categories) {
                                        if (this.drilldown.data[i] > 0) {
                                            detail += '<tr>';
                                            detail += '<td style="text-align: center">' + sr + '</td><td>' + this.drilldown.categories[i] + '</td>';
                                            detail += '</tr>';
                                            sr++;
                                        }
                                    };
                                    detail += '</tbody></table>';
                                    $('#LabPerformanceDetail').html(detail);
                                    $('#LabPerformanceDetailTitle').html('Online Status: ' + this.name);
                                }
                            }
                        }
                    }
                },
                series: [{
                    data: data,
                    size: '100%',
                    innerSize: '50%',
                    showInLegend: true,
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            return this.point.name
                        },
                        distance: 10,
                        //format: '<b>{point.name} days</b>: {point.percentage:.1f} %',
                        format: '<b>{point.percentage:.1f} %',
                    }
                }]
            });

            ShowOnlineStatusDetail(data[0].name, data[0].drilldown.categories, cat1_data);
        }

        // OnlineStatus Detail
        function ShowOnlineStatusDetail(category, sites, cat1_data) {
            //alert('Category: ' + this.drilldown.categories[0] + ', value: ' + this.y);
            var detail = '<table id="dt_online_basic" class="table table-striped table-bordered table-hover" style="margin-bottom: 0px">' +
                '<thead><tr><th>Sr.</th><th>Laboratory Name</th></thead><tbody></tr>';
            var sr = 1;
            for (var i in sites) {
                //alert(cat1_data[i]);
                if (cat1_data[i] > 0) {
                    detail += '<tr>';
                    detail += '<td style="text-align: center">' + sr + '</td><td>' + sites[i] + '</td>';
                    detail += '</tr>';
                    sr++;
                }
            }
            detail += '</tbody></table>';
            $('#LabPerformanceDetail').html(detail);
            $('#LabPerformanceDetailTitle').html('Online Status: ' + category);
        }

        function BindOnlineStatusHistory(jsonString) {
            var subject = JSON.parse(jsonString);
            var series = [], categories = [], data = [], name = [];
            categories = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
            var colors = ['#27AE60', '#2980B9', '#F4D03F', '#FF5733']; //#C0392B
            for (var i in subject) {
                var selColor = null;
                if (subject[i][12] == '0-7')
                    selColor = colors[0];
                else if (subject[i][12] == '8-14')
                    selColor = colors[1];
                else if (subject[i][12] == '15-30')
                    selColor = colors[2];
                else
                    selColor = colors[3];
                series.push({
                    color: selColor,
                    name: subject[i][12] + ' days',
                    data: [subject[i][0], subject[i][1], subject[i][2], subject[i][3], subject[i][4], subject[i][5], subject[i][6], subject[i][7], subject[i][8], subject[i][9], subject[i][10], subject[i][11], ]
                });
            }
                
            window.chart = new Highcharts.chart('LabPerformanceHistory', {
                chart: {
                    type: 'area'
                },
                title: {
                    text: ''
                },
                xAxis: {
                    categories: categories,
                    gridLineWidth: 1,
                    tickmarkPlacement: 'on'
                },
                yAxis: {
                    title: {
                        text: 'Percent'
                    }
                },
                legend: {
                    layout: 'horizontal',
                    align: 'center',
                    x: 0,
                    verticalAlign: 'bottom',
                    floating: false,
                    y: 0,
                    floating: false,
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                    borderColor: '#CCC',
                    borderWidth: 1,
                    shadow: false
                },
                tooltip: {
                    //headerFormat: '<b>{point.x}</b><br/>',
                    //pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                    pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.percentage:.1f}%</b> ({point.y:,.0f})<br/>',
                    split: true
                },
                color: colors,
                plotOptions: {
                    area: {
                        stacking: 'percent',
                        lineColor: '#ffffff',
                        lineWidth: 1,
                        marker: {
                            lineWidth: 1,
                            lineColor: '#ffffff'
                        },
                        //dataLabels: {
                        //    enabled: true,
                        //    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                        //}
                    }
                },
                series: series
            });
        }
       
    </script>    
   
    <div class="row">        
		<article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
            <div class="jarviswidget jarviswidget-sortable jarviswidget-color-greenDark" id="wid-id-1" data-widget-editbutton="false" role="widget" style="">
				<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>					
                    <h2>Online Status</h2>             
                </header>
                <div role="content">
                    <div class="widget-body no-padding">
                        <div id="LabPerformanceByDateRange" style="height: 400px; max-width: 600px; margin: 0 auto"></div>
                    </div>                    
				</div>                
			</div>                              
       	</article>
        <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
            <div class="jarviswidget jarviswidget-sortable jarviswidget-color-greenDark" id="wid-id-2" data-widget-editbutton="false" role="widget" style="">
				<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>					                  
                    <span class="widget-icon"><i class="fa fa-table"></i> </span>
					<h2 id="LabPerformanceDetailTitle"></h2>
                </header>
                <div role="content">
                    <div class="widget-body no-padding">
                        <div id="LabPerformanceDetail" style="height: 400px; max-width: 600px; margin: 0 auto; overflow-y: scroll">
                        </div>
                    </div>
				</div>
			</div>
       	</article>                    
    </div>
     
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>        
		    <article class="col-xs-24 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
            <div class="jarviswidget jarviswidget-sortable jarviswidget-color-greenDark" id="wid-id-3" data-widget-editbutton="false" role="widget" style="">
			    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
				    <h2>Online Status (History)</h2>                    
                </header>                
                <div role="content">
                    <div class="widget-body-toolbar">
                        <div class="row">
                            <div class="col-xs-2 col-sm-1 col-md-1 col-lg-1 pull-left">
							    <span>Year:&nbsp;</span>
						    </div>
                            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 pull-left">
                                <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1 pull-left">
                                <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-default btn-primary" OnClick="btnFilter_Click" />
                            </div>
                            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1 pull-left">
                                <asp:UpdateProgress ID="updatePro" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                    <ProgressTemplate>
                                        <asp:Image ImageUrl="~/img/ajax-loader2.gif" runat="server" ID="waitsymbol" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                    </div>

                    <div class="widget-body no-padding">
                        <div id="LabPerformanceHistory" style="min-width: 1024px; height: 300px; max-width: 600px; margin: 0 auto"></div>                        
                    </div>

                    <%--<div class="widget-body no-padding">                            
                        <div id="LabPerformanceHistoryLine" style="min-width: 1024px; height: 250px; max-width: 600px; margin: 0 auto"></div>
                    </div>

                    <div class="widget-body no-padding">                            
                        <div id="LabOnlineHistory" style="min-width: 1024px; height: 300px; max-width: 600px; margin: 0 auto"></div>
                    </div>--%>
			    </div>
		    </div>
            </article>
        </ContentTemplate>
        </asp:UpdatePanel>        			    
    </div>  

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>

