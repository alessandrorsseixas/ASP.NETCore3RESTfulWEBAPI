# ASP.NET Core 3 RESTful WEB API - 2020 | Formação Completa

Sobre este curso

Aprenda de forma definitiva como criar aplicações 100% RESTful e de forma profissional.

Descrição

RESTful API representa hoje o primeiro passo para você aprender sobre desenvolvimento de sistemas web altamente escaláveis e que atenda a demanda cada vez maior em todo mundo por soluções capazes de processar um grande número de requisições.

Imagina nesse momento o número de pessoas acessando sistemas web de ensino(EAD), banking line, loja virtuais ou qualquer uma das redes sociais? A proposta desta formação é ajudá lo a cria soluções web robustas utilizando o estilo de arquitetura REST e além disso você vai aprender a trabalhar em alto nível com ferramentas de desenvolvimento como Visual Studio, .NET Core 3.x e a linguagem de programação C#

#### O que você aprenderá

- Conceito de Request e Response
- Fundamentos ASP NET Core
- Entity Framework Core in Memory
- Construindo uma RESTful API
- Documentação da API com OpenAPI / Swagger
- Como Utilizar a HttpClient Para Consumir APIs
- Cuidando da Segurança da API com OAuth2 e OpenID Connect
- Implantação da sua API no SmarterASPNet ou Azure

#### Há algum requisito ou pré-requisito para o curso?

- Conhecimentos Básicos da Linguagem C#

#### Para quem é este curso:

- Amadores e Profissionais com alguma experiência em desenvolvimento WEB

  

**Seção 3: Construindo Sua Primeira WEB API**

19. ##### Criando o Arquivo de Solução

    Nesse item foi criado um projeto de solução vazia chamado Rally.Dakar.

20. ##### Adicionando Projetos de Domínio

    - Adicionada uma pasta de Solução chamada 0 - Dominio
    - Utilizar o padrão NomeCliente.NomeProjeto.NomeBiblioteca
    - Adicionar uma biblioteca de classes .Net Standard chamada RallyDakar.Dominio
    - Adicionar um Projeto de Teste do Tipo MSTest na Pasta de Dominiochamada RallyDakar.Dominio.Testes

21. ##### Abordagem Que Será Adotada

    - Abordagem a ser adotada DDD
    
22. ##### Adicionando as Pastas do Projeto

    - Estruturar o projeto do modo AntiPadrão
    - Adicionar a pasta de Entidades(Partners) - Eu gosto de trabalhar em inglês
    - Adicionar a pasta de Repositorios(AntiPaterns) - Ideal trabalhar Repositórios com o padrão Inversão de Controle
    - Adicionar a pasta de Servicos(AntiPaterns) - Ideal trabalhar Serviços com o padrão Inversão de Controle
    - Adicionar a pasta de Interfaces 

23. ##### Criando as Entidades

    - Adicionar Entidade Temporada

      - ```
        namespace RallyDakar.Dominio.Entidades
        {
            public class Temporada
            {
                public int Id { get; set; }
                public string Nome { get; set; }
        
                public DateTime DataInicio { get; set; }
        		//Nullable em C# é representado por "?"
                public DateTime? DataFim { get; set; }
            }
        }	
        ```

    - Adicionar Entidade Equipes
    - Adicionar Entidade Piloto
    - Adicionar Entidade Telemetria

24. ##### Entidades e seus Relacionamentos
	- Alterar o nome de Equipes para Equipe
	
	- Atualizar as propriedades da temporada
		- Uma temporada pode ter uma ou mais equipes: Criar o relacionamento de Temporada para Equipes
			```
			public ICollection<Equipe> Equipes { get; set; }
    		```
    
	- Atualizar as propriedades da Equipe
		
		- Uma Equipe está em uma temporada: Criar campo TemporadaID para o EF e Criar o relacionamento para Temporada
		
		- Uma Equipe tem um(a) ou mais pilotos(as): Criar o relacionamento Equipe com Piloto
		
		  ```
		   // Atributo para identificar o relacionamento no banco de dados para o entity framework(EF)
		   public int TemporadaId { get; set; }
		  // Ao utiliar Virtual o EF o entity framework em tempo de execução possibilita carregar os dados da entitidade.
		  public virtual Temporada Temporada { get; set;}
		  // Uma equipe possui um ou mais pilotos
		  public ICollection<Piloto> Pilotos { get; set; }
		  ```
		
	- Atualizar as propriedades do Piloto
	
		```
		namespace RallyDakar.Dominio.Entidades
		{
			public class Piloto
			{
				public int Id { get; set; }
				public string Nome { get; set; }
				public int EquipeID { get; set; }
				public virtual Equipe Equipe { get; set; }
			}
		}
		```
	
	