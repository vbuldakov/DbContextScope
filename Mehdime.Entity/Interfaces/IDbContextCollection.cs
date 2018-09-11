/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Data.Entity;

namespace Mehdime.Entity
{
    /// <summary>
    /// Maintains a list of lazily-created DbContext instances.
    /// </summary>
    public interface IDbContextCollection : IDisposable
    {
        /// <summary>
        /// Get or create a DbContext instance of the specified type. 
        /// </summary>
		TDbContext Get<TDbContext>() where TDbContext : DbContext;

        /// <summary>
        /// Get DbSet for specified entity type in specified db context. Context is created if necessary.
        /// </summary>
        /// <typeparam name="TDbContext">Specific DbContext type</typeparam>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns></returns>
        DbSet<TEntity> GetDbSet<TDbContext, TEntity>() where TDbContext : DbContext where TEntity : class;

        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
    }
}