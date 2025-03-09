-- 1. Create (or switch to) the database:
CREATE DATABASE IF NOT EXISTS client_schedule;
USE client_schedule;

-- 2. Create the COUNTRY table:
CREATE TABLE IF NOT EXISTS country (
  countryId     INT NOT NULL AUTO_INCREMENT,
  country       VARCHAR(50) NOT NULL,
  createDate    DATETIME NOT NULL,
  createdBy     VARCHAR(40) NOT NULL,
  lastUpdate    TIMESTAMP NOT NULL 
                DEFAULT CURRENT_TIMESTAMP 
                ON UPDATE CURRENT_TIMESTAMP,
  lastUpdateBy  VARCHAR(40) NOT NULL,
  PRIMARY KEY (countryId)
) ENGINE=InnoDB;

-- 3. Create the CITY table:
CREATE TABLE IF NOT EXISTS city (
  cityId        INT NOT NULL AUTO_INCREMENT,
  city          VARCHAR(50) NOT NULL,
  countryId     INT NOT NULL,
  createDate    DATETIME NOT NULL,
  createdBy     VARCHAR(40) NOT NULL,
  lastUpdate    TIMESTAMP NOT NULL 
                DEFAULT CURRENT_TIMESTAMP 
                ON UPDATE CURRENT_TIMESTAMP,
  lastUpdateBy  VARCHAR(40) NOT NULL,
  PRIMARY KEY (cityId),
  CONSTRAINT fk_city_country 
    FOREIGN KEY (countryId)
    REFERENCES country (countryId)
    ON DELETE RESTRICT 
    ON UPDATE CASCADE
) ENGINE=InnoDB;

-- 4. Create the ADDRESS table:
CREATE TABLE IF NOT EXISTS address (
  addressId     INT NOT NULL AUTO_INCREMENT,
  address       VARCHAR(50) NOT NULL,
  address2      VARCHAR(50),
  cityId        INT NOT NULL,
  postalCode    VARCHAR(10) NOT NULL,
  phone         VARCHAR(20) NOT NULL,
  createDate    DATETIME NOT NULL,
  createdBy     VARCHAR(40) NOT NULL,
  lastUpdate    TIMESTAMP NOT NULL
                DEFAULT CURRENT_TIMESTAMP 
                ON UPDATE CURRENT_TIMESTAMP,
  lastUpdateBy  VARCHAR(40) NOT NULL,
  PRIMARY KEY (addressId),
  CONSTRAINT fk_address_city 
    FOREIGN KEY (cityId)
    REFERENCES city (cityId)
    ON DELETE RESTRICT 
    ON UPDATE CASCADE
) ENGINE=InnoDB;

-- 5. Create the CUSTOMER table:
CREATE TABLE IF NOT EXISTS customer (
  customerId    INT NOT NULL AUTO_INCREMENT,
  customerName  VARCHAR(45) NOT NULL,
  addressId     INT NOT NULL,
  active        TINYINT(1) NOT NULL,
  createDate    DATETIME NOT NULL,
  createdBy     VARCHAR(40) NOT NULL,
  lastUpdate    TIMESTAMP NOT NULL 
                DEFAULT CURRENT_TIMESTAMP 
                ON UPDATE CURRENT_TIMESTAMP,
  lastUpdateBy  VARCHAR(40) NOT NULL,
  PRIMARY KEY (customerId),
  CONSTRAINT fk_customer_address 
    FOREIGN KEY (addressId)
    REFERENCES address (addressId)
    ON DELETE RESTRICT 
    ON UPDATE CASCADE
) ENGINE=InnoDB;

-- 6. Create the USER table:
CREATE TABLE IF NOT EXISTS user (
  userId        INT NOT NULL AUTO_INCREMENT,
  userName      VARCHAR(50) NOT NULL,
  password      VARCHAR(50) NOT NULL,
  active        TINYINT NOT NULL,
  createDate    DATETIME NOT NULL,
  createdBy     VARCHAR(40) NOT NULL,
  lastUpdate    TIMESTAMP NOT NULL
                DEFAULT CURRENT_TIMESTAMP 
                ON UPDATE CURRENT_TIMESTAMP,
  lastUpdateBy  VARCHAR(40) NOT NULL,
  PRIMARY KEY (userId)
) ENGINE=InnoDB;

-- 7. Create the APPOINTMENT table:
CREATE TABLE IF NOT EXISTS appointment (
  appointmentId INT NOT NULL AUTO_INCREMENT,
  customerId    INT NOT NULL,
  userId        INT NOT NULL,
  title         VARCHAR(255) NOT NULL,
  description   TEXT,
  location      TEXT,
  contact       TEXT,
  type          TEXT NOT NULL,
  url           VARCHAR(255),
  start         DATETIME NOT NULL,
  end           DATETIME NOT NULL,
  createDate    DATETIME NOT NULL,
  createdBy     VARCHAR(40) NOT NULL,
  lastUpdate    TIMESTAMP NOT NULL
                DEFAULT CURRENT_TIMESTAMP 
                ON UPDATE CURRENT_TIMESTAMP,
  lastUpdateBy  VARCHAR(40) NOT NULL,
  PRIMARY KEY (appointmentId),
  CONSTRAINT fk_appointment_customer 
    FOREIGN KEY (customerId)
    REFERENCES customer (customerId)
    ON DELETE CASCADE 
    ON UPDATE CASCADE,
  CONSTRAINT fk_appointment_user 
    FOREIGN KEY (userId)
    REFERENCES user (userId)
    ON DELETE RESTRICT 
    ON UPDATE CASCADE
) ENGINE=InnoDB;

