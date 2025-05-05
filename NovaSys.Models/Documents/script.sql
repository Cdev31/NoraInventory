CREATE DATABASE novaInventory;

use [novaInventory]

CREATE TABLE product (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    price DECIMAL(6,4) NOT NULL,
    stock INT NOT NULL CHECK ( stock >= 0 ),
    [state] VARCHAR(10) CHECK ( [state] IN ('Disponible', 'Agotado') ),
    description VARCHAR(200) NOT NULL
);

CREATE TABLE client (
    id INT IDENTITY(1,1) PRIMARY KEY,
    firstname VARCHAR(10) NOT NULL,
    surname VARCHAR(10) NOT NULL,
    email VARCHAR(200) NOT NULL,
    [state] VARCHAR(10) CHECK ( [state] IN ('Activo', 'Inactivo', 'Bloqueado')) NOT NULL,
);


CREATE TABLE orders (
    id INT IDENTITY(1,1) PRIMARY KEY,
    created DATETIME NOT NULL DEFAULT GETDATE(),
    client_id INT NOT NULL,
    [state] VARCHAR(20) CHECK ( [state] IN ('Procesando','Terminada') ),
    CONSTRAINT FK_ORDER_CLIENT FOREIGN KEY ( client_id ) REFERENCES client(id)
);

CREATE TABLE product_order(
    id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    CONSTRAINT FK_PRODUCT_ORDER FOREIGN KEY ( order_id ) REFERENCES orders(id),
    CONSTRAINT FK_ORDER_PRODUCT FOREIGN KEY ( product_id ) REFERENCES product(id)
);