
import navbarprova from "../../navbar-prova.vue";

import { DropdownPlugin, TablePlugin } from 'bootstrap-vue'
import graficoii from "../../graficoii.vue";

Vue.use(DropdownPlugin);
Vue.component("graficoii", graficoii);
Vue.component("navbar-prova", navbarprova);


Vue.config.devtools = true;