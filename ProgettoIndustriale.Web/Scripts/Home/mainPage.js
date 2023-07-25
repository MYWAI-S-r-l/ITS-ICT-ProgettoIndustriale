import { createApp } from 'vue';
import theme from "./../theme.js";
import App from "./App.vue";

var vue = new Vue({
    const app = createApp(App);
    el: "#myApp",
    vuetify: new Vuetify(),
    data: {
        loading: false,
    },
    computed: {},
    mounted: function () {},
    created: function () { },
    app.mount('#app');

});
