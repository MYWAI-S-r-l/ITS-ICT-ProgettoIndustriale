USE `progettoindustriale` ;

create or replace table `progettoindustriale`.`Token`(
`id` INT NOT NULL AUTO_INCREMENT,
`TokenType` VARCHAR(20) not null,
`AccessToken` VARCHAR(50) not null,
`Provider` VARCHAR(50) not null,
PRIMARY KEY (`id`)
);
