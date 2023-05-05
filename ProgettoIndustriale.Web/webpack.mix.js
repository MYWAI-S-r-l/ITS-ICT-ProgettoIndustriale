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

mix
    .vue()

    .js('./Scripts/Services/serviceBuilder.js', 'js/site.js')
    .js(['./Vue/ComponentBuilder/Home/indexComponentBuilder.js', './Scripts/Home/mainPage.js'], 'js/mainPage.js')
    
    .js(['./Vue/ComponentBuilder/AttiGiudiziari/attiGiudiziariComponentBuilder.js', './Scripts/AttiGiudiziari/attiGiudiziari.js'], 'js/attiGiudiziari.js')
    .js(['./Vue/ComponentBuilder/AttiGiudiziari/attiGiudiziariComponentBuilder.js', './Scripts/AttiGiudiziari/attiGiudiziariInsert.js'], 'js/attiGiudiziariInsert.js')
    
    .js(['./Vue/ComponentBuilder/Enti/entiComponentBuilder.js', './Scripts/Enti/enti.js'], 'js/enti.js')
    .js(['./Vue/ComponentBuilder/Enti/entiComponentBuilder.js', './Scripts/Enti/entiInsert.js'], 'js/entiInsert.js')

    .js(['./Vue/ComponentBuilder/Persone/personeComponentBuilder.js', './Scripts/Persone/persone.js'], 'js/persone.js')
    .js(['./Vue/ComponentBuilder/Persone/personeComponentBuilder.js', './Scripts/Persone/personeInsert.js'], 'js/personeInsert.js')

    .js(['./Vue/ComponentBuilder/Posta/postaComponentBuilder.js', './Scripts/Posta/posta.js'], 'js/posta.js')
    .js(['./Vue/ComponentBuilder/Posta/postaComponentBuilder.js', './Scripts/Posta/postaUscita.js'], 'js/postaUscita.js')

    .js(['./Vue/ComponentBuilder/Posta/postaComponentBuilder.js', './Scripts/Posta/postaInsert.js'], 'js/postaInsert.js')
    .js(['./Vue/ComponentBuilder/Posta/postaComponentBuilder.js', './Scripts/Posta/postaUscitaInsert.js'], 'js/postaUscitaInsert.js')