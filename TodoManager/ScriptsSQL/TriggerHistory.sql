-- TRIGGER DE HISTÓRICO DE PrioridadeTarefa
CREATE TRIGGER TG_HPrioridadeTarefas
ON PrioridadesTarefas
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO  VALUES (PRD_Id, PRD_Descricao, GETDATE())
    SELECT PRD_Id, PRD_Descricao
    FROM deleted;

    DELETE FROM PrioridadesTarefas
    WHERE PRD_Id IN (SELECT PRD_Id,PRD_Descricao FROM deleted);
END;
