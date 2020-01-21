using SIS.HTTP.Sessions;
using SIS.HTTP.Sessions.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Sessions
{
    public class HttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private static readonly ConcurrentDictionary<string, IHttpSession> httpsessions =
            new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return httpsessions.GetOrAdd(id, _ => new HttpSession(id));
        }
    }
}
