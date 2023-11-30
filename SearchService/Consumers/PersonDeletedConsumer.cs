using Entities.BusEvents;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class PersonDeletedConsumer : IConsumer<PersonDeleted>
    {
        public async Task Consume(ConsumeContext<PersonDeleted> context)
        {
            Console.WriteLine("--> Consuming Person Delete: " + context.Message.Id);
            var itemIdToDelete = context.Message.Id;

            await DB.DeleteAsync<Item>(x => x.ID == itemIdToDelete.ToString());
        }
    }
}
