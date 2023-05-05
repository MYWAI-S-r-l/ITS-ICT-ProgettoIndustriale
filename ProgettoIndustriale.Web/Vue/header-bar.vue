<template>

</template>


<script>
import Services from '../Scripts/Services/serviceBuilder';

export default {
    name: 'header-bar',
    props: {
        pageTitle: null,
        user: null,
        drawer: null
    },
    data: function () {
        return {
            userControl: false,
        };
    },
    computed: {
        compProp: function () {
            return this.drawer;
        }
    },
    created: function () {
        if (this.user == null) {
            this.user = {name: "Enrico"};
        }
    },
    mounted: function () {
    },
    methods: {

    }
}
</script>