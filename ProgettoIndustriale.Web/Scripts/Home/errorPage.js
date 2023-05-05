
var vue = new Vue({
    el: "#myApp",
    vuetify: new Vuetify(),
    data: {},
    methods: {
        goHome: function () {
            window.location.href = "./";
        },
        goLogout: function () {
            window.location.href = "./Home/Logout";
        },
    },
});