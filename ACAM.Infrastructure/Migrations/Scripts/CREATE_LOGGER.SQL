CREATE TABLE LOGGER
(
	loggerId INT IDENTITY(1,1) PRIMARY KEY, 
	mensagem  varchar(max),
	stack    varchar(max)
);