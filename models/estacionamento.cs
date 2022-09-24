using System;

namespace ProjetoEstacionamento.Models;

public class Estacionamento
{
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<string> placas = new List<string>();
    private Dictionary<string, decimal> Faturado = new Dictionary<string, decimal>();
    public bool statusSistema = true;

    private string VerificaReadLine(){
        bool verificaValor = true;
        string valor;
        do{
            valor = Console.ReadLine();
            if(valor == ""){
                Console.WriteLine("Favor inserir um valor não vazio");
            }else{
                verificaValor = false;
            }
        }while(verificaValor);
        return valor;
    }

    public decimal VerificaValoresMonetarios(){
        decimal valorMonetario;
        bool verificaValor = false;
        do
        {
        verificaValor = Decimal.TryParse(VerificaReadLine().Replace(',', '.'), out valorMonetario);
        if (verificaValor == false || valorMonetario < 0){
            Console.Write("Favor inserir um valor válido:\nR$");
            verificaValor = false;
            }
        } while (!verificaValor);
        return valorMonetario;
    }

    public int VerificaValoresInteiros(){
        int valorInteiro;
        bool verificaValor = false;
        do
        {
        verificaValor = int.TryParse(VerificaReadLine().Replace(',', '.'), out valorInteiro);
        if (verificaValor == false || valorInteiro < 0){
            Console.WriteLine("Favor inserir um valor válido");
            verificaValor = false;
        }
        } while (!verificaValor);
        return valorInteiro;
    }
    
    public void AtualizarValores()
    {
        Console.Write($"Digite o valor do novo preço Inicial | Preço Inicial Atual R${precoInicial.ToString("0.00")}\nR$");
        precoInicial = VerificaValoresMonetarios();
        Console.Write($"Digite o valor do novo preço por Hora | Preço por Hora Atual R${precoPorHora.ToString("0.00")}\nR$");
        precoPorHora = VerificaValoresMonetarios();
        Console.Clear();
    }

    public void CadastrarVeículo()
    {
        Console.Clear();
        Console.WriteLine("Digite a placa a ser cadastrada");
        string placa = VerificaReadLine();
        if(placas.Contains(placa)){
            Console.WriteLine("Essa placa já esta cadastrada no sistema:");
        }else{
            Console.Clear();
            placas.Add(placa);
            Console.WriteLine($"Placa {placa} cadastrada com sucesso! \nPressione enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

    }

    public void ListarVeiculos(){
        Console.WriteLine("Placas listadas");
        foreach(string placa in placas){
            Console.Write($"{placa} | ");
        }
    }

    public void RemoverVeículo()
    {
        if (placas.Count > 0)
        {
            Console.Clear();
            ListarVeiculos();
            Console.WriteLine("\nDigite a placa que deseja Remover");
            string placa = VerificaReadLine();
            if (placas.Contains(placa))
            {
                Console.Clear();
                Console.WriteLine("Digite a quantidade de horas que o veículo ficou estacionado:");
                int horas = VerificaValoresInteiros();
                decimal valor = precoInicial + (precoPorHora * horas);
                Console.Clear();
                Console.WriteLine($"Valor a ser pago da placa {placa} - R${valor.ToString("0.00")} \nPressione enter para continuar");
                Console.ReadLine();
                Faturado.Add(placa, valor);
                placas.Remove(placa);
                Console.Clear();
                Console.WriteLine("Veículo retirado com sucesso! \nPressione enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("placa não localizada, favor digitar um valor válido!");
            }
        }else{
            Console.Clear();
            Console.WriteLine("Sem placas cadastradas!");
        }
        
    }

    public void ListarFaturamento(){
        int contador = 1;
        decimal total = 0;
        Console.Write("Faturamento do dia \n--------------");
        foreach(var (placa, valor) in Faturado){
            total += valor;
            Console.Write($"\n{contador} - {placa} {valor.ToString("0.00")}");
            contador++;
        }
        Console.Write($"\nTotal:\n{contador-1} - {total.ToString("0.00")}\n");
    }


}
