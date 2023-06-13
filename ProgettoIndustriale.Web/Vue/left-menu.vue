<template>
    <div>
        <notifier v-model="notifier.show" :timeout="5000" :messageInfo="notifier.message" />
        <v-app-bar flat short>
            <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
            <v-toolbar-title @click="changePage('')" v-if="!drawer">
                <v-list-item-avatar rounded>
                    <v-img :src="getImageSource" :contain="true"></v-img>
                </v-list-item-avatar>
                Progetto Industriale 
            </v-toolbar-title>
            <v-spacer></v-spacer>
            Welcome, User
        </v-app-bar>

        <!--drawer-->
        <v-navigation-drawer app v-model="drawer" class="mywaiTheme">
            <div style="text-align:center; margin-top:5px;" @click="changePage('')">
                <img :src="getImageSource" style="height:60px"  alt="companyLogo"/>
                <p>
                    ITS - ICT <span style="font-size:smaller">Version {{ appVersion }}</span>
                </p>
            </div>

            <v-expansion-panels v-for="(voice, index) in menuModel" :key="'menu' + voice.title"
                                flat v-model="voice.panelOpen" class="condensed mb-5" style="padding-right: 10px">
                <v-expansion-panel>
                    <v-expansion-panel-header :class="getElementStyle($vuetify.theme.dark, 'menuColor')">
                        {{voice.title}}
                        <template v-slot:actions>
                            <v-icon color="mywaiOverTextColor">
                                $expand
                            </v-icon>
                        </template>
                    </v-expansion-panel-header>
                    <v-expansion-panel-content id="paddingMenuBottom" class="mywaiTheme">
                        <v-treeview hoverable activatable item-key="name"
                                    :open="initiallyOpen" :items="voice.items" :class="getElementStyle($vuetify.theme.dark, 'leftbar')">
                            <template v-slot:prepend="{ item, hover }">
                                <v-icon>{{ item.icon }}</v-icon>
                            </template>
                            <template v-slot:label="{ item, open }">
                                <div @click="changePage(item.link)">
                                    {{ item.name }}
                                </div>
                            </template>
                            <v-divider></v-divider>
                        </v-treeview>
                    </v-expansion-panel-content>
                </v-expansion-panel>
            </v-expansion-panels>
        </v-navigation-drawer>
    </div>
</template>

<script>
    import Services from '../Scripts/Services/serviceBuilder';
    
    export default {
        name: 'left-menu',
        props: {
            userobject: null,
            currentpage: null
        },
        data: function () {
            return {
                placeholderImgPath: "./assets/images/placeholder-image-user.png",
                userControl: false,
                menuModel: [
                    {
                        title: "Anagrafica",
                        panelOpen: 0,
                        items:
                        [
                            {
                                name: "Meteo Province",
                                icon: "mdi-tape-measure",
                                link: "/test/"
                            },
                        ]
                    },
                    {
                        title: "Placeholder",
                        panelOpen: 0,
                        items: [
                            {
                                name: "SubPlaceholder1",
                                icon: "mdi-tape-measure",
                                link: "/SubPlaceholder1/"
                            },
                            {
                                name: "SubPlaceholder2",
                                icon: "mdi-tape-measure",
                                link: "/SubPlaceholder2/SubPlaceholder2"
                            },
                        ]
                    },
                ],
                initiallyOpen: [],
                menuOpen: [
                    
                ],
                drawer: true,
                appConfig: null,
                companyInfo: null,
                user: null,
                notifier: {
                    show: false,
                    message: ""
                }
            };
        },
        computed: {
            appVersion: function () {
                if(!this.appConfig)
                    return "";

                return this.appConfig.major + '.'
                    + this.appConfig.minor + '.'
                    + this.appConfig.build;
            },
            getImageSource: function () {
                    return "./assets/images/aen-logo.svg";
            }
        },
        created: function () {
            console.log("called left menu created");
            this.loadAppVersion();
        
            this.$vuetify.theme.dark = Vue.prototype.darkMode ?? false;
        },
        mounted: function () {
            this.openMenuItems();            
        },
        methods: {
            getAvatarSource: function () {
                return this.getImageUser(null);
            },
            getImageUser: function (image) {
                if (!image)
                    return "./assets/images/placeholder-image-user.png";
                return "data:image/*;base64," + image;
            },
            loadAppVersion: function () {
                var that = this;
                // Services.getApiCaller()
                //     .then(apiCaller => {
                //         apiCaller.getAppVersion()
                //             .then(res => {
                //                 that.appConfig = res.data;
                //             })
                //             .catch(res => {
                //                 console.log(">>>> Error: " + res);
                //             });
                //     });
                that.appConfig = {
                    major: 0,
                    minor: 0,
                    build: 1
                }
            },
            openMenuItems: function () {
                if (!this.currentpage)
                    return;

                var obj = this.menuOpen.find(x => x.page.includes(this.currentpage));
                if(obj)
                    this.initiallyOpen.push(...obj.items);
            },
            changePage: function (page) {
                if(!page)
                    return;

                window.location.href = page;
            }
        }        
    }
</script>

<style scoped>
    .condensed {
        font-size: small;
    }

    .v-expansion-panels.condensed .v-expansion-panel-header {
        min-height: auto !important;
        padding: 10px;
    }

    .titleBackground {
        background: #e9f3f2 !important;
    }
    .v-expansion-panel-content__wrap {
        padding: 0px !important;
    }
    .imageInput {
        width: 60px;
        height: 60px;
        top: 0px;
        left: 0;
    }
    .avatarImage {
        border: 1px solid #ccc;
        margin-bottom: 6px;
        margin-top: 6px;
    }
    .avatarImage:hover {
        cursor: pointer;
    }
</style>

<style>
    .condensed .v-treeview-node__root {
        min-height: 34px !important;
    }
     .myHeader {
         position: fixed;
     }

    .myList {
        min-height: 58px !important;
    }

    .no-uppercase {
        text-transform: none;
        font-size: small;
    }

    #logoImage {
        position: absolute;
        width: 60px;
        height: 60px;
        top: 19px;
        left: 10px;
        z-index: 999;
    }
    .condensed .theme--light.v-treeview--hoverable .v-treeview-node__root:hover:before {
        opacity: .15 !important;
    }
        .condensed .theme--dark.v-treeview--hoverable .v-treeview-node__root:hover:before {
            opacity: .3 !important;
        }

        .v-treeview-node__label {
            cursor: pointer;
        }

    .condensed .theme--light.v-treeview--hoverable .v-treeview-node__root:hover:before {
        opacity: .15 !important;
    }
        .condensed .theme--dark.v-treeview--hoverable .v-treeview-node__root:hover:before {
            opacity: .3 !important;
        }

        .v-treeview-node__label {
            cursor: pointer;
        }

    .condensed .theme--light.v-treeview--hoverable .v-treeview-node__root:hover:before {
        opacity: .15 !important;
    }
        .condensed .theme--dark.v-treeview--hoverable .v-treeview-node__root:hover:before {
            opacity: .3 !important;
        }

        .v-treeview-node__label {
            cursor: pointer;
        }

    #paddingtMenuTop > *{
        padding:0px !important
    }
    #paddingMenuBottom > * {
        padding: 0px !important
    }
</style>

