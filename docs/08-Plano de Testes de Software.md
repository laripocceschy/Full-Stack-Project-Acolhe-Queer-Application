# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>
 
| **Caso de Teste** 	| **CT-01 – Cadastro de usuário e instituição** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 -	A aplicação deve permitir o cadastro do usúario e da instituição |
| Objetivo do Teste 	| O objetivo dos testes é garantir que a funcionalidade de cadastro de usuários e instituições atenda aos requisitos definidos e funcione corretamente, oferecendo uma experiência de usuário fluida e segura. |
| Passos 	| - Simular o processo de cadastro completo, desde a entrada de dados pelo usuário até o armazenamento no banco de dados. <br> - Verificar se os dados inseridos são corretamente processados e armazenados.<br> - Validar se o sistema responde corretamente a diferentes cenários de entrada (dados válidos, dados inválidos, etc.). <br> - Garantir que a interface de usuário forneça feedback adequado durante o processo de cadastro.|
|Critério de Êxito | Os usuários e instituições podem se cadastrar com sucesso, com todas as informações necessárias armazenadas corretamente. |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Efetuar login usuário e instituição**	|
|Requisito Associado |RF-002 -	A aplicação deve ter uma área de login para o usuário e a instituição |
| Objetivo do Teste 	| Garantir que a área de login da aplicação atenda aos requisitos funcionais e ofereça uma experiência segura e intuitiva para os usuários e instituições. |
| Passos 	| - Testar o processo de login com credenciais válidas de usuário e instituição. <br> - Testar o processo de login com credenciais inválidas para verificar a detecção de erro e a apresentação de mensagens adequadas.<br> - Avaliar a usabilidade da interface de login em diferentes dispositivos e navegadores. <br>  |
|Critério de Êxito | Os usuários e instituições podem fazer login com sucesso usando credenciais válidas. Mensagens de erro adequadas são exibidas para credenciais inválidas. A interface de login é intuitiva e funcional em diferentes ambientes. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Efetuar agendamento para atendimento psicológico**	|
|Requisito Associado |RF-003	- A aplicação deve oferecer uma área para agendamento de atendimento psicológico |
| Objetivo do Teste | Garantir que a área de agendamento de atendimento psicológico na aplicação atenda aos requisitos funcionais e permita que os usuários marquem consultas de forma eficiente e precisa. |
| Passos 	| - Verificar se os usuários podem acessar a área de agendamento psicológico de forma clara e intuitiva. <br> -	Testar a funcionalidade de visualização de disponibilidade de horários para agendamento. <br> - Testar a capacidade de selecionar um horário disponível para agendar uma consulta. <br> - Avaliar a interface de usuário para garantir que seja fácil de entender e navegar durante o processo de agendamento. |
|Critério de Êxito | Os usuários podem acessar a área de agendamento de forma intuitiva. Os horários disponíveis são exibidos corretamente e podem ser selecionados para agendamento. O processo de agendamento é fácil de entender e completar.|
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Informações sobre casas de acolhimento**	|
|Requisito Associado |RF-004 -	A aplicação deve ter páginas de informações sobre as casas de acolhimento |
| Objetivo do Teste | Garantir que as páginas de informações sobre as casas de acolhimento na aplicação forneçam aos usuários acesso claro e útil aos detalhes relevantes sobre essas instituições. |
| Passos 	| - Verificar se os usuários podem acessar as páginas de informações sobre as casas de acolhimento de forma direta e intuitiva. <br> - Testar a apresentação das informações, incluindo detalhes como localização, serviços oferecidos, equipe, horário de funcionamento e contato. <br> - Avaliar a usabilidade da interface para garantir uma navegação fácil e uma apresentação clara das informações. |
|Critério de Êxito | Os usuários podem acessar facilmente as informações sobre as casas de acolhimento.	As informações apresentadas são completas, precisas e úteis para os usuários. A interface é intuitiva e facilita a navegação pelas informações.|
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Cadastro em instituições**	|
|Requisito Associado |RF-005 -	A aplicação deve disponibilizar o cadastro em instuições para os usuários |
| Objetivo do Teste | Assegurar que a aplicação permita aos usuários realizar o cadastro em instituições de forma eficaz e sem complicações. |
| Passos 	| - Verificar se os usuários têm acesso claro e direto à funcionalidade de cadastro em instituições. <br> - Testar a integridade e a validação dos dados inseridos durante o processo de cadastro. <br> -	Avaliar a eficiência do fluxo de cadastro, desde a entrada dos dados até a confirmação bem-sucedida do cadastro. <br> - Testar a integração com sistemas de notificação ou confirmação para garantir que os usuários recebam feedback adequado após o cadastro. |
|Critério de Êxito | Os usuários podem acessar facilmente a funcionalidade de cadastro em instituições. Os dados inseridos durante o cadastro são validados corretamente para garantir sua integridade. O processo de cadastro é concluído sem problemas, resultando em uma confirmação bem-sucedida do cadastro. Os usuários recebem feedback adequado após o cadastro, seja por meio de notificações ou confirmações.|
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Área de doação para as instituições**	|
|Requisito Associado |RF-006 -	A aplicação deve disponibilizar uma área de doação para as instituições |
| Objetivo do Teste | Assegurar que a aplicação ofereça uma área de doação para as instituições, permitindo que os usuários realizem doações de forma fácil e segura. |
| Passos 	| - Verificar se os usuários têm acesso claro e direto à área de doação. <br> - Os usuários podem acessar facilmente a área de doação na aplicação. |
|Critério de Êxito | Os usuários podem acessar facilmente a área de doação na aplicação.|
|  	|  	|
| **Caso de Teste** 	| **CT-07 – Responsividade**	|
|Requisito Associado |RNF-001 - A aplicação deve ser responsiva |
| Objetivo do Teste | Assegurar que a aplicação seja responsiva em diferentes dispositivos e tamanhos de tela, garantindo uma experiência consistente para os usuários em todos os dispositivos. |
| Passos 	| - Verificar se a aplicação se ajusta automaticamente para fornecer uma experiência de usuário otimizada em dispositivos de diferentes tamanhos, como desktops, tablets e smartphones. <br> - Testar a legibilidade e usabilidade dos elementos da interface em diferentes tamanhos de tela, incluindo texto, botões e menus. <br> - Avaliar a navegação e a interação do usuário em dispositivos com diferentes resoluções de tela, garantindo que todas as funcionalidades sejam acessíveis e fáceis de usar. <br> - Verificar se não há problemas de layout ou formatação em dispositivos com telas menores, como sobreposição de elementos ou quebra de layout. <br> - Testar a compatibilidade da aplicação com diferentes navegadores e sistemas operacionais para garantir uma experiência consistente em todos os ambientes.|
|Critério de Êxito |A aplicação se ajusta automaticamente para fornecer uma experiência de usuário otimizada em diferentes dispositivos e tamanhos de tela. Todos os elementos da interface são legíveis e fáceis de usar em todos os tamanhos de tela. A navegação e a interação do usuário são consistentes e intuitivas em dispositivos com diferentes resoluções de tela. Não há problemas de layout ou formatação em dispositivos com telas menores. A aplicação é compatível com uma variedade de navegadores e sistemas operacionais, garantindo uma experiência consistente em todos os ambientes.|
|  	|  	|
| **Caso de Teste** 	| **CT-08 – Publicação em um ambiente acessível na internet**	|
|Requisito Associado |RNF-002 - A aplicação deve ser publicada em um ambiente acessível publicamente na internet |
| Objetivo do Teste | Garantir que a aplicação seja publicada em um ambiente acessível publicamente na internet, permitindo que os usuários acessem e usem a aplicação sem restrições de acesso. |
| Passos 	| - Verificar se a aplicação está hospedada em um ambiente acessível publicamente na internet, com um URL acessível aos usuários. <br> Testar o acesso à aplicação a partir de diferentes dispositivos e redes, incluindo computadores, tablets e smartphones, usando diferentes conexões de internet.  |
|Critério de Êxito |A aplicação está hospedada em um ambiente acessível publicamente na internet, com um URL acessível aos usuários. Os usuários podem acessar facilmente a aplicação a partir de diferentes dispositivos e redes, sem restrições de acesso.
|
