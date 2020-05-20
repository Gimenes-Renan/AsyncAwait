using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsyncAwait
{
    class TesteAsync
    {

        public async Task Tarefa(int tempo, string nomeTarefa)
        {
            Console.WriteLine($"Iniciando {nomeTarefa}");
            var a = Task.Delay(tempo * 1000);
            await a;
            Console.WriteLine($"Finalizando {nomeTarefa}");
        }

    }
}
