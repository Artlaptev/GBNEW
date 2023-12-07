using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Network;

namespace Patterns
{

    public class Manager
    {
        private Server  _server;
        public Manager( Server server) =>_server = server;
        public TypeSend Execute(Message msg, IPEndPoint iPEndPoint)
        {
            switch (msg.command)
            {
                case Commands.Delete: Delete(msg.NicknameFrom);
                    break;
                case Commands.Register: Register(msg.NicknameFrom, iPEndPoint);
                    
                    break;
                default: return Send(msg);
                    
            }
            return TypeSend.defaultmes;
        }

        public TypeSend Send(Message msg)
        {
            if (string.IsNullOrEmpty(msg.NicknameTo))
                return TypeSend.ToAll;
            return TypeSend.ToOne;
        }


        public void Register(string user, IPEndPoint iPEndPoint)
        {
            if (_server.Users == null)
                _server.Users = new Dictionary<string, IPEndPoint>();
            _server.Users.Add(user, iPEndPoint);

            Console.WriteLine($"Пользователь {user} создан");
        }
        public void Delete(string user)
        {
            _server.Users.Remove(user);
            Console.WriteLine($"Пользователь {user} удален");
        }
    }
}


