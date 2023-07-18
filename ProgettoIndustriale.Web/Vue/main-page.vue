<template>
    <div class="page-container">
        <main class="main-container">
            <div class="button-group">
                <button class="button" @click="goToNextPage">
                    <div class="button-wrapper">
                        <img src="../wwwroot/assets/images/button.png" alt="Button 1" class="button-image">
                        <span class="button-text">Button 1</span>
                    </div>
                </button>
                <button class="button" @click="goToNextPage">
                    <div class="button-wrapper">
                        <img src="../wwwroot/assets/images/button.png" alt="Button 2" class="button-image">
                        <span class="button-text">Button 2</span>
                    </div>
                </button>
                <button class="button" @click="goToNextPage">
                    <div class="button-wrapper">
                        <img src="../wwwroot/assets/images/button.png" alt="Button 3" class="button-image">
                        <span class="button-text">Button 3</span>
                    </div>
                </button>
            </div>
        </main>
        <router-view :key="$route.fullPath" v-if="showNextPage" />
    </div>
</template>

<script>
    /* eslint-disable */

    import { useRouter } from 'vue-router';

    export default {
        name: 'main-page',
        data() {
            return {
                showNextPage: false,
                buttonText: 'Button 1'
            };
        },
        methods: {
            goToNextPage() {
                this.showNextPage = true;
                this.$router.push('/next-page');
            },
            goToHomePage() {
                this.showNextPage = false;
                this.$router.replace('/');
                window.scrollTo(0, 0);
            },
            hoverButton() {
                this.buttonText = 'Button 1'; // Aggiungi il testo desiderato
            },
            resetButton() {
                this.buttonText = 'Button 1'; // Ripristina il testo originale
            }
        },
        beforeRouteLeave(to, from, next) {
            this.showNextPage = false;
            next();
        }
    };
</script>

<style scoped>
    /* Stili CSS */
    .page-container {
        background-image: url('../wwwroot/assets/images/background.png');
        background-repeat: no-repeat;
        background-size: cover;
        background-position: center;
        min-height: 100vh;
        margin: 0;
        padding: 0;
        align-items: center; /* Centra verticalmente il contenuto */
        justify-content: center; /* Centra orizzontalmente il contenuto */
    }

    .main-container {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        min-height: calc(100vh - 100px);
    }

    .button-group {
        display: flex;
        margin-top: 1.5rem;
    }

    .button {
        background-color: transparent;
        border: none;
        cursor: pointer;
        text-align: center;
        text-decoration: none;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        margin: 0.5rem 2rem;
        padding: 0;
        transition: transform 0.2s ease-in-out;
        position: relative;
    }

    .button-wrapper {
        position: relative;
    }

    .button-image {
        width: 250px;
        height: 250px;
    }

    .button-text {
        position: absolute;
        bottom: 0;
        left: 0;
        right: 0;
        padding: 0.5rem;
        background-color: transparent;
        color: #000000;
        text-align: center;
        font-size: 1.2rem;
        text-decoration: none;
        transition: text-decoration 0.2s ease-in-out;
    }

    .button::before {
        content: '';
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background-color: rgba(255, 255, 255, 0.5); /* Sovrapposizione bianca trasparente */
        opacity: 0;
        transition: opacity 0.2s ease-in-out;
    }

    .button:hover .button-text {
        text-decoration: underline;
    }

    .button:hover::before {
        opacity: 1; /* Mostra la sovrapposizione bianca quando il cursore è sopra il pulsante */
    }

    .button:hover {
        transform: scale(1.2);
    }
</style>
