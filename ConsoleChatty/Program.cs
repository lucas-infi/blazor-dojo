using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleChatty
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var connection = new HubConnectionBuilder()
                .WithUrl("https://chattyapi.azurewebsites.net/ChatHub")
                .Build();

            connection.On<string, string>(
                "ReceiveMessage",
                (user, message) => { Console.Write($"\r{user}: {message}\n>"); });

            await connection.StartAsync();

            Console.Write("What is your name? ");
            var name = Console.ReadLine();

            while (true)
            {
                Console.Write(">");
                var msg = Console.ReadLine();
                await connection.InvokeAsync("SendMessage", name, msg ?? string.Empty);
            }
        }
    }
}