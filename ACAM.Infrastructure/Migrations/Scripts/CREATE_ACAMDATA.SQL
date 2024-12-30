CREATE TABLE AcamData (
    client VARCHAR(255),
    pix_key VARCHAR(255),
    cpf_name VARCHAR(255),
    amount NUMERIC(20,2), 
    trndate TIMESTAMP NULL 
);

CREATE INDEX IX_AcamData_Client_PixKey_CpfName
ON AcamData (client, pix_key, cpf_name);

ALTER TABLE AcamData
ADD COLUMN id_arquivo INT;

CREATE TABLE AcamArquivo (
    id_arquivo SERIAL PRIMARY KEY, 
    nome_arquivo VARCHAR(255) NOT NULL,
    data_importacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP 
);

CREATE INDEX IX_AcamArquivo_Nome_arquivo ON AcamArquivo (nome_arquivo);

ALTER TABLE AcamData
ADD CONSTRAINT fk_acamdata_acamarquivo FOREIGN KEY (id_arquivo)
REFERENCES AcamArquivo (id_arquivo);

ALTER TABLE AcamData
ADD COLUMN ind_positivo BOOLEAN DEFAULT FALSE;

