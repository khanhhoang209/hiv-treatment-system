using Microsoft.Extensions.Configuration;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implements;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public UnitOfWork(ApplicationDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }
}