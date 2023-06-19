USE `progettoindustriale` ;

create or replace table `progettoindustriale`.`ApiCallsLogs`(
`id` INT NOT NULL AUTO_INCREMENT,
`apiCallName` VARCHAR(50) not null,
`callFrequency` VARCHAR(5) not null,
`lastSuccessfulRun` TIMESTAMP not null,
PRIMARY KEY (`id`)
);
