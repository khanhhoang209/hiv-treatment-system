using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}