using ArchiLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiLibrary.Data
{
    public abstract class BaseDbContext : DbContext
    {
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeCreatedState();
            ChangeDeletedState();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ChangeDeletedState()
        {
            var deleteEntites = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);
            foreach (var item in deleteEntites)
            {
                if (item.Entity is BaseModel model)
                {
                    model.Active = false;
                    model.DeletedAt = DateTime.Now;
                    item.State = EntityState.Modified;
                }
            }
        }

        private void ChangeCreatedState()
        {
            var createEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var item in createEntities)
            {
                if (item.Entity is BaseModel model)
                {
                    model.Active = true;
                    model.CreatedAt = DateTime.Now;
                }
            }
        }
    }
}
