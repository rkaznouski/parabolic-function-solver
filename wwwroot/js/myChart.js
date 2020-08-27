var ctx = document.getElementById('myChart');
var data = {
    labels: [-10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
    datasets: [{
        label: 'f(x) = a(x*x) + b*x + c',
        function: function (x) {
            return x*x + +x;
        },
        borderColor: 'rgba(153, 102, 255, 1)',
        data: [],
        fill: false
    }]
};

Chart.pluginService.register({
    beforeInit: function (chart) {
        var data = chart.config.data;
        for (var i = 0; i < data.datasets.length; i++) {
            for (var j = 0; j < data.labels.length; j++) {
                var fct = data.datasets[i].function,
                    x = data.labels[j],
                    y = fct(x);
                data.datasets[i].data.push(y);
            }
        }
    }
});

var myBarChart = new Chart(ctx, {
    type: 'line',
    data: data,
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginArZero: true,
                    stepSize: 5
                }
            }]
        }
    }
});


