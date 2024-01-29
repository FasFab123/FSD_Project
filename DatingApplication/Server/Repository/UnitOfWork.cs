using DatingApplication.Server.Data;
using DatingApplication.Server.IRepository;
using DatingApplication.Server.Models;
using DatingApplication.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DatingApplication.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Chat> _chats;
        private IGenericRepository<DatingAppUser> _datingappusers;
        private IGenericRepository<Match> _matches;
        private IGenericRepository<UserProfile> _userprofiles;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
            
        public IGenericRepository<Chat> Chats
            => _chats ??= new GenericRepository<Chat>(_context);
        public IGenericRepository<DatingAppUser> DatingAppUsers
            => _datingappusers ??= new GenericRepository<DatingAppUser>(_context);
        public IGenericRepository<Match> Matches
            => _matches ??= new GenericRepository<Match>(_context);
        public IGenericRepository<UserProfile> UserProfiles
            => _userprofiles ??= new GenericRepository<UserProfile>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}