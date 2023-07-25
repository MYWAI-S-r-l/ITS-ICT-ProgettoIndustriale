
import notifier from "../../notifier.vue";
import mainPage from "../../main-page.vue";
import nextPage from "../../next-page.vue";
import App from "../../App.vue";


Vue.component("main-page", mainPage);
Vue.component("next-page", nextPage);
Vue.component("notifier", notifier);
Vue.component("App", App)



Vue.config.devtools = true;


