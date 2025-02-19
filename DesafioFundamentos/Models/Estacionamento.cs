using System.Globalization;
using System.Text.RegularExpressions;

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
            // *IMPLEMENTADO*
            string placa = ValidaPlaca();

            veiculos.Add(placa);
        }
        
        private string ValidaPlaca(){

            string placa;
            do
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placa = Console.ReadLine().ToUpper();

                // Verifica se a placa já está cadastrada
                if(veiculos.Contains(placa))
                {
                    Console.WriteLine("Esta placa já está cadastrada.\n");
                    placa = "";
                }
                else
                {
                    // Verifica se a placa possui padrão válido
                    if (placa.Length != 7)
                    {
                        Console.WriteLine("A placa é inválida.\n");
                        placa = "";
                    }
                    else
                    {
                        // Padrão antigo (LLLNNNN)
                        string padraoAntigo = "^[A-Z]{3}[0-9]{4}$";
                        
                        // Padrão Mercosul (LLLNLLN)
                        string padraoMercosul = "^[A-Z]{3}[0-9][A-Z]{2}[0-9]$";

                        if (!Regex.IsMatch(placa, padraoAntigo) && !Regex.IsMatch(placa, padraoMercosul))
                        {
                            Console.WriteLine("A placa é inválida.\n");
                            placa = "";
                        }
                    }
                }

            } while (placa == String.Empty);

            return placa;
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // *IMPLEMENTADO*
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                // *IMPLEMENTADO*
                int horas = 0;
                decimal valorTotal = 0; 

                bool isConvert = false;
                do
                {
                    isConvert = int.TryParse(Console.ReadLine(), out horas);

                    if (!isConvert)
                        Console.WriteLine($"Por favor, digite a quantidade de horas que o veículo {placa} permaneceu estacionado:");

                } while (!isConvert);

                valorTotal = precoInicial + precoPorHora * horas;

                // *IMPLEMENTADO*
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal.ToString("C", new CultureInfo("pt-BR"))}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                // *IMPLEMENTADO*
                foreach (var veiculo in veiculos)
                    Console.WriteLine(veiculo);
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
