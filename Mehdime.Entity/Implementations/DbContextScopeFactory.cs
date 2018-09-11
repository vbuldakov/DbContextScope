/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Data;

namespace Mehdime.Entity
{
    public class DbContextScopeFactory : IDbContextScopeFactory
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly Type _defaultDbContextType;

        public DbContextScopeFactory(IDbContextFactory dbContextFactory = null, Type defaultDbContextType = null)
        {
            _dbContextFactory = dbContextFactory;
            _defaultDbContextType = defaultDbContextType;
        }

        public IDbContextScope Create(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting)
        {
            return new DbContextScope(
                joiningOption: joiningOption, 
                readOnly: false, 
                isolationLevel: null, 
                dbContextFactory: _dbContextFactory,
                defaultDbContextType: _defaultDbContextType);
        }

        public IDbContextReadOnlyScope CreateReadOnly(DbContextScopeOption joiningOption = DbContextScopeOption.JoinExisting)
        {
            return new DbContextReadOnlyScope(
                joiningOption: joiningOption, 
                isolationLevel: null, 
                dbContextFactory: _dbContextFactory,
                defaultDbContextType: _defaultDbContextType);
        }

        public IDbContextScope CreateWithTransaction(IsolationLevel isolationLevel)
        {
            return new DbContextScope(
                joiningOption: DbContextScopeOption.ForceCreateNew, 
                readOnly: false, 
                isolationLevel: isolationLevel, 
                dbContextFactory: _dbContextFactory,
                defaultDbContextType: _defaultDbContextType);
        }

        public IDbContextReadOnlyScope CreateReadOnlyWithTransaction(IsolationLevel isolationLevel)
        {
            return new DbContextReadOnlyScope(
                joiningOption: DbContextScopeOption.ForceCreateNew, 
                isolationLevel: isolationLevel, 
                dbContextFactory: _dbContextFactory,
                defaultDbContextType: _defaultDbContextType);
        }

        public IDisposable SuppressAmbientContext()
        {
            return new AmbientContextSuppressor();
        }
    }
}