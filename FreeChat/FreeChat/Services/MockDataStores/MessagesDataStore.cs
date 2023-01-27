using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Services.MockDataStores
{
    public class MessagesDataStore : IMessageDataStore
    {
        readonly List<Message> _messages;

        public MessagesDataStore(Conversation conversation)
        {
            _messages = new List<Message>();

            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                Content = "Hi There.. I am Chat UI.",
                CreationDate = DateTime.Now - TimeSpan.FromDays(1),
                ISent = false,
                SenderId = conversation.Peer.Id,
                Sender = conversation.Peer
            });
            
            conversation.LastMessage = _messages.Last();
        }

        public Task<bool> AddItemAsync(Message item)
        {
            item.Id = Guid.NewGuid().ToString();
            _messages.Add(item);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetMessagesForConversation(string conversationId)
        {
            return Task.FromResult(_messages.Where(m => m.ConversationId == conversationId));
        }

        public Task<bool> UpdateItemAsync(Message item)
        {
            throw new NotImplementedException();
        }
    }
}
