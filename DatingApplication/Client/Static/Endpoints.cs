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

        public static readonly string DatingAppUsersEndpoint = $"{Prefix}/DatingAppUsers";
        public static readonly string UserProfilesEndpoint = $"{Prefix}/UserProfiles";
        public static readonly string MatchesEndpoint = $"{Prefix}/Matches";
        public static readonly string ChatsEndpoint = $"{Prefix}/Chats";
        
    }
}
