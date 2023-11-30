using AutoMapper;
using Entities.BusEvents;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class PersonUpdatedConsumer : IConsumer<PersonUpdated>
    {
        private readonly IMapper _mapper;

        public PersonUpdatedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<PersonUpdated> context)
        {
            Console.WriteLine("--> Consuming Person Updated: " + context.Message.Id);

            var newItemValues = _mapper.Map<PersonUpdated, Item>(context.Message);

            await DB.Update<Item>()
                .Match(x => x.ID == context.Message.Id.ToString())
                .ModifyOnly(x => new { x.Name, x.Email, x.Address, x.UpdateAt, x.UpdateUser }, newItemValues)
                .ExecuteAsync();
            
        }
    }
}
