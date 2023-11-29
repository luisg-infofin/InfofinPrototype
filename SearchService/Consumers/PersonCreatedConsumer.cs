using AutoMapper;
using Entities.BusEvents;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;


namespace SearchService.Consumers
{
    public class PersonCreatedConsumer : IConsumer<PersonCreated>
    {
        private readonly IMapper _mapper;

        public PersonCreatedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<PersonCreated> context)
        {
            Console.WriteLine("--> Consuming Person Created: " + context.Message.Name);
            var item = _mapper.Map<PersonCreated, Item>(context.Message);

            await item.SaveAsync();
        }
    }
}
