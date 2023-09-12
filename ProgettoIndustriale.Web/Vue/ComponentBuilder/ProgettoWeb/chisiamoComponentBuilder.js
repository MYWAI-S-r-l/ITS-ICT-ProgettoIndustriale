
import navbarprova from "../../navbar-prova.vue";

import { DropdownPlugin, TablePlugin } from 'bootstrap-vue'
import chisiamo from "../../chisiamo.vue";

Vue.use(DropdownPlugin);
Vue.component("chisiamo", chisiamo);
Vue.component("navbar-prova", navbarprova);


Vue.config.devtools = true;