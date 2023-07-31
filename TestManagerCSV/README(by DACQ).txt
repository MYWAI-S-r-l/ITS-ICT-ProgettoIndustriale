Il Program presente all'interno di TestManagerCSV va avviato SOLAMENTE 1 volta e sopratutto 
SOLO la prima volta che i dati andranno caricati sul DB. E' obbligatorio avviarlo PRIMA di ogni altro Program che andrebbe a riempire il DB.
Essendo che il Program, prima di caricare i dati sul DB, cancella il contenuto delle tabelle Macrozone, Province, Region, Industry, Load e Generation, 
bisogna fare estrema attenzione a non avviarlo una seconda volta.