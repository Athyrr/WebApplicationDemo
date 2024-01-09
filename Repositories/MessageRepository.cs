using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public readonly MessagesContext _context;

        public MessageRepository(MessagesContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var mess = _context.Messages.FirstOrDefault(m => m.Id == id);

            _context.Messages.Remove(mess);
            await _context.SaveChangesAsync();
        }

        public async Task EditMessageAsync(int id, string contenu)
        {
            Message mess = _context.Messages.FirstOrDefault(m => m.Id == id);
            mess.Contenu = contenu;

            await _context.SaveChangesAsync();
        }

        public async Task<Message?> GetMessageAsync(int id)
            => await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<List<Message>> GetMessagesAsync()
            => _context.Messages.ToList();
    }
}
