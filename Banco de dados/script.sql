CREATE DATABASE AssistenciaTecnica;
GO

USE AssistenciaTecnica;
GO

CREATE TABLE Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Telefone VARCHAR(20),
    Email VARCHAR(100)
);

CREATE TABLE Tecnico (
    IdTecnico INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL
);

CREATE TABLE Equipamento (
    IdEquipamento INT IDENTITY(1,1) PRIMARY KEY,

    IdCliente INT NOT NULL,

    TipoEquipamento VARCHAR(50) NOT NULL,
    Marca VARCHAR(50) NOT NULL,
    Modelo VARCHAR(100) NOT NULL,
    NumeroSerie VARCHAR(100),

    CONSTRAINT FK_Equipamento_Cliente
        FOREIGN KEY (IdCliente)
        REFERENCES Cliente(IdCliente)
);

CREATE TABLE OrdemServico (
    IdOrdemServico INT IDENTITY(1,1) PRIMARY KEY,

    IdEquipamento INT NOT NULL,
    IdTecnico INT NOT NULL,

    DefeitoRelatado VARCHAR(500) NOT NULL,
    Diagnostico VARCHAR(500),
    ServicoExecutado VARCHAR(500),

    DataEntrada DATE NOT NULL,
    DataSaida DATE,

    Status VARCHAR(50) NOT NULL,

    CONSTRAINT FK_OrdemServico_Equipamento
        FOREIGN KEY (IdEquipamento)
        REFERENCES Equipamento(IdEquipamento),

    CONSTRAINT FK_OrdemServico_Tecnico
        FOREIGN KEY (IdTecnico)
        REFERENCES Tecnico(IdTecnico)
);
GO

select * from Cliente
select * from Tecnico
select * from Equipamento
SELECT * FROM OrdemServico