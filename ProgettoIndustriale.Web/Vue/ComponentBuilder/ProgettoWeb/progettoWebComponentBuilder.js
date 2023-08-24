
import navbarprova from "../../navbar-prova.vue";
import progettoweb from "../../progettoWeb.vue";

import { DropdownPlugin, TablePlugin } from 'bootstrap-vue'


Vue.use(DropdownPlugin);
Vue.component("progettoweb", progettoweb);
Vue.component("navbar-prova", navbarprova);



Vue.config.devtools = true;