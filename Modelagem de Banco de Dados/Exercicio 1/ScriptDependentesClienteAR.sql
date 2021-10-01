select 
	d.nome AS "Nome do Dependente", 
    d.idade AS "Idade do Dependente", 
    c.nome AS "Nome do Cliente" 
	from cliente c
	right join dependente d on d.id_cliente = c.id
    where c.nome LIKE "%AR%"
