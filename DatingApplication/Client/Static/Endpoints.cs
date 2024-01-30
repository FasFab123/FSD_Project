using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApplication.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string DatingAppUserEndpoint = $"{Prefix}/datingAppUsers";
        public static readonly string UserProfilesEndpoint = $"{Prefix}/userProfiles";
        public static readonly string MatchesEndpoint = $"{Prefix}/matches";
        public static readonly string ChatsEndpoint = $"{Prefix}/chats";
        
    }
}
