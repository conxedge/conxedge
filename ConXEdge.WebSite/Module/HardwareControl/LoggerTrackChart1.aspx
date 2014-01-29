<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggerTrackChart1.aspx.cs" 
Inherits="ConXEdge.WebSite.Module.HardwareControl.LoggerTrackChart1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
    <head>
        <title>Logger Track Chart</title>
        <script src="../../JavaScript/jquery-1.8.2.min.js" type="text/javascript"></script>
        <script src="../../JavaScript/Highstock-1.3.7/highstock.js" type="text/javascript"></script>
    </head>
    <script type="text/javascript">
        var strNames = eval("<%=strNames %>");
        var strTooltips = eval("<%=strTooltips %>");

        $(function () {
            var seriesOptions = [],
		        yAxisOptions = [],
		        seriesCounter = 0,
		        names = strNames,
		        colors = Highcharts.getOptions().colors;

            $.each(names, function (i, name) {
                //alert(strTooltips[i]);
                $.getJSON('OperationHandler.aspx?sType=GetChart1Data&pid=' + name.toLowerCase() + '&rand=' + new Date().toString()
                , function (data) {
                    seriesOptions[i] = {
                        name: strTooltips[i],
                        data: data,
                        type: 'spline'
                    };

                    // As we're loading the data asynchronously, we don't know what order it will arrive. So
                    // we keep a counter and create the chart when all the data is loaded.
                    seriesCounter++;

                    if (seriesCounter == names.length) {
                        createChart();
                    }
                });
            });

            // create the chart when all data is loaded
            function createChart() {
                $('#container').highcharts('StockChart', {
                    chart: {
                },

                legend: {
                    enabled: true
                },

                title: {
                    text: 'Temp ver Elapsed Time'
                },

                rangeSelector: {
                    selected: 4
                },

                xAxis: {
                    tickPixelInterval: 150, //x轴上的间隔  
                    // 如果X轴刻度是日期或时间，该配置是格式化日期及时间显示格式
                    dateTimeLabelFormats: {
                        second: '%Y-%m-%d %H:%M:%S',
                        minute: '%Y-%m-%d %H:%M',
                        hour: '%Y-%m-%d %H:%M',
                        day: '%Y-%m-%d',
                        week: '%Y-%m-%d',
                        month: '%Y-%m',
                        year: '%Y'
                    }
                },

                yAxis: {
                    title: {
                        text: 'Temp'  //y轴上的标题  
                    },
                    labels: {
                        formatter: function () {
                            return (this.value > 0 ? '+' : '') + this.value + '℃';
                        }
                    },
                    plotLines: [{
                        value: 0,
                        width: 2,
                        color: 'silver'
                    }]
                },

                plotOptions: {
                    series: {
                    //compare: 'percent'
                }
            },

            tooltip: {
                pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}℃</b><br/>',
                valueDecimals: 1
            },

            rangeSelector: {
                buttons: [{//定义一组buttons,下标从0开始  
                    type: 'hour',
                    count: 1,
                    text: '1h'
                }, {
                    type: 'hour',
                    count: 2,
                    text: '2h'
                }, {
                    type: 'hour',
                    count: 3,
                    text: '3h'
                }, {
                    type: 'hour',
                    count: 6,
                    text: '6h'
                }, {
                    type: 'ytd',
                    text: 'YTD'
                }, {
                    type: 'day',
                    count: 1,
                    text: '1d'
                }, {
                    type: 'all',
                    text: 'All'
                }],
                selected: 1//表示以上定义button的index,从0开始  
            },

            series: seriesOptions
        });
    }

});
    </script>
    <body>
        <div id="container" style="text-align:center;">
        </div>
    </body>
</html>
