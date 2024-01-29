using DatingApplication.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApplication.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Chat> Chats { get; }
        IGenericRepository<DatingAppUser> DatingAppUsers { get; }
        IGenericRepository<Match> Matches { get; }
        IGenericRepository<UserProfile> UserProfiles { get; }
    }
}