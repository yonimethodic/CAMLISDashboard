<%@ Page Title="HIV VL Lab Dashboard" Language="C#" MasterPageFile="~/Shared/ModuleMaster.master" AutoEventWireup="true" CodeFile="FrmLab.aspx.cs" Inherits="CHAI.LISDashboard.Modules.VLDashboard.Views.FrmLab" %>
<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" Runat="Server">
    
    <script src="../js/libs/jquery-2.0.2.min.js"></script>
    <%--<script src="../js/bootstrap/bootstrap-datetimepicker.min.js"></script>--%>

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
                yearRange: '2018:' + new Date().getFullYear(),

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

            //$(function() {
            //    $('.date-picker').datepicker( {
            //        changeMonth: true,
            //        changeYear: true,
            //        showButtonPanel: true,
            //        dateFormat: 'mm/yy',
            //        onClose: function(dateText, inst) { 
            //            $(this).datepicker('setDate', new Date(inst.selectedYear, inst.selectedMonth, 1));
            //        }
            //        //justMonth: true,
            //        //create: function(input, inst) {
            //        //    $(".ui-datepicker table").addClass("badbad");
            //        //},
            //        //onClose: function(dateText, inst) {
            //        //    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
            //        //    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
            //        //    $(this).datepicker('setDate', new Date(year, month, 1));
            //        //}
            //    });
            //});

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
                if('<%= JstringVLTestYearly %>' == '')
                    return;

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
                                text: 'Supperssion',
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
                        series: series,
                        //exporting: {
                        //    csv: {
                        //        itemDelimiter: ';'
                        //    },
                        //    filename: 'changed'
                        //},
                        exporting: {
                            buttons: {
                                contextButton: {
                                    menuItems: [{
                                        textKey: 'downloadXLS',
                                        onclick: function () {
                                            this.downloadXLS();
                                        }
                                    }, {
                                        textKey: 'downloadCSV',
                                        onclick: function () {
                                            this.downloadCSV();
                                        }
                                    }, {
                                        textKey: 'downloadPNG',
                                        onclick: function () {
                                            this.exportChart({ type: 'image/png', filename: 'vlTestYearly' });
                                        }
                                    }]
                                }
                            }
                        },
                    });
                }
            });
            document.getElementById('vlTestYearlyExportCsv').onclick = () => {
                event.preventDefault();
                chartVLTestYearly.downloadCSV();

                //chart.exportChart({       // not working
                //    type: 'text/csv',
                //    filename: 'vlTestYearly'
                //}, {
                //    itemDelimiter: ';',
                //    csv: this.chart.getCSV()
                //});
            }

            document.getElementById('vlTestYearlyExportPng').onclick = () => {
                event.preventDefault();                
                //chart.exportChart({ filename: 'vlTestYearly' }, null);       // working
                chartVLTestYearly.exportChart({ type: 'image/png', filename: 'vlTestYearly' });
            }


            // VL Test Quarterly
            $(function GetVLTestQuarterly() {
                if('<%= JstringVLTestQuarterly %>' == '')
                    return;
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
                            text: 'VL Test Outcome ( <%= hdnStartDate.Value %> ) Quarterly'
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

            // VL Test Monthly
            $(function GetVLTestMonthly() {
                if('<%= JstringVLTestMonthly %>' == '')
                    return;
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
                            text: 'VL Test Outcome ( <%= hdnStartDate.Value %> ) Monthly'
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

            // VL Test By Age Yearly
            $(function GetVLTestByAgeYearly() {
                if('<%= JstringVLTestByAgeYearly %>' == '')
                    return;
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
                            text: 'VL Test Outcome By Age ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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
                if('<%= JstringVLTestByGender %>' == '')
                    return;
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
                            text: 'VL Test Outcome by Gender ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'                            
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
                if('<%= JstringVLTestByProvince %>' == '')
                    return;
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
                            text: 'VL Test Outcome by State & Region / Facility ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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

            // VL Test Reason All Instruments By Lab
            $(function GetVLTestReasonAllInstruments() {
                if('<%= JstringVLTestReasonAll %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestReasonAll %>');
                var series = [], categories = [], cat1 = [], cat2 = [], cat3 = [], cat4 = [], cat5 = [], cat6 = [];
                
                for (var i in subject) {
                    categories.push(subject[i][6]);
                    cat1.push(subject[i][0]);
                    cat2.push(subject[i][1]);
                    cat3.push(subject[i][2]);
                    cat4.push(subject[i][3]);
                    cat5.push(subject[i][4]);
                    cat6.push(subject[i][5]);
                }
                series.push({
                    name: 'Not mentioned on form',
                    data: cat1
                },
                {
                    name: 'Other',
                    data: cat2
                },
                {
                    name: 'Repeated after enhanced adherence',
                    data: cat3
                },
                {
                    name: 'Routine',
                    data: cat4
                },
                {
                    name: 'Targeted',
                    data: cat5
                },
                {
                    name: 'VL for Pregnant Woman',
                    data: cat6
                }
            );

                BindVLTestReasonAllInstruments(categories, series);
                function BindVLTestReasonAllInstruments(categories, series) {
                    window.chart = new Highcharts.chart('vlTestReasonAllInstruments', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'All ( <%= txtStartDate.Text %>  - <%= txtEndDate.Text %> )'
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
                            //headerFormat: '<b>{point.x}</b><br/>',
                            //pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
                            formatter: function() {
                                var s = '<b>'+ this.x +'</b>',
                                    sum = 0;

                                $.each(this.points, function(i, point) {
                                    s += '<br/><span style="color:' + point.color + '">\u25CF</span>' + ' ' + point.series.name +': '+
                                        point.y;                                    
                                    sum += point.y;
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

            // VL Test By Lab (Abbott)
            $(function GetVLTestReasonByAbbott() {
                if('<%= JstringVLTestReasonByAbbott %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestReasonByAbbott %>');
                var series = [], categories = [], cat1 = [], cat2 = [], cat3 = [], cat4 = [], cat5 = [], cat6 = [];
                
                for (var i in subject) {
                    categories.push(subject[i][6]);
                    cat1.push(subject[i][0]);
                    cat2.push(subject[i][1]);
                    cat3.push(subject[i][2]);
                    cat4.push(subject[i][3]);
                    cat5.push(subject[i][4]);
                    cat6.push(subject[i][5]);
                }
                series.push({
                    name: 'Not mentioned on form',
                    data: cat1
                },
                {
                    name: 'Other',
                    data: cat2
                },
                {
                    name: 'Repeated after enhanced adherence',
                    data: cat3
                },
                {
                    name: 'Routine',
                    data: cat4
                },
                {
                    name: 'Targeted',
                    data: cat5
                },
                {
                    name: 'VL for Pregnant Woman',
                    data: cat6
                }
            );

                BindVLTestReasonByAbbott(categories, series);
                function BindVLTestReasonByAbbott(categories, series) {
                    window.chart = new Highcharts.chart('vlTestReasonByAbbott', {
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

            // VL Test By Lab (BioCentric)
            $(function GetVLTestReasonByBioCentric() {
                if('<%= JstringVLTestReasonByBioCentric %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestReasonByBioCentric %>');
                var series = [], categories = [], cat1 = [], cat2 = [], cat3 = [], cat4 = [], cat5 = [], cat6 = [];
                
                for (var i in subject) {
                    categories.push(subject[i][6]);
                    cat1.push(subject[i][0]);
                    cat2.push(subject[i][1]);
                    cat3.push(subject[i][2]);
                    cat4.push(subject[i][3]);
                    cat5.push(subject[i][4]);
                    cat6.push(subject[i][5]);
                }
                series.push({
                    name: 'Not mentioned on form',
                    data: cat1
                },
                {
                    name: 'Other',
                    data: cat2
                },
                {
                    name: 'Repeated after enhanced adherence',
                    data: cat3
                },
                {
                    name: 'Routine',
                    data: cat4
                },
                {
                    name: 'Targeted',
                    data: cat5
                },
                {
                    name: 'VL for Pregnant Woman',
                    data: cat6
                }
            );

                BindVLTestReasonByBioCentric(categories, series);
                function BindVLTestReasonByBioCentric(categories, series) {
                    window.chart = new Highcharts.chart('vlTestReasonByBioCentric', {
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

            // VL Test By Lab (GeneXpert)
            $(function GetVLTestReasonByGeneXpert() {
                if('<%= JstringVLTestReasonByGeneXpert %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestReasonByGeneXpert %>');
                var series = [], categories = [], cat1 = [], cat2 = [], cat3 = [], cat4 = [], cat5 = [], cat6 = [];
                
                for (var i in subject) {
                    categories.push(subject[i][6]);
                    cat1.push(subject[i][0]);
                    cat2.push(subject[i][1]);
                    cat3.push(subject[i][2]);
                    cat4.push(subject[i][3]);
                    cat5.push(subject[i][4]);
                    cat6.push(subject[i][5]);
                }
                series.push({
                    name: 'Not mentioned on form',
                    data: cat1
                },
                {
                    name: 'Other',
                    data: cat2
                },
                {
                    name: 'Repeated after enhanced adherence',
                    data: cat3
                },
                {
                    name: 'Routine',
                    data: cat4
                },
                {
                    name: 'Targeted',
                    data: cat5
                },
                {
                    name: 'VL for Pregnant Woman',
                    data: cat6
                }
            );

                BindVLTestReasonByGeneXpert(categories, series);
                function BindVLTestReasonByGeneXpert(categories, series) {
                    window.chart = new Highcharts.chart('vlTestReasonByGeneXpert', {
                        chart: {
                            type: 'column',
                           
                        },
                        title: {
                            text: 'GeneXpert ( <%= txtStartDate.Text %>  - <%= txtEndDate.Text %> )'
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
            $(function GetVLTestReasonAllInstrumentsPieChart() {
                if('<%= JstringVLTestReasonAll %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestReasonAll %>');
                var series = [], categories = [], cat1_total = 0, cat2_total = 0, cat3_total = 0, cat4_total = 0, cat5_total = 0, cat6_total = 0;                                
                for (var i in subject) {                    
                    categories.push(subject[i][6]);
                    cat1_total += subject[i][0];
                    cat2_total += subject[i][1];
                    cat3_total += subject[i][2];
                    cat4_total += subject[i][3];
                    cat5_total += subject[i][4];
                    cat6_total += subject[i][5];
                }

                var slice_data = [];
                slice_data.push({
                    name: 'Not mentioned on form',                    
                    y: cat1_total
                },
                {
                    name: 'Other',                    
                    y: cat2_total
                },
                {
                    name: 'Repeated after enhanced adherence',                    
                    y: cat3_total
                },
                {
                    name: 'Routine',                    
                    y: cat4_total
                },
                {
                    name: 'Targeted',                    
                    y: cat5_total
                },
                {
                    name: 'VL for Pregnant Woman',                    
                    y: cat6_total
                });
                
                series.push({
                    name: 'Reasons',
                    colorByPoint: true,                    
                    data: slice_data
                });

                BindVLTestReasonAllInstrumentsPieChart(categories, series);
                function BindVLTestReasonAllInstrumentsPieChart(categories, series) {
                    window.chart = new Highcharts.chart('vlTestReasonAllInstrumentsPieChart', {
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
            $(function GetVLTestReasonByAbbottPieChart() {
                if('<%= JstringVLTestReasonByAbbott %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestReasonByAbbott %>');
                var series = [], categories = [], cat1_total = 0, cat2_total = 0, cat3_total = 0, cat4_total = 0, cat5_total = 0, cat6_total = 0;                                
                for (var i in subject) {                    
                    categories.push(subject[i][6]);
                    cat1_total += subject[i][0];
                    cat2_total += subject[i][1];
                    cat3_total += subject[i][2];
                    cat4_total += subject[i][3];
                    cat5_total += subject[i][4];
                    cat6_total += subject[i][5];
                }

                var slice_data = [];
                slice_data.push({
                    name: 'Not mentioned on form',                    
                    y: cat1_total
                },
                {
                    name: 'Other',                    
                    y: cat2_total
                },
                {
                    name: 'Repeated after enhanced adherence',                    
                    y: cat3_total
                },
                {
                    name: 'Routine',                    
                    y: cat4_total
                },
                {
                    name: 'Targeted',                    
                    y: cat5_total
                },
                {
                    name: 'VL for Pregnant Woman',                    
                    y: cat6_total
                });
                
                series.push({
                    name: 'Reasons',
                    colorByPoint: true,                    
                    data: slice_data
                });

                BindVLTestReasonByAbbottPieChart(categories, series);
                function BindVLTestReasonByAbbottPieChart(categories, series) {
                    window.chart = new Highcharts.chart('vlTestReasonByAbbottPieChart', {
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
            $(function GetVLTestReasonByGeneXpertPieChart() {
                if('<%= JstringVLTestReasonByGeneXpert %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestReasonByGeneXpert %>');
                var series = [], categories = [], cat1_total = 0, cat2_total = 0, cat3_total = 0, cat4_total = 0, cat5_total = 0, cat6_total = 0;                                
                for (var i in subject) {                    
                    categories.push(subject[i][6]);
                    cat1_total += subject[i][0];
                    cat2_total += subject[i][1];
                    cat3_total += subject[i][2];
                    cat4_total += subject[i][3];
                    cat5_total += subject[i][4];
                    cat6_total += subject[i][5];
                }

                var slice_data = [];
                slice_data.push({
                    name: 'Not mentioned on form',                    
                    y: cat1_total
                },
                {
                    name: 'Other',                    
                    y: cat2_total
                },
                {
                    name: 'Repeated after enhanced adherence',                    
                    y: cat3_total
                },
                {
                    name: 'Routine',                    
                    y: cat4_total
                },
                {
                    name: 'Targeted',                    
                    y: cat5_total
                },
                {
                    name: 'VL for Pregnant Woman',                    
                    y: cat6_total
                });
                
                series.push({
                    name: 'Reasons',
                    colorByPoint: true,                    
                    data: slice_data
                });

                BindVLTestReasonByGeneXpertPieChart(categories, series);
                function BindVLTestReasonByGeneXpertPieChart(categories, series) {
                    window.chart = new Highcharts.chart('vlTestReasonByGeneXpertPieChart', {
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: ''
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
            $(function GetVLTestReasonByBioCentricPieChart() {
                if('<%= JstringVLTestReasonByBioCentric %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestReasonByBioCentric %>');
                var series = [], categories = [], cat1_total = 0, cat2_total = 0, cat3_total = 0, cat4_total = 0, cat5_total = 0, cat6_total = 0;                                
                for (var i in subject) {                    
                    categories.push(subject[i][6]);
                    cat1_total += subject[i][0];
                    cat2_total += subject[i][1];
                    cat3_total += subject[i][2];
                    cat4_total += subject[i][3];
                    cat5_total += subject[i][4];
                    cat6_total += subject[i][5];
                }

                var slice_data = [];
                slice_data.push({
                    name: 'Not mentioned on form',                    
                    y: cat1_total
                },
                {
                    name: 'Other',                    
                    y: cat2_total
                },
                {
                    name: 'Repeated after enhanced adherence',                    
                    y: cat3_total
                },
                {
                    name: 'Routine',                    
                    y: cat4_total
                },
                {
                    name: 'Targeted',                    
                    y: cat5_total
                },
                {
                    name: 'VL for Pregnant Woman',                    
                    y: cat6_total
                });
                
                series.push({
                    name: 'Reasons',
                    colorByPoint: true,                    
                    data: slice_data
                });

                BindVLTestReasonByAbbottPieChart(categories, series);
                function BindVLTestReasonByAbbottPieChart(categories, series) {
                    window.chart = new Highcharts.chart('vlTestReasonByBioCentricPieChart', {
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

            $(function GetVLLabByLabInstrumentAbbott() {
                if('<%= JstringVLLabByLabInstrumentAbbott %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLLabByLabInstrumentAbbott %>');                
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
                
                BindVLLabByLabInstrumentAbbott(categories, series);
                function BindVLLabByLabInstrumentAbbott(categories, series) {
                    window.chart = new Highcharts.chart('VLLabByLabInstrumentAbbott', {
                        chart: {
                            type: 'area'
                        },
                        title: {
                            //text: 'HIV Viral Load Testing in ' + <%= txtStartDate.Text %> + '(NAP - Abbott)'
                            //text: 'Abbott (<%= txtStartDate.Text %> - <%= txtEndDate.Text %>)'
                            text: 'Abbott (<%= hdnStartDate.Value %>'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1,
                            tickmarkPlacement: 'on'
                        },
                        yAxis: {
                            title: {
                                text: 'Number of HIV Viral Load Tests'
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

            $(function GetVLLabByLabInstrumentBioCentric() {
                if('<%= JstringVLLabByLabInstrumentBioCentric %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLLabByLabInstrumentBioCentric %>');                
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
                
                BindVLLabByLabInstrumentBioCentric(categories, series);
                function BindVLLabByLabInstrumentBioCentric(categories, series) {
                    window.chart = new Highcharts.chart('VLLabByLabInstrumentBioCentric', {
                        chart: {
                            type: 'area'
                        },
                        title: {
                            //text: 'HIV Viral Load Testing in ' + <%= txtStartDate.Text %> + '(NAP - Abbott)'
                            //text: 'BioCentric (<%= txtStartDate.Text %> - <%= txtEndDate.Text %>)'
                            text: 'BioCentric (<%= hdnStartDate.Value %>)'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1,
                            tickmarkPlacement: 'on'
                        },
                        yAxis: {
                            title: {
                                text: 'Number of HIV Viral Load Tests'
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

            $(function GetVLLabByLabInstrumentGeneXpert() {
                if('<%= JstringVLLabByLabInstrumentGeneXpert %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLLabByLabInstrumentGeneXpert %>');                
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
                
                BindVLLabByLabInstrumentGeneXpert(categories, series);
                function BindVLLabByLabInstrumentGeneXpert(categories, series) {
                    window.chart = new Highcharts.chart('VLLabByLabInstrumentGeneXpert', {
                        chart: {
                            type: 'area'
                        },
                        title: {
                            //text: 'HIV Viral Load Testing in ' + <%= txtStartDate.Text %> + '(NAP - Abbott)'
                            //text: 'GeneXpert (<%= txtStartDate.Text %> - <%= txtEndDate.Text %>)'
                            text: 'GeneXpert (<%= hdnStartDate.Value %>)'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1,
                            tickmarkPlacement: 'on'
                        },
                        yAxis: {
                            title: {
                                text: 'Number of HIV Viral Load Tests'
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

            $(function GetVLLabByLabInstrumentComparison() {
                if('<%= JstringVLLabByLabInstrumentComparison %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLLabByLabInstrumentComparison %>');                
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
                
                BindVLLabByLabInstrumentComparison(categories, series);
                function BindVLLabByLabInstrumentComparison(categories, series) {
                    window.chart = new Highcharts.chart('VLLabByLabInstrumentComparison', {
                        chart: {
                            type: 'area'
                        },
                        title: {
                            //text: 'HIV Viral Load Testing in ' + <%= txtStartDate.Text %> + '(NAP - Abbott)'
                            //text: 'All Instruments (<%= txtStartDate.Text %> - <%= txtEndDate.Text %>)'
                            text: 'All Instruments (<%= hdnStartDate.Value %>)'
                        },
                        xAxis: {
                            categories: categories,
                            gridLineWidth: 1,
                            tickmarkPlacement: 'on'
                        },
                        yAxis: {
                            title: {
                                text: 'Number of HIV Viral Load Tests'
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

 <%--           $(function GetVLTATTrends() {
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

            // VL Test By State and Region & Facilities
            $(function GetVLTestByStateRegionFacility() {
                if('<%= JstringVLTestByLabFaclility %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestByLabFaclility %>');
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

                BindVLTestByStateRegionFacility(categories, series);
                function BindVLTestByStateRegionFacility(categories, series) {
                    window.chart = new Highcharts.chart('vlTestByStateRegionFacility', {
                        chart: {
                            type: 'column',                           
                        },
                        title: {
                            text: 'VL Test Facilities by State & Region'
                        },
                        subtitle: {
                            text: '<%= ddlLab.SelectedItem.Text %> (<%= txtStartDate.Text %> - <%= txtEndDate.Text %>)'
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
            $(function GetVLTestByStateRegionFacilityPieChart() {
                if('<%= JstringVLTestByLabFaclility %>' == '')
                    return;
                var subject = JSON.parse('<%= JstringVLTestByLabFaclility %>');
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

                BindVLTestReasonByGeneXpertPieChart(categories, series);
                function BindVLTestReasonByGeneXpertPieChart(categories, series) {
                    window.chart = new Highcharts.chart('vlTestByStateRegionFacilityPieChart', {
                        chart: {
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie'
                        },
                        title: {
                            text: '(<%= txtStartDate.Text %>  - <%= txtEndDate.Text %>)'
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
            $(function GetVLTuraroundByYear() {
                if('<%= JstringVLTurnaroundbyYear %>' == '')
                    return;
                var subject = JSON.parse('<%=JstringVLTurnaroundbyYear%>');
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
                           
                BindVLTurnaroundByYear(categories, series);
                function BindVLTurnaroundByYear(categories, series) {                    
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
            $(function GetVLTuraroundByQuarter() {
                if('<%= JstringVLTurnaroundbyQuarter %>' == '')
                    return;
                var subject = JSON.parse('<%=JstringVLTurnaroundbyQuarter%>');
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
                           
                BindVLTurnaroundByQuarter(categories, series);
                function BindVLTurnaroundByQuarter(categories, series) {                    
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
                            text: 'VL Test Rejection by State & Region / Facility ( <%= txtStartDate.Text %> - <%= txtEndDate.Text %> )'
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

            // VL Positive Negative Summary
            $(function GetVLSummary() {
                if('<%= JstringVLSummary %>' == '')
                    return;
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
                detail += '<tr><td>Total VL Received:</td><td style="text-align: right">' + total_received + '</td>' +
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
            
        });

        function getValue(val){
            if(isNaN(val))
                return 0;
            else
                return val;            
        }
    </script>
  
    <%--<link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />--%>
    <style>
        .highcharts-container {
            background-color: #000;
            overflow: visible;
            z-index: 1;
        }

        #container, #container > .highcharts-container {
          overflow: visible !important;
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

    <%--<label for="startDate">Date :</label>
    <asp:TextBox ID="txtstartDate" runat="server" CssClass="date-picker" ReadOnly="true"></asp:TextBox>--%>
    <%--<input name="startDate" id="startDate" class="date-picker" />--%>
    <%--<div class="control-group">
                <label class="control-label">Date Picking</label>
                <div class="controls input-append date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                    <input size="16" type="text" value="" readonly>
                    <span class="add-on"><i class="icon-remove"></i></span>
					<span class="add-on"><i class="icon-th"></i></span>
                </div>
				<input type="hidden" id="dtp_input2" value="" /><br/>
            </div>--%>

    <div id="content">
        <div class="row">
			<div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">                
				<h1 class="page-title txt-color-blueDark"><i class="fa fa-lg fa-fw fa-bar-chart-o"></i> HIV Viral Load <span>&gt; Lab Dashboard</span></h1>
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
            <div class="row">
                <%--<div id="divNational" runat="server">--%>
			    <div class="col-sm-4 pull-left">                      
                    <asp:DropDownList ID="ddlLab" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataTextField="ProvinceName" DataValueField="Id">
                        <asp:ListItem Value="0">All</asp:ListItem>
                    </asp:DropDownList><i></i>
                    <%--<asp:Label ID="lbllocation" runat="server" Text="National" CssClass="label-primary"></asp:Label>--%>
			    </div>
                <%--</div>--%>
                <%--<div class="col-sm-3 pull-left">                    
                </div>--%>
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
                    <%--<asp:DropDownList ID="ddlYearFrom" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>--%>
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control date-picker" ReadOnly="false"></asp:TextBox>
                    <asp:RegularExpressionValidator
                        id="validatorStartDate" runat="server" 
                        Type="Date"
                        Operator="DataTypeCheck"
                        ControlToValidate="txtStartDate" 
                        ValidationExpression="((0|1)\d{1})/((19|20)\d{2})"
                        ErrorMessage="mm/yyyy"
                        ValidationGroup="grpDate">
                    </asp:RegularExpressionValidator>
                    <asp:HiddenField ID="hdnStartDate" runat="server" />                    
			    </div>
                <div class="col-sm-1 pull-left text-align-right">
                    <asp:Label ID="lblTo" runat="server" Text="To:"></asp:Label>
                </div>
                <div class="col-sm-2 pull-left">
                    <%--<asp:DropDownList ID="ddlYearTo" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>--%>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control date-picker" ReadOnly="false"></asp:TextBox>                    
                    <asp:RegularExpressionValidator
                        id="RegularExpressionValidator1" runat="server" 
                        Type="Date"
                        Operator="DataTypeCheck"
                        ControlToValidate="txtEndDate" 
                        ValidationExpression="((0|1)\d{1})/((19|20)\d{2})"
                        ErrorMessage="mm/yyyy"
                        ValidationGroup="grpDate">
                    </asp:RegularExpressionValidator>
			    </div>
                <div class="col-sm-1 pull-right">
                    <asp:Button ID="btnFilter" class="btn btn-default btn-primary" runat="server" ValidationGroup="grpDate" Text="Filter" OnClick="btnFilter_Click"  />
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
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-8" data-widget-editbutton="false" role="widget" style="">
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
                                            <div id="vlTestYearly" style="min-width: 1024px; height: 250px; margin: 0 auto"></div>
                                            <button id="vlTestYearlyExportCsv">Export to CSV</button>
                                            <button id="vlTestYearlyExportPng">Export to PNG</button>                                            
                                        </div>
                                    </div>
				                </div>
				                <div class="tab-pane" id="1">                                    
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="vlTestQuarterly" style="min-width: 1024px; height: 250px; margin: 0 auto"></div>
                                        </div>
					                </div>
				                </div>
                                <div class="tab-pane" id="2">                                    
                 	                <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="vlTestMonthly" style="min-width: 1024px; height: 250px; margin: 0 auto"></div>
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
                        <h2>VL Test Outcome by State & Region / Facility</h2>
                    </header>                  
					<!-- add: non-hidden - to disable auto hide -->                            
                    <div role="content">
						<div class="widget-body no-padding">                                     									
                            <div id="vlTestByProvince" style="min-width: 1024px; height: 400px; margin: 0 auto"></div>
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
						<h2>HIV Viral Load Test by Instruments</h2>                        
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
                        <h2>HIV Viral Load Test by Instruments</h2>
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
                        <h2>Reasons for HIV Viral Load Test by Lab</h2>                        

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
                                        <div id="vlTestReasonAllInstruments" style="min-width: 310px; height: 500px; width: 500px; margin: 0 auto; float: left"></div>
                                        <div id="vlTestReasonAllInstrumentsPieChart" style="min-width: 500px; height: 500px; margin: 0 auto; float: left"></div>
                                    </div>
                                </div>
				            </div>
                                <div class="tab-pane" id="21">                                    
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="vlTestReasonByAbbott" style="min-width: 310px; height: 500px; width: 600px; margin: 0 auto; float: left"></div>
                                            <div id="vlTestReasonByAbbottPieChart" style="min-width: 400px; height: 500px; margin: 0 auto; float: left"></div>
                                        </div>
                                    </div>
				                </div>
                                <div class="tab-pane" id="22">
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="vlTestReasonByGeneXpert" style="min-width: 310px; height: 600px; width: 600px; margin: 0 auto; float: left"></div>
                                            <div id="vlTestReasonByGeneXpertPieChart" style="min-width: 400px; height: 400px; margin: 0 auto; float: left"></div>
                                        </div>
                                    </div>
				                </div>
                                <div class="tab-pane" id="23">                                    
                                    <div role="content">
                                        <div class="widget-body no-padding">
                                            <div id="vlTestReasonByBioCentric"  style="min-width: 310px; height: 500px; width: 600px; margin: 0 auto; float: left"></div>
                                            <div id="vlTestReasonByBioCentricPieChart" style="min-width: 400px; height: 500px; margin: 0 auto; float: left"></div>
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
						<h2>VL Test Facilities by State & Region</h2>
                    </header>
                 	<div>
                        <div class="widget-body no-padding">
                            <div id="vlTestByStateRegionFacility" style="min-width: 700px; height: 400px; margin: 0 auto; float: left"></div>                            
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
        
        <%--<div class="row">
		 <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12 sortable-grid ui-sortable">
              <div class="jarviswidget jarviswidget-sortable jarviswidget-color-blue" id="wid-id-agegroup-facility" data-widget-editbutton="false" role="widget" style="" data-widget-attstyle="jarviswidget-color-darken">
					<header role="heading">
                        <span class="widget-icon"><i class="glyphicon glyphicon-stats txt-color-white"></i></span>
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>						
                        <h2>VL Test Age Group Outcome by State & Region / Facility</h2>
                    </header>
                    <div role="content">
						<div class="widget-body no-padding">                                     									
                            <div id="vlTestAgeGroupByProvince" style="min-width: 1024px; height: 300px; margin: 0 auto;"></div>
						</div>
					</div>
			 </div>
		 </article>
		</div>--%>        

        <div class="row">
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-by-state-region-facilities-piechart" data-widget-editbutton="false" role="widget" style="">								
					<header role="heading"><div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
						<h2>
                            <asp:Label ID="Label1" runat="server" Text="HIV Viral Load Test by State & Region"></asp:Label></h2>
                    </header>
                 	<div role="content">
                        <div class="widget-body no-padding">                                        
                            <div id="vlTestByStateRegionFacilityPieChart" style="min-width: 450px; height: 420px; margin: 0 auto; float: left"></div>
                        </div>
					</div>
				</div>
			</article>
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="wid-id-vl-turnaround-yearly" data-widget-editbutton="false" role="widget" style="">								
					<header role="heading">
                        <div class="jarviswidget-ctrls" role="menu"><a href="javascript:void(0);" class="button-icon jarviswidget-fullscreen-btn" rel="tooltip" title="" data-placement="bottom" data-original-title="Fullscreen"><i class="fa fa-expand "></i></a></div>
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
                        <h2>VL Test Rejection by State & Region / Facility</h2>
                    </header>                  
					<!-- add: non-hidden - to disable auto hide -->                            
                    <div role="content">
						<div class="widget-body no-padding">                                     									
                            <div id="vlTestRejectByProvince" style="min-width: 1024px; height: 520px; margin: 0 auto;"></div>
						</div>
					</div>
			 </div>
		 </article>
		</div>

        <%--<div class="row">
            <article class="col-xs-12 col-sm-6 col-md-6 col-lg-6 sortable-grid ui-sortable">
                <div class="jarviswidget jarviswidget-sortable jarviswidget-color-darken" id="widVLSummary" data-widget-editbutton="false" role="widget" style="">
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
              
     </section>                
       
   </asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="menuContent" Runat="Server">
</asp:Content>

