# Sistema de Estacionamento JAC PARK

Bem-vindo ao **JAC PARK**, um sistema simples de gerenciamento de estacionamento, desenvolvido em C#. Este programa permite cadastrar veículos, registrar horários de entrada e saída, listar veículos cadastrados e calcular o valor a pagar com base no tempo de permanência.

## Funcionalidades

- **Cadastrar Veículo**: Registre um veículo com a placa e a hora de entrada automaticamente.
- **Remover Veículo**: Insira a placa para remover o veículo, registre a hora de saída e calcule o valor total com base no tempo de permanência.
- **Listar Veículos**: Visualize todos os veículos atualmente cadastrados com suas placas e horários de entrada.
- **Configurar Valores**: Defina o valor inicial e o valor por hora para o cálculo do estacionamento.

## Exemplo de Uso

1. Ao iniciar o programa, você será solicitado a inserir:
   - O valor inicial do estacionamento.
   - O valor por hora adicional.
2. Em seguida, você poderá escolher entre as seguintes opções:
   - `1` - Cadastrar um novo veículo.
   - `2` - Remover um veículo (inserindo a placa para calcular o valor total).
   - `3` - Listar todos os veículos atualmente no estacionamento.
   - `4` - Encerrar o programa.

## Exemplo de Execução

```plaintext
Seja bem-vindo ao sistema de estacionamento JAC PARK!
Digite o preço inicial: 5.00
Digite o valor por hora: 2.50

Escolha uma opção:
1 - Cadastrar veículo
2 - Remover veículo
3 - Listar veículos
4 - Encerrar

Digite a placa do veículo: ABC-1234
Veículo ABC-1234 cadastrado às 10/11/2024 14:35:00

Escolha uma opção:
2 - Remover veículo
Digite a placa do veículo que deseja remover: ABC-1234
Tempo de permanência: 1.50 horas.
Total a pagar: R$8.75
```
## Estrutura do Projeto
* Estacionamento.cs: Contém a lógica principal para gerenciamento dos veículos, incluindo o cálculo do tempo de permanência e do valor a ser pago.

* Program.cs: Gerencia a interface com o usuário e as opções do menu.

## Tecnologias Utilizadas

* C#
* .NET Core

## Como Executar
1. Clone o repositório:
    ```
    git clone https://github.com/seuusuario/nome-do-repositorio.git
    ```
2. Navegue até a pasta do projeto:
    ```
    cd nome-do-repositorio
    ```

3. Compile e execute o projeto:
    ```
    dotnet run
    ```

## Melhorias Futuras
* Adicionar interface gráfica para facilitar o uso.
* Adicionar banco de dados para persistência de dados.
* Implementar relatórios de entrada e saída.

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença
Este projeto é licenciado sob a licença MIT. Consulte o arquivo LICENSE para mais informações.

Feito com ❤️ por <a href="https://www.linkedin.com/in/joao-ac-castro/"> João Antônio de Castro</a>.