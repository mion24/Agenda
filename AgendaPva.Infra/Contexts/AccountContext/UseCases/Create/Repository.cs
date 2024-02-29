﻿using AgendaPva.Core.Contexts.AccountContext.Entities;
using AgendaPva.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using AgendaPva.Infra.Contexts.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Infra.Contexts.AccountContext.UseCases.Create
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
            => await _context.Users.AsNoTracking().AnyAsync(x => x.Email.Address == email, cancellationToken);

        public async Task SaveAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
