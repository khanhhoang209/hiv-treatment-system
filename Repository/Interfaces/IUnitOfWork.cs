namespace Repository.Interfaces;

public interface IUnitOfWork
{
    IArvRepository ArvRepository { get; }

}