CREATE DATABASE TestCapta
GO

USE TestCapta
GO

CREATE TABLE customer_type(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CustomerType varchar(128)
)
GO

CREATE TABLE customer_status(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CustomerStatus VARCHAR(128)
)
GO

CREATE TABLE customer(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CustomerName varchar(256),
	Cpf VARCHAR(14) UNIQUE,
	CustomerTypeId INT FOREIGN KEY REFERENCES customer_type(Id),
	Gender VARCHAR(1),
	CustomerStatusId INT FOREIGN KEY REFERENCES customer_status(Id)
)
GO

INSERT INTO customer_status (CustomerStatus) VALUES ('Ativo')
INSERT INTO customer_status (CustomerStatus) VALUES ('Inativo')

INSERT INTO customer_type (CustomerType) VALUES ('Essencial')
INSERT INTO customer_type (CustomerType) VALUES ('Extra')
INSERT INTO customer_type (CustomerType) VALUES ('Deluxe')

INSERT INTO customer (CustomerName, Cpf, CustomerTypeId, Gender, CustomerStatusId) VALUES ('João da Silva', '111.111.111-11', 1, 'M', 1)
INSERT INTO customer (CustomerName, Cpf, CustomerTypeId, Gender, CustomerStatusId) VALUES ('José Souza', '222.222.222-22', 2, 'M', 2)
INSERT INTO customer (CustomerName, Cpf, CustomerTypeId, Gender, CustomerStatusId) VALUES ('Maria Alvez', '333.333.333-33', 3, 'F', 1)