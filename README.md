<h1 align="center">Desafio API .NET</h1> 
Neste repositório encontra-se a criação de uma api feita na semana de desafio de api do projeto starter.

## :bomb: Descrição do Desafio

<p style="text-align: justify">As funcionalidades obrigatórias para o desafio são: </p>

- CRUD completo para clientes (armazenar somente dados básicos) 
- CRUD completo para médicos veterinários (armazenar somente dados básicos)
- CRUD completo para o cachorro (cada animal deverá estar associado a um tutor/cliente | dados básicos do animal) 
- Registrar dados do atendimento: veterinário que está atendendo, tutor, animal em atendimento, data, hora, dados do animal no dia, diagnóstico, comentários. 
- Autenticação do usuário (Basic Authentication – user:password) para acessar os End Points. 
- Não deixe de popular o banco 

**<h4>Exceeds</h4>**

- No  cadastro  do  animal,  recuperar  dados  da  raça  buscando  na  API fornecida pelo link no final da descrição da atividade.
- Fornecer ao menos 3 serviços da API descrita no final da atividade para o cliente ( o cliente não pode acessar a API diretamente, deve acessar seu 
End Point, e seu End Poit deverá acessar a API e passar os dados para o cliente) 
- Manter histórico dos atendimentos e permitir que tanto o cliente quanto veterinário possam acessar esses dados. OBS: Nesse caso, o cliente poderá acessar somente dados das consultas de seus animais. Os veterinários por sua vez, podem ver histórico de qualquer consulta. 
- Swagger ou projeto no postman 
- TDD 

**<h4>Entidades</h4>**

<img width = "470" src="/Documentos/entidades.PNG">

Criado o back end utilizando c# com o framework .NET 5;

Criado Front end que consumirá a api do back end em angular 13;

****
## Funcionalidades

- Listar, adicionar, remover e alterar Veterinarios;
- Listar, adicionar, remover e alterar Cachorros;
- Listar, adicionar, remover e alterar Clientes;
- Listar, adicionar, remover e alterar Atendimentos;
- Cadastro e Login de usuarios;

****
## Tecnologias utilizadas
- `Entitiy Framework`
- `.NET 5`
- `Xunit`
- `Auto Mapper`
- `JavaScript`
- `BootStrap`
- `MySql`
- `Identity`
- `Angular 13`
- `Angular Material`

## Banco de dados


Banco de dados utilizado no projeto é o MySql provedor de acesso Pomelo;

Ao abrir o projeto, ir para o diretorio DogAPI e dar o comando "dotnet ef database update" em seu terminal;

Ele populará o seu banco de dados com as informações necessárias para executar o programa.

<p style="text-align: justify">Os dados de login dos usuários criados automaticamente são os seguintes: </p>

Perfil | Usuário | Senha |
------|---------|------|
Admin | admin@gft.com | Gft@1234 |
Usuario | usuario@gft.com | Gft@1234 |

---
<hr />
<h4>Endpoints</h4>

Abaixo os endpoints dos atendimentos no swagger.<br>
<img width = "470" src="/Documentos/Atendimentos.PNG">
<hr />

Abaixo os endpoints dos cachorros no swagger.<br>
<img width = "470" src="/Documentos/Cachorro.PNG">
<hr />

Abaixo os endpoints dos clientes no swagger.<br>
<img width = "470" src="/Documentos/Clientes.PNG">
<hr />

Abaixo os endpoints dos login no swagger.<br>
<img width = "470" src="/Documentos/Login.PNG">
<hr />

Abaixo os endpoints dos usuarios no swagger.<br>
<img width = "470" src="/Documentos/Usuario.PNG">
<hr />

## :european_castle: Front-end

- Home: página inicial da aplicação, com uma mensagem simples.
- Login: formulário de login de usuário já cadastrado. Responsável por validar e salvar algumas informações na sessionStorage, como o token, role e nome do usuário.
- resgister: formulário para registro de novo usuário ao sistema. 
- profile: página para ver os dados do usuário.
- user: página para utilizar os endpoints do usuário.
- admin: páginar para utilizar os endpoints do administrador.
- veterinarios: página que mostra a lista de veterinarios cadastrados.<br>
<img width = "470" src="/Documentos/vet.PNG"><br>

- veterinario/novo: o admin cadastrado poderá cadastrar um novo veterinario através do formulário.
- veterinario/id: o admin poderá editar um veterinario que conste da lista de veterinarios. Todos os dados serão preenchidos automaticamente neste formulário e o admin poderá realizar as alterações que quiser.
- pets: página que mostra a lista de pets cadastrados.<br>
<img width = "470" src="/Documentos/pet.PNG"><br>

- pet/novo: o admin cadastrado poderá cadastrar um novo pet através do formulário.
- pet/id: o admin poderá editar um pet que conste da lista de pets. Todos os dados serão preenchidos automaticamente neste formulário e o admin poderá realizar as alterações que quiser.
- clientes: página que mostra a lista de clientes cadastrados.<br>
<img width = "470" src="/Documentos/cliente.PNG"><br>

- cliente/novo: o admin cadastrado poderá cadastrar um novo cliente através do formulário.
- cliente/id: o admin poderá editar um cliente que conste da lista de clientes. Todos os dados serão preenchidos automaticamente neste formulário e o admin poderá realizar as alterações que quiser.
- atendimentos: página que mostra a lista de atendimentos cadastrados.<br>
<img width = "470" src="/Documentos/atendimento.PNG"><br>

- atendimento/novo: o admin cadastrado poderá cadastrar um novo atendimento através do formulário.
- atendimento/id: o admin poderá editar um atendimento que conste da lista de atendimentos. Todos os dados serão preenchidos automaticamente neste formulário e o admin poderá realizar as alterações que quiser.
- racas: mostra todas as raças de cachorro para o usuario cadastrado.<br>
<img width = "470" src="/Documentos/user1.PNG"><br>

- raca: faz a bucas de uma raça especificada pelo usuário.<br>
<img width = "470" src="/Documentos/user2.PNG"><br>

- user/atendimentos: busca todos os atendimentos do usuário logado.<br>
<img width = "470" src="/Documentos/user4.PNG"><br>

- imagem: traz link de imagens das raças de cachorros.<br>
<br>
<img width = "470" src="/Documentos/user3.PNG"><br>

## :loudspeaker: Informações importantes

<p style ="text-align: justify">Os dois projetos foram feitos separadamente, desta forma, cada um deverá ser rodado de forma autônoma para que funcionem.</p>

<p style ="text-align: justify">Para rodar a aplicação Angular, será necessário instalar os node_modules: </p>

> angular material<br>
> npm install
---

## :arrow_heading_up: Melhorias futuras

<p style ="text-align: justify">Melhorar a tratativa de erros da API no front-end e melhorar o design das páginas.</p>


# Executando o projeto

## backend

- Faça o clone do projeto <br>
- Para restaurar os pacotes use o <br>
<code>dotnet restore </code>
- Para instalar entity framework globalmente <br>
<code>dotnet tool install --global dotnet-ef</code>
- Dentro da aplicação acesse appsettings.Development.json coloque a string de conexão de acordo com o seu banco de dados mysql
- Atualizar a base de dados com o mysql <br>
<code>dotnet ef database update </code>
- Use o comando <br>
<code>dotnet watch run </code>

## frontend 

- Faça o clone do projeto <br>
- Instale os node_modules do angular material<br>
<code>ng add @angular/material</code>
- Use o comando <br>
<code>ng serve </code>
****
