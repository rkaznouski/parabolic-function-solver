var ctx = document.getElementById('canvas');

var MONTHS = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

//var randomScalingFactor = function () {
//    return Math.round(Math.random() * 100);
//};

var config = {
    type: 'line',
    data: {
        labels: ['-15', '-14', '-13', '-12', '-11', '-10', '-9', '-8', '-7', '-6', '-5', '-4', '-3', '-2', '-1', '0',
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15'],
        datasets: [{
            label: 'Parabolic function',
            borderColor: 'rgba(153, 102, 255, 1)',
            
            data: [1,2,3,4,5
                //randomScalingFactor(),
                //randomScalingFactor(),
                //randomScalingFactor(),
                //randomScalingFactor(),
                //randomScalingFactor(),
                //randomScalingFactor(),
                //randomScalingFactor()
            ],
            fill: false,
        }, ]
    },
    options: {
        responsive: true,
        title: {
            display: true,
            text: 'Chart.js Line Chart'
        },
        tooltips: {
            mode: 'index',
            intersect: false,
        },
        hover: {
            mode: 'nearest',
            intersect: true
        },
        scales: {
            x: {
                display: true,
                scaleLabel: {
                    display: true,
                    labelString: 'Month'
                }
            },
            y: {
                display: true,
                scaleLabel: {
                    display: true,
                    labelString: 'Value'
                },
                min: 0,
                max: 100,
                ticks: {
                    // forces step size to be 5 units
                    stepSize: 5
                }
            }
        }
    }
};

window.onload = function () {
    var ctx = document.getElementById('canvas').getContext('2d');
    window.myLine = new Chart(ctx, config);
};

document.getElementById('randomizeData').addEventListener('click', function () {
    config.data.datasets.forEach(function (dataset) {
        dataset.data = dataset.data.map(function () {
            return randomScalingFactor();
        });
    });

    window.myLine.update();
});

var colorNames = Object.keys(window.chartColors);
document.getElementById('addDataset').addEventListener('click', function () {
    var colorName = colorNames[config.data.datasets.length % colorNames.length];
    var newColor = window.chartColors[colorName];
    var newDataset = {
        label: 'Dataset ' + config.data.datasets.length,
        backgroundColor: newColor,
        borderColor: newColor,
        data: [],
        fill: false
    };

    for (var index = 0; index < config.data.labels.length; ++index) {
        newDataset.data.push(randomScalingFactor());
    }

    config.data.datasets.push(newDataset);
    window.myLine.update();
});

document.getElementById('addData').addEventListener('click', function () {
    if (config.data.datasets.length > 0) {
        var month = MONTHS[config.data.labels.length % MONTHS.length];
        config.data.labels.push(month);

        config.data.datasets.forEach(function (dataset) {
            dataset.data.push(randomScalingFactor());
        });

        window.myLine.update();
    }
});

document.getElementById('removeDataset').addEventListener('click', function () {
    config.data.datasets.splice(0, 1);
    window.myLine.update();
});

document.getElementById('removeData').addEventListener('click', function () {
    config.data.labels.splice(-1, 1); // remove the label first

    config.data.datasets.forEach(function (dataset) {
        dataset.data.pop();
    });

    window.myLine.update();
});
