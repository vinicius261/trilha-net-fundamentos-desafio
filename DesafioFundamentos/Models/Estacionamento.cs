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
            Console.WriteLine("Digite a placa do veículo para registrar a saída:\n");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:\n");
                string horas = Console.ReadLine();

                while (!int.TryParse(horas, out int horasInteiro) || horasInteiro < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Coloque apenas horas cheias.\n");

                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:\n");

                    horas = Console.ReadLine();
                }

                int horasEstacionado =  int.Parse(horas);
                decimal valorTotal = this.precoInicial + this.precoPorHora * horasEstacionado ;

                this.veiculos.Remove(placa.ToUpper());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}\n");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente\n" +
                    "Lembre-se que a placa deve ter 7 caracteres e apenas números e letras.\n");
            }
        }
        /// <summary>
        /// Método para listar os veículos estacionados.
        /// </summary>
        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo + "\n");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.\n");
            }
        }
    }
}
