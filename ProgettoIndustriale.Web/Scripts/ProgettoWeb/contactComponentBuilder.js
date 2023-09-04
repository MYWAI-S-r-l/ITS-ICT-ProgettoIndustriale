
import navbarprova from "../../navbar-prova.vue";

import { createPopper } from '@popperjs/core';
import { DropdownPlugin, TablePlugin } from 'bootstrap-vue'
import contact from "../../contact.vue";
Vue.use(createPopper);
Vue.use(DropdownPlugin);
Vue.component("contact", contact);
Vue.component("navbar-prova", navbarprova);



Vue.config.devtools = true;