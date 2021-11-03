using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChattyApi.Pages
{
    public partial class ShowRoom
    {
        private HubConnection _connection;
        public List<string> Messages { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://chattyapi.azurewebsites.net/ChatHub")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string, string>(
                "ReceiveMessage",
                (user, message) =>
                {
                    Console.Write($"\r{user}: {message}\n>");
                    Messages.Add($"[{user}] {message}");
                    StateHasChanged();
                });

            await _connection.StartAsync();
        }
    }
}