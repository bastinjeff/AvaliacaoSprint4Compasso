select 
	d.nome AS "Nome do Dependente",d.idade AS "Idade do Dependente",
	c.nome AS "Nome do Cliente",c.idade AS "Idade do Cliente"
    from dependente d 
    join cliente c on d.id_cliente = c.id 
    join tipo_cliente tc on tc.id = c.tp_cliente 
    where tc.descricao = "FIDELIZADO"
