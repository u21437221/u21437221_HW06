const chart = require("./chart");
const { Chart } = require("./chart");

const Reports = document.getElementById("Reports");

chart.defaults.font.family = "Teko";
chart.defaults.font.size = 22;
chart.defaults.font.color = "red";

let ReportsData = {
    labels: 'Number of Mountain Bikes sold',
    data: [163, 152, 200, 211, 139, 127, 122, 148, 160, 125, 118, 90]
};

let barChart = new Chart(Reports, {
    type: 'bar',
    data: {
        labels: ["January","February","March","April","May","June","July","August","September","October","November","December"],
        datasets: [ReportsData]
    }
    
});