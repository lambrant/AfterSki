window.onload = function () {

   
    var chart = new CanvasJS.Chart("chartContainer",{
        title: { text: "Martins Statistik" },
        axisY: { suffix: ""	},
        legend :{
            verticalAlign: 'bottom',
            horizontalAlign: "center"
        },
        data: [
        {
            type: "line",
            bevelEnabled: true,
            indexLabel: "{y}",
            dataPoints: dps
        }
        ]
    });
    var updateInterval = 1000;
    var updateChart = function () {
        chart.render();
    };

    updateChart();


}