--Script necessario per la creazione della Procedure necessaria al reset dell'ID delle tabelle qui sotto elencate.

DELIMITER //

CREATE PROCEDURE ResetAutoIncrement()
BEGIN
    -- Ripristina l'ID auto-incrementale per la tabella macrozone
    SET @macrozoneSql = 'ALTER TABLE macrozone AUTO_INCREMENT = 1;';
    PREPARE macrozoneStmt FROM @macrozoneSql;
    EXECUTE macrozoneStmt;
    DEALLOCATE PREPARE macrozoneStmt;

    -- Ripristina l'ID auto-incrementale per la tabella region
    SET @regionSql = 'ALTER TABLE region AUTO_INCREMENT = 1;';
    PREPARE regionStmt FROM @regionSql;
    EXECUTE regionStmt;
    DEALLOCATE PREPARE regionStmt;

    -- Ripristina l'ID auto-incrementale per la tabella province
    SET @provinceSql = 'ALTER TABLE province AUTO_INCREMENT = 1;';
    PREPARE provinceStmt FROM @provinceSql;
    EXECUTE provinceStmt;
    DEALLOCATE PREPARE provinceStmt;

    -- Ripristina l'ID auto-incrementale per la tabella industry
    SET @industrySql = 'ALTER TABLE industry AUTO_INCREMENT = 1;';
    PREPARE industryStmt FROM @industrySql;
    EXECUTE industryStmt;
    DEALLOCATE PREPARE industryStmt;
   
    
    SET @generationSql = 'ALTER TABLE generation AUTO_INCREMENT = 1;';
    PREPARE generationStmt FROM @generationSql;
    EXECUTE generationStmt;
    DEALLOCATE PREPARE generationStmt;
END //

DELIMITER ;
