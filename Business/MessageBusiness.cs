using Business.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MessageBusiness : IMessageBusiness
    {
        public IMessageBusiness messageRepository;

        public MessageBusiness(IMessageBusiness messageBusiness)
        {
            this.messageRepository = messageBusiness;
        }

        public async Task AddMessageAsync(Message message)
        {
            await messageRepository.AddMessageAsync(message);

        }

        public async Task DeleteMessageAsync(int id)
        {
            await messageRepository.DeleteMessageAsync(id);
        }

        public async Task EditMessageAsync(int id, string contenu)
        {
            await messageRepository.EditMessageAsync(id, contenu);
        }

        public async Task<Message> GetMessageAsync(int id)
        {
            var mess = await GetMessageAsync(id);
            if (mess is null)
            {
                throw new Exception("Aucun message à supprimer");
            }
            return mess;
        }

        public async Task<List<Message>> GetMessagesAsync()
            => await messageRepository.GetMessagesAsync();


    }
}
