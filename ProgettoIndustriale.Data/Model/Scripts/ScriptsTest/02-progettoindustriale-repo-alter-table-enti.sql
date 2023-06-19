use progettoindustriale;

ALTER TABLE Enti 
ADD COLUMN IF NOT EXISTS Descrizione varchar(50);
