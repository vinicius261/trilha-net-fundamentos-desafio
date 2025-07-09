namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

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
