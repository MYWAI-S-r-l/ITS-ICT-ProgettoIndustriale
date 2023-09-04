ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN date_time datetime NOT NULL;

ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN `year` smallint(6) NOT NULL;

ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN `month` tinyint(4) NOT NULL;

ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN `day` tinyint(4) NOT NULL;

ALTER TABLE progettoindustriale.`date` 
MODIFY COLUMN `hour` int NOT NULL;


ALTER TABLE progettoindustriale.`commodity` 
MODIFY COLUMN `name` varchar(40);

ALTER TABLE progettoindustriale.`commodity` 
MODIFY COLUMN `unit` varchar(30);
