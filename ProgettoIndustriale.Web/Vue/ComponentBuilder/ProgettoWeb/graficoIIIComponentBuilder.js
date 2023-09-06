
import navbarprova from "../../navbar-prova.vue";

import { DropdownPlugin, TablePlugin } from 'bootstrap-vue'
import graficoiii from "../../graficoiii.vue";

Vue.use(DropdownPlugin);
Vue.component("graficoiii", graficoiii);
Vue.component("navbar-prova", navbarprova);


Vue.config.devtools = true;