namespace Data.Repositories;

/// <summary>
/// Base data repository
/// </summary>
public class DataRepository
{
    private readonly DataContext _dataContext;

    public DataRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    /// Add method to prevent extreme changes in case of _dataContext.SaveChanges() rename.
    /// Admittedly, extremely low chance of this case.
    /// </summary>
    protected void SaveChanges() => _dataContext.SaveChanges();
}