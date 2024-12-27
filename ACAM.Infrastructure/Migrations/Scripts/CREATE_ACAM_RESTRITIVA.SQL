CREATE TABLE Acam_Restritiva (
    client VARCHAR(255),
    pix_key VARCHAR(255),
    cpf_name VARCHAR(255),
    amount NUMERIC(20,2), 
    trndate TIMESTAMP NULL 
);

-- Criar índice
CREATE INDEX IX_Acam_Restritiva_Client_PixKey_CpfName
ON Acam_Restritiva (client, pix_key, cpf_name);

ALTER TABLE Acam_Restritiva
ADD COLUMN id_arquivo INT;

ALTER TABLE Acam_Restritiva
ADD CONSTRAINT fk_acam_restritiva_acamarquivo FOREIGN KEY (id_arquivo)
REFERENCES AcamArquivo (id_arquivo);
