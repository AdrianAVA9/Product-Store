namespace ProductStore.Persistance
{
    public enum RepositoryActionStatus
    {
        Ok = 1,
        Created = 2,
        Edited = 3,
        Deleted = 4,
        NotFound = 5,
        Error = 6,
        NothingModified = 7
    }
}
