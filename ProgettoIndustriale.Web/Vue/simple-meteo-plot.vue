<template>
    <div>
        <canvas ref="chartCanvas"></canvas>
    </div>
</template>

<script>
import { Chart } from 'chart.js/auto';

export default {
    name: 'meteo-plot',
    props: {
        meteoResponse: null,
    },
    data() {
        return {
            chartInstance: null,  // Store the chart instance here
        };
    },
    methods: {
        plotTemperature() {
            console.log("called plotTemperature, meteoResponse: ", this.meteoResponse);
            const ctx = this.$refs.chartCanvas.getContext('2d');
            const hourlyData = this.meteoResponse.hourly;

            const labels = hourlyData.time;
            const temperatureData = hourlyData.temperature_2m;

            // If a previous chart instance exists, destroy it
            if (this.chartInstance) {
                this.chartInstance.destroy();
            }

            this.chartInstance = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: labels,
                    datasets: [
                        {
                            label: 'Temperature',
                            data: temperatureData,
                            borderColor: 'rgba(75, 192, 192, 1)',
                            backgroundColor: 'rgba(75, 192, 192, 0.2)',
                            borderWidth: 1,
                        },
                    ],
                },
                options: {
                    responsive: true,
                    scales: {
                        x: {
                            type: 'category',
                            display: true,
                            title: {
                                display: true,
                                text: 'Time',
                            },
                        },
                        y: {
                            type: 'linear',  // linear scale for numerical y-values
                            display: true,
                            title: {
                                display: true,
                                text: 'Temperature',
                            },
                        },
                    },
                },
            });
        },
    },
    watch: {
        meteoResponse() {
            this.plotTemperature();
        },
    },
    mounted() {
        this.plotTemperature();
    },
};
</script>

<style scoped>
canvas {
    width: 100%;
    height: 400px;
}
</style>
