<template>
    <div>
        <router-view v-if="currentPage === 'home'" @goToNextPage="setCurrentPage('next')" />
        <router-view v-if="currentPage === 'next'" @goToHomePage="setCurrentPage('home')" />
    </div>
</template>

<script>
    /* eslint-disable */
    import mainPage from './main-page.vue';
    import nextPage from './next-page.vue';

    export default {
        name: 'App',
        components: {
            mainPage,
            nextPage
        },
        data() {
            return {
                currentPage: 'home'
            };
        },
        methods: {
            setCurrentPage(page) {
                this.currentPage = page;
            }
        }
    };
</script>
