CREATE TABLE CAF (
    ID VARCHAR(255) ,                        -- Identificador �nico da tabela
    CriadoEm TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Data de cria��o
    AtualizadoEm TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Data de atualiza��o
    CriadoPor VARCHAR(100),                       -- Nome do criador do registro
    Nome VARCHAR(255),                            -- Nome do cliente ou entidade
    CPFCNPJ VARCHAR(20),                          -- CPF ou CNPJ do cliente
    Status VARCHAR(50),                           -- Status do registro
    Mensagem TEXT,                                -- Mensagem associada ao registro
    MotivoReprovacao TEXT,                        -- Motivo da reprova��o na Documentoscopia
    URLTrust VARCHAR(2083),                       -- URL da Trust
    Id_arquivo INT NOT NULL,                      -- Identificador do arquivo associado
    ind_positivo BOOLEAN DEFAULT TRUE
    CONSTRAINT FK_Id_arquivo FOREIGN KEY (Id_arquivo) REFERENCES acamarquivo(id_arquivo) ON DELETE CASCADE
);
