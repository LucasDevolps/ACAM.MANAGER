-- Criação da tabela "configuracoes"
CREATE TABLE configuracoes (
    id SERIAL PRIMARY KEY, -- ID único para cada configuração
    tipo_configuracao VARCHAR(255) NOT NULL, -- Tipo de configuração
    valor TEXT NOT NULL,                     -- Valor da configuração
    legenda VARCHAR(255) DEFAULT ''          -- Legenda adicional (opcional)
);

INSERT INTO configuracoes (tipo_configuracao, valor, legenda)
VALUES
    ('Valor máximo', '45000', ''),
    ('Conexao com o banco', 'String de conexão', 'Lucas'),
    ('Conexao com o banco', 'String de conexão', 'Vinicius'),
    ('Conexao com o banco', 'String de conexão', 'Cliente');
