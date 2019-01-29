CREATE TABLE dbo.BolsasValores(
	Sigla VARCHAR(10) NOT NULL,
	NomeBolsa VARCHAR(60) NOT NULL,
	DataReferencia DATETIME NOT NULL,
	Variacao NUMERIC (10,4) NOT NULL,
	CONSTRAINT PK_BolsasValores PRIMARY KEY (Sigla)
)
GO


INSERT INTO dbo.BolsasValores
           (Sigla
           ,NomeBolsa
           ,DataReferencia
           ,Variacao)
     VALUES
           ('BOVESPA'
           ,'Brasil | Bovespa'
           ,'2018-04-25'
           ,-0.0050)

INSERT INTO dbo.BolsasValores
           (Sigla
           ,NomeBolsa
           ,DataReferencia
           ,Variacao)
     VALUES
           ('NASDAQ'
           ,'EUA | NASDAQ'
           ,'2018-04-25'
           ,-0.0005)

INSERT INTO dbo.BolsasValores
           (Sigla
           ,NomeBolsa
           ,DataReferencia
           ,Variacao)
     VALUES
           ('NIKKEI'
           ,'Japão | Nikkei'
           ,'2018-04-25'
           ,0.0052)
