using ProjetoEstacionamento.Models;

Estacionamento Sistema = new Estacionamento();
Console.Clear();

Console.WriteLine(
    "Seja bem Vindo ao sistema de estacionamento!"
);

Sistema.AtualizarValores();
Console.Clear();

while (Sistema.statusSistema)
{
    Console.WriteLine(
        "Selecione a função:\n" +
        "1 - Cadastrar veículo\n" +
        "2 - Remover veiculos\n" +
        "3 - Listar veiculos\n" +
        "4 - Ajustar valores\n" +
        "5 - Encerrar sistema");

    switch (Console.ReadLine()) 
    {
        case "1":
            Sistema.CadastrarVeículo();
            break;
        case "2":
            Sistema.RemoverVeículo();
            break;
        case "3":
            Console.Clear();
            Sistema.ListarVeiculos();
            Console.WriteLine("\nPressione enter para continuar");
            Console.ReadLine();
            Console.Clear();
            break;
        case "4":
            Console.Clear();
            Sistema.AtualizarValores();
            break;
        case "5":
            Sistema.statusSistema = false;
            break;
        default:
            Console.Clear();
            Console.WriteLine("Favor selecione uma opção válida");
            break;
    }
}

Console.Clear();
Sistema.ListarFaturamento();
Console.WriteLine("Obrigado por Utilizar o Sistema!");