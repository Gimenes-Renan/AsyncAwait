using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("========================");
                Console.WriteLine("Iniciando." + DateTime.Now);
                TesteAsync testeAsync = new TesteAsync();

                //Usando o arrayList para poder colocar qualquer quantidade de tarefas dentro da lista sem se preocupar com o tamanho
                ArrayList listaTarefas = new ArrayList
                {
                    testeAsync.Tarefa(3, "TAREFA 1 - 3 SEG"),
                    testeAsync.Tarefa(2, "TAREFA 2 - 2 SEG"),
                    testeAsync.Tarefa(5, "TAREFA 3 - 5 SEG"),
                    testeAsync.Tarefa(2, "TAREFA 4 - 2 SEG")
                };

                Task[] tasks = (Task[])listaTarefas.ToArray(typeof(Task)); //Conversão de ArrayList em Array, com conversão explicita de type
                Task[] tasks2 = listaTarefas.ToArray(typeof(Task)) as Task[]; //Conversão de ArrayList em Array, com conversão explicita de type - segunda forma

                Console.WriteLine("Aguardando finalização das tasks");
                Task.WaitAll(tasks); //aceita somente Array como parâmetro... Se aceitasse um ArrayList não precisaria da conversão da linha 27
                Console.WriteLine("Tasks Completas");

                Console.WriteLine("Terminado..." + DateTime.Now);
                Thread.Sleep(2000);
            }
        }
    }
}
