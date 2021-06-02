-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema solar
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema solar
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `solar` DEFAULT CHARACTER SET utf8 ;
USE `solar` ;

-- -----------------------------------------------------
-- Table `solar`.`Utilizador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Utilizador` (
  `username` VARCHAR(45) NOT NULL,
  `nome` VARCHAR(100) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `lastTimeOnline` DATETIME NOT NULL,
  PRIMARY KEY (`username`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Evento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Evento` (
  `idEvento` INT NOT NULL,
  `data` DATETIME NOT NULL,
  `descricao` TEXT(1000) NOT NULL,
  `dataFinal` DATETIME NOT NULL,
  PRIMARY KEY (`idEvento`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Localidade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Localidade` (
  `idLocalidade` INT NOT NULL,
  `latitude` DOUBLE NOT NULL,
  `longitude` DOUBLE NOT NULL,
  `Nome` VARCHAR(100) NOT NULL,
  `Distrito` VARCHAR(45) NOT NULL,
  `Concelho` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idLocalidade`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Meteorologia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Meteorologia` (
  `data` DATE NOT NULL,
  `idLocalidade` INT NOT NULL,
  `weatherType` VARCHAR(8) NOT NULL,
  `skyCondition` VARCHAR(10) NOT NULL,
  `probPrecipitacao` DOUBLE NOT NULL,
  `sunrise` TIME NOT NULL,
  `sunset` TIME NOT NULL,
  PRIMARY KEY (`data`, `idLocalidade`),
  INDEX `fk_Meteorologia_Localidade_idx` (`idLocalidade` ASC) VISIBLE,
  CONSTRAINT `fk_Meteorologia_Localidade`
    FOREIGN KEY (`idLocalidade`)
    REFERENCES `solar`.`Localidade` (`idLocalidade`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Lembrete`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Lembrete` (
  `idLembrete` INT NOT NULL,
  `dataHora` DATETIME NOT NULL,
  `Utilizador_username` VARCHAR(45) NOT NULL,
  `Evento_idEvento` INT NOT NULL,
  PRIMARY KEY (`idLembrete`),
  INDEX `fk_Lembrete_Utilizador1_idx` (`Utilizador_username` ASC) VISIBLE,
  INDEX `fk_Lembrete_Evento1_idx` (`Evento_idEvento` ASC) VISIBLE,
  CONSTRAINT `fk_Lembrete_Utilizador1`
    FOREIGN KEY (`Utilizador_username`)
    REFERENCES `solar`.`Utilizador` (`username`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Lembrete_Evento1`
    FOREIGN KEY (`Evento_idEvento`)
    REFERENCES `solar`.`Evento` (`idEvento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Alerta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Alerta` (
  `idAlerta` INT NOT NULL,
  `dataHora` DATETIME NOT NULL,
  `descricao` TEXT NOT NULL,
  `sugestoes` TEXT NOT NULL,
  `TIPO` INT NOT NULL,
  PRIMARY KEY (`idAlerta`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Habitacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Habitacao` (
  `idHabitacao` INT NOT NULL,
  `morada` VARCHAR(150) NOT NULL,
  `latitude` DOUBLE NOT NULL,
  `longitude` DOUBLE NOT NULL,
  `bateria` DOUBLE NOT NULL,
  `capacidade` DOUBLE NOT NULL,
  `Localidade_idLocalidade` INT NOT NULL,
  `Utilizador_username` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idHabitacao`),
  INDEX `fk_Habitacao_Localidade1_idx` (`Localidade_idLocalidade` ASC) VISIBLE,
  INDEX `fk_Habitacao_Utilizador1_idx` (`Utilizador_username` ASC) VISIBLE,
  CONSTRAINT `fk_Habitacao_Localidade1`
    FOREIGN KEY (`Localidade_idLocalidade`)
    REFERENCES `solar`.`Localidade` (`idLocalidade`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Habitacao_Utilizador1`
    FOREIGN KEY (`Utilizador_username`)
    REFERENCES `solar`.`Utilizador` (`username`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`ConsumoEnergetico`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`ConsumoEnergetico` (
  `data` DATE NOT NULL,
  `Habitacao_idHabitacao` INT NOT NULL,
  `consumo` DOUBLE NOT NULL,
  PRIMARY KEY (`data`, `Habitacao_idHabitacao`),
  INDEX `fk_ConsumoEnergetico_Habitacao1_idx` (`Habitacao_idHabitacao` ASC) VISIBLE,
  CONSTRAINT `fk_ConsumoEnergetico_Habitacao1`
    FOREIGN KEY (`Habitacao_idHabitacao`)
    REFERENCES `solar`.`Habitacao` (`idHabitacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Painel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Painel` (
  `idPainel` INT NOT NULL,
  `Habitacao_idHabitacao` INT NOT NULL,
  `producaoPrevistaHora` DOUBLE NOT NULL,
  `modelo` VARCHAR(45) NOT NULL,
  `estado` INT NOT NULL,
  PRIMARY KEY (`idPainel`),
  INDEX `fk_Painel_Habitacao1_idx` (`Habitacao_idHabitacao` ASC) VISIBLE,
  CONSTRAINT `fk_Painel_Habitacao1`
    FOREIGN KEY (`Habitacao_idHabitacao`)
    REFERENCES `solar`.`Habitacao` (`idHabitacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`ProducaoEnergetica`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`ProducaoEnergetica` (
  `data` DATE NOT NULL,
  `Painel_idPainel` INT NOT NULL,
  `producao` DOUBLE NOT NULL,
  PRIMARY KEY (`data`, `Painel_idPainel`),
  INDEX `fk_ProducaoEnergetica_Painel1_idx` (`Painel_idPainel` ASC) VISIBLE,
  CONSTRAINT `fk_ProducaoEnergetica_Painel1`
    FOREIGN KEY (`Painel_idPainel`)
    REFERENCES `solar`.`Painel` (`idPainel`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Funcionario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Funcionario` (
  `Utilizador_username` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Utilizador_username`),
  CONSTRAINT `fk_table1_Utilizador1`
    FOREIGN KEY (`Utilizador_username`)
    REFERENCES `solar`.`Utilizador` (`username`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Manutencao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Manutencao` (
  `Funcionario_username` VARCHAR(45) NOT NULL,
  `Habitacao_idHabitacao` INT NOT NULL,
  `data` DATETIME NOT NULL,
  PRIMARY KEY (`Funcionario_username`),
  INDEX `fk_Manutencao_Habitacao1_idx` (`Habitacao_idHabitacao` ASC) VISIBLE,
  CONSTRAINT `fk_Manutencao_Funcionario1`
    FOREIGN KEY (`Funcionario_username`)
    REFERENCES `solar`.`Funcionario` (`Utilizador_username`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Manutencao_Habitacao1`
    FOREIGN KEY (`Habitacao_idHabitacao`)
    REFERENCES `solar`.`Habitacao` (`idHabitacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`Avaria`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`Avaria` (
  `Habitacao_idHabitacao` INT NOT NULL,
  `dataHora` DATETIME NOT NULL,
  INDEX `fk_Avaria_Habitacao1_idx` (`Habitacao_idHabitacao` ASC) VISIBLE,
  PRIMARY KEY (`dataHora`),
  CONSTRAINT `fk_Avaria_Habitacao1`
    FOREIGN KEY (`Habitacao_idHabitacao`)
    REFERENCES `solar`.`Habitacao` (`idHabitacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `solar`.`AlertasUtilizador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solar`.`AlertasUtilizador` (
  `Tipo` INT NOT NULL,
  `Utilizador_username` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Utilizador_username`, `Tipo`),
  CONSTRAINT `fk_table1_Utilizador2`
    FOREIGN KEY (`Utilizador_username`)
    REFERENCES `solar`.`Utilizador` (`username`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
