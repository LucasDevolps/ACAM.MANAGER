-- Cria��o da tabela "configuracoes"
CREATE TABLE configuracoes (
    id SERIAL PRIMARY KEY, -- ID �nico para cada configura��o
    tipo_configuracao VARCHAR(255) NOT NULL, -- Tipo de configura��o
    valor TEXT NOT NULL,                     -- Valor da configura��o
    legenda VARCHAR(255) DEFAULT ''          -- Legenda adicional (opcional)
);

INSERT INTO configuracoes (tipo_configuracao, valor, legenda)
VALUES
    ('Valor m�ximo', '45000', ''),
    ('Conexao com o banco', 'String de conex�o', 'Lucas'),
    ('Conexao com o banco', 'String de conex�o', 'Vinicius'),
    ('Conexao com o banco', 'String de conex�o', 'Cliente');
