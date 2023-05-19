CREATE OR REPLACE DATABASE progettoindustriale;

use progettoindustriale;

CREATE OR REPLACE TABLE Enti (
  Id int NOT NULL AUTO_INCREMENT,
  Nome varchar(256) NOT NULL,
  Sigla varchar(50),
  IsDeleted boolean default 0,
  PRIMARY KEY (id)
);

-- creare l’utente RestUser con password restPassword e assegnarli i diritti di lettura/scrittura sul database progettoindustriale
-- (NOTA: il comando GRANT crea implicitamente l’utente se non esiste; attenzione al case del nome utente e della password)
GRANT ALL PRIVILEGES ON progettoindustriale.* TO 'RestUser'@localhost IDENTIFIED BY 'restPassword';
