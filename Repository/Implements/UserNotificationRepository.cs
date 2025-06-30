using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class UserNotificationRepository : GenericRepository<UserNotification>, IUserNotificationRepository
{
    public UserNotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}