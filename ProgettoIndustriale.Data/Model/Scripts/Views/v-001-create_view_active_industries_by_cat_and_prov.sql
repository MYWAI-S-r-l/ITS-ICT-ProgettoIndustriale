CREATE OR REPLACE VIEW `active_industries_by_category_and_provinces` AS
SELECT  p.`name` AS `name_province`,i.`ateco_code` AS `category`, i.`count_active`
FROM `progettoindustriale`.`Industry` AS i
JOIN `progettoindustriale`.`Province` AS p ON i.`COD_province` = p.`ID_province`  
GROUP BY p.`name`,i.`ateco_code`;


/* Semplice test in SQL qui sotto nel caso servisse:


SET FOREIGN_KEY_CHECKS = 0;

TRUNCATE TABLE province;

INSERT INTO province (name, COD_region)
VALUES
	("Genova",1), 
	("Potenza",2),
	("Roma",3);

TRUNCATE TABLE industry;

INSERT INTO industry(ateco_code, count_active, COD_province)
VALUES
	("Tessile", 2,1),
	("Edile", 14,2),
	("Alimentare", 22,3);
	
SET FOREIGN_KEY_CHECKS = 1;

SELECT * FROM active_industries_by_category_and_provinces; 
*/