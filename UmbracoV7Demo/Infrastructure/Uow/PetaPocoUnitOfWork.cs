// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PetaPocoUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   The peta poco unit of work.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Infrastructure.Uow
{

    using Umbraco.Core;
    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.Core.Interfaces;

    /// <summary>
    /// The peta poco unit of work.
    /// </summary>
    public class PetaPocoUnitOfWork : IUnitOfWork
    {
        #region Fields

        /// <summary>
        /// The _db.
        /// </summary>
        private readonly Database db;

        /// <summary>
        /// The _peta tranaction.
        /// </summary>
        private readonly Transaction petaTranaction;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PetaPocoUnitOfWork"/> class.
        /// </summary>
        public PetaPocoUnitOfWork()
        {
            this.db = ApplicationContext.Current.DatabaseContext.Database;
            this.petaTranaction = new Transaction(this.db);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The commit.
        /// </summary>
        public void Commit()
        {
            this.petaTranaction.Complete();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.petaTranaction.Dispose();
        }

        #endregion
    }
}