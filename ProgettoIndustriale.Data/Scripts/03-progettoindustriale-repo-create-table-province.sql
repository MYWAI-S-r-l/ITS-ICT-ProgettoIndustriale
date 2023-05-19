use progettoindustriale;

CREATE OR REPLACE TABLE Province (
  Codice varchar(3) NOT NULL,
  Nome varchar(50) NOT NULL,
  Sigla varchar(2)NOT NULL,
  Regione varchar(50) NOT NULL,
  PRIMARY KEY (Codice)
);