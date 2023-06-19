USE `progettoindustriale` ;

create or replace table `progettoindustriale`.`TernaToken`(
`id` INT NOT NULL AUTO_INCREMENT,
`TokenType` VARCHAR(20) not null,
`AccessToken` VARCHAR(50) not null,
`AddedTime` TIMESTAMP not null,
PRIMARY KEY (`id`)
);
