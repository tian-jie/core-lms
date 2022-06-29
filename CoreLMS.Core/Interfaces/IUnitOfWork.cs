using System;
using System.Collections.Generic;

public interface IUnitOfWork : IDisposable
{
    int SaveChanges();
}