using Microsoft.Extensions.Configuration;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implements;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IConfiguration _configuration;
    public IArvRepository ArvRepository { get;  }
    public INotificationRepository NotificationRepository { get;  }
    public IUserNotificationRepository UserNotificationRepository { get;  }
    public IPrescriptionRepository PrescriptionRepository { get;  }
    public IDoctorRepository DoctorRepository { get;  }
    public IEmployeeRepository EmployeeRepository { get;  }

    public UnitOfWork(ApplicationDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;

        _configuration = configuration;

        ArvRepository = new ArvRepository(dbContext);

        NotificationRepository = new NotificationRepository(dbContext);

        UserNotificationRepository = new UserNotificationRepository(dbContext);

        PrescriptionRepository = new PrescriptionRepository(dbContext);

        DoctorRepository = new DoctorRepository(dbContext);

        EmployeeRepository = new EmployeeRepository(dbContext);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }
}