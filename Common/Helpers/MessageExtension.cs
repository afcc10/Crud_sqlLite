using Common.Utilities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class MessageExtension
    {
        public static List<MessageResult> AddMessageList(string mensaje)
        {
            List<MessageResult> _listMessages = new List<MessageResult>();

            _listMessages.Add(new MessageResult
            {
                Message = mensaje
            });

            return _listMessages;
        }
    }
}
