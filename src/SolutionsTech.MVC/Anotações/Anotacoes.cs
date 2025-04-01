namespace SolutionsTech.MVC.Anotações
{
	public class Anotacoes
	{
		/*

											Migração 
		
					Migra uma base de dados com todas as tabelas do banco de dados
--------------------------------------------------------------------------------------------------------------

											Update 
		
							ele cria aquilo no banco de dados, consiste
--------------------------------------------------------------------------------------------------------------

											Entidade
		
					Entidade é blindada, é o contexto do meu banco de dados
--------------------------------------------------------------------------------------------------------------

										   	  Dto 
				representação da minha entidade, é nela que voce polui, coloca a lista de usuarios.

--------------------------------------------------------------------------------------------------------------
											[NotMappad] 
							 Remove duplicidade de id no banco de dados

--------------------------------------------------------------------------------------------------------------
											Use Case 
		
					Funcionalidade, é serviço que voce chama o repositorio dentro dele
--------------------------------------------------------------------------------------------------------------
											Repository
						classe que voce tem o contexto de banco de dados
						dentro dele, voce faz as transações de banco de dados, crud
						classe usada para realizar ações em um contexto de banco de dados
--------------------------------------------------------------------------------------------------------------
	
									Metodos para usar no Repository

								public interface IAgentRepository

								// Método para criar um novo agente
								Task<Agent> CreateAgentAsync(Agent agent);

								// Método para buscar um agente pelo seu ID
								Task<Agent?> GetAgentByIdAsync(int id);

								// Método para buscar todos os agentes
								Task<List<Agent>> GetAllAgentsAsync();

								// Método para atualizar um agente
								Task<Agent> UpdateAgentAsync(Agent agent);

								// Método para deletar um agente
								Task<bool> DeleteAgentAsync(int id);
--------------------------------------------------------------------------------------------------------------













		*/
	}
}
