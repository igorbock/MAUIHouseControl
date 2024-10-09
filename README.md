## Solution

The solution will be divided into two into 3 projects. Communication between them will happen via dependency injection and RabbitMQ.
You can see more in the "Mapeamento.png" file in the master branch.

The idea is to use two data sources: a local one with SQLite and a remote one with a WebAPI. There will be a data synchronization service and the possibility of working offline.
