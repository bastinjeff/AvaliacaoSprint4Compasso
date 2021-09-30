select 
	c.id AS "ID", 
    c.nome AS "Nome do Cliente" 
    from cliente c 
    left join dependente d on c.id = d.id_cliente 
    where d.id is null