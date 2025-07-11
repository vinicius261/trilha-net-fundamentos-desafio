namespace DesafioFundamentos.Models
{   /// <summary>Classe que representa a lógica de registo e cobrança do estacionamento.</summary>
    public class Estacionamento
    {   
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        /// <summary>
        /// Construtor da classe estacionamento.
        /// </summary>
        /// <param name="precoInicial">Valor em R$ da primeira hora no estacionamento</param>
        /// <param name="precoPorHora">Valor em R$ das horas adicionais no estacionamento</param>
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        /// <summary>
        /// Método para adicionar um veículo ao estacionamento.
        /// </summary>
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Para estacionar, digite a placa do veículo sem pontuações:\n");
            string placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa) || placa.Length != 7 || placa.Contains("-"))
            {
                Console.WriteLine("Placa inválida. A placa deve ter 7 caracteres e apenas números e letras.\n");
            }
            else if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("O veículo já está estacionado\n");
            }
            else
            {
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"A entrada do veículo de {placa} foi registrada\n");
            }
        }
        /// <summary>
        /// Método para remover um veículo do estacionamento e calcular o valor total a ser pago.
        /// </summary>
        public void RemoverVeiculo()
        {
            if (veiculos.Count() > 0)
            {
                bool opcaoInvalida = true;

                while (opcaoInvalida)
                {
                    Console.WriteLine("Qual veículo deseja remover?\n");
                    for (int i = 0; i < veiculos.Count(); i++)
                    {
                        Console.WriteLine($"{i+1} - {veiculos[i]}\n");
                    }
                    Console.WriteLine("Digite o número correspondente a placa que deseja apagar:\n");
                    string opcao = Console.ReadLine();

                    // Opção é i+1 para melhor experiência do usuário.
                    if (int.TryParse(opcao, out int indice) && indice > 0 && indice <= veiculos.Count)
                    {
                        indice = int.Parse(opcao);
                        opcaoInvalida = false;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Por favor, digite um número correspondente a uma placa listada.\n");
                    }

                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:\n");
                    string horas = Console.ReadLine();

                    while (!int.TryParse(horas, out int horasInteiro) || horasInteiro < 0)
                    {
                        Console.WriteLine("Quantidade de horas inválida. Coloque apenas horas cheias.\n");

                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:\n");

                        horas = Console.ReadLine();
                    }

                    int horasEstacionado = int.Parse(horas);
                    decimal valorTotal = this.precoInicial + this.precoPorHora * horasEstacionado;

                    string placa = veiculos[indice-1];

                    this.veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}\n");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.\n");
            }
        }
        /// <summary>
        /// Método para listar os veículos estacionados.
        /// </summary>
        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                for(int i = 0; i < veiculos.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {veiculos[i]}\n");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.\n");
            }
        }
    }
}
