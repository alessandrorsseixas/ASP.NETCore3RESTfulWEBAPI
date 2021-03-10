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
25. ##### Classe Telemetria

    - Atualizar as propriedades da Telemetria

      ```
      namespace RallyDakar.Dominio.Entidades
      {
          public class Telemetria
          {
              public int Id { get; set; }
              public int TemporadaId { get; set; }
              public int PilotoId { get; set; }
              public DateTime Data { get; set; }
              public TimeSpan Hora { get; set; }
              public Decimal Latitude { get; set; }
              public Decimal Longitude { get; set; }
              public Decimal PercentualCombustivel { get; set; }
              public double Velocidade { get; set; }
              public double RPM { get; set; }
              public int TemperaturaExterna { get; set; }
              public int TemperaturaMotor { get; set; }
              public double AltitudeNivelMar { get; set; }
              public bool PedalAcelerador { get; set; }
              public bool PedalFreio { get; set; }
              public virtual Temporada Temporada { get; set; }
              public virtual Piloto Piloto { get; set; }
          }
      }
      ```

    - Atualizar as propriedades da Temporada

      ```
      public ICollection<Telemetria> Telemetrias { get; set; }
      ```

    - Atualizar as propriedades do Piloto

      ```
      public ICollection<Telemetria> Telemetrias { get; set; }
      ```
26. ##### Enviando a Solução Para o GitHub
	- Ensina a publicar a atualização do projeto no Github
	
27. ##### Testes Unitários
	- Explica um pouco do TDD e qual abordagem que será adotada
	
28. ##### Adicionando um Comportamento(Método)
	- Criar Método com validações simples Adicionar Equipe
	
	  ```
	   public void AdicionarEquipe(Equipe equipe)
	   {
	       //Pré condição
	       if (equipe != null)
	       {
	  
	          if (!string.IsNullOrEmpty(equipe.Nome))
	          {
	  
	                  Equipes.Add(equipe);
	          }
	      }
	  
	  }
	  ```

29. ##### Criando o Primeiro Teste	
      - Criar Pasta de Temporadas no projeto de teste para armazenar os testes da classe temporada
      
      - Criar Classe de Teste "TemporadaTestes.cs", Exemplo para demonstrar uma classe de teste unificada com todos os testes(Classe Comentada para não impactar no projeto)
    
      ```
      //using Microsoft.VisualStudio.TestTools.UnitTesting;
      //using System;
      //using System.Collections.Generic;
      //using System.Text;
      
      //namespace RallyDakar.Dominio.Testes.Temporadas
      //{
      //    [TestClass]
      //    public class TemporadaTestes
      //    {
      //    }
      //}
      
      ```
    
      - Criar Classe de teste "AdicionarEquipesTeste.cs"

         

        ```
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        using RallyDakar.Dominio.Entidades;
        
        namespace RallyDakar.Dominio.Testes.Temporadas
        {
            [TestClass]
            public class AdicionarEquipesTeste
            {
                Temporada temporada;
                Equipe equipe1;
                Equipe equipe2;
                Equipe equipe3;
        
        
                // Metodo de inicialização do Teste
                [TestInitialize]
                public void Initialize()
                {
                    temporada = new Temporada()
                    {
                        Id = 1,
                        Nome = "Temporada2020"
        
                    };
        
                    equipe1 = new Equipe()
                    {
                        Id = 1,
                        Nome = "EquipeTeste1"
        
                    };
                    equipe2 = new Equipe()
                    {
                        Id = 2,
                        Nome = "EquipeTeste2"
        
                    };
                    equipe3 = new Equipe()
                    {
                        Id = 3,
                        Nome = "EquipeTeste3"
        
                    };
        
                    temporada.AdicionarEquipe(equipe1);
                    temporada.AdicionarEquipe(equipe2);
                    temporada.AdicionarEquipe(equipe3);
                }
            }
        }
        
        ```
30. ##### Aplicando o Assert no Teste

	- Criar o teste EquipesAdicionadasComSucesso.cs para validar se as equipes estão sendo adicionadas corretamente   
	
	  ```
	  [TestMethod]
	  public void EquipesAdicionadasComSucesso()
	  {
	  Assert.IsTrue(temporada.Equipes.Count() > 1);
	  }
	  ```
31. ##### Usando o gerenciador de Testes	
	- Para executar o teste é preciso que a solução esteja compilando 
	
	- Entrar no Gerenciador de testes Teste => Gerenciar Teste (Crtl+ E,T)
	
	- Ao executar o teste foi gerado um erro devido a ICollection<Equipe> não estava instanciado. Será criado o método construtor para instanciar a lista.
	
	  ![](Attachment\Erro_Teste.PNG)
	
	  ![](Attachment\MotivoErro.PNG)
	
	  ```
	  public Temporada()
	  {
	  	Equipes = new List<Equipe>();
	  }
	  ```
32. ##### Executando Testes
	- Executar o teste com sucesso
33. ##### Sincronizando Projeto (GitHub)
	- Projeto atualizado no GitHub
34. ##### Resumo Dos Testes Unitários
	- Explicado como criar outros testes
35. ##### Entity Framework Core e Banco de Dados Em Memória
	- Adicionar a pasta DbContext no Domínio
	- Adicionar na pasta DbContext na classe RallyDbContext
	- Adicionar a referência do EF em memória(Microsoft.EntityFrameworkCore.InMemory 3.1.12)
36. ##### Adicionando o Contexto de Banco de Dados
	- Escrever o source na classe RallyDbContext
	
	  ```
	  using Microsoft.EntityFrameworkCore;
	  using RallyDakar.Dominio.Entidades;
	  
	  namespace RallyDakar.Dominio.DbContexto
	  {
	      public class RallyDbContext:DbContext
	      {
	          //Configurando os DbSets
	          public DbSet<Temporada> Temporadas { get; set; }
	          public DbSet<Equipe> Equipes { get; set; }
	          public DbSet<Piloto> Pilotos { get; set; }
	          public DbSet<Telemetria> Telemetrias { get; set; }
	  
	          public RallyDbContext(DbContextOptions<RallyDbContext> options):base(options)
	          {
	  
	          }
	      }
	  }
	  
	  ```
37. ##### Criando o Primeiro Repositório
	
	- Escrever a classe PilotoRepositorio onde deve conter um método para AdicionarPiloto e um para ObterTodosPilotos.
	
	- Criar uma variável readonly da classe de Contexto RallyDbContext onde será injetado no construtor de PilotoRepositorio
	  
	  ```
	  using RallyDakar.Dominio.DbContexto;
	  using RallyDakar.Dominio.Entidades;
	  using System;
	  using System.Collections.Generic;
	  using System.Linq;
	  using System.Text;
	  
	  namespace RallyDakar.Dominio.Repositorios
	  {
	      public class PilotoRepositorio
	      {
	          private readonly RallyDbContext _rallyDbContext;
	          public PilotoRepositorio(RallyDbContext rallyDbContext)
	          {
	              _rallyDbContext = rallyDbContext;
	          }
	  
	          public void AdicionarPiloto(Piloto piloto)
	          {
	              _rallyDbContext.Pilotos.Add(piloto);
	  
	          }
	  
	          public IEnumerable<Piloto> ObterTodosPilotos()
	          {
	  
	             return _rallyDbContext.Pilotos.ToList();
	  
	          }
	  
	          public IEnumerable<Piloto> ObterTodosPilotos(string nome)
	          {
	  
	              return _rallyDbContext.Pilotos
	                  .Where(x=>x.Nome.Contains(nome))
	                  .ToList();
	  
	          }
	      }
	  }
	  
	  ```
38. ##### Adicionando Projeto de WEB API	  
	 - O projeto do WEB API será o responsável por gerar a instância do contexto PilotoRepositorio através da injeção de dependência. 
	
	 - Será necessário criar interfaces para o Repositório e a classe PilotoRepositorio implementa essa interface IPilotoRepositorio
	
	   ```
	   using System;
	   using System.Collections.Generic;
	   using System.Text;
	   
	   namespace RallyDakar.Dominio.Interfaces
	   {
	       public interface IPilotoRepositorio
	       {
	   
	       }
	   }
	   
	   ```
	
	   ```
	    public class PilotoRepositorio : IPilotoRepositorio
	    {
	   
	   }
	   ```
	   
	 - Criar uma pasta de solução 1- WEB e adicionar um projeto e uma pasta 1.1 API e adicionar um projeto do tipo ASPNET.Core RallyDaka.API marcar o projeto como projeto de inicialização
	
	 - Adicionar a referência do projeto de Dominio no projeto de API
	
	 - Adicionar o entity framework no projeto e adicionar o contexto na classe StartUp
	
	   ```
	   public class Startup
	   {
	           public Startup(IConfiguration configuration)
	           {
	               Configuration = configuration;
	           }
	   
	           public IConfiguration Configuration { get; }
	   
	           // This method gets called by the runtime. Use this method to add services to the container.
	           public void ConfigureServices(IServiceCollection services)
	           {
	           	//Com Scope a cada requisição terá uma nova instancia de Db_Rally
	               services.AddDbContext<RallyDbContext>(options => options.UseInMemoryDatabase("Db_Rally")
	                   ,ServiceLifetime.Scoped
	                   ,ServiceLifetime.Scoped);
	               services.AddControllers();
	   
	               services.AddScoped<IPilotoRepositorio, PilotoRepositorio>();
	           }
	   }
	   ```
39. ##### Adicionando um Controller	
	 - Criar a controller PilotoController herdando de ControllerBase
	
	 - Criar uma variável readonly da interface IPilotoRepositorio e depois criar o metodo construtor. o AspNet.Core será responsável por passar a instancia do PilotoRepositorio a controller para cada requisição
	
	 - Criar um metodo com verbor HttpGet para retornar todos os pilotos
	
	   ```
	   namespace RallyDaka.API.Controllers
	   {
	   
	       [ApiController]
	       [Route("api/produtos")]
	       public class PilotoController : ControllerBase 
	       {
	           private readonly IPilotoRepositorio _pilotoRepositorio;
	   
	           public PilotoController(IPilotoRepositorio pilotoRepositorio)
	           {
	               _pilotoRepositorio = pilotoRepositorio;
	           }
	   
	           [HttpGet]
	           public IActionResult ObterTodos()
	           {
	               return Ok("Retornou com sucesso");
	   
	           }
	       }
	   ```
40. ##### Refactoring no PilotoRepositorio	
	 - Refatorar a Interface IPilotoRepositorio com os metodos da PilotoRepositorio para incluir as assinaturas dos métodos e alterando o nome para remover o termo piloto
	
	   ```
	   namespace RallyDakar.Dominio.Interfaces
	   {
	       public interface IPilotoRepositorio
	       {
	           void Adicionar(Piloto piloto);
	   
	           IEnumerable<Piloto> ObterTodos();
	   
	           IEnumerable<Piloto> ObterTodos(string nome);
	   
	       }
	   }
	   ```
	
	- Alterar a classe concreta PilotoRepositorio para implementar os novos métodos da interface Ipiloto Repositorio.
	
	  ```
	  namespace RallyDakar.Dominio.Repositorios
	  {
	      public class PilotoRepositorio : IPilotoRepositorio
	      {
	          private readonly RallyDbContext _rallyDbContext;
	          public PilotoRepositorio(RallyDbContext rallyDbContext)
	          {
	              _rallyDbContext = rallyDbContext;
	          }
	  
	          public void Adicionar(Piloto piloto)
	          {
	              _rallyDbContext.Pilotos.Add(piloto);
	  
	          }
	  
	          public IEnumerable<Piloto> ObterTodos()
	          {
	  
	             return _rallyDbContext.Pilotos.ToList();
	  
	          }
	  
	          public IEnumerable<Piloto> ObterTodos(string nome)
	          {
	  
	              return _rallyDbContext.Pilotos
	                  .Where(x=>x.Nome.Contains(nome))
	                  .ToList();
	  
	          }
	      }
	  }
	  
	  ```
	
	  
	
	 - Adicionando o método ObterTodos do PilotoRepositorio no método da controller ObterTodos e incluir o método Adicionar [HttpPost].
	
	   ```
	   [HttpGet]
	   public IActionResult ObterTodos()
	   {
	   	return Ok(_pilotoRepositorio.ObterTodos());
	   }
	   
	   /// <summary>
	   /// A api vai ler as requisições no corpo da chamada
	   /// </summary>
	   /// <param name="piloto"></param>
	   /// <returns></returns>
	   [HttpPost]
	   public IActionResult Adicionar([FromBody]Piloto piloto)
	   {
	    _pilotoRepositorio.Adicionar(piloto);
	    return Ok();
	   }
	   ```
41. ##### Testando sua API com o Postman	

	[https://www.postman.com/]

42. ##### Chamando a API ( HTTPGet)	
	- Teste com o postman
43. ##### Chamando a API ( HTTPPost)	
	- Teste com o postman
44. ##### Resumo dos Comandos
	- HttpGet - Coletar informações
	- HttpPost - Adicionar informações
	- HttpPut - Atualizar Informações totais do objeto
	- HttpPatch - Atualizar informações parciais do objeto
	- HttpDelete - Delete informações
45. ##### Resumo dos Comandos
	- Escrevendo os métodos Put, Patch e Delete

	  ```
	   [HttpPut]
	   public IActionResult AtualizarPiloto([FromBody]Piloto piloto)
	   {
	   return Ok();
	   }
	  
	  
	  [HttpPatch]
	  public IActionResult AtualizarParcialPiloto([FromBody]Piloto piloto)
	  {
	  return Ok();
	  }
	  
	  
	  [HttpDelete("{id}")]
	  public IActionResult DeletarPiloto([FromBody]int id)
	  {
	  return Ok();
	  }
	  ```
46. ##### Conhecendo o HTTP Status Code	
	
	- Respostas de informação (100-199)
	- Respostas de sucesso (200-299)
	- Redirecionamentos (300-399)
	- Erros do cliente (400-499)
	- Erros do servidor (500-599)
	
47. ##### [Artigo] Status Code
	
	[https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status]()