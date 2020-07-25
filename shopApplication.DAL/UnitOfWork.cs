using shopApplication.DAL.Repositories.Contracts;
using shopApplication.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public IImageRepository Images { get; }

        public IAdvertisementRepository Advertisements { get; }

        public ICategoryRepository Categories { get; }

        public ICommentRepository Comments { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Images = new RepositoryImage(context);
            Advertisements = new RepositoryAdvertisement(context);
            Categories = new RepositoryCategory(context);
            Comments = new RepositoryComment(context);
            
        }

        #region Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
