<template>
    <div class="app-container">
        <nav class="breadcrumb" v-if="breadcrumbRoutes.length">
            <ul>
                <li>
                    <router-link to="/">Home</router-link>
                </li>
                <li v-for="(route, index) in breadcrumbRoutes" :key="index">
                    <span class="breadcrumb-separator">&gt;</span>
                    <router-link :to="route.path">{{ route.name }}</router-link>
                </li>
            </ul>
        </nav>

        <main class="main-container">
            <div class="chart-container">
                <!-- GRAFICO -->
            </div>
        </main>
    </div>
</template>


<script>
    export default {
        name: 'next-page',
        data() {
            return {
                breadcrumbRoutes: [],
                currentRoute: null,
            };
        },
        mounted() {
            this.breadcrumbRoutes = this.getRoutesForBreadcrumb();
            this.currentRoute = this.$route.name;
        },
        methods: {
            goToHomePage() {
                this.$router.push('/'); // Naviga alla homepage
            },
            getRoutesForBreadcrumb() {
                const routePath = this.$route.path;
                const routeSegments = routePath.split('/').filter(segment => segment !== '');

                return routeSegments.map((segment, index) => {
                    const path = `/${routeSegments.slice(0, index + 1).join('/')}`;
                    return { name: segment, path };
                });
            },
        },
        beforeRouteUpdate(to, from, next) {
            if (to.path !== from.path) {
                // Mantieni la pagina corrente solo a livello visivo
                this.currentRoute = to.name;
                this.breadcrumbRoutes = this.getRoutesForBreadcrumb();
            }

            next();
        },
    };
</script>


<style scoped>
    /* Stili CSS */
    .app-container {
        background-image: url("../assets/background.png");
        background-size: cover;
        background-position: center;
        /* Aggiungi altri stili o modifiche al layout se necessario */
    }

    .main-container {
        display: flex;
        justify-content: center;
        align-items: flex-start;
        height: calc(100vh - 100px);
    }

    .chart-container {
        flex: 1;
        padding: 1rem;
    }

    .description-container {
        flex: 1;
        padding: 1rem;
    }

    .breadcrumb {
        padding: 1rem;
    }

        .breadcrumb ul {
            list-style-type: none;
            display: flex;
        }

        .breadcrumb li {
            margin-right: 5px;
        }

    .breadcrumb-separator {
        margin: 0 5px;
    }

    .breadcrumb a {
        text-decoration: none;
        color: #333;
    }

        .breadcrumb a:hover {
            text-decoration: underline;
        }
</style>

