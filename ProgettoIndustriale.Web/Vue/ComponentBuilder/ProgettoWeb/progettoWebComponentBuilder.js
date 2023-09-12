
import navbarprova from "../../navbar-prova.vue";
import progettoweb from "../../progettoWeb.vue";
import grafico from "../../grafico.vue";

import { DropdownPlugin, TablePlugin } from 'bootstrap-vue'


Vue.use(DropdownPlugin);
Vue.component("progettoweb", progettoweb);
Vue.component("navbar-prova", navbarprova);
Vue.component("grafico", grafico);



Vue.config.devtools = true;