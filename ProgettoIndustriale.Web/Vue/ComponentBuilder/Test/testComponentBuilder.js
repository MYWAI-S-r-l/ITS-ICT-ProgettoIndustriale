import leftMenu from "../../left-menu.vue";
import notifier from "../../notifier.vue";
import test from "../../test.vue";
import listVisualizer from "../../list-visualizer.vue";
import simpleMeteoPlot from "../../simple-meteo-plot.vue";
import Chart from "chart.js";

Vue.component("left-menu", leftMenu);
Vue.component("notifier", notifier);
Vue.component("test", test);
Vue.component("list-visualizer", listVisualizer);
Vue.component("simple-meteo-plot", simpleMeteoPlot);
Vue.component("Chart", Chart);

Vue.config.devtools = true;