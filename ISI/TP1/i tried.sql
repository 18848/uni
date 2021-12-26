USE ISI;

--SELECT MAX(total) as 'Mais Caro' 
--FROM(

	SELECT SUM(result.conta) as 'Total', result.id as 'IdEquipa'
    FROM equipa as e 
		INNER JOIN(
        SELECT (m.custo * rm.qtd) as conta, e.idEquipa as id
        FROM equipa as e 
        INNER JOIN requisicao as r 
            ON r.idEquipa = e.idEquipa
        INNER JOIN requisicaoMaterial as rm
            ON rm.idRequisicao = r.idRequisicao
        INNER JOIN material as m
            ON m.idMaterial = rm.idMaterial
        GROUP BY m.custo, rm.qtd, e.idEquipa
        ) as result
		ON e.idEquipa = result.id
    GROUP BY conta, id
	--) as 

SELECT equipa.idEquipa
FROM equipa as e 
		INNER JOIN requisicao as r 
			ON r.idEquipa = e.idEquipa
		INNER JOIN 
		(
		SELECT qtd
		FROM requisicaoMaterial
		GROUP BY requisicaoMaterial.idMaterial
		) as rm
			ON rm.idRequisicao = r.idRequisicao
		INNER JOIN material as m
			ON m.idMaterial = rm.idMaterial
		GROUP BY m.custo, rm.qtd, e.idEquipa
		) as result


