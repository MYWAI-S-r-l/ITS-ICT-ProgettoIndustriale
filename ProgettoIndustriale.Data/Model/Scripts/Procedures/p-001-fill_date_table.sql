-- ATTENZIONE: Assicurarsi che la colonna "date_time" sia di tipo DATETIME invece di TIMESTAMP
-- Lo script 007 converte il tipo in DATETIME

DROP PROCEDURE IF EXISTS PopulateDates;

DELIMITER //

CREATE PROCEDURE IF NOT EXISTS PopulateDates()
BEGIN
	
    DECLARE `start_date` DATETIME;
    DECLARE `end_date` DATETIME;
    DECLARE `current_date` DATETIME;
    
    SET `start_date` = '2021-01-01 00:00:00';
    SET `end_date` = '2026-12-31 23:59:00';
    SET `current_date` = `start_date`;
    
    WHILE `current_date` <= `end_date` DO
        INSERT INTO `progettoindustriale`.`date` (`date_time`, `year`, `month`, `day`, `hour`)
        VALUES (`current_date`, YEAR(`current_date`), MONTH(`current_date`), DAY(`current_date`), HOUR(`current_date`));
        
        SET `current_date` = DATE_ADD(`current_date`, INTERVAL 1 HOUR);
    END WHILE;
    
END //

DELIMITER ;


CALL PopulateDates();

/*
 * Da runnare nel caso si volesse resettare la tabella dates:
 * Evidenziarlo e farlo partire come un normale script senza bisogno di de-commentarlo
 
SET FOREIGN_KEY_CHECKS = 0;

TRUNCATE TABLE `progettoindustriale`.`date`;

SET FOREIGN_KEY_CHECKS = 1;

*/
