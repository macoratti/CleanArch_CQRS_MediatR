CQRS 

Command Query Responsibility Segregation, é um Padrão arquitetural que propõe a separação das 
operações de leitura (queries) das operações de escrita (commands) em um sistema. 

Comandos (Commands): Representam as operações de escrita no sistema. São responsáveis por alterar o estado do sistema.

Consultas (Queries): Representam as operações de leitura no sistema. São responsáveis por recuperar dados 
do sistema sem modificar seu estado

Mediator

O Mediator é um padrão comportamental que permite o acoplamento fraco entre objetos, encapsulando como esses objetos 
interagem e eliminando a necessidade desses objetos se comunicarem diretamente entre si, reduzindo a complexidade geral do sistema

MediatR

É uma biblioteca para o padrão Mediator, e é usada em conjunto com o padrão CQRS (Command Query Responsibility Segregation).

O Mediator é um padrão de projeto que promove o desacoplamento entre componentes em um sistema. Quando aplicado ao CQRS, 
o MediatR ajuda a implementar a comunicação entre comandos, manipuladores de comandos, consultas e manipuladores de consultas.
