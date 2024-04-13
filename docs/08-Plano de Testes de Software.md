# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Não deixe de enumerar os casos de teste de forma sequencial e de garantir que o(s) requisito(s) associado(s) a cada um deles está(ão) correto(s) - de acordo com o que foi definido na seção "2 - Especificação do Projeto". 

Por exemplo:
 
| **Caso de Teste** 	| **CT-01 – Cadastro de usuário e instituição** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 -	A aplicação deve permitir o cadastro do usúario e da instituição |
| Objetivo do Teste 	| O objetivo dos testes é garantir que a funcionalidade de cadastro de usuários e instituições atenda aos requisitos definidos e funcione corretamente, oferecendo uma experiência de usuário fluida e segura. |
| Passos 	| - Simular o processo de cadastro completo, desde a entrada de dados pelo usuário até o armazenamento no banco de dados. <br> - Verificar se os dados inseridos são corretamente processados e armazenados.<br> - Validar se o sistema responde corretamente a diferentes cenários de entrada (dados válidos, dados inválidos, etc.). <br> - Garantir que a interface de usuário forneça feedback adequado durante o processo de cadastro.|
|Critério de Êxito | - Os usuários e instituições podem se cadastrar com sucesso, com todas as informações necessárias armazenadas corretamente. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login usuário e instituição	|
|Requisito Associado |RF-002 -	A aplicação deve ter uma área de login para o usuário e a instituição |
| Objetivo do Teste 	| Garantir que a área de login da aplicação atenda aos requisitos funcionais e ofereça uma experiência segura e intuitiva para os usuários e instituições. |
| Passos 	| - Testar o processo de login com credenciais válidas de usuário e instituição. <br> - Testar o processo de login com credenciais inválidas para verificar a detecção de erro e a apresentação de mensagens adequadas.<br> - Avaliar a usabilidade da interface de login em diferentes dispositivos e navegadores. <br>  |
|Critério de Êxito | - Os usuários e instituições podem fazer login com sucesso usando credenciais válidas. Mensagens de erro adequadas são exibidas para credenciais inválidas. A interface de login é intuitiva e funcional em diferentes ambientes. |
|  	|  	|
| Caso de Teste 	| CT-03 – Efetuar agendamento para atendimento psicológico	|
|Requisito Associado |RF-003	- A aplicação deve oferecer uma área para agendamento de atendimento psicológico |
| Objetivo do Teste | Garantir que a área de agendamento de atendimento psicológico na aplicação atenda aos requisitos funcionais e permita que os usuários marquem consultas de forma eficiente e precisa. |
| Passos 	| - Verificar se os usuários podem acessar a área de agendamento psicológico de forma clara e intuitiva. <br> -	Testar a funcionalidade de visualização de disponibilidade de horários para agendamento. <br> - Testar a capacidade de selecionar um horário disponível para agendar uma consulta. <br> Avaliar a interface de usuário para garantir que seja fácil de entender e navegar durante o processo de agendamento. |
|Critério de Êxito | - Os usuários podem acessar a área de agendamento de forma intuitiva. Os horários disponíveis são exibidos corretamente e podem ser selecionados para agendamento. O processo de agendamento é fácil de entender e completar.|
|  	|  	|
| Caso de Teste 	| CT-03 – Informações sobre casas de acolhimento	|
|Requisito Associado |RF-004 -	A aplicação deve ter páginas de informações sobre as casas de acolhimento |
| Objetivo do Teste | Garantir que as páginas de informações sobre as casas de acolhimento na aplicação forneçam aos usuários acesso claro e útil aos detalhes relevantes sobre essas instituições. |
| Passos 	| - Verificar se os usuários podem acessar as páginas de informações sobre as casas de acolhimento de forma direta e intuitiva. <br> Testar a apresentação das informações, incluindo detalhes como localização, serviços oferecidos, equipe, horário de funcionamento e contato. <br> - 3.	Avaliar a usabilidade da interface para garantir uma navegação fácil e uma apresentação clara das informações. |
|Critério de Êxito | - Os usuários podem acessar facilmente as informações sobre as casas de acolhimento.	As informações apresentadas são completas, precisas e úteis para os usuários. A interface é intuitiva e facilita a navegação pelas informações.|



 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
