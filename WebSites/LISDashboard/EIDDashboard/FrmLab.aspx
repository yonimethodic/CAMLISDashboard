<%@ Page Title="EID Lab Dashboard" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="FrmLab.aspx.cs" Inherits="CHAI.LISDashboard.Modules.EIDDashboard.Views.FrmLab" %>
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

            $(".date-picker").datepicker({ 
                dateFormat: 'mm/yy',
                changeMonth: true,
                changeYear: true,
                showButtonPanel: false,
                yearRange: '2015:' + new Date().getFullYear(),

                onClose: function(dateText, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val(); 
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val(); 
                    $(this).val($.datepicker.formatDate('mm/yy', new Date(year, month, 1)));
                }
            });

            $(".date-picker").focus(function () {            
                $(".ui-icon-circle-triangle-w").html("&laquo;");
                $(".ui-icon-circle-triangle-e").html("&raquo;");                
                $(".ui-datepicker-calendar").hide();
                $("#ui-datepicker-div").position({
                    my: "center top",
                    at: "center bottom",
                    of: $(this)
                });    
            });

            $('#easyPie1').easyPieChart({
                animate: 1000,
                scaleColor: false,
                lineWidth: 6,
                lineCap: 'square',
                size: 60,
                trackColor: '#e5e5e5',
                barColor: '#3da0ea'
            });

            $('#easyPie2').easyPieChart({
                animate: 1000,
                scaleColor: false,
                lineWidth: 6,
                lineCap: 'square',
                size: 60,
                trackColor: '#e5e5e5',
                barColor: '#3da0ea'
            });

            $('#easyPie3').easyPieChart({
                animate: 1000,
                scaleColor: false,
                lineWidth: 6,
                lineCap: 'square',
                size: 60,
                trackColor: '#e5e5e5',
                barColor: '#3da0ea'
            });
                        
            // DNA PCR Test Yearly
            $(function GetEIDInitialPCRbyYearly() {
                var subject = JSON.parse('<%=JstringEIDInitialPCRbyYear%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [], Positivity=[];
                
                var sums = function(i)
                {                    
                    return No_Positive[i] + No_Negative[i];
                }

                for (var i in subject) {
                    categories.push(subject[i][3]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive,
                    type: 'column',
                },
                {
                    name: 'Negative',
                    data: No_Negative,
                    type: 'column',
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

                BindEIDInitialPCRbyYearly(categories, series);
                function BindEIDInitialPCRbyYearly(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRbyYear', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'DNA PCR Test Initial (Yearly)'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            gridLineWidth: 1,                        
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: 'Positivity',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                    sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y + (i == 2? ' %' : '');
                                    if(i != 2)
                                        sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });
           
            // EID All Test Outcome by Year
            //DNA PCR Test Quarterly
            $(function GetEIDInitialPCRbyQuarterly() {
                var subject = JSON.parse('<%=JstringEIDInitialPCRbyQuarter%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [], Positivity=[];
                
                var sums = function(i)
                {                    
                    return No_Positive[i] + No_Negative[i];
                }

                for (var i in subject) {
                    categories.push(subject[i][3]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                    Positivity.push(subject[i][2]);                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive,
                    type: 'column',
                },
                {
                    name: 'Negative',
                    data: No_Negative,
                    type: 'column',
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

                BindEIDInitialPCRbyQuarterly(categories, series);
                function BindEIDInitialPCRbyQuarterly(categories, series) {
                    window.chart = new Highcharts.chart('testAllTestbyYear', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'DNA PCR Test Initial ( <%= hdnStartDate.Value %> ) Quarterly'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            gridLineWidth: 1,                        
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: 'Positivity',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                    sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y + (i == 2? ' %' : '');
                                    if(i != 2)
                                        sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

            //Added by ZaySoe on 09_Jan_2019
            //DNA PCR Test Monthly
            $(function GetEIDInitialPCRbyMonthly() {
                var subject = JSON.parse('<%=JstringEIDInitialPCRbyMonth%>');
                var series = [], categories = [], No_Positive = [], No_Negative = [], Positivity=[];
                var sums = function(i)
                {                    
                    return No_Positive[i] + No_Negative[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    No_Positive.push(subject[i][0]);
                    No_Negative.push(subject[i][1]);
                    Positivity.push(subject[i][2]);                    
                }
                series.push({
                    name: 'Positive',
                    data: No_Positive,
                    type: 'column',
                },
                {
                    name: 'Negative',
                    data: No_Negative,
                    type: 'column',
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

                BindEIDInitialPCRbyMonthly(categories, series);
                function BindEIDInitialPCRbyMonthly(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRbyMonth', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: 'DNA PCR Test Initial ( <%= hdnStartDate.Value %> ) Monthly'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            gridLineWidth: 1,                        
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: 'Positivity',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                    sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y + (i == 2? ' %' : '');
                                    if(i != 2)
                                        sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

           // DNA PCR Test by Facility
            $(function GetEIDPCRdbyFacility() {
                var subject = JSON.parse('<%= JstringEIDPCRByFacility %>');
                //var subject = JSON.parse('[[0,2,0,0,0.00,"Amarapura Township Hospital"]]');
                var series = [], categories = [], Total_Tested = [], No_Positive = [], Positivity = [], Less2month_Rate = [];
                //No_Negative = [], less2m_positive = [], less2m_initial_positive = [], Target = [];
                
                //var sums = function(i)
                //{                    
                //    return No_Positive[i] + No_Negative[i] + less2m_positive[i] + less2m_initial_positive[i];
                //}
                for (var i in subject) {                    
                    categories.push(subject[i][4]);
                    Total_Tested.push(subject[i][0]);
                    No_Positive.push(subject[i][1]);
                    //No_Negative.push(subject[i][1]);
                    //less2m_positive.push(subject[i][2]);
                    //less2m_initial_positive.push(subject[i][3]);
                    Positivity.push(subject[i][2]);
                    Less2month_Rate.push(subject[i][3]);
                    //Target.push(90);
                }
                series.push({
                    name: 'Total Tested',
                    data: Total_Tested,
                    type: 'column',
                },
                {
                    name: 'Positive',
                    data: No_Positive,
                    type: 'column',
                },
                //{
                //    name: '<2m Positive',
                //    data: less2m_positive,
                //    type: 'column',
                //},
                //{
                //    name: '<2m Initial Positive',
                //    data: less2m_initial_positive,
                //    type: 'column',
                //},
                {
                    type: 'spline',
                    name: 'Positivity',
                    data: Positivity,
                    lineWidth: 0,
                    yAxis: 1,
                    //color: '#F2784B',
                    //marker: {
                    //    lineWidth: 2,
                    //    lineColor: '#cd0000',
                    //    fillColor: '#cd0000'
                    //    //lineColor: '#F2784B',
                    //    //fillColor: '#F2784B'
                    //}
                },
                {
                    type: 'spline',
                    name: '≤ 2 months',
                    data: Less2month_Rate,
                    lineWidth: 0,
                    yAxis: 1,
                    //color: '#1BA39C',
                    //marker: {
                    //    lineWidth: 2,
                    //    lineColor: '#1BA39C',
                    //    fillColor: '#1BA39C'
                    //    //lineColor: '#1BA39C',
                    //    //fillColor: '#1BA39C'
                    //}
                }
                //{
                //    type: 'spline',
                //    name: '90% Target',
                //    data: Target,
                //    yAxis: 1,
                //    color: '#1BA39C',
                //    marker: {
                //        lineWidth: 2,
                //        lineColor: '#1BA39C',
                //        fillColor: '#1BA39C'
                //    }
                //}              
                );

                BindEIDPCRbyFacility(categories, series);
                function BindEIDPCRbyFacility(categories, series) {
                    window.chart = new Highcharts.chart('EIDPCRbyFacility', {
                        chart: {
                            type: 'column'                            
                        },
                        title: {
                            text: 'DNA PCR Test Initial ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0,                            
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            tickInterval: 500,
                            gridLineWidth: 1,
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                },                                
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: 'Rate',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            //headerFormat: '<b>{point.x}</b><br/>',
                            //pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}',
                            //pointFormatter: function () {                                
                            //    return this.series.name + ': ' + this.y + '<br/>Total: ' + sums(this.x);
                            //}
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                    sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y + (i == 2 || i == 3? ' %' : '');
                                    if(i != 2 && i != 3)
                                        sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });                                                     

            //Added by ZaySoe on 09_Jan_2019
            // EID Initial PCR Age by Yearly       
            $(function GetEIDInitialPCRAgeByYearly() {
                var subject = JSON.parse('<%=JstringEIDIntialPCRAgeByYear%>');
                var series = [], categories = [], nodata = [], less2month = [], between2and6month = [], between6and9month = [], between9and18month = [], greaterthan18month = [], NoData = [], lessthan_2months_rate=[];
                var sums = function(i)
                {                    
                    return nodata[i] + less2month[i] + between2and6month[i] + between6and9month[i] + between9and18month[i] + greaterthan18month[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][7]);
                    nodata.push(subject[i][0]);
                    less2month.push(subject[i][1]);
                    between2and6month.push(subject[i][2]);
                    between6and9month.push(subject[i][3]);
                    between9and18month.push(subject[i][4]);
                    greaterthan18month.push(subject[i][5]);
                    //NoData.push(subject[i][5]);
                    lessthan_2months_rate.push(subject[i][6]);                    
                }
                series.push({
                        name: 'No Data',
                        data: nodata,
                        type: 'column',
                    },
                    {
                        name: '≤ 2 month',
                        data: less2month,
                        type: 'column'
                    },
                    {
                        name: '2-6 month',
                        data: between2and6month,
                        type: 'column'
                    },
                    {
                        name: '6-9 month',
                        data: between6and9month,
                        type: 'column'
                    },
                    {
                        name: '9-18 month',
                        data: between9and18month,
                        type: 'column'
                    },
                    {
                        name: '> 18 month',
                        data: greaterthan18month,
                        type: 'column'
                    },
                   //{
                   //     name: 'No Data',
                   //     data: NoData
                   //},
                    {
                       type: 'spline',
                       name: '≤ 2 months Testing Rate',
                       data: lessthan_2months_rate,
                       lineWidth: 2,
                       yAxis: 1,
                       marker: {
                           lineWidth: 2,
                           lineColor: Highcharts.getOptions().colors[3],
                           fillColor: 'black'
                       }
                   }
                );

                BindEIDInitialPCRAgeByYearly(categories, series);
                function BindEIDInitialPCRAgeByYearly(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRAgeByYearly', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: 'DNA PCR Test Initial by Age ( Yearly )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            gridLineWidth: 1,                        
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: '<2 months Testing Rate',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function () {
                                var s = '<b>' + this.x + '</b>',
                                    sum = 0;

                                $.each(this.points, function (i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name + ': ' +
                                        point.y + (i == 6 ? ' %' : '');
                                    if (i != 6)
                                        sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

            // EID Initial PCR Age by Quarterly       
            $(function GetEIDInitialPCRAgeByQuarterly() {
                var subject = JSON.parse('<%=JstringEIDIntialPCRAgeByQuarter%>');
                var series = [], categories = [], nodata = [], less2month = [], between2and6month = [], between6and9month = [], between9and18month = [], greaterthan18month = [], NoData = [], lessthan_2months_rate=[];
                var sums = function(i)
                {                    
                    return nodata[i] + less2month[i] + between2and6month[i] + between6and9month[i] + between9and18month[i] + greaterthan18month[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][7]);
                    nodata.push(subject[i][0]);
                    less2month.push(subject[i][1]);
                    between2and6month.push(subject[i][2]);
                    between6and9month.push(subject[i][3]);
                    between9and18month.push(subject[i][4]);
                    greaterthan18month.push(subject[i][5]);
                    //NoData.push(subject[i][5]);
                    lessthan_2months_rate.push(subject[i][6]);                    
                }
                series.push({
                        name: 'No Data',
                        data: nodata,
                        type: 'column',
                    },
                    {
                        name: '≤ 2 month',
                        data: less2month,
                        type: 'column'
                    },
                    {
                        name: '2-6 month',
                        data: between2and6month,
                        type: 'column'
                    },
                    {
                        name: '6-9 month',
                        data: between6and9month,
                        type: 'column'
                    },
                    {
                        name: '9-18 month',
                        data: between9and18month,
                        type: 'column'
                    },
                    {
                        name: '> 18 month',
                        data: greaterthan18month,
                        type: 'column'
                    },
                   //{
                   //     name: 'No Data',
                   //     data: NoData
                   //},
                    {
                       type: 'spline',
                       name: '≤ 2 months Testing Rate',
                       data: lessthan_2months_rate,
                       lineWidth: 2,
                       yAxis: 1,
                       marker: {
                           lineWidth: 2,
                           lineColor: Highcharts.getOptions().colors[3],
                           fillColor: 'black'
                       }
                   }
                );

                BindEIDInitialPCRAgeByQuarterly(categories, series);
                function BindEIDInitialPCRAgeByQuarterly(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRAgeByQuarterly', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: 'DNA PCR Test Initial by Age ( <%= hdnStartDate.Value %> ) Quarterly'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            gridLineWidth: 1,                        
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: '<2 months Testing Rate',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function () {
                                var s = '<b>' + this.x + '</b>',
                                    sum = 0;

                                $.each(this.points, function (i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name + ': ' +
                                        point.y + (i == 6 ? ' %' : '');
                                    if (i != 6)
                                        sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

            // EID Initial PCR Age by Monthly
            $(function GetEIDIntialPCRdAgeByMonthly() {
                var subject = JSON.parse('<%=JstringEIDIntialPCRAgeByMonth%>');
                var series = [], categories = [], nodata = [], less2month = [], between2and6month = [], between6and9month = [], between9and18month = [], greaterthan18month = [], NoData = [], lessthan_2months_rate=[];
                var sums = function(i)
                {                    
                    return nodata[i] + less2month[i] + between2and6month[i] + between6and9month[i] + between9and18month[i] + greaterthan18month[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][7]);
                    nodata.push(subject[i][0]);
                    less2month.push(subject[i][1]);
                    between2and6month.push(subject[i][2]);
                    between6and9month.push(subject[i][3]);
                    between9and18month.push(subject[i][4]);
                    greaterthan18month.push(subject[i][5]);
                    //NoData.push(subject[i][5]);
                    lessthan_2months_rate.push(subject[i][6]);                    
                }
                series.push({
                        name: 'No Data',
                        data: nodata,
                        type: 'column',
                    },
                    {
                        name: '≤ 2 month',
                        data: less2month,
                        type: 'column'
                    },
                    {
                        name: '2-6 month',
                        data: between2and6month,
                        type: 'column'
                    },
                    {
                        name: '6-9 month',
                        data: between6and9month,
                        type: 'column'
                    },
                    {
                        name: '9-18 month',
                        data: between9and18month,
                        type: 'column'
                    },
                    {
                        name: '> 18 month',
                        data: greaterthan18month,
                        type: 'column'
                    },
                   //{
                   //     name: 'No Data',
                   //     data: NoData
                   //},
                    {
                       type: 'spline',
                       name: '≤ 2 months Testing Rate',
                       data: lessthan_2months_rate,
                       lineWidth: 2,
                       yAxis: 1,
                       marker: {
                           lineWidth: 2,
                           lineColor: Highcharts.getOptions().colors[3],
                           fillColor: 'black'
                       }
                   }
                );

                BindEIDIntialPCRdAgeByMonthly(categories, series);
                function BindEIDIntialPCRdAgeByMonthly(categories, series) {
                    window.chart = new Highcharts.chart('testIntialPCRAgeByMonthly', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: 'DNA PCR Test Initial by Age ( <%= hdnStartDate.Value %> ) Monthly'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            gridLineWidth: 1,                        
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: '<2 months Testing Rate',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function () {
                                var s = '<b>' + this.x + '</b>',
                                    sum = 0;

                                $.each(this.points, function (i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name + ': ' +
                                        point.y + (i == 6 ? ' %' : '');
                                    if (i != 6)
                                        sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

            $(function GetEIDLabByLabInstrumentAbbott() {
                var subject = JSON.parse('<%= JstringEIDLabByLabInstrumentAbbott %>');                
                var series = [], categories = [], data = [], name = [];
                var selYear = <%= hdnStartDate.Value %>;                
                categories = ['Q1-' + selYear, 'Q2-' + selYear, 'Q3-' + selYear, 'Q4-' + selYear];
                var colors = ['#27AE60', '#2980B9', '#F4D03F', '#FF5733']; //#C0392B
                for (var i in subject) {
                    //var selColor = null;
                    //if (subject[i][12] == '0-7')
                    //    selColor = colors[0];
                    //else if (subject[i][12] == '8-14')
                    //    selColor = colors[1];
                    //else if (subject[i][12] == '15-30')
                    //    selColor = colors[2];
                    //else
                    //    selColor = colors[3];
                    series.push({
                        //color: selColor,
                        name: subject[i][4],
                        data: [subject[i][0], subject[i][1], subject[i][2], subject[i][3]]
                    });
                }
                
                BindEIDLabByLabInstrumentAbbott(categories, series);
                function BindEIDLabByLabInstrumentAbbott(categories, series) {
                    window.chart = new Highcharts.chart('VLLabByLabInstrumentAbbott', {
                        chart: {
                            type: 'area'
                        },
                        title: {                            
                            text: 'Abbott ( <%= hdnStartDate.Value %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1,
                            tickmarkPlacement: 'on'
                        },
                        yAxis: {
                            title: {
                                text: 'Number of  Tests'
                            },
                            labels: {
                                formatter: function () {
                                    return this.value;
                                }
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
                                stacking: 'normal', //percent
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
            });

            $(function GetEIDLabByLabInstrumentGeneXpert() {
                var subject = JSON.parse('<%= JstringEIDLabByLabInstrumentGeneXpert %>');                
                var series = [], categories = [], data = [], name = [];
                var selYear = <%= hdnStartDate.Value %>;                
                categories = ['Q1-' + selYear, 'Q2-' + selYear, 'Q3-' + selYear, 'Q4-' + selYear];
                var colors = ['#27AE60', '#2980B9', '#F4D03F', '#FF5733']; //#C0392B
                for (var i in subject) {
                    //var selColor = null;
                    //if (subject[i][12] == '0-7')
                    //    selColor = colors[0];
                    //else if (subject[i][12] == '8-14')
                    //    selColor = colors[1];
                    //else if (subject[i][12] == '15-30')
                    //    selColor = colors[2];
                    //else
                    //    selColor = colors[3];
                    series.push({
                        //color: selColor,
                        name: subject[i][4],
                        data: [subject[i][0], subject[i][1], subject[i][2], subject[i][3]]
                    });
                }
                
                BindEIDLabByLabInstrumentGeneXpert(categories, series);
                function BindEIDLabByLabInstrumentGeneXpert(categories, series) {
                    window.chart = new Highcharts.chart('VLLabByLabInstrumentGeneXpert', {
                        chart: {
                            type: 'area'
                        },
                        title: {                            
                            text: 'GeneXpert ( <%= hdnStartDate.Value %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1,
                            tickmarkPlacement: 'on'
                        },
                        yAxis: {
                            title: {
                                text: 'Number of DNA PCR Tests'
                            },
                            labels: {
                                formatter: function () {
                                    return this.value;
                                }
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
                                stacking: 'normal', //percent
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
            });

            $(function GetEIDLabByLabInstrumentBioCentric() {
                var subject = JSON.parse('<%= JstringEIDLabByLabInstrumentBioCentric %>');                
                var series = [], categories = [], data = [], name = [];
                var selYear = <%= hdnStartDate.Value %>;                
                categories = ['Q1-' + selYear, 'Q2-' + selYear, 'Q3-' + selYear, 'Q4-' + selYear];
                var colors = ['#27AE60', '#2980B9', '#F4D03F', '#FF5733']; //#C0392B
                for (var i in subject) {
                    //var selColor = null;
                    //if (subject[i][12] == '0-7')
                    //    selColor = colors[0];
                    //else if (subject[i][12] == '8-14')
                    //    selColor = colors[1];
                    //else if (subject[i][12] == '15-30')
                    //    selColor = colors[2];
                    //else
                    //    selColor = colors[3];
                    series.push({
                        //color: selColor,
                        name: subject[i][4],
                        data: [subject[i][0], subject[i][1], subject[i][2], subject[i][3]]
                    });
                }
                
                BindEIDLabByLabInstrumentBioCentric(categories, series);
                function BindEIDLabByLabInstrumentBioCentric(categories, series) {
                    window.chart = new Highcharts.chart('VLLabByLabInstrumentBioCentric', {
                        chart: {
                            type: 'area'
                        },
                        title: {                            
                            text: 'BioCentric ( <%= hdnStartDate.Value %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1,
                            tickmarkPlacement: 'on'
                        },
                        yAxis: {
                            title: {
                                text: 'Number of DNA PCR Tests'
                            },
                            labels: {
                                formatter: function () {
                                    return this.value;
                                }
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
                                stacking: 'normal', //percent
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
            });

            $(function GetEIDLabByLabInstrumentComparison() {
                var subject = JSON.parse('<%= JstringEIDLabByLabInstrumentComparison %>');                
                var series = [], categories = [], data = [], name = [];
                var selYear = <%= hdnStartDate.Value %>;                
                categories = ['Q1-' + selYear, 'Q2-' + selYear, 'Q3-' + selYear, 'Q4-' + selYear];
                var colors = ['#27AE60', '#2980B9', '#F4D03F', '#FF5733']; //#C0392B
                for (var i in subject) {
                    //var selColor = null;
                    //if (subject[i][12] == '0-7')
                    //    selColor = colors[0];
                    //else if (subject[i][12] == '8-14')
                    //    selColor = colors[1];
                    //else if (subject[i][12] == '15-30')
                    //    selColor = colors[2];
                    //else
                    //    selColor = colors[3];
                    series.push({
                        //color: selColor,
                        name: subject[i][4],
                        data: [subject[i][0], subject[i][1], subject[i][2], subject[i][3]]
                    });
                }
                
                BindEIDLabByLabInstrumentComparison(categories, series);
                function BindEIDLabByLabInstrumentComparison(categories, series) {
                    window.chart = new Highcharts.chart('VLLabByLabInstrumentComparison', {
                        chart: {
                            type: 'area'
                        },
                        title: {                            
                            text: 'All Instruments <%= hdnStartDate.Value %>'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1,
                            tickmarkPlacement: 'on'
                        },
                        yAxis: {
                            title: {
                                text: 'Number of DNA PCR Tests'
                            },
                            labels: {
                                formatter: function () {
                                    return this.value;
                                }
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
                                stacking: 'normal', //percent
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
            });

            // VL Test Reason All Instruments By Lab
            $(function GetEIDTestReasonAllInstruments() {
                var subject = JSON.parse('<%= JstringEIDTestReasonAll %>');
                var series = [], categories = [], cat1 = [], cat2 = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    cat1.push(subject[i][0]);
                    cat2.push(subject[i][1]);                    
                }
                series.push({
                    name: 'Initial First Time',
                    data: cat1
                },
                {
                    name: 'Repeat Confirmatory',
                    data: cat2
                }
            );

                BindEIDTestReasonAllInstruments(categories, series);
                function BindEIDTestReasonAllInstruments(categories, series) {
                    window.chart = new Highcharts.chart('eidTestReasonAllInstruments', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'All ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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
                                    text: 'Percentage',
                              
                                },
                                gridLineWidth: 1,
                                opposite: true,
                                min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y;                                    
                                    sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

            // VL Test By Lab (Abbott)
            $(function GetEIDTestReasonByAbbott() {
                var subject = JSON.parse('<%= JstringEIDTestReasonByAbbott %>');
                var series = [], categories = [], cat1 = [], cat2 = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    cat1.push(subject[i][0]);
                    cat2.push(subject[i][1]);                    
                }
                series.push({
                    name: 'Initial First Time',
                    data: cat1
                },
                {
                    name: 'Repeat Confirmatory',
                    data: cat2
                }
            );

                BindEIDTestReasonByAbbott(categories, series);
                function BindEIDTestReasonByAbbott(categories, series) {
                    window.chart = new Highcharts.chart('eidTestReasonByAbbott', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'Abbott ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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
                                    text: 'Percentage',
                              
                                },
                                gridLineWidth: 1,
                                opposite: true,
                                min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y;                                    
                                    sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

            // VL Test By Lab (GeneXpert)
            $(function GetEIDTestReasonByGeneXpert() {
                var subject = JSON.parse('<%= JstringEIDTestReasonByGeneXpert %>');
                var series = [], categories = [], cat1 = [], cat2 = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    cat1.push(subject[i][0]);
                    cat2.push(subject[i][1]);                    
                }
                series.push({
                    name: 'Initial First Time',
                    data: cat1
                },
                {
                    name: 'Repeat Confirmatory',
                    data: cat2
                }
            );

                BindEIDTestReasonByGeneXpert(categories, series);
                function BindEIDTestReasonByGeneXpert(categories, series) {
                    window.chart = new Highcharts.chart('eidTestReasonByGeneXpert', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'GeneXpert ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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
                                    text: 'Percentage',
                              
                                },
                                gridLineWidth: 1,
                                opposite: true,
                                min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y;                                    
                                    sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

            // VL Test By Lab (BioCentric)
            $(function GetEIDTestReasonByBioCentric() {
                var subject = JSON.parse('<%= JstringEIDTestReasonByBioCentric %>');
                var series = [], categories = [], cat1 = [], cat2 = [];
                
                for (var i in subject) {
                    categories.push(subject[i][2]);
                    cat1.push(subject[i][0]);
                    cat2.push(subject[i][1]);                    
                }
                series.push({
                    name: 'Initial First Time',
                    data: cat1
                },
                {
                    name: 'Repeat Confirmatory',
                    data: cat2
                }
            );

                BindEIDTestReasonByBioCentric(categories, series);
                function BindEIDTestReasonByBioCentric(categories, series) {
                    window.chart = new Highcharts.chart('eidTestReasonByBioCentric', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'BioCentric ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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
                                    text: 'Percentage',
                              
                                },
                                gridLineWidth: 1,
                                opposite: true,
                                min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y;                                    
                                    sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

            // VL Test PieChart All Instruments Pie Chart
            $(function GetEIDTestReasonAllInstrumentsPieChart() {
                var subject = JSON.parse('<%= JstringEIDTestReasonAll %>');
                var series = [], categories = [], cat1_total = 0, cat2_total = 0, cat3_total = 0;
                for (var i in subject) {                    
                    categories.push(subject[i][2]);
                    cat1_total += subject[i][0];
                    cat2_total += subject[i][1];                    
                }

                var slice_data = [];
                slice_data.push({
                    name: 'Initial First TIme',
                    y: cat1_total
                },
                {
                    name: 'Repeat Confirmatory',                    
                    y: cat2_total
                });
                
                series.push({
                    name: 'Reasons',
                    colorByPoint: true,                    
                    data: slice_data
                });

                BindEIDTestReasonAllInstrumentsPieChart(categories, series);
                function BindEIDTestReasonAllInstrumentsPieChart(categories, series) {
                    window.chart = new Highcharts.chart('eidTestReasonAllInstrumentsPieChart', {
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: '( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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

            // VL Test PieChart By Abbott Pie Chart
            $(function GetEIDTestReasonByAbbottPieChart() {
                var subject = JSON.parse('<%= JstringEIDTestReasonByAbbott %>');
                var series = [], categories = [], cat1_total = 0, cat2_total = 0, cat3_total = 0;
                for (var i in subject) {                    
                    categories.push(subject[i][2]);
                    cat1_total += subject[i][0];
                    cat2_total += subject[i][1];                    
                }

                var slice_data = [];
                slice_data.push({
                    name: 'Initial First TIme',
                    y: cat1_total
                },
                {
                    name: 'Repeat Confirmatory',                    
                    y: cat2_total
                });
                
                series.push({
                    name: 'Reasons',
                    colorByPoint: true,                    
                    data: slice_data
                });

                BindEIDTestReasonByAbbottPieChart(categories, series);
                function BindEIDTestReasonByAbbottPieChart(categories, series) {
                    window.chart = new Highcharts.chart('eidTestReasonByAbbottPieChart', {
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: '( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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

            // VL Test PieChart By GeneXpert Pie Chart
            $(function GetEIDTestReasonByGeneXpertPieChart() {
                var subject = JSON.parse('<%= JstringEIDTestReasonByGeneXpert %>');
                var series = [], categories = [], cat1_total = 0, cat2_total = 0, cat3_total = 0;
                for (var i in subject) {                    
                    categories.push(subject[i][2]);
                    cat1_total += subject[i][0];
                    cat2_total += subject[i][1];                    
                }

                var slice_data = [];
                slice_data.push({
                    name: 'Initial First TIme',
                    y: cat1_total
                },
                {
                    name: 'Repeat Confirmatory',                    
                    y: cat2_total
                });
                
                series.push({
                    name: 'Reasons',
                    colorByPoint: true,                    
                    data: slice_data
                });

                BindEIDTestReasonByGeneXpertPieChart(categories, series);
                function BindEIDTestReasonByGeneXpertPieChart(categories, series) {
                    window.chart = new Highcharts.chart('eidTestReasonByGeneXpertPieChart', {
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: '( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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

            // VL Test PieChart By BioCentric Pie Chart
            $(function GetEIDTestReasonByBioCentricPieChart() {
                var subject = JSON.parse('<%= JstringEIDTestReasonByBioCentric %>');
                var series = [], categories = [], cat1_total = 0, cat2_total = 0;
                for (var i in subject) {                    
                    categories.push(subject[i][2]);
                    cat1_total += subject[i][0];
                    cat2_total += subject[i][1];                
                }

                var slice_data = [];
                slice_data.push({
                    name: 'Initial First TIme',
                    y: cat1_total
                },
                {
                    name: 'Repeat Confirmatory',                    
                    y: cat2_total
                });
                
                series.push({
                    name: 'Reasons',
                    colorByPoint: true,                    
                    data: slice_data
                });

                BindEIDTestReasonByAbbottPieChart(categories, series);
                function BindEIDTestReasonByAbbottPieChart(categories, series) {
                    window.chart = new Highcharts.chart('eidTestReasonByBioCentricPieChart', {
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: '( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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

            // VL Test By State and Region & Facilities
            $(function GetEIDTestByStateRegionFacility() {
                var subject = JSON.parse('<%= JstringEIDTestByLabFaclility %>');
                var series = [], categories = [], tests = [], noOfFacilities = [], facilities = [], total_test_by_fac = [];
                var sums = function(i)
                {                    
                    return tests[i];
                }
                var facList = function(i)
                {                    
                    return facilities[i];                    
                }
                var totalTestList = function(x, facilityId)
                {                    
                    testCountArray = String(total_test_by_fac[x]).split('$');                    
                    for (i=0 ; i<testCountArray.length ; i++) {                        
                        token = testCountArray[i].split(';');
                        tokenid = token[0];
                        tokenval = token[1];                        
                        if(facilityId == tokenid)                                                   
                            return tokenval;                        
                    }                    
                    return 0;
                }
                for (var i in subject) {
                    //alert(subject[i][0] + ', ' + subject[i][1] + ', ' + subject[i][2]);
                    categories.push(subject[i][1]);
                    tests.push(subject[i][0]);
                    noOfFacilities.push(subject[i][2]);
                    facilities[i] = subject[i][3];
                    total_test_by_fac[i] = subject[i][4];
                }                
                                
                series.push({
                    name: 'State & Regions',
                    data: tests,
                    type: 'column',                    
                },
                {
                    type: 'spline',
                    name: 'Facilities',
                    data: noOfFacilities,
                    lineWidth: 0,
                    yAxis: 1,
                    color: '#F2784B',
                    marker: {
                        lineWidth: 2,                        
                        lineColor: '#F2784B',
                        fillColor: '#F2784B',
                        symbol: 'diamond' // square
                    }                    
                });

                BindEIDTestByStateRegionFacility(categories, series);
                function BindEIDTestByStateRegionFacility(categories, series) {
                    window.chart = new Highcharts.chart('eidTestByStateRegionFacility', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: 'DNA PCR Test Facilities by State & Region'
                        },
                        subtitle: {                            
                            text: '( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            gridLineWidth: 1,
                            title: {
                                text: 'Number of Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: 'Number of Facility',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 300,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],
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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y;                                    
                                    sum += point.y;
                                });

                                //s += '<br/>Total: ' + sum;

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
                            spline: {
                                marker: {
                                    radius: 4,
                                    lineColor: '#666666',
                                    lineWidth: 1
                                }
                            },
                            series: {
                                cursor: 'pointer',
                                point: {
                                    events: {
                                        click: function () {
                                            var detail = '<table id="dt_online_basic" class="table table-striped table-bordered table-hover"  style="margin-bottom: 0px">' +
                                                //'<caption><b>' + this.category + '</b></caption>' +
                                                '<thead><tr><th>Sr.</th><th>Facility</th><th>Total Test</th></thead><tbody></tr>';
                                            var sr = 1;
                                            var list = facList(this.x).split("$");
                                            for (var i in list) {                                                
                                                if (list[i].trim() != '') {
                                                    id = list[i].trim().split("=")[0];
                                                    name = list[i].trim().split("=")[1];
                                                    total_test = totalTestList(this.x, id)
                                                    detail += '<tr>';
                                                    detail += '<td style="text-align: center">' + sr + '</td><td>' + name + '</td><td>' + total_test + '</td>';
                                                    detail += '</tr>';
                                                    sr++;
                                                }
                                            };

                                            //var list = facList(this.x).split("$");
                                            //for (var i in list) {                                                
                                            //    if (list[i].trim() != '') {
                                            //        id = list[i].trim().split("=")[0];
                                            //        name = list[i].trim().split("=")[1];
                                            //        total_test = totalTestList(this.x, id)
                                            //        if(total_test > 0)
                                            //        {                                                   
                                            //            detail += '<tr>';
                                            //            detail += '<td style="text-align: center">' + sr + '</td><td>' + name + '</td><td>' + total_test + '</td>';
                                            //            detail += '</tr>';
                                            //            sr++;
                                            //        }
                                            //    }
                                            //};

                                            //var list = facList(this.x).split("$");
                                            //for (var i in list) {                                                
                                            //    if (list[i].trim() != '') {
                                            //        id = list[i].trim().split("=")[0];
                                            //        name = list[i].trim().split("=")[1];
                                            //        total_test = totalTestList(this.x, id)
                                            //        if(total_test == 0)
                                            //        {
                                            //            detail += '<tr>';
                                            //            detail += '<td style="text-align: center">' + sr + '</td><td>' + name + '</td><td>' + totalTestList(this.x, id) + '</td>';
                                            //            detail += '</tr>';
                                            //            sr++;
                                            //        }
                                            //    }
                                            //};

                                            detail += '</tbody></table>';
                                            $('#FacilityDetail').html(detail);
                                            $('#FacilityDetailTitle').html('Facility List: ' + this.category);
                                        }
                                    }
                                }
                            }
                        },
                        series: series
                    });
                }
            });

            // VL Test PieChart By State and Region & Facilities
            $(function GetEIDTestByStateRegionFacilityPieChart() {
                var subject = JSON.parse('<%= JstringEIDTestByLabFaclility %>');
                var series = [], categories = [], slice_data = [];
                for (var i in subject) {                    
                    categories.push(subject[i][1]);
                    slice_data.push({
                        name: subject[i][1],
                        y: subject[i][0]
                    });                    
                }
                
                series.push({
                    name: 'Reasons',
                    colorByPoint: true,                    
                    data: slice_data
                });

                BindEIDTestByStateRegionFacilityPieChart(categories, series);
                function BindEIDTestByStateRegionFacilityPieChart(categories, series) {
                    window.chart = new Highcharts.chart('eidTestByStateRegionFacilityPieChart', {
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: '( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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

            // EID Turnaround by Year
            $(function GetEIDTuraroundByYear() {
                if('<%= JstringEIDTurnaroundbyYear %>' == '')
                    return;
                var subject = JSON.parse('<%=JstringEIDTurnaroundbyYear%>');
                var series = [], categories=[], data1=[], data2=[], data3=[], data4=[];
                for (var i in subject) {                    
                    data1.push(subject[i][0]);
                    data2.push(subject[i][1]);
                    data3.push(subject[i][2]);
                    data4.push(subject[i][3]);
                    categories.push(subject[i][4]);
                }

                series.push({
                    name: 'Days of Tested to Result Dispatched',
                    data: data4
                }, {
                    name: 'Days of Received at the Lab to Tested',
                    data: data3
                }, {
                    name: 'Days of Shipment to Received at the Lab',
                    data: data2
                }, {
                    name: 'Days of Collected to Shipment',
                    data: data1
                });
                           
                BindEIDturnaroundByYear(categories, series);
                function BindEIDturnaroundByYear(categories, series) {                    
                    window.chart = new Highcharts.chart('turnaroundbyYear', {
                        chart: {
                            type: 'bar'
                        },
                        title: {
                            text: ''
                        },
                        subtitle: {
                            text: 'Turnaround time calculation is based on working days.'
                        },
                        xAxis: {
                            categories: categories
                        },
                        yAxis: {
                            min: 0,
                            title: {
                                text: ''
                            }
                        },
                        legend: {
                            reversed: true
                        },
                        tooltip: {
                            formatter: function () {
                                var barTitle = '<b>' + this.x + '</b>';
                                var s = '';
                                sum = 0;

                                $.each(this.points, function (i, point) {
                                    s = '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name + ': ' +
                                        point.y + ' day' + (parseInt(point.y) > 1 ? 's' : '') + s;
                                    sum += point.y;
                                });

                                s = barTitle + s + '<br/>Total: ' + sum + ' day' + (parseInt(sum) > 1? 's' : '')

                                return s;
                            },
                            shared: true
                        },
                        plotOptions: {
                            series: {
                                stacking: 'normal'
                            }
                        },
                        series: series
                    });
                }
            });

            // EID Turnaround by Quarter
            $(function GetEIDTuraroundByQuarter() {
                if('<%= JstringEIDTurnaroundbyQuarter %>' == '')
                    return;                
                var subject = JSON.parse('<%=JstringEIDTurnaroundbyQuarter%>');
                var series = [], categories=[], data1=[], data2=[], data3=[], data4=[];
                for (var i in subject) {                    
                    data1.push(subject[i][0]);
                    data2.push(subject[i][1]);
                    data3.push(subject[i][2]);
                    data4.push(subject[i][3]);
                    categories.push(subject[i][5]);
                }

                series.push({
                    name: 'Days of Tested to Result Dispatched',
                    data: data4,
                    showInLegend: false,
                }, {
                    name: 'Days of Received at the Lab to Tested',
                    data: data3,
                    showInLegend: false,
                }, {
                    name: 'Days of Shipment to Received at the Lab',
                    data: data2,
                    showInLegend: false,
                }, {
                    name: 'Days of Collected to Shipment',
                    data: data1,
                    showInLegend: false,
                });
                           
                BindEIDturnaroundByQuarter(categories, series);
                function BindEIDturnaroundByQuarter(categories, series) {                    
                    window.chart = new Highcharts.chart('turnaroundbyQuarter', {
                        chart: {
                            type: 'bar'
                        },
                        title: {
                            text: ''
                        },
                        subtitle: {
                            //text: 'Turnaround time calculation is based on working days.'
                        },
                        xAxis: {
                            categories: categories
                        },
                        yAxis: {
                            min: 0,
                            title: {
                                text: ''
                            }
                        },
                        legend: {
                            reversed: true
                        },
                        tooltip: {
                            formatter: function () {
                                var barTitle = '<b>' + this.x + '</b>';
                                var s = '';
                                sum = 0;

                                $.each(this.points, function (i, point) {                                    
                                    s = '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name + ': ' +
                                        point.y + ' day' + (parseInt(point.y) > 1 ? 's' : '') + s;
                                    sum += point.y;
                                });

                                s = barTitle + s + '<br/>Total: ' + sum + ' day' + (parseInt(sum) > 1 ? 's' : '')

                                return s;
                            },
                            shared: true
                        },
                        plotOptions: {
                            series: {
                                stacking: 'normal'
                            }
                        },
                        series: series
                    });
                }
            });

            // DNA PCR Test Outcome by Age
            $(function GetEIDTestByAgeOutcome() {
                var subject = JSON.parse('<%= JstringEIDTestByAgeOutcome %>');
                var series = [], categories = [], Pos = [], Neg = [], Positivity=[];
                var sums = function(i)
                {                    
                    return Pos[i] + Neg[i];
                }
                for (var i in subject) {                    
                    categories.push(subject[i][3]);                    
                    Pos.push(subject[i][0]);
                    Neg.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'Positive',
                    data: Pos,
                    type: 'column'
                },
                {
                    name: 'Negative',
                    data: Neg,
                    type: 'column'
                },
                {
                    type: 'spline',
                    name: 'Positivity',
                    data: Positivity,
                    lineWidth: 0,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'black',                   
                    }
                });

                BindEIDTestByAgeOutcome(categories, series);
                function BindEIDTestByAgeOutcome(categories, series) {
                    window.chart = new Highcharts.chart('eidTestByAgeOutcome', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'DNA PCR Test Outcome by Age ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            gridLineWidth: 1,                        
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: 'Positivity',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],

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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                    sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y + (i == 2? ' %' : '');
                                    if(i != 2)
                                        sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                        },
                        series: series
                    });
                }
            });

            // EID Test By Gender Outcome
            $(function GetEIDTestByGenderOutcome() {
                var subject = JSON.parse('<%= JstringEIDTestByGender %>');
                var series = [], categories = [], no_positive = [], no_negative = [], positivity=[];
                var sums = function(i)
                {                    
                    return LE_1000[i] + G_1000[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    no_positive.push(subject[i][0]);
                    no_negative.push(subject[i][1]);
                    positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: 'Positive',
                    data: no_positive,
                    type: 'column',
                },
                {
                    name: 'Negative',
                    data: no_negative,
                    type: 'column',
                },
                {
                    type: 'spline',
                    name: 'Positivity',
                    data: positivity,
                    lineWidth: 0,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'black'
                    }
                });

                BindEIDTestByGenderOutcome(categories, series);
                function BindEIDTestByGenderOutcome(categories, series) {
                    window.chart = new Highcharts.chart('eidTestByGenderOutcome', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'EID Test Outcome by Gender ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            gridLineWidth: 1,                        
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: 'Positivity',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 100,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }],

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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                    sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y + (i == 2? ' %' : '');
                                    if(i != 2)
                                        sum += point.y;
                                });

                                s += '<br/>Total: ' + sum

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
                            }
                        },
                        series: series
                    });
                }
            });

            // VL Test Reject By State & Region / Facility
            $(function GetEIDTestRejectByProvince() {
                var subject = JSON.parse('<%= JstringEIDTestRejectByProvince %>');
                var series = [], categories = [], Tot_Received = [], Rejected_Rate = [], Tot_Rejected = [];
                
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    Tot_Received.push(subject[i][0]);
                    Tot_Rejected.push(subject[i][1]);
                    Rejected_Rate.push(subject[i][2]);
                }
                series.push({
                    name: 'Total Received',
                    data: Tot_Received,
                    type: 'column',
                },
                {
                    name: 'Rejected',
                    data: Tot_Rejected,
                    type: 'column',
                }, {
                    type: 'spline',
                    name: 'Rejected Rate',
                    data: Rejected_Rate,
                    lineWidth: 0,
                    yAxis: 1,
                    color: '#F2784B',
                    marker: {
                        lineWidth: 2,
                        lineColor: '#F2784B',
                        fillColor: '#F2784B'
                    }
                }
                //{
                //    type: 'spline',
                //    name: 'Target',
                //    data: Target,
                //    lineWidth: 2,
                //    yAxis: 1,
                //    color: '#1BA39C',
                //    marker: {
                //        lineWidth: 2,
                //        lineColor: '#1BA39C',
                //        fillColor: '#1BA39C'
                //    }
                //}
                );

                BindEIDTestRejectByProvince(categories, series);
                function BindEIDTestRejectByProvince(categories, series) {
                    window.chart = new Highcharts.chart('eidTestRejectByProvince', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: 'DNA PCR Test Rejection by State & Region / Facility ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            tickInterval: 500,
                            gridLineWidth: 1,                        
                            title: {
                                text: 'Total Tests',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            }, labels: {
                                format: '{value}',
                                style: {
                                    color: Highcharts.getOptions().colors[1]
                                }
                            },
                        },{    // Secondary yAxis
                            title: {
                                text: 'Rejected Rate',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[0]
                                }
                            },
                            gridLineWidth: 1,
                            opposite: true,
                            min: 0, max: 3,
                            stackLabels: {
                                enabled: true,
                                style: {
                                    fontWeight: 'bold',
                                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                }
                            }
                        }
                        ],
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
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                    sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y + (i == 2? ' %' : '');
                                    if(i != 2)
                                        sum += point.y;
                                });
                                //$.each(this.points, function(i, point) {
                                //    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                //        point.y;
                                //    sum += point.y;                                        
                                //});

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
                            }
                        },
                        series: series
                    });
                }
            });

            // EID Positive Negative Summary
            $(function GetEIDSummary() {
                var subject = JSON.parse('<%= JstringEIDSummary %>');                
                var series = [], categories = [], total_received = 0, total_tested = 0, positive = 0, negative = 0,
                    initial = 0, initial_positive = 0, initial_less2m = 0, initial_less2m_positive = 0,
                    initial_above2y = 0, initial_above2y_positive = 0, rejected = 0, rejected_rate = 0, error = 0;
                total_received += getValue(subject[0][0]);
                total_tested += getValue(subject[0][1]);
                positive += getValue(subject[0][2]);
                negative += getValue(subject[0][3]);
                initial += getValue(subject[0][4]);
                initial_positive += getValue(subject[0][5]);
                initial_less2m += getValue(subject[0][6]);
                initial_less2m_positive += getValue(subject[0][7]);
                initial_above2y += getValue(subject[0][8]);
                initial_above2y_positive += getValue(subject[0][9]);
                rejected += getValue(subject[0][10]);
                rejected_rate += getValue(subject[0][11]);
                error += getValue(subject[0][12]);

                var detail = '<table id="dt_basic" class="table table-striped table-bordered table-hover" style="margin-bottom: 0px; margin-left: 20px;">' +
                    '<tbody>'
                detail += '<tr><td>Total EID Received:</td><td style="text-align: right">' + total_received + '</td>' +
                    //'<td>Positive (+):</td><td style="text-align: right">' + positive + ' <span class="txt-color-blue">(' + (positive / total_tested * 100).toFixed(2) + '%)</span></td></tr>';
                    '<td></td><td style="text-align: right"><span class="txt-color-blue"></span></td></tr>';
                detail += '<tr class="txt-color-red"><td>Rejected Samples:</td><td style="text-align: right">' + rejected + '</td>' +
                    '<td>Rejection (%):</td><td style="text-align: right"><span class="txt-color-red">' + rejected_rate + '%</span></td></tr>';
                detail += '<tr class="txt-color-green"><td>Total Tested:</td><td style="text-align: right">' + total_tested + '</td>' +
                    '<td>Total Tested Rate (%):</td><td style="text-align: right">' + (total_tested / total_received * 100).toFixed(2) + '%</span></td></tr>';
                detail += '<tr class="txt-color-red"><td>Error:</td><td style="text-align: right">' + error + '</td>' +
                    '<td>Error Rate (%):</td><td style="text-align: right"><span class="txt-color-red">' + (error / total_received * 100).toFixed(2) + '%</span></td></tr>';
                detail += '<tr class="txt-color-green"><td>Total Tested with valid Outcome:</td><td style="text-align: right">' + (total_tested-error) + '</td>' +
                    '<td>Positive (+):</td><td style="text-align: right">' + positive + ' <span class="txt-color-green">(' + (positive / (total_tested-error) * 100).toFixed(2) + '%)</span></td></tr>';
                detail += '<tr><td style="padding-left: 30px">Initial PCR:</td><td style="text-align: right">' + initial + '</td>' +
                    '<td>Positive (+):</td><td style="text-align: right">' + initial_positive + ' <span class="txt-color-blue">(' + (initial_positive/initial * 100).toFixed(2) + '%)</span></td></tr>';
                detail += '<tr><td style="padding-left: 30px">Initial Infants ≤ 2m:</td><td style="text-align: right">' + initial_less2m + '</td>' +
                    '<td>Infants ≤ 2m Positive:</td><td style="text-align: right">' + initial_less2m_positive + ' <span class="txt-color-blue">(' + (initial_less2m_positive/initial * 100).toFixed(2) + '%)</span></td></tr>';
                //detail += '<tr><td style="padding-left: 30px">Initial Above 2years Tested:</td><td style="text-align: right">' + initial_above2y + '</td>' +
                //    '<td>Positive (+):</td><td style="text-align: right">' + initial_above2y_positive + ' <span class="txt-color-blue">(' + (initial_above2y_positive / initial_above2y * 100).toFixed(2) + '%)</span></td></tr>';                
                detail += '</tbody></table>';
                $('#SummaryDetail').html(detail);
                
                $('#InitialRate').html((initial/(total_tested-error) * 100).toFixed(2));
                $("#InitialRate").attr("data-percent", (initial/(total_tested-error) * 100).toFixed(2));
                $('#easyPie1').data('easyPieChart').update((initial/(total_tested-error) * 100).toFixed(2));

                $('#InitialPositiveRate').html((initial_positive/initial * 100).toFixed(2));
                $("#InitialPositiveRate").attr("data-percent",  (initial_positive/initial * 100).toFixed(2));
                $('#easyPie2').data('easyPieChart').update((initial_positive/initial * 100).toFixed(2));

                $('#InitialLT2MonthsPositiveRate').html((initial_less2m_positive/initial * 100).toFixed(2));
                $("#InitialLT2MonthsPositiveRate").attr("data-percent", (initial_less2m_positive/initial * 100).toFixed(2));
                $('#easyPie3').data('easyPieChart').update((initial_less2m_positive/initial * 100).toFixed(2));

                $('#Initial').html(initial);
                $('#InitialPositive').html(initial_positive);
                $('#InitialLT2MonthsPositive').html(initial_less2m_positive);

                var slice_data = [];
                slice_data.push({
                    name: 'Positive',                    
                    y: positive
                },
                {
                    name: 'Negative',                    
                    y: negative
                },
                {
                    name: 'Rejected',                    
                    y: rejected
                },
                {
                    name: 'Invalid/Error',                    
                    y: error
                });
                
                series.push({
                    name: 'EID_Summary',
                    colorByPoint: true,                    
                    data: slice_data
                });                

                BindEIDSummary(categories, series);
                function BindEIDSummary(categories, series) {
                    window.chart = new Highcharts.chart('EIDSummary', {
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: ''
                        },
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
                            x: 0,
                            verticalAlign: 'bottom',
                            y: 0,
                            floating: false,
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.2f}%</b>'                            
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,
                                    format: '<b>{point.name}</b>: {point.percentage:.2f} %',
                                    style: {
                                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                                    }
                                },
                                showInLegend: true
                            }
                        },
                        series: series
                    });
                }                
            });
            
        });

        function getValue(val){
            if(isNaN(val))
                return 0;
            else
                return val;            
        }
    </script>

    <style>
        #highcharts-audclk3-348 > .highcharts-container {
            overflow: visible!important;
        }

        .ui-datepicker-calendar {
            display: none;
        }

        .ui-icon ui-icon-circle-triangle-w{
            font-size: 8px;
        }

        .ui-icon ui-icon-circle-triangle-e{
            font-size: 8px;
        }
    </style>
  
    <div id="content">            
        <div class="row">
			<div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">                
				<h1 class="page-title txt-color-blueDark"><i class="fa fa-lg fa-fw fa-bar-chart-o"></i> EID <span>&gt; Lab Dashboard</span></h1>
			</div>
        </div>

        <div class="well">
            <div class="row">
                <%--<div id="divNational" runat="server">--%>
			    <div class="col-sm-4 pull-left">
                    <asp:DropDownList ID="ddlLab" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataTextField="ProvinceName" DataValueField="Id">
                        <asp:ListItem Value="0">All</asp:ListItem>
                    </asp:DropDownList><i></i>
                    <%--<asp:Label ID="lbllocation" runat="server" Text="National" CssClass="label-primary"></asp:Label>--%>
			    </div>
                <%--</div>--%>
                <%--<div class="col-sm-3 pull-left"></div>--%>
                <div class="col-sm-2 pull-left" style="display: none">
                    <asp:DropDownList ID="ddlDate" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Yearly</asp:ListItem>
                        <asp:ListItem Value="1">Quarterly</asp:ListItem>
                    </asp:DropDownList><i></i>
                </div>
                <div class="col-sm-1 pull-left">
                    <asp:Label ID="lblFrom" runat="server" Text="From:"></asp:Label>
                </div>
                <div class="col-sm-2 pull-left">
                    <%--<asp:DropDownList ID="ddlYearFrom" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>--%>
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control date-picker" ReadOnly="false"></asp:TextBox>
                    <asp:HiddenField ID="hdnStartDate" runat="server" />
			    </div>
                <div class="col-sm-1 pull-left">
                    <asp:Label ID="lblTo" runat="server" Text="To:"></asp:Label>
                </div>
                <div class="col-sm-2 pull-left">
                    <%--<asp:DropDownList ID="ddlYearTo" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>--%>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control date-picker" ReadOnly="false"></asp:TextBox>                    
			    </div>
                <div class="col-sm-1 pull-right">
                    <asp:Button ID="btnFilter" class="btn btn-default btn-primary" runat="server" Text="Filter" OnClick="btnFilter_Click"  />								
			    </div>
		    </div>
	    </div>

        <div class="row">
			<div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">                				    
			</div>
			<div class="col-xs-12 col-sm-5 col-md-5 col-lg-8">				    
		    </div>   
		</div>

        <div class="row" id="easy-pie-chart-row">
            <div class="show-stat-microcharts">
				<div class="col-xs-8 col-sm-4 col-md-4 col-lg-4">
                    <div id="easyPie1" class="easy-pie-chart txt-color-greenLight easyPieChart" data-percent="" data-pie-size="50" style="width: 50px; height: 50px; line-height: 50px; top: -20px;">
						<span class="percent percent-sign" id="InitialRate"></span>
					    <canvas width="50" height="50"></canvas>
                    </div>
                    <span class="easy-pie-title">Initial First Time <br />
                        <span class="txt-color-blue" id="Initial"></span>
                    </span>
                    <%--<span class="easy-pie-title"> Initial First Time <i class="fa fa-caret-up icon-color-bad"></i>
                    </span>--%>
                </div>
                <div class="col-xs-8 col-sm-4 col-md-4 col-lg-4">
                    <div id="easyPie2" class="easy-pie-chart txt-color-greenLight easyPieChart" data-percent="" data-pie-size="50" style="width: 50px; height: 50px; line-height: 50px; top: -20px;">
						<span class="percent percent-sign" id="InitialPositiveRate"></span>
					    <canvas width="50" height="50"></canvas>
                    </div>
                    <span class="easy-pie-title"> Total Initial Positive <br />
                        <span class="txt-color-blue" id="InitialPositive"></span>
                    </span>
                    <%--<span class="easy-pie-title"> Initial Positive <%--<i class="fa fa-caret-up icon-color-bad"></i>
                    </span>--%>
                </div>
                <div class="col-xs-8 col-sm-4 col-md-4 col-lg-4">
                    <div id="easyPie3" class="easy-pie-chart txt-color-blue easyPieChart" data-percent="" data-pie-size="50" style="width: 50px; height: 50px; line-height: 50px; top: -20px;">
						<span class="percent percent-sign" id="InitialLT2MonthsPositiveRate"></span>                        
					    <canvas width="50" height="50"></canvas>                        
                    </div>
                    <span class="easy-pie-title"> Total Initial Positive ≤ 2month <br />
                        <span class="txt-color-blue" id="InitialLT2MonthsPositive"></span>
                    </span>
                    <%--<span class="easy-pie-title"> Initial ≤ 2m <i class="fa fa-caret-up icon-color-good"></i>
                    </span>--%>
                </div>                
            </div>                        
        </div>
     </div>
    
    <%--<div id="content">--%>
        <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-9" data-widget-editbutton="false" role="widget" style="">
				<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>					
                    <h2>EID Summary</h2>             
                </header>
                <div role="content">
                    <div class="widget-body no-padding">
                        <div id="EIDSummary" style="min-width: 450px; height: 200px; margin: 0 auto; float: left"></div>
                        <div id="SummaryDetail" style="min-width: 450px; margin: 10px auto; overflow-y: no-display; float: left"></div>                        
                    </div>                    
				</div>                
			</div>
            </article>
		</div>
    <%--</div>--%>
         
    <section id="widget-grid" class="">

        <!-- Tab Initial PCR Test -->
        <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable" id="c439e80cae8e4d94e4027ca799d50cbf" data-widget-editbutton="false" data-widget-colorbutton="false" role="widget">
	                <header role="heading">
		                <div class="jarviswidget-ctrls" role="menu">
			                <a href="#" class="button-icon jarviswidget-toggle-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Collapse"><i class="fa fa-minus "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-delete-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Delete"><i class="fa fa-times"></i></a>
		                </div>

                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-darken"></i></span>
                        <h2>DNA PCR Test by State & Region / Facility</h2>

		                <ul class="nav nav-tabs pull-right">
			                <li class="active">
				                <a href="#0" data-toggle="tab">Yearly</a>
			                </li>
			                <li class="">
				                <a href="#1" data-toggle="tab">Quarterly</a>
			                </li>
                            <li class="">
				                <a href="#2" data-toggle="tab">Monthly</a>
			                </li>
		                </ul>

		                <span class="jarviswidget-loader">
			                <i class="fa fa-refresh fa-spin"></i>
		                </span>
	                </header>

	                <div role="content">
		                <div class="jarviswidget-editbox">
		                </div>
		                <div class="widget-body ">
			                <div class="tab-content padding-10">
				                <div class="tab-pane active" id="0">

                                    <%--<div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-0" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
                                        <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
                                            <h2>Initial PCR  by Year(<asp:Label ID="lblDatefromyear" runat="server" Text=""></asp:Label>-<asp:Label ID="lblDatetoyear" runat="server" Text=""></asp:Label>)</h2>   
                                        </header>--%>
                                        <!-- add: non-hidden - to disable auto hide -->
                                        <div role="content">
                                            <div class="widget-body no-padding">
                                                <div id="testIntialPCRbyYear" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                            </div>
                                        </div>
			                         <%--</div>--%>

				                </div>
				                <div class="tab-pane" id="1">

                                    <%--<div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-2" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					                    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						                    <h2>All Test Outcome</h2>
                                        </header>--%>
                 	                    <div role="content">
                                            <div class="widget-body no-padding">
                                                <div id="testAllTestbyYear" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                            </div>
					                    </div>
				                    <%--</div>--%>

				                </div>
                                <div class="tab-pane" id="2">                                    
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRbyMonth" style="min-width: 1024px; height: 220px; margin: 0 auto"></div>
                                        </div>
					                </div>
				                </div>
			                </div>
		                </div>
	                </div>
                </div>
            </article>
        </div>
        <!-- End Tab -->

        <!-- Tab Initial PCR By Age -->
        <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable" id="tabInitialPCRAge" data-widget-editbutton="false" data-widget-colorbutton="false" role="widget">
	                <header role="heading">
		                <div class="jarviswidget-ctrls" role="menu">
			                <a href="#" class="button-icon jarviswidget-toggle-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Collapse"><i class="fa fa-minus "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-delete-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Delete"><i class="fa fa-times"></i></a>
		                </div>

                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-darken"></i></span>
                        <h2>DNA PCR Test By Age</h2>

		                <ul class="nav nav-tabs pull-right">
			                <li class="active">
				                <a href="#3" data-toggle="tab">Yearly</a>
			                </li>
			                <li class="">
				                <a href="#4" data-toggle="tab">Quarterly</a>
			                </li>
                            <li class="">
				                <a href="#5" data-toggle="tab">Monthly</a>
			                </li>
		                </ul>

		                <span class="jarviswidget-loader">
			                <i class="fa fa-refresh fa-spin"></i>
		                </span>
	                </header>

	                <div role="content">
		                <div class="jarviswidget-editbox">
		                </div>
		                <div class="widget-body ">
			                <div class="tab-content padding-10">
				                <div class="tab-pane active" id="3">                                    
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRAgeByYearly" style="min-width: 1024px; height: 220px;  margin: 0 auto"></div>
                                        </div>
                                    </div>
				                </div>
				                <div class="tab-pane" id="4">
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRAgeByQuarterly" style="min-width: 1024px; height: 220px;  margin: 0 auto"></div>
                                        </div>
					                </div>
				                </div>
                                <div class="tab-pane" id="5">                                    
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRAgeByMonthly" style="min-width: 1024px; height: 220px;  margin: 0 auto"></div>
                                        </div>
					                </div>
				                </div>
			                </div>
		                </div>
	                </div>
                </div>
            </article>
        </div>        
        <!-- End Tab -->

        <div class="row">
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-eidTestByAgeOutcome" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
                    <header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>	                    
                        <h2>DNA PCR Test Outcome by Age</h2>
                    </header>                  
                    <!-- add: non-hidden - to disable auto hide -->                            
                    <div role="content">
	                    <div class="widget-body no-padding">                            
                            <div id="eidTestByAgeOutcome" style="min-width: 300px; height: 250px; max-width: 500px; margin: 0 auto"></div>
	                    </div>
                    </div>
			    </div>
            </article>
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-gender" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					<header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<%--<h2>VL Test Outcome By Gender <%= filter_criteria %></h2>--%>
                        <h2>EID Test Outcome By Gender</h2>
                    </header>                  
					<!-- add: non-hidden - to disable auto hide -->                            
                    <div role="content">
						<div class="widget-body no-padding">                                     									
                            <div id="eidTestByGenderOutcome" style="min-width: 300px; height: 250px; max-width: 500px; margin: 0 auto"></div>
						</div>
					</div>
			 </div>             
		    </article>
        </div>
        <div class="row">
			<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-test-by-facility" data-widget-editbutton="false" role="widget" style="">
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2> DNA PCR Test by State & Region / Facility</h2>
                    </header>
                 	<div role="content">
                        <div class="widget-body no-padding">                                        
                            <div id="EIDPCRbyFacility" style="min-width: 1024px; height: 400px;  margin: 0 auto"></div>
                        </div>
					</div>
				</div>
			</article>
		</div>

        <!-- Lab Devices -->
        <div class="row">
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-lab-data-by-all-devices" data-widget-editbutton="false" role="widget" style="">
					<header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>DNA PCR Test by Instruments</h2>                        
                    </header>
                 	<div role="content">
                        <div class="widget-body no-padding">
                            <div id="VLLabByLabInstrumentComparison" style="min-width: 310px; height: 500px; max-width: 600px; margin: 0 auto"></div>
                        </div>
					</div>
				</div>
       	    </article>
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable" id="tabLabDevices" data-widget-editbutton="false" data-widget-colorbutton="false" role="widget">
	                <header role="heading">
		                <div class="jarviswidget-ctrls" role="menu">
			                <a href="#" class="button-icon jarviswidget-toggle-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Collapse"><i class="fa fa-minus "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-delete-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Delete"><i class="fa fa-times"></i></a>
		                </div>

                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-darken"></i></span>                        
                        <h2>DNA PCR Test by Instruments</h2>
		                <ul class="nav nav-tabs pull-right">
			                <li class="active">
				                <a href="#10" data-toggle="tab"><i class="fa fa-flask"></i> NAP Abbott</a>
			                </li>
                            <li>
				                <a href="#11" data-toggle="tab"><i class="fa fa-flask"></i> GeneXpert</a>
			                </li>
                            <li>
				                <a href="#12" data-toggle="tab"><i class="fa fa-flask"></i> BioCentric</a>
			                </li>			                
		                </ul>

		                <span class="jarviswidget-loader">
			                <i class="fa fa-refresh fa-spin"></i>
		                </span>
	                </header>

	                <div role="content">
		                <div class="jarviswidget-editbox">
		                </div>
		                <div class="widget-body ">
			                <div class="tab-content padding-10">
				                <div class="tab-pane active" id="10">                                    
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="VLLabByLabInstrumentAbbott" style="min-width: 310px; height: 435px;  margin: 0 auto"></div>
                                        </div>
                                    </div>
				                </div>
                                <div class="tab-pane" id="11">
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="VLLabByLabInstrumentGeneXpert" style="min-width: 310px; height: 435px;  margin: 0 auto"></div>
                                        </div>
                                    </div>
				                </div>
                                <div class="tab-pane" id="12">                                    
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="VLLabByLabInstrumentBioCentric" style="min-width: 310px; height: 435px;  margin: 0 auto"></div>
                                        </div>
                                    </div>
				                </div>				                
			                </div>
		                </div>
	                </div>
                </div>
            </article>            
        </div>
        <!-- End Tab -->        

        <!-- Reasons by Lab Devices -->
        <div class="row">            
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable" id="tabReasonsByLab" data-widget-editbutton="false" data-widget-colorbutton="false" role="widget">
	                <header role="heading">                        
		                <div class="jarviswidget-ctrls" role="menu">
			                <a href="#" class="button-icon jarviswidget-toggle-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Collapse"><i class="fa fa-minus "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-delete-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Delete"><i class="fa fa-times"></i></a>
		                </div>

                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-darken"></i></span>
                        <h2>Reasons for DNA PCR Test by Lab</h2>                        

		                <ul class="nav nav-tabs pull-right">
			                <li class="active">
				                <a href="#20" data-toggle="tab"><i class="fa fa-flask"></i> All</a>
			                </li>
			                <li>
				                <a href="#21" data-toggle="tab"><i class="fa fa-flask"></i> NAP Abbott</a>
			                </li>
                            <li>
				                <a href="#22" data-toggle="tab"><i class="fa fa-flask"></i> GeneXpert</a>
			                </li>
                            <li>
				                <a href="#23" data-toggle="tab"><i class="fa fa-flask"></i> BioCentric</a>
			                </li>			                
		                </ul>

		                <span class="jarviswidget-loader">
			                <i class="fa fa-refresh fa-spin"></i>
		                </span>
	                </header>

	                <div role="content">
		                <div class="jarviswidget-editbox">
		                </div>
		                <div class="widget-body ">                            
			                <div class="tab-content padding-10">
                                <div class="tab-pane active" id="20">
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="eidTestReasonAllInstruments" style="min-width: 310px; height: 500px; width: 600px; margin: 0 auto; float: left"></div>
                                            <div id="eidTestReasonAllInstrumentsPieChart" style="min-width: 400px; height: 500px; margin: 0 auto; float: left"></div>
                                        </div>
                                    </div>
				                </div>
				                <div class="tab-pane" id="21">
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="eidTestReasonByAbbott" style="min-width: 310px; height: 500px; width: 600px; margin: 0 auto; float: left"></div>
                                            <div id="eidTestReasonByAbbottPieChart" style="min-width: 400px; height: 500px; margin: 0 auto; float: left"></div>
                                        </div>
                                    </div>
				                </div>
                                <div class="tab-pane" id="22">
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="eidTestReasonByGeneXpert" style="min-width: 310px; height: 600px; width: 600px; margin: 0 auto; float: left"></div>
                                            <div id="eidTestReasonByGeneXpertPieChart" style="min-width: 400px; height: 400px; margin: 0 auto; float: left"></div>
                                        </div>
                                    </div>
				                </div>
                                <div class="tab-pane" id="23">
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="eidTestReasonByBioCentric"  style="min-width: 310px; height: 500px; width: 600px; margin: 0 auto; float: left"></div>
                                            <div id="eidTestReasonByBioCentricPieChart" style="min-width: 400px; height: 500px; margin: 0 auto; float: left"></div>
                                        </div>
                                    </div>
				                </div>				                
			                </div>
		                </div>
	                </div>
                </div>
            </article>
        </div>        
        <!-- End Tab -->        
        
        <div class="row">
		    <article class="col-xs-18 col-sm-8 col-md-8 col-lg-8 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-by-state-region-facilities" data-widget-editbutton="false" role="widget" style="">								
					<header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>DNA PCR Test Facilities by State & Region</h2>
                    </header>
                 	<div>
                        <div class="widget-body no-padding">                            
                            <div id="eidTestByStateRegionFacility" style="min-width: 700px; height: 400px; margin: 0 auto; float: left"></div>                            
                            <%--<div id="FacilityDetail" style="height: 400px; max-width: 300px; margin: 0 auto; overflow-y: scroll">--%>
                        </div>
					</div>
				</div>
			</article>
            <article class="col-xs-12 col-sm-4 col-md-4 col-lg-4 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-by-state-region-facilities-table" data-widget-editbutton="false" role="widget" style="">
				    <header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>					                  
                        <span class="widget-icon"><i class="fa fa-table"></i> </span>
					    <h2 id="FacilityDetailTitle"></h2>
                    </header>
                    <div role="content">
                        <div class="widget-body no-padding">
                            <div id="FacilityDetail" style="height: 400px; min-width: 350px; margin: 0 auto; overflow-y: scroll">
                            </div>
                        </div>
				    </div>
			    </div>
       	    </article>            
        </div>        

        <div class="row">
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-by-state-region-facilities-piechart" data-widget-editbutton="false" role="widget" style="">								
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>
                            <asp:Label ID="Label1" runat="server" Text="DNA PCR Test by State & Region"></asp:Label></h2>
                    </header>
                 	<div role="content">
                        <div class="widget-body no-padding">
                            <div id="eidTestByStateRegionFacilityPieChart" style="min-width: 450px; height: 420px; margin: 0 auto; float: left"></div>                            
                        </div>
					</div>
				</div>
			</article>
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-eid-turnaround-yearly" data-widget-editbutton="false" role="widget" style="">								
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>
                            <asp:Label ID="lbloutcomeProFac" runat="server" Text="Turnaround Time"></asp:Label></h2>
                    </header>
                 	<div role="content">
                        <div class="widget-body no-padding">                                        
                            <div id="turnaroundbyYear" style="min-width: 300px; height: 200px;  margin: 0 auto"></div>
                            <div id="turnaroundbyQuarter" style="min-width: 300px; height: 220px;  margin: 0 auto"></div>                            
                        </div>
					</div>
				</div>
			</article>            
		</div>        

        <div class="row">
		 <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-reject" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					<header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>						
                        <h2>DNA PCR Test Rejection by State & Region / Facility</h2>
                    </header>                  
					<!-- add: non-hidden - to disable auto hide -->                            
                    <div role="content">
						<div class="widget-body no-padding">                                     									
                            <div id="eidTestRejectByProvince" style="min-width: 1024px; height: 420px; margin: 0 auto;"></div>
						</div>
					</div>
			 </div>
		 </article>
		</div>

        <%--<div class="row">
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-9" data-widget-editbutton="false" role="widget" style="">
				<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>					
                    <h2>EID Outcome</h2>             
                </header>
                <div role="content">
                    <div class="widget-body no-padding">
                        <div id="EIDSummary" style="min-width: 300px; height: 300px; margin: 0 auto;"></div>
                    </div>        
				</div>
                <div role="content">
                    <div class="widget-body no-padding">
                        <div id="SummaryDetail" style="max-width: 600px; margin: 0 auto; overflow-y: no-display"></div>
                    </div>
				</div>
			</div>
            </article>
		</div>--%>
     </section>
   </asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>