
import navbarprova from "../../navbar-prova.vue";

import { DropdownPlugin, TablePlugin } from 'bootstrap-vue'
import contact from "../../contact.vue";

Vue.use(DropdownPlugin);
Vue.component("contact", contact);
Vue.component("navbar-prova", navbarprova);


Vue.config.devtools = true;