MusicPro es un proyecto de la asignatura Integración de plataformas, este mismo contiene api transbank la cual nos redirige a metodo de pago WebPay
a su vez utilizamos Sql Server como base de datos local para la realizacion de un registro de datos y usuarios dentro de la misma.


===============================
CREACION DE BASE DE DATOS
===============================

CREATE DATABASE waMusicPro

===============================
CREACION DE TABLAS
===============================

CREATE TABLE Usuario (
    id INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL
);

CREATE TABLE Productos(
    ProductoId int primary key identity (1,1) not null,
    Nombre varchar (40) not null,
    Cantidad int not null,
    Descripcion text,
    Precio int not null,
    Vigente bit not null
);

CREATE TABLE CarritoCompras (
    carritoId INT IDENTITY(1,1) PRIMARY KEY,
    clienteId INT NOT NULL,
    valorTotal INT NOT NULL,
    estado BIT NOT NULL DEFAULT 0,
    fechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
);
CREATE TABLE DetalleCarrito (
    detalleId INT IDENTITY(1,1) PRIMARY KEY,
    carritoId INT NOT NULL,
    productoId VARCHAR(50) NOT NULL,
    valor INT NOT NULL,
    cantidad INT NOT NULL
);

===============================
POBLAR TABLAS
===============================

Insert into Usuario values ('Admin', 'admin@gmail.com','admin','Administrador')


INSERT INTO [dbo].[Productos] ([Nombre], [Cantidad], [Descripcion], [Precio], [Vigente]) VALUES
('Batería Tama', 30, 'Pro Series ébano', 499990, 1),
('LTD EC256', 60, 'Guitarra Electrica modelo Les Paul', 419990, 1),
('Violin Etinger', 100, 'Violin 3/4 étinger', 79990, 1),
('Charango Andino', 100, 'Charango cuerpo caoba', 39990, 1),
('Bajo Tagima', 100, 'TGB-pro series 5 cuerdas', 599990, 1),
('Piano Yamaha', 100, 'Piano 78 teclas, sensibilidad, sustain', 959990, 1),
('Amplificador Marshall MG100', 12, 'Combo amplificador transistores 2x12', 675990, 1);
