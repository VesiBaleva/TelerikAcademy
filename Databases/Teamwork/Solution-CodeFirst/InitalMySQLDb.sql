SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `productsdb` DEFAULT CHARACTER SET utf8 ;
USE `productsdb` ;

-- -----------------------------------------------------
-- Table `productsdb`.`measures`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `productsdb`.`measures` (
  `MeasureID` INT(11) NOT NULL AUTO_INCREMENT ,
  `MeasureName` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`MeasureID`) )
ENGINE = InnoDB
AUTO_INCREMENT = 501
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `productsdb`.`vendors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `productsdb`.`vendors` (
  `VendorID` INT(11) NOT NULL AUTO_INCREMENT ,
  `VendorName` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`VendorID`) ,
  UNIQUE INDEX `unq_VendorName` (`VendorName` ASC) )
ENGINE = InnoDB
AUTO_INCREMENT = 201
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `productsdb`.`products`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `productsdb`.`products` (
  `ProductsID` INT(11) NOT NULL AUTO_INCREMENT ,
  `VendorID` INT(11) NOT NULL ,
  `ProductName` VARCHAR(50) NOT NULL ,
  `MeasureID` INT(11) NOT NULL ,
  `BasePrice` DECIMAL(8,2) NOT NULL ,
  PRIMARY KEY (`ProductsID`) ,
  UNIQUE INDEX `unq_ProductName` (`ProductName` ASC) ,
  INDEX `VendorID` (`VendorID` ASC) ,
  INDEX `MeasureID` (`MeasureID` ASC) ,
  CONSTRAINT `products_ibfk_1`
    FOREIGN KEY (`VendorID` )
    REFERENCES `productsdb`.`vendors` (`VendorID` ),
  CONSTRAINT `products_ibfk_2`
    FOREIGN KEY (`MeasureID` )
    REFERENCES `productsdb`.`measures` (`MeasureID` ))
ENGINE = InnoDB
AUTO_INCREMENT = 51
DEFAULT CHARACTER SET = utf8;

USE `productsdb` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


-------------------------------------------
-------------------------------------------

INSERT Vendors VALUES (10, 'Nestle Sofia Corp.');
INSERT Vendors VALUES (20, 'Zagorka Corp.');
INSERT Vendors VALUES (30, 'Targovishte Bottling Company Ltd.');
INSERT Vendors VALUES (40, 'Misho Birata Ltd.');
INSERT Vendors VALUES (50, 'Bulgartabac Corp.');
INSERT Vendors VALUES (60, 'Peshtera Bottling Company Ltd.');
INSERT Vendors VALUES (70, 'Chio Foods Ltd.');
INSERT Vendors VALUES (80, 'Purshevitsa Ltd.');
INSERT Vendors VALUES (90, 'Moreni Ltd.');
INSERT Vendors VALUES (100, 'Vinprom Karnobat Ltd.');
INSERT Vendors VALUES (110, 'Roev Furits Ltd.');
INSERT Vendors VALUES (120, 'Green Ltd.');
INSERT Vendors VALUES (130, 'Niki Fruit Ltd.');
INSERT Vendors VALUES (140, 'Danone Ltd.');
INSERT Vendors VALUES (150, 'Craft Foods Corp.');
INSERT Vendors VALUES (160, 'Coca-Cola Sofia Corp.');
INSERT Vendors VALUES (170, 'Rusev And Son Ltd.');
INSERT Vendors VALUES (180, 'Moni-77 Ltd.');
INSERT Vendors VALUES (190, 'Pepsi Sofia Ltd.');
INSERT Vendors VALUES (200, 'Margarit Ltd.');


INSERT Measures VALUES (100, 'liters');
INSERT Measures VALUES (200, 'pieces');
INSERT Measures VALUES (300, 'packs');
INSERT Measures VALUES (400, 'grams');
INSERT Measures VALUES (500, 'kilograms');

INSERT Products VALUES (1, 20, 'Beer "Zagorka"', 100, 0.86);
INSERT Products VALUES (2, 30, 'Vodka "Targovishte"', 100, 6.73);
INSERT Products VALUES (3, 20, 'Beer “Beck\'s”', 100, 0.95);
INSERT Products VALUES (4, 60, 'Mastika "Peshtera"', 100, 5.03);
INSERT Products VALUES (5, 60, 'Menta "Peshtera"', 100, 3.03);
INSERT Products VALUES (6, 200, 'Wine “Vrachanska Temenuga”', 100, 6.30);
INSERT Products VALUES (7, 20, 'Beer “Ariana”', 100, 1.00);
INSERT Products VALUES (8, 40, 'Beer "Ledenika"', 100, 0.73);
INSERT Products VALUES (9, 40, 'Beer “MM”', 100, 0.80);
INSERT Products VALUES (10, 20, 'Beer “Stella Artois”', 100, 1.20);
INSERT Products VALUES (11, 20, 'Beer "Staropramen"', 100, 1.10);
INSERT Products VALUES (12, 100, 'Rakia “Pomoriiska Muskatova”', 100, 6.03);
INSERT Products VALUES (13, 100, 'Rakia "Karnobatska"', 100, 7.00);
INSERT Products VALUES (14, 100, 'Wine "Romanca"', 100, 5.00);
INSERT Products VALUES (15, 100, 'Menta "Karnobat"', 100, 3.50);
INSERT Products VALUES (16, 100, 'Mastika “Karnobat”', 100, 5.15);
INSERT Products VALUES (17, 100, 'Rakia “Kehlibar”', 100, 6.30);
INSERT Products VALUES (18, 100, 'Wine “Chateau Karnobat”', 100, 5.40);
INSERT Products VALUES (19, 50, 'Cigarettes “Victory”', 300, 5.00);
INSERT Products VALUES (20, 50, 'Cigarettes “Melnik”', 300, 4.00);
INSERT Products VALUES (21, 50, 'Cigarettes “King”', 300, 4.50); 
INSERT Products VALUES (22, 50, 'Cigarettes “Kent”', 300, 5.03);
INSERT Products VALUES (23, 50, 'Cigarettes “Parlament”', 300, 5.43);
INSERT Products VALUES (24, 150, 'Chocolate “Milka”', 200, 1.50);
INSERT Products VALUES (25, 10, 'Chocolate "LZ"', 200, 1.00);
INSERT Products VALUES (26, 10, 'Chocolate "Kuma Lisa"', 200, 1.00);
INSERT Products VALUES (27, 140, 'Yogurt “Danone”', 100, 1.20); 
INSERT Products VALUES (28, 150, 'Wafer “Kit Kat”', 400, 1.10);
INSERT Products VALUES (29, 150, 'Wafer “Lion”', 400, 1.00);
INSERT Products VALUES (30, 150, 'Wafer “Mura”', 400, 0.60);
INSERT Products VALUES (31, 150, 'Coffee “Jacobs”', 100, 0.23);
INSERT Products VALUES (32, 70, 'Chips "Chio"', 400, 2.03);
INSERT Products VALUES (33, 150, 'Chocolate “Svoge”', 200, 1.13);
INSERT Products VALUES (34, 150, 'Wafer “Corny”', 400, 1.03);
INSERT Products VALUES (35, 160, 'Soft Drink “Fanta”', 100, 2.60);
INSERT Products VALUES (36, 160, 'Soft Drink “Coca-Cola”', 100, 2.60);
INSERT Products VALUES (37, 160, 'Soft Drink “Sprite', 100, 2.60);
INSERT Products VALUES (38, 160, 'Soft Drink “Lift”', 100, 2.60);
INSERT Products VALUES (39, 160, 'Soft Drink “Schweppes”', 100, 2.60);
INSERT Products VALUES (40, 190, 'Soft Drink “Pepsi”', 100, 2.60);
INSERT Products VALUES (41, 190, 'Soft Drink “Mirinda”', 100, 2.60);
INSERT Products VALUES (42, 190, 'Soft Drink “7 Up”', 100, 2.60);
INSERT Products VALUES (43, 170, 'Potatos', 500, 3.20);
INSERT Products VALUES (44, 180, 'Tomatoes', 500, 1.80);
INSERT Products VALUES (45, 120, 'Onion', 500, 0.30);
INSERT Products VALUES (46, 110, 'Wattermellons', 500, 0.80);
INSERT Products VALUES (47, 110, 'Pineapples', 500, 3.03);
INSERT Products VALUES (48, 110, 'Mellons', 500, 1.43);
INSERT Products VALUES (49, 130, 'Oranges', 500, 2.40);
INSERT Products VALUES (50, 20, 'Yogurt “Purshevitsa”', 100, 1.03);