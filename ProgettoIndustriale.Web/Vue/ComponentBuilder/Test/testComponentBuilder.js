import leftMenu from "../../left-menu.vue";
import notifier from "../../notifier.vue";
import test from "../../test.vue";

Vue.component("left-menu", leftMenu);
Vue.component("notifier", notifier);
Vue.component("test", test);

Vue.config.devtools = true;