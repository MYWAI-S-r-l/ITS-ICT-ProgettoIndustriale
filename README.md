# Introduction 
Progetto Industriale

# Getting Started
Per il proggetto web si fa uso di Vue e di Laravel Mix (come wrapper di Webpack).
Alcuni passaggi preliminari:
1. Una volta clonato il progetto, posizionarsi nella cartella del progetto web, dove è presente anche il file package.json, e installare i pacchetti NPM con l'istruzione
> npm install
> npm install axios -pacchetto per invio mail-

2. Al termine dell'installazione, e all'apertura ogni volta del progetto, ricordarsi di posizionarsi nella cartella del progetto web e lanciare laravel in modalità watch con l'istruzione
> npm run watch

Per una più semplice gestione e per automatizzare i passaggi appena descritti, si consiglia di installare alcuni pacchetti in base all'ambiente di sviluppo.

## Visual Studio
* **NPM Task Runner**
https://marketplace.visualstudio.com/items?itemName=MadsKristensen.NPMTaskRunner
Questa estensione si occuperà, all'apertura del progetto, di lanciare automaticamente laravel in modalità watch, senza quindi necessità di interventi manuali

## Visual Studio Code
* **Task Runner**
https://marketplace.visualstudio.com/items?itemName=SanaAjani.taskrunnercode
Questa estensione predispone un'area "Task Runner" che permette di lanciare gli script con un semplice click da interfaccia. 
Ricordarsi di lanciare le istruzioni relative al solo progetto Web