using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IMessageRepository
    {
        public Task<Message> GetMessageAsync(int id);
               
        public Task<List<Message>> GetMessagesAsync();
               
        public Task AddMessageAsync(Message message);
               
        public Task EditMessageAsync(int id, string contenu);
               
        public Task DeleteMessageAsync(int id);
    }
}
