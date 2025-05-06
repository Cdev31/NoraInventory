CREATE DATABASE novaInventory;

use [novaInventory]

CREATE TABLE states(
    id INT IDENTITY( 1,1) PRIMARY KEY,
    state_name VARCHAR(20) NOT NULL,
    module_name VARCHAR(20) NOT NULL
    UNIQUE( state_name)
);


CREATE TABLE product (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    price DECIMAL(6,2) NOT NULL,
    stock INT NOT NULL CHECK ( stock >= 0 ),
    description VARCHAR(200) NOT NULL,
    [state] INT NOT NULL,
    CONSTRAINT FK_PRODUCT_STATE FOREIGN KEY ( [state] ) REFERENCES states( id )
);

CREATE TABLE client (
    id INT IDENTITY(1,1) PRIMARY KEY,
    firstname VARCHAR(10) NOT NULL,
    surname VARCHAR(10) NOT NULL,
    email VARCHAR(200) NOT NULL,
    [state] INT NOT NULL,
    CONSTRAINT FK_CLIENT_STATE FOREIGN KEY ( [state] ) REFERENCES states( id )
);


CREATE TABLE orders (
    id INT IDENTITY(1,1) PRIMARY KEY,
    created DATETIME NOT NULL DEFAULT GETDATE(),
    client_id INT NOT NULL,
    [state] INT NOT NULL,
    CONSTRAINT FK_ORDER_CLIENT FOREIGN KEY ( client_id ) REFERENCES client(id),
    CONSTRAINT FK_ORDER_STATE FOREIGN KEY ( [state] ) REFERENCES states( id)
);

CREATE TABLE product_order(
    id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    CONSTRAINT FK_PRODUCT_ORDER FOREIGN KEY ( order_id ) REFERENCES orders(id),
    CONSTRAINT FK_ORDER_PRODUCT FOREIGN KEY ( product_id ) REFERENCES product(id)
);

-- Consultas para ver estructura y schemas de las tablas --

SELECT COLUMN_NAME, CHARACTER_MAXIMUM_LENGHT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = "products";

SELECT NAME FROM SYS.TABLES;