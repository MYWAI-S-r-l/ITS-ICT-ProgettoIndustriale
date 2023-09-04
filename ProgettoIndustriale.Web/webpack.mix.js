let mix = require('laravel-mix')

/*
 |--------------------------------------------------------------------------
 | Mix Asset Management
 |--------------------------------------------------------------------------
 |
 | Mix provides a clean, fluent API for defining some Webpack build steps
 | for your Laravel application. By default, we are compiling the Sass
 | file for your application, as well as bundling up your JS files.
 |
 | API Documentation: https://laravel-mix.com/docs
 */

if (!mix.inProduction()) {
    mix.webpackConfig({ devtool: 'source-map' });
}

mix.setPublicPath('wwwroot');

mix.sass('./Styles/site.scss', 'css/site.css');


mix.vue()

.js('./Scripts/Services/serviceBuilder.js', 'js/site.js')
    .js(['./Vue/ComponentBuilder/Home/indexComponentBuilder.js', './Scripts/Home/mainPage.js'], 'js/mainPage.js')
    .js(['./Vue/ComponentBuilder/ProgettoWeb/progettoWebComponentBuilder.js', './Scripts/ProgettoWeb/progettoWeb.js'], 'js/progettoWeb.js')
    .js(['./Vue/ComponentBuilder/ProgettoWeb/contactComponentBuilder.js', './Scripts/ProgettoWeb/contact.js'], 'js/contact.js')

mix.copy('./Scripts/commonModule.js', './wwwroot/js/commonModule.js')