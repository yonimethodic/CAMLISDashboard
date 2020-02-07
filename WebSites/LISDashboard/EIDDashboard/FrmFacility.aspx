<%@ Page Title="EID Facility Dashboard" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="FrmFacility.aspx.cs" Inherits="CHAI.LISDashboard.Modules.EIDDashboard.Views.FrmFacility" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">
    
    <script src="../js/libs/jquery-2.0.2.min.js"></script>
    <!-- HIGHCHART:  -->
    <script src="../js/plugin/HighCharts/highcharts.js"></script>
    <script src="../js/plugin/HighCharts/exporting.js"></script>
    <script src="../js/plugin/HighCharts/export-data.js"></script>
    <script src="../js/plugin/HighCharts/grouped-categories.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'MM/DD/YYYY'
            });
            $('#datetimepicker2').datetimepicker({
                format: 'MM/DD/YYYY'
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
                var subject = JSON.parse('<%=JstringEIDInitialPCRbyYearly%>');
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
                var subject = JSON.parse('<%=JstringEIDInitialPCRbyQuarterly%>');
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
                            text: 'DNA PCR Test Initial - Quarterly ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
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
                var subject = JSON.parse('<%=JstringEIDInitialPCRbyMonthly%>');
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
                            text: 'DNA PCR Test Initial - Monthly ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
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
                            text: 'DNA PCR Test Initial Outcome ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0,                            
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            tickInterval: 50,
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
                var subject = JSON.parse('<%=JstringEIDIntialPCRAgeByYearly%>');
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
                                        point.y + (i == 6? ' %' : '');
                                    if(i != 6)
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
                var subject = JSON.parse('<%=JstringEIDIntialPCRAgeByQuarterly%>');
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
                            text: 'DNA PCR Test Initial by Age - Quarterly ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
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
                                        point.y + (i == 6? ' %' : '');
                                    if(i != 6)
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
                var subject = JSON.parse('<%=JstringEIDIntialPCRAgeByMonthly%>');
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
                            text: 'DNA PCR Test Initial by Age - Monthly ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
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
                                        point.y + (i == 6? ' %' : '');
                                    if(i != 6)
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
                            text: 'DNA PCR Test Outcome by Age ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
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

            // EID Sample Drainage by Lab
            function isFound(list, val){
                for (var l in list)
                {
                    if(l == val)
                        return true;
                }
                return false;
            }
            $(function GetEIDTestLabAndFacility() {
                var subject = JSON.parse('<%= JstringEIDTestLabAndFacility %>');
                var series = [], categories = [], provinces = [], provinceIds = [], l1 = [], l2 = [], l3 = [], l4 = [], l5 = [],
                    l6 = [], l7 = [], l8 = [], l9 = [], l10 = [], l11 = [], l12 = [], l13 = [], l14 = [], l15 = [],
                    l16 = [], l17 = [], l18 = [], l19 = [], l20 = [], l21 = [], l22 = [], l23 = [], l24 = [], l25 = [],
                    l26 = [], l27 = [], l28 = [], l29 = [], l30 = [], l31 = [], l32 = [], l33 = [];
                                
                for (var i in subject) {
                    categories.push(subject[i][5] + ', ' + subject[i][3]);

                    if (subject[i][1] == 1) {
                        l1.push(subject[i][0]);
                        l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0); l10.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 2) {
                        l2.push(subject[i][0]);
                        l1.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0); l10.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 3) {
                        l3.push(subject[i][0]);
                        l1.push(0); l2.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0); l10.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 4) {
                        l4.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0); l10.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 5) {
                        l5.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0); l10.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 6) {
                        l6.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l7.push(0); l8.push(0); l9.push(0); l10.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 7) {
                        l7.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l8.push(0); l9.push(0); l10.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 8) {
                        l8.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l9.push(0); l10.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 9) {
                        l9.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l10.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 10) {
                        l10.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 11) {
                        l11.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 12) {
                        l12.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 13) {
                        l13.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 14) {
                        l14.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 15) {
                        l15.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 16) {
                        l16.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l17.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 17) {
                        l17.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l18.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 18) {
                        l18.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l19.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 19) {
                        l19.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l20.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 20) {
                        l20.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 21) {
                        l21.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 22) {
                        l22.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 23) {
                        l23.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 24) {
                        l24.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 25) {
                        l25.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l24.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 26) {
                        l26.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l27.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 27) {
                        l27.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l28.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 28) {
                        l28.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l29.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 29) {
                        l29.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l30.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 30) {
                        l30.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0);
                        l31.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 31) {
                        l31.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0);
                        l30.push(0); l32.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 32) {
                        l32.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0);
                        l30.push(0); l31.push(0); l33.push(0);
                    }
                    else if (subject[i][1] == 33) {
                        l33.push(subject[i][0]);
                        l1.push(0); l2.push(0); l3.push(0); l4.push(0); l5.push(0); l6.push(0); l7.push(0); l8.push(0); l9.push(0);
                        l10.push(0); l11.push(0); l12.push(0); l13.push(0); l14.push(0); l15.push(0); l16.push(0); l17.push(0); l18.push(0); l19.push(0);
                        l20.push(0); l21.push(0); l22.push(0); l23.push(0); l24.push(0); l25.push(0); l26.push(0); l27.push(0); l28.push(0); l29.push(0);
                        l30.push(0); l31.push(0); l32.push(0);
                    }
                }
                
                series.push({ name: 'NHL', data: l1, type: 'column' });
                series.push({ name: 'PHL', data: l2, type: 'column' });
                series.push({ name: 'SHM', data: l3, type: 'column' });
                series.push({ name: 'MGH', data: l4, type: 'column' });
                series.push({ name: 'Myaungmya', data: l5, type: 'column' });
                series.push({ name: 'Pathein', data: l6, type: 'column' });
                series.push({ name: 'Pyay', data: l7, type: 'column' });
                series.push({ name: 'Bhamo', data: l8, type: 'column' });
                series.push({ name: 'Myitkyina1', data: l9, type: 'column' });
                series.push({ name: 'Myitkyina2', data: l10, type: 'column' });
                series.push({ name: 'Loikaw', data: l11, type: 'column' });
                series.push({ name: 'Myawaddy', data: l12, type: 'column' });
                series.push({ name: 'Hpa-an', data: l13, type: 'column' });
                series.push({ name: 'Mawlamyine', data: l14, type: 'column' });
                series.push({ name: 'Naypyidaw', data: l15, type: 'column' });
                series.push({ name: 'Pyinmana', data: l16, type: 'column' });
                series.push({ name: 'Sittwe', data: l17, type: 'column' });
                series.push({ name: 'Kale', data: l18, type: 'column' });
                series.push({ name: 'Monywa', data: l19, type: 'column' });
                series.push({ name: 'Tachileik', data: l20, type: 'column' });
                series.push({ name: 'Lashio', data: l21, type: 'column' });
                series.push({ name: 'Taunggyi', data: l22, type: 'column' });
                series.push({ name: 'Kawthaung', data: l23, type: 'column' });
                series.push({ name: 'PHL-UNION', data: l24, type: 'column' });
                series.push({ name: 'PSI', data: l25, type: 'column' });
                series.push({ name: 'MAM-Putoa', data: l26, type: 'column' });
                series.push({ name: 'Chauk', data: l27, type: 'column' });
                series.push({ name: 'CMTZ', data: l28, type: 'column' });
                series.push({ name: 'MAM', data: l29, type: 'column' });
                series.push({ name: 'NHL-UNION', data: l30, type: 'column' });
                series.push({ name: 'MSF', data: l31, type: 'column' });
                series.push({ name: 'SML', data: l32, type: 'column' });
                series.push({ name: 'ShweBo', data: l33, type: 'column' });                
                //series.push({
                //    name: '',
                //    data: l,
                //    type: 'column',
                //});

                BindVLTestLabAndFacility(categories, series);
                function BindVLTestLabAndFacility(categories, series) {
                    window.chart = new Highcharts.chart('eidTestLabAndFacility', {
                        chart: {
                            renderTo: "container",
                            type: 'column',                           
                        },
                        title: {
                            text: 'DNA PCR Sample Drainage by Lab ( ' + <%= ddlYearFrom.SelectedItem.Text %> + ' - ' + <%= ddlYearTo.SelectedItem.Text %> + ' )'
                        },
                        xAxis: {
                            //title: { text: 'State & Region, Facility' },
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
                        }
                        //, {    // Secondary yAxis
                        //    title: {
                        //        text: 'Suppression',
                        //        style: {
                        //            color: Highcharts.getOptions().colors[0]
                        //        }
                        //    },
                        //    labels: {
                        //        format: '{value} %',
                        //        style: {
                        //            color: Highcharts.getOptions().colors[0]
                        //        }
                        //    },
                        //    gridLineWidth: 1,
                        //    opposite: true,
                        //    min: 0, max: 100,
                        //    stackLabels: {
                        //        enabled: true,
                        //        style: {
                        //            fontWeight: 'bold',
                        //            color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                        //        }
                        //    }
                        //}
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

                                $.each(this.points, function (i, point) {
                                    if (point.y != 0) {
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
                            }
                        },
                        series: series                        
                    });
                    //chart.options.yAxis[0].title = 'Facility,';
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
                            text: 'EID Test Outcome by Gender ( ' + <%= ddlYearFrom.SelectedItem.Text %> + ' - ' + <%= ddlYearTo.SelectedItem.Text %> + ' )'
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
                            text: 'DNA PCR Test Rejection by State & Region / Facility ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
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
                detail += '<tr><td>Total EID Sample Collected:</td><td style="text-align: right">' + total_received + '</td>' +
                    //'<td>Positive (+):</td><td style="text-align: right">' + positive + ' <span class="txt-color-blue">(' + (positive / total_tested * 100).toFixed(2) + '%)</span></td></tr>';
                    '<td></td><td style="text-align: right"><span class="txt-color-blue"></span></td></tr>';
                detail += '<tr class="txt-color-red"><td>Rejected Samples:</td><td style="text-align: right">' + rejected + '</td>' +
                    '<td>Rejection (%):</td><td style="text-align: right"><span class="txt-color-red">' + rejected_rate + '%</span></td></tr>';
                detail += '<tr class="txt-color-green"><td>Total Tested:</td><td style="text-align: right">' + total_tested + '</td>' +
                    '<td>Total Tested Rate (%):</td><td style="text-align: right">' + (total_tested / total_received * 100).toFixed(2) + '%</span></td></tr>';
                detail += '<tr class="txt-color-red"><td>Error:</td><td style="text-align: right">' + error + '</td>' +
                    '<td>Error Rate (%):</td><td style="text-align: right"><span class="txt-color-red">' + (error / total_received * 100).toFixed(2) + '%</span></td></tr>';
                detail += '<tr class="txt-color-green"><td>Total Tested with valid Outcome:</td><td style="text-align: right">' + (total_tested - error) + '</td>' +
                    '<td>Positive (+):</td><td style="text-align: right">' + positive + ' <span class="txt-color-green">(' + (positive / (total_tested - error) * 100).toFixed(2) + '%)</span></td></tr>';
                detail += '<tr><td style="padding-left: 30px">Initial PCR:</td><td style="text-align: right">' + initial + '</td>' +
                    '<td>Positive (+):</td><td style="text-align: right">' + initial_positive + ' <span class="txt-color-blue">(' + (initial_positive / initial * 100).toFixed(2) + '%)</span></td></tr>';
                detail += '<tr><td style="padding-left: 30px">Initial Infants ≤ 2m:</td><td style="text-align: right">' + initial_less2m + '</td>' +
                    '<td>Infants ≤ 2m Positive:</td><td style="text-align: right">' + initial_less2m_positive + ' <span class="txt-color-blue">(' + (initial_less2m_positive / initial * 100).toFixed(2) + '%)</span></td></tr>';
                //detail += '<tr><td style="padding-left: 30px">Initial Above 2years Tested:</td><td style="text-align: right">' + initial_above2y + '</td>' +
                //    '<td>Positive (+):</td><td style="text-align: right">' + initial_above2y_positive + ' <span class="txt-color-blue">(' + (initial_above2y_positive / initial_above2y * 100).toFixed(2) + '%)</span></td></tr>';                
                detail += '</tbody></table>';
                $('#SummaryDetail').html(detail);
                
                $('#InitialRate').html((initial / (total_tested - error) * 100).toFixed(2));
                $("#InitialRate").attr("data-percent", (initial / (total_tested - error) * 100).toFixed(2));
                $('#easyPie1').data('easyPieChart').update((initial / (total_tested - error) * 100).toFixed(2));

                $('#InitialPositiveRate').html((initial_positive / initial * 100).toFixed(2));
                $("#InitialPositiveRate").attr("data-percent", (initial_positive / initial * 100).toFixed(2));
                $('#easyPie2').data('easyPieChart').update((initial_positive / initial * 100).toFixed(2));

                $('#InitialLT2MonthsPositiveRate').html((initial_less2m_positive / initial * 100).toFixed(2));
                $("#InitialLT2MonthsPositiveRate").attr("data-percent", (initial_less2m_positive / initial * 100).toFixed(2));
                $('#easyPie3').data('easyPieChart').update((initial_less2m_positive / initial * 100).toFixed(2));

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

        function getValue(val) {
            if (isNaN(val))
                return 0;
            else
                return val;
        }
    </script>    
  
    <div id="content">            
        <div class="row">
			<div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">                
				<h1 class="page-title txt-color-blueDark"><i class="fa fa-lg fa-fw fa-bar-chart-o"></i> EID <span>&gt; Facility Dashboard</span></h1>
			</div>
        </div>

        <div class="well">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
            <ContentTemplate>
                <div class="row">
                    <div id="divNational" runat="server">
			            <div class="col-sm-2 pull-left">                 
                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataTextField="ProvinceName" DataValueField="Id">
                                <asp:ListItem Value="0">All</asp:ListItem>
                            </asp:DropDownList><i></i>
			            </div>
                    </div>
                    <div class="col-sm-4 pull-left">
                        <asp:DropDownList ID="ddlFacility" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataTextField="FacilityName" DataValueField="Id" AutoPostBack="false">
                            <asp:ListItem Value="0">All Facilities</asp:ListItem>
                        </asp:DropDownList>
			        </div>            
                    <div class="col-sm-2 pull-left" style="display: none">
                        <asp:DropDownList ID="ddlDate" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0">Yearly</asp:ListItem>
                            <asp:ListItem Value="1">Quarterly</asp:ListItem>
                        </asp:DropDownList><i></i>
                    </div>
                    <div class="col-sm-1 pull-left text-align-right">
                        <asp:Label ID="lblFrom" runat="server" Text="From:"></asp:Label>
                    </div>
                    <div class="col-sm-2 pull-left">
                        <asp:DropDownList ID="ddlYearFrom" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>					
			        </div>
                    <div class="col-sm-1 pull-left text-align-right">
                        <asp:Label ID="lblTo" runat="server" Text="To:"></asp:Label>
                    </div>
                    <div class="col-sm-2 pull-left">
                        <asp:DropDownList ID="ddlYearTo" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>					
			        </div>
                    <div class="col-sm-1 pull-right">
                        								
			        </div>
		        </div>
                <div class="row">
                    <div class="col-sm-4 pull-left text-align-left" style="margin-top: 10px;">
                        <asp:Label ID="Label2" runat="server" Text="State / Region"></asp:Label><span style="padding-left: 20px;"></span>
                        <asp:CheckBox ID="chkAllRegion" runat="server" Text="Select All" oncheckedchanged="chkAllRegion_OnCheckedChanged" AutoPostBack="true" style="text-align: left" role="group" Checked="true" />
                        <br />
                        <div style="border: 1px solid rgba(0,0,0,.1); overflow-y: auto; width: 200px; height: 160px; padding: 5px">
                            <asp:CheckBoxList ID="ddlProvince" runat="server" AutoPostBack="true" DataTextField="ProvinceName" DataValueField="Id" CssClass = "listbox"
                                OnSelectedIndexChanged = "ddlProvince_OnSelectedIndexChanged">
                            </asp:CheckBoxList>
                        </div>                        
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-sm-8 pull-left"  style="margin-top: 10px;">
                        <asp:RadioButtonList ID="rdbFacilityType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbFacilityType_SelectedIndexChanged">
                            <asp:ListItem Value="Public">Public</asp:ListItem>
                            <asp:ListItem Value="Private">Private</asp:ListItem>
                            <asp:ListItem Value="All">Select All</asp:ListItem>
                        </asp:RadioButtonList>
                        <div style="border: 1px solid rgba(0,0,0,.1); overflow-y: auto; width: 200px; height: 160px; padding: 5px">
                            <asp:CheckBoxList ID="ddlFacilityType" runat="server" AppendDataBoundItems="False" DataTextField="FacilityTypeName" DataValueField="Id" RepeatDirection="Vertical" CssClass = "checklistbox">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkAllRegion" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlProvince" EventName="SelectedIndexChanged" />
                <%--<asp:AsyncPostBackTrigger ControlID="rdbFacilityType" EventName="SelectedIndexChanged" />--%>
            </Triggers>
        </asp:UpdatePanel>
            <div class="row">                    
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
         
    <div class="row">
        <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
            <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-eid-summary" data-widget-editbutton="false" role="widget" style="">
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
                        <h2>DNA PCR Test Initial</h2>

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
                        <h2>DNA PCR Test Initial by Age</h2>

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
                                            <div id="testIntialPCRAgeByYearly" style="min-width: 1024px; height: 350px;  margin: 0 auto"></div>
                                        </div>
                                    </div>
				                </div>
				                <div class="tab-pane" id="4">
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRAgeByQuarterly" style="min-width: 1024px; height: 350px;  margin: 0 auto"></div>
                                        </div>
					                </div>
				                </div>
                                <div class="tab-pane" id="5">                                    
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="testIntialPCRAgeByMonthly" style="min-width: 1024px; height: 350px;  margin: 0 auto"></div>
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
						<h2>DNA PCR Test by State & Region / Facility</h2>
                    </header>
                 	<div role="content">
                        <div class="widget-body no-padding">                                        
                            <div id="EIDPCRbyFacility" style="min-width: 1024px; height: 350px;  margin: 0 auto"></div>
                        </div>
					</div>
				</div>
			</article>
		</div>

        <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                  <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-lab-facility" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					    <header role="heading">
                            <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                            <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>						
                            <h2>DNA PCR Sample Drainage by Lab</h2>
                        </header>                  
					    <!-- add: non-hidden - to disable auto hide -->                            
                        <div role="content">
						    <div class="widget-body no-padding">                                     									
                                <div id="eidTestLabAndFacility" style="min-width: 1024px; height: 670px; max-width: 500px; margin: 0 auto;"></div>
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
        
     </section>
   </asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>