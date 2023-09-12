
import navbarprova from "../../navbar-prova.vue";

import { DropdownPlugin, TablePlugin } from 'bootstrap-vue'
import graficoi from "../../graficoi.vue";

Vue.use(DropdownPlugin);
Vue.component("graficoi", graficoi);
Vue.component("navbar-prova", navbarprova);


Vue.config.devtools = true;