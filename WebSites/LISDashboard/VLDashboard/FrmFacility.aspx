<%@ Page Title="HIV VL Facility Dashboard" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="FrmFacility.aspx.cs" Inherits="CHAI.LISDashboard.Modules.VLDashboard.Views.FrmFacility" %>
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

            // VL Test Yearly
            $(function GetVLTestYearly() {
                var subject = JSON.parse('<%= JstringVLTestYearly %>');
                var series = [], categories = [], LE_1000 = [], G_1000 = [], Positivity=[];
                var sums = function(i)
                {                    
                    return LE_1000[i] + G_1000[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    LE_1000.push(subject[i][0]);
                    G_1000.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: '≤ 1000',
                    data: LE_1000,
                    type: 'column'
                    //color: '#57889C'
                },
                {
                    name: '> 1000',
                    data: G_1000,
                    type: 'column'
                    //color: '#ED1C24'
                },
                {
                    type: 'spline',
                    name: 'Suppression',
                    data: Positivity,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'black'
                    }
                });

                BindVLTestYearly(categories, series);
                function BindVLTestYearly(categories, series) {
                    chartVLTestYearly = new Highcharts.chart('vlTestYearly', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: 'VL Test Outcome (Yearly)'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            tickInterval: 10000,
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
                                text: 'Suppression Rate',
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
                        series: series,
                        ////exporting: {
                        ////    csv: {
                        ////        itemDelimiter: ';'
                        ////    },
                        ////    filename: 'changed'
                        ////},
                        //exporting: {
                        //    buttons: {
                        //        contextButton: {
                        //            menuItems: [{
                        //                textKey: 'downloadXLS',
                        //                onclick: function () {
                        //                    this.downloadXLS();
                        //                }
                        //            }, {
                        //                textKey: 'downloadCSV',
                        //                onclick: function () {
                        //                    this.downloadCSV();
                        //                }
                        //            }, {
                        //                textKey: 'downloadPNG',
                        //                onclick: function () {
                        //                    this.exportChart({ type: 'image/png', filename: 'vlTestYearly' });
                        //                }
                        //            }]
                        //        }
                        //    }
                        //},
                    });
                }
            });
            //document.getElementById('vlTestYearlyExportCsv').onclick = () => {
            //    event.preventDefault();
            //    chartVLTestYearly.downloadCSV();

            //    //chart.exportChart({       // not working
            //    //    type: 'text/csv',
            //    //    filename: 'vlTestYearly'
            //    //}, {
            //    //    itemDelimiter: ';',
            //    //    csv: this.chart.getCSV()
            //    //});
            //}

            //document.getElementById('vlTestYearlyExportPng').onclick = () => {
            //    event.preventDefault();                
            //    //chart.exportChart({ filename: 'vlTestYearly' }, null);       // working
            //    chartVLTestYearly.exportChart({ type: 'image/png', filename: 'vlTestYearly' });
            //}


            // VL Test Quarterly
            $(function GetVLTestQuarterly() {
                var subject = JSON.parse('<%= JstringVLTestQuarterly %>');
                var series = [], categories = [], LE_1000 = [], G_1000 = [], Positivity=[];
                var sums = function(i)
                {                    
                    return LE_1000[i] + G_1000[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    LE_1000.push(subject[i][0]);
                    G_1000.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: '≤ 1000',
                    data: LE_1000,
                    type: 'column'
                },
                {
                    name: '> 1000',
                    data: G_1000,
                    type: 'column'
                },
                {
                    type: 'spline',
                    name: 'Suppression',
                    data: Positivity,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'black'
                    }
                });

                BindVLTestQuarterly(categories, series);
                function BindVLTestQuarterly(categories, series) {
                    window.chart = new Highcharts.chart('vlTestQuarterly', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'VL Test Outcome ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> ) Quarterly'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            tickInterval: 1000,
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
                                text: 'Suppression',
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

            // VL Test Monthly
            $(function GetVLTestMonthly() {
                var subject = JSON.parse('<%= JstringVLTestMonthly %>');
                var series = [], categories = [], LE_1000 = [], G_1000 = [], Positivity=[];
                var sums = function(i)
                {                    
                    return LE_1000[i] + G_1000[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    LE_1000.push(subject[i][0]);
                    G_1000.push(subject[i][1]);
                    Positivity.push(subject[i][2]);                    
                }
                series.push({
                    name: '≤ 1000',
                    data: LE_1000,
                    type: 'column'
                },
                {
                    name: '> 1000',
                    data: G_1000,
                    type: 'column'
                },
                {
                    type: 'spline',
                    name: 'Suppression',
                    data: Positivity,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'black'
                    }
                });

                BindVLTestMonthly(categories, series);
                function BindVLTestMonthly(categories, series) {
                    window.chart = new Highcharts.chart('vlTestMonthly', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {                            
                            text: 'VL Test Outcome ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> ) Monthly'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            tickInterval: 1000,
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
                                text: 'Suppression',
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

            // VL Test By Age Yearly
            $(function GetVLTestByAgeYearly() {
                var subject = JSON.parse('<%= JstringVLTestByAgeYearly %>');
                var series = [], categories = [], LE_1000 = [], G_1000 = [], Positivity=[];
                var sums = function(i)
                {                    
                    return LE_1000[i] + G_1000[i];
                }
                for (var i in subject) {
                    if(i == 0)
                        categories.push(subject[i][3]);
                    else
                        categories.push(subject[i][3] + ' yr');
                    LE_1000.push(subject[i][0]);
                    G_1000.push(subject[i][1]);
                    Positivity.push(subject[i][2]);
                    
                }
                series.push({
                    name: '≤ 1000',
                    data: LE_1000,
                    type: 'column'
                },
                {
                    name: '> 1000',
                    data: G_1000,
                    type: 'column'
                },
                {
                    type: 'spline',
                    name: 'Suppression',
                    data: Positivity,
                    lineWidth: 0,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'black',                   
                    }
                });

                BindVLTestByAgeYearly(categories, series);
                function BindVLTestByAgeYearly(categories, series) {
                    window.chart = new Highcharts.chart('vlTestByAgeYearly', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'VL Test Outcome By Age ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
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
                                text: 'Suppression',
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

            // VL Test By Gender Outcome
            $(function GetVLTestByGenderOutcome() {
                var subject = JSON.parse('<%= JstringVLTestByGender %>');
                var series = [], categories = [], LE_1000 = [], G_1000 = [], Suppression_Rate=[];
                var sums = function(i)
                {                    
                    return LE_1000[i] + G_1000[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    LE_1000.push(subject[i][0]);
                    G_1000.push(subject[i][1]);
                    Suppression_Rate.push(subject[i][2]);
                    
                }
                series.push({
                    name: '≤ 1000',
                    data: LE_1000,
                    type: 'column',
                },
                {
                    name: '> 1000',
                    data: G_1000,
                    type: 'column',
                },
                {
                    type: 'spline',
                    name: 'Suppression',
                    data: Suppression_Rate,
                    lineWidth: 0,
                    yAxis: 1,
                    marker: {
                        lineWidth: 2,
                        lineColor: Highcharts.getOptions().colors[3],
                        fillColor: 'black'
                    }
                });

                BindVLTestByGenderOutcome(categories, series);
                function BindVLTestByGenderOutcome(categories, series) {
                    window.chart = new Highcharts.chart('vlTestByGenderOutcome', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'VL Test Outcome by Gender ( ' + <%= ddlYearFrom.SelectedItem.Text %> + ' - ' + <%= ddlYearTo.SelectedItem.Text %> + ' )'
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
                                text: 'Suppression',
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
            
            // VL Test By Province
            $(function GetVLTestByProvince() {
                var subject = JSON.parse('<%= JstringVLTestByProvince %>');
                var series = [], categories = [], LE_1000 = [], G_1000 = [], Suppression_Rate = [], Target = [];
                var sums = function(i)
                {                    
                    return LE_1000[i] + G_1000[i];
                }
                for (var i in subject) {
                    categories.push(subject[i][3]);
                    LE_1000.push(subject[i][0]);
                    G_1000.push(subject[i][1]);
                    Suppression_Rate.push(subject[i][2]);
                    Target.push(90);
                }
                series.push({
                    name: '≤ 1000',
                    data: LE_1000,
                    type: 'column',
                },
                {
                    name: '> 1000',
                    data: G_1000,
                    type: 'column',
                },
                {
                    type: 'spline',
                    name: 'Suppression',
                    data: Suppression_Rate,
                    lineWidth: 0,
                    yAxis: 1,
                    color: '#F2784B',
                    marker: {
                        lineWidth: 2,
                        lineColor: '#F2784B',
                        fillColor: '#F2784B'
                    }
                },
                {
                    type: 'spline',
                    name: 'Target',
                    data: Target,
                    lineWidth: 2,
                    yAxis: 1,
                    color: '#1BA39C',
                    marker: {
                        lineWidth: 2,
                        lineColor: '#1BA39C',
                        fillColor: '#1BA39C'
                    }
                });

                BindVLTestByProvince(categories, series);
                function BindVLTestByProvince(categories, series) {
                    window.chart = new Highcharts.chart('vlTestByProvince', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'VL Test Outcome by Facility ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            tickInterval: 1000,
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
                                text: 'Suppression',
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
                                        point.y + (i == 2 || i == 3 ? ' %' : '');
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

            // VL Test Age Group By Province
            <%--$(function GetVLTestAgeGroupByProvince() {
                var subject = JSON.parse('<%= JstringVLTestAgeGroupByProvince %>');
                var series = [], categories = [], LE_1000 = [], G_1000 = [], Suppression_Rate = [], AgeRange = [], Target = [];
                var sums = function(i)
                {                    
                    return LE_1000[i] + G_1000[i];
                }
                for (var i in subject) {                    
                    categories.push(subject[i][3]);
                    LE_1000.push(subject[i][0]);
                    G_1000.push(subject[i][1]);
                    Suppression_Rate.push(subject[i][2]);
                    //Target.push(90);                    
                }
                series.push({
                    name: '≤ 1000',
                    data: LE_1000,
                    type: 'column',
                },
                {
                    name: '> 1000',
                    data: G_1000,
                    type: 'column',
                },      
                {
                    type: 'spline',
                    name: 'Suppression',
                    data: Suppression_Rate,
                    lineWidth: 0,
                    yAxis: 1,
                    color: '#F2784B',
                    marker: {
                        lineWidth: 2,
                        lineColor: '#F2784B',
                        fillColor: '#F2784B'
                    }
                },               
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

                BindVLTestAgeGroupByProvince(categories, series);
                function BindVLTestAgeGroupByProvince(categories, series) {
                    window.chart = new Highcharts.chart('vlTestAgeGroupByProvince', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'VL Test Age Group Outcome by State & Region / Facility ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 0
                        },
                        yAxis: [{   // Primary yAxis
                            min: 0,
                            tickInterval: 1000,
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
                                text: 'Suppression',
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
                                        point.y + (i == 2 || i == 3 ? ' %' : '');
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
            });--%>

            // VL Test Reject By State & Region / Facility
            $(function GetVLTestRejectByProvince() {
                var subject = JSON.parse('<%= JstringVLTestRejectByProvince %>');
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

                BindVLTestRejectByProvince(categories, series);
                function BindVLTestRejectByProvince(categories, series) {
                    window.chart = new Highcharts.chart('vlTestRejectByProvince', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: 'VL Test Rejection by State & Region / Facility ( <%= ddlYearFrom.SelectedItem.Text %> - <%= ddlYearTo.SelectedItem.Text %> )'
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

            // VL Sample Drainage by Lab            
            $(function GetVLTestLabAndFacility() {
                var subject = JSON.parse('<%= JstringVLTestLabAndFacility %>');
                var series = [], categories = [],
                    l1 = [], l2 = [], l3 = [], l4 = [], l5 = [],
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
                               
                BindVLTestLabAndFacility(categories, series);
                function BindVLTestLabAndFacility(categories, series) {
                    window.chart = new Highcharts.chart('vlTestLabAndFacility', {
                        chart: {
                            renderTo: "container",
                            type: 'column',                            
                        },
                        title: {
                            text: 'VL Sample Drainage by Lab ( ' + <%= ddlYearFrom.SelectedItem.Text %> + ' - ' + <%= ddlYearTo.SelectedItem.Text %> + ' )'
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
                }
            });

            // VL Positive Negative Summary
            $(function GetVLSummary() {
                var subject = JSON.parse('<%= JstringVLSummary %>');
                var series = [], categories = [], total_received = 0, total_tested = 0, not_suppressed = 0, suppressed = 0,
                    ldl = 0, rejected = 0, rejected_rate = 0, error = 0, error_rate = 0;
                total_received += getValue(subject[0][0]);
                total_tested += getValue(subject[0][1]);
                not_suppressed += getValue(subject[0][2]);
                suppressed += getValue(subject[0][3]);
                ldl += getValue(subject[0][4]);
                rejected += getValue(subject[0][5]);
                rejected_rate += getValue(subject[0][6]);
                error += getValue(subject[0][7]);
                error_rate += error/total_received * 100;

                var detail = '<table id="dt_basic" class="table table-striped table-bordered table-hover" style="margin-bottom: 0px; margin-left: 20px;">' +
                    '<tbody>';
                detail += '<tr><td>Total VL Sample Collected:</td><td style="text-align: right">' + total_received + '</td>' +
                    //'<td>Not Suppressed:</td><td style="text-align: right">' + not_suppressed + ' <span class="txt-color-blue">(' + (not_suppressed/total_tested * 100).toFixed(2) + '%)</span></td></tr>';
                    '<td></td><td style="text-align: right"><span class="txt-color-blue"></span></td></tr>';
                detail += '<tr class="txt-color-red"><td>Rejected Samples:</td><td style="text-align: right">' + rejected + '</td>' +
                    '<td>Rejection (%):</td><td style="text-align: right"><span class="txt-color-red">' + rejected_rate + '%</span></td></tr>';
                detail += '<tr class="txt-color-green"><td>Total Tested:</td><td style="text-align: right">' + total_tested + '</td>' +
                    '<td></td><td style="text-align: right"><span class="txt-color-green"></span></td></tr>';
                detail += '<tr class="txt-color-red"><td>Invalid/Error:</td><td style="text-align: right">' + error + '</td>' +
                    '<td>Invalid/Error Rate (%):</td><td style="text-align: right"><span class="txt-color-red">' + (error/total_received * 100).toFixed(2) + '%</span></td></tr>';
                detail += '<tr class="txt-color-green"><td>Total Tested valid Outcome:</td><td style="text-align: right">' + (total_tested-error) + '</td>' +
                    '<td></td><td style="text-align: right"><span class="txt-color-green"></span></td></tr>';
                detail += '<tr><td style="padding-left: 30px">Valid Tests > 1000 copies/ml:</td><td style="text-align: right">' + not_suppressed + '</td>' +
                    '<td>Not Suppressed (%):</td><td style="text-align: right"><span class="txt-color-blue">' + (not_suppressed/(total_tested-error) * 100).toFixed(2) + '%</span></td></tr>';
                detail += '<tr><td style="padding-left: 30px"> Valid Tests ≤ 1000 copies/ml:</td><td style="text-align: right">' + suppressed + '</td>' +
                    '<td>Suppressed (%):</td><td style="text-align: right"><span class="txt-color-blue">' + (suppressed/(total_tested-error) * 100).toFixed(2) + '%</span></td></tr>';                
                //detail += '<tr><td style="padding-left: 30px"> Valid Tests < LDL:</td><td style="text-align: right">' + ldl + '</td>' +
                //    '<td>LDL (%):</td><td style="text-align: right"><span class="txt-color-blue">' + (ldl/total_tested * 100).toFixed(2) + '%</span></td></tr>';                
                detail += '</tbody></table>';
                $('#SummaryDetail').html(detail);
                
                $('#SuppressedRate').html((suppressed/(total_tested-error) * 100).toFixed(2));
                $("#SuppressedRate").attr("data-percent", (suppressed/(total_tested-error) * 100).toFixed(2));
                $('#easyPie1').data('easyPieChart').update((suppressed/(total_tested-error) * 100).toFixed(2));

                $('#NotSuppressedRate').html((not_suppressed/(total_tested-error) * 100).toFixed(2));
                $("#NotSuppressedRate").attr("data-percent", (not_suppressed/(total_tested-error) * 100).toFixed(2));
                $('#easyPie2').data('easyPieChart').update((not_suppressed/(total_tested-error) * 100).toFixed(2));

                $('#ErrorRate').html((error/total_received * 100).toFixed(2));
                $("#ErrorRate").attr("data-percent", (error/total_received * 100).toFixed(2));
                $('#easyPie3').data('easyPieChart').update((error/total_received * 100).toFixed(2));

                $('#Suppressed').html(suppressed);
                $('#NotSuppressed').html(not_suppressed);
                $('#Error').html(error);

                var slice_data = [];
                slice_data.push({
                    name: 'Not Suppressed',                    
                    y: not_suppressed
                },
                {
                    name: 'Suppressed',
                    y: suppressed
                },
                {
                    name: 'Rejected',
                    y: rejected
                },
                {
                    name: 'Invalid/Error',
                    y: error
                }
                //{
                //    name: '< LDL',
                //    y: ldl
                //}
                );
                
                series.push({
                    name: 'VL_Summary',
                    colorByPoint: true,                    
                    data: slice_data
                });                

                BindVLSummary(categories, series);
                function BindVLSummary(categories, series) {
                    window.chart = new Highcharts.chart('VLSummary', {
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

<%--            $(function GetVLTATTrends() {
                var subject = JSON.parse('<%=JstringVLTATTrends%>');
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
                } else
                {
                    categories=['Q1','Q2','Q3','Q4']
                    for (var i in subject) {
                        series.push({                        
                            name: subject[i][4],
                            data: [subject[i][0],subject[i][1],subject[i][2],subject[i][3]]                   
                        });
                    }
                    
                 }
               

                BindVLTATTrends(categories, series);
                function BindVLTATTrends(categories, series) {
                    window.chart = new Highcharts.chart('TurnaroundTime', {
                        chart: {
                            type: 'spline',
                            height: 250
                        },
                        title: {
                            text: ''
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1
                        },
                        yAxis: {
                            title: {
                                text: 'TAT (Days)'
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
            });--%>
            
        });

        function getValue(val){
            if(isNaN(val))
                return 0;
            else
                return val;            
        }
    </script>    
  
    <div id="content">
        <div class="row">
	        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">                
		        <h1 class="page-title txt-color-blueDark"><i class="fa fa-lg fa-fw fa-bar-chart-o"></i> HIV Viral Load <span>&gt; Facility Dashboard</span></h1>
	        </div>
            <%--<div class="col-xs-12 col-sm-5 col-md-5 col-lg-8">
				<ul id="sparks" class="">
					<li class="sparks-info">
						<h5>Total Tests <span class="txt-color-blue"> <asp:Label ID="lblTotTests" runat="server" /></span></h5>								
					</li>                    
                    <li class="sparks-info">
						<h5>Rejected %<span class="txt-color-blue"> <asp:Label ID="lblNoOfRejectedSample" runat="server" /></span></h5>								
					</li>
                    <li class="sparks-info">
						<h5>≤ 1000 <span class="txt-color-blue"> <asp:Label ID="lblTotDetectedLE1000" runat="server" /></span></h5>								
					</li>
                    <li class="sparks-info">
						<h5>> 1000 <span class="txt-color-blue"> <asp:Label ID="lblTotDetectedG1000" runat="server" /></span></h5>								
					</li>                    
					<li class="sparks-info">
						<h5>Invalid/Error <span class="txt-color-purple"> <asp:Label ID="lblError" runat="server" /></span></h5>
					</li>                    
				</ul>
		    </div>--%>
        </div>

        <div class="well">
            
        <%--<div class="row">
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
                <asp:Button ID="btnFilter" class="btn btn-default btn-primary" runat="server" Text="Filter" OnClick="btnFilter_Click"  />								
			</div>
		</div>--%>

        <%--<div class="row">
            <div id="divFacilities" runat="server" role="content" class="col-sm-12 pull-left">                    
                <div class="widget-body">
                    <p class="alert alert-info" style="margin-top: 10px">
                        Facilities concerned with this user ...                                            					                                
					</p>
                    <asp:PlaceHolder ID="plhFacilities" runat="server"></asp:PlaceHolder>

                    <form class="smart-form">
                        <label class="radio">
                            <input type="radio" name="radio"><i></i>Clemencia
                        </label>
                    </form>
                </div>
            </div>
        </div>--%>
        
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
				<%--<h1 class="page-title txt-color-blueDark"><i class="fa fa-lg fa-fw fa-bar-chart-o"></i> HIV VL <span>&gt; Program Dashboard</span></h1>--%>
			</div>			   
		</div>
        <div class="row" id="easy-pie-chart-row">
            <div class="show-stat-microcharts">               
                <%--<div class="col-xs-6 col-sm-3 col-md-3 col-lg-3">
					
				</div>    --%>            
				<div class="col-xs-8 col-sm-4 col-md-4 col-lg-4">
                    <div id="easyPie1" class="easy-pie-chart txt-color-greenLight easyPieChart" data-percent="" data-pie-size="50" style="width: 50px; height: 50px; line-height: 50px; top: -20px;">
					    <span class="percent percent-sign" id="SuppressedRate"></span>
					    <canvas width="50" height="50"></canvas>
                    </div>                    
                    <span class="easy-pie-title"> (Suppressed) Valid Tests ≤ 1000 copies/ml <br /> <%--<i class="fa fa-caret-down icon-color-good"></i>--%>
                        <span class="txt-color-blue" id="Suppressed"></span>
                    </span>
                </div>
                <div class="col-xs-8 col-sm-4 col-md-4 col-lg-4">
                    <div id="easyPie2" class="easy-pie-chart txt-color-red easyPieChart" data-percent="" data-pie-size="50" style="width: 50px; height: 50px; line-height: 50px; top: -20px;">
					    <span class="percent percent-sign" id="NotSuppressedRate"></span>
					    <canvas width="50" height="50"></canvas>                        
                    </div>
                    <span class="easy-pie-title"> (Not Suppressed) Valid Tests > 1000 copies/ml <br /> <%--<i class="fa fa-caret-up icon-color-bad"></i>--%>
                        <span class="txt-color-blue" id="NotSuppressed"></span>
                    </span>
                </div>
                <div class="col-xs-8 col-sm-4 col-md-4 col-lg-4">
                    <div id="easyPie3" class="easy-pie-chart txt-color-blue easyPieChart" data-percent="" data-pie-size="50" style="width: 50px; height: 50px; line-height: 50px; top: -20px;">
					    <span class="percent percent-sign" id="ErrorRate"></span>
					    <canvas width="50" height="50"></canvas>
                    </div>
                    <span class="easy-pie-title"> Invalid/Error <br /> <%--<i class="fa fa-caret-down icon-color-bad"></i>--%>
                        <span class="txt-color-blue" id="Error"></span>
                    </span>
                </div>
                <%--<div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <h5 style="margin:5px 0 0 0"> Invalid/Error/Noresult <span class="txt-color-purple"><asp:Label ID="lblError" runat="server" Text=""/></span></h5>
                </div>--%>
            </div>
        </div>

     </div>     

    <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-vl-summary" data-widget-editbutton="false" role="widget" style="">
				<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>					
                    <h2>VL Summary</h2>             
                </header>
                <div role="content">
                    <div class="widget-body no-padding">                        
                        <div id="VLSummary" style="min-width: 450px; height: 200px; margin: 0 auto; float: left"></div>
                        <div id="SummaryDetail" style="min-width: 450px; margin: 10px auto; overflow-y: no-display; float: left"></div>                        
                    </div>                    
				</div>
                <%--<div role="content">
                    <div class="widget-body no-padding">
                    </div>
				</div>--%>
			</div>
            </article>
		</div>

    <section id="widget-grid" class="">
        <!-- VL Testing -->
        <div class="row">
            <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable" id="tabInitialPCR" data-widget-editbutton="false" data-widget-colorbutton="false" role="widget">
	                <header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-darken"></i></span>
                        <h2>VL Test Outcome</h2>

		                <div class="jarviswidget-ctrls" role="menu">
			                <a href="#" class="button-icon jarviswidget-toggle-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Collapse"><i class="fa fa-minus "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a>

			                <a href="javascript:void(0);" class="button-icon jarviswidget-delete-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Delete"><i class="fa fa-times"></i></a>
		                </div>
                                                                       
		                <ul class="nav nav-tabs pull-right">
			                <li class="active">                                
				                <a href="#0" data-toggle="tab"><i class="fa fa-clock-o"></i> Yearly</a>
			                </li>
			                <li class="">                                
				                <a href="#1" data-toggle="tab"><i class="fa fa-clock-o"></i> Quarterly</a>
			                </li>
                            <li class="">                                
				                <a href="#2" data-toggle="tab"><i class="fa fa-clock-o"></i> Monthly</a>
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
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="vlTestYearly" style="min-width: 1024px; height: 350px; margin: 0 auto"></div>
                                            <%--<button id="vlTestYearlyExportCsv">Export to CSV</button>
                                            <button id="vlTestYearlyExportPng">Export to PNG</button>--%>                                            
                                        </div>
                                    </div>
				                </div>
				                <div class="tab-pane" id="1">                                    
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="vlTestQuarterly" style="min-width: 1024px; height: 350px; margin: 0 auto"></div>
                                        </div>
					                </div>
				                </div>
                                <div class="tab-pane" id="2">                                    
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="vlTestMonthly" style="min-width: 1024px; height: 350px; margin: 0 auto"></div>
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
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-by-age-yearly" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
                    <header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>	                    
                        <h2> VL Test Outcome By Age</h2>
                    </header>                  
                    <!-- add: non-hidden - to disable auto hide -->                            
                    <div role="content">
	                    <div class="widget-body no-padding">                            
                            <div id="vlTestByAgeYearly" style="min-width: 300px; height: 350px; max-width: 500px; margin: 0 auto"></div>
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
                        <h2>VL Test Outcome By Gender</h2>
                    </header>                  
					<!-- add: non-hidden - to disable auto hide -->                            
                    <div role="content">
						<div class="widget-body no-padding">                                     									
                            <div id="vlTestByGenderOutcome" style="min-width: 300px; height: 350px; max-width: 500px; margin: 0 auto"></div>                                       
						</div>
					</div>
			 </div>             
		 </article>
        </div>
       
        <div class="row">
		    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
                  <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-facility" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					    <header role="heading">
                            <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                            <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>						
                            <h2>VL Test Outcome by Facility</h2>
                        </header>                  
					    <!-- add: non-hidden - to disable auto hide -->                            
                        <div role="content">
						    <div class="widget-body no-padding">                                     									
                                <div id="vlTestByProvince" style="min-width: 1024px; height: 520px; max-width: 500px; margin: 0 auto;"></div>
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
                            <h2>Sample Drainage by Lab</h2>
                        </header>                  
					    <!-- add: non-hidden - to disable auto hide -->                            
                        <div role="content">
						    <div class="widget-body no-padding">                                     									
                                <div id="vlTestLabAndFacility" style="min-width: 1024px; height: 670px; max-width: 500px; margin: 0 auto;"></div>
						    </div>
					    </div>
			     </div>
            </article>
		</div>

        <%--<div class="row">
         <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-agegroup-facility" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
                    <header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>                       
                        <h2>VL Test Age Group Outcome by State & Region / Facility</h2>
                    </header>                  
                    <!-- add: non-hidden - to disable auto hide -->                            
                    <div role="content">
                        <div class="widget-body no-padding">                                                                        
                            <div id="vlTestAgeGroupByProvince" style="min-width: 1024px; height: 300px; margin: 0 auto;"></div>
                        </div>
                    </div>
             </div>
         </article>
        </div>--%>
        
        <div class="row">
		 <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-reject" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					<header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>						
                        <h2>VL Test Rejection by State & Region / Facility</h2>
                    </header>                  
					<!-- add: non-hidden - to disable auto hide -->                            
                    <div role="content">
						<div class="widget-body no-padding">                                     									
                            <div id="vlTestRejectByProvince" style="min-width: 1024px; height: 420px; margin: 0 auto;"></div>
						</div>
					</div>
			 </div>
		 </article>
		</div>

        <%--<div class="row">
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-8" data-widget-editbutton="false" role="widget" style="">
				<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>					
                    <h2>VL Outcome</h2>             
                </header>
                <div role="content">
                    <div class="widget-body no-padding">
                        <div id="VLSummary" style="min-width: 300px; height: 300px; margin: 0 auto;"></div>
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
        <!-- End Tab -->        

        <%--<div class="row">            
		    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">            
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-turnaround" data-widget-editbutton="false" role="widget" style="">								
					<header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>Turnaround Time (Collection - Dispatch)</h2>
                    </header>
                 	<div>
                        <div class="widget-body no-padding">                            
                            <div id="TurnaroundTime" style="min-width: 1024px; height: 250px; margin: 0 auto"></div>
                        </div>
					</div>
				</div>
			</article>            
        </div>--%>
              
     </section>
   </asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>

